using ServiceManager.DALServiceReference;
using ServiceManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UIClient.Controlls;
using UIClient.AddDialogs;
using ServiceManager.ClientSideClasses;
using System.ServiceModel;

namespace UIClient
{
    public class MainPresenter
    {
        #region Privates
        private readonly ServiceConnector _serviceManager = new ServiceConnector();

        private List<DepartmentCS> _departmentStructure;

        private MainForm _mainForm;

        #endregion

        #region Dependencies Properties
        public BaseDialogForm AddEmployeeForm { get; set; }
        public BaseDialogForm AddDepartmentForm { get; set; }
        #endregion

        public MainPresenter(MainForm mainForm)
        {
            _mainForm = mainForm;
            // Добавление древо подразделений на форму, список сотрудников отображается через событие AfterSelect
            mainForm.DepartmentStructureTreeView.Nodes.AddRange(this.LoadDepartmentStructure());
            // Подготовка столбцов DataGrid для списка сотрудников
            mainForm.EmployeeDataGridView.SetUpGrid();
            mainForm.Presenter = this;
            Application.Run(mainForm);
        }

        #region To Service Methods
        /// <summary>
        /// Выполняет запрос сервиса к дб
        /// </summary>
        /// <returns></returns>
        private System.Windows.Forms.TreeNode[] LoadDepartmentStructure()
        {
            _departmentStructure = _serviceManager.GetDepartmentStructureWithEmployees().ToList();
            List<System.Windows.Forms.TreeNode> result = new List<System.Windows.Forms.TreeNode>();
           
            foreach(var dep in _departmentStructure)
            {
                result.Add(GetSubNodes(dep));
            }
            return result.ToArray();
        }
        private System.Windows.Forms.TreeNode GetSubNodes(DepartmentCS department)
        {
            var node = new System.Windows.Forms.TreeNode()
            {
                Name = department.Name,
                Tag = department,      
                Text = department.ToString()
            };
            
            foreach (var subDep in department.ChildDepartments)
            {
                node.Nodes.Add(GetSubNodes(subDep));
            }
            return node;
        }

        /// <summary>
        /// Получение массива имен отделов без иерархии из уже загруженной структуры (без обращения к бд)
        /// </summary>
        /// <returns></returns>
        public List<DepartmentCS> GetDepartmentList()
        {
            List<DepartmentCS> result = new List<DepartmentCS>();
            foreach(var department in this._departmentStructure)
            {
                GetSubDepartments(result, department);
            }
            return result;
        }
        private void GetSubDepartments(List<DepartmentCS> allDeps, DepartmentCS rootDep)
        {
            allDeps.Add(rootDep);
            foreach(var dep in rootDep.ChildDepartments)
            {
                GetSubDepartments(allDeps, dep);
            }
        }

        #endregion

        #region Methods for UI Events
        
        /// <summary>
        /// Вывести список сотрудников на контрол DataGridView, настроенный через SetUpGrid. Не очищает имеющиеся элементы. 
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="department"></param>
        public void SelectEmployeeToGrid(DepartmentCS department)
        {
            _mainForm.EmployeeDataGridView.Rows.Clear();
            var employees = _serviceManager.GetEmployeesByDepartment(department.ID);
            _mainForm.EmployeeDataGridView.SelectEmployeeToGrid(employees.ToArray());
        }



        #region Add methods
        public void AddDepartmentShowDialog(DepartmentCS toDepartment)
        {
            if (AddDepartmentForm == null) AddDepartmentForm = new AddDepartmentForm();
            this.AddDepartmentForm.DepartmentList = this.GetDepartmentList();
            this.AddDepartmentForm.SelectedDepartment = toDepartment;
            this.AddDepartmentForm.Text = "Новое подразделение";
            if (AddDepartmentForm.ShowDialog() == DialogResult.OK)
            {
                var t = (DepartmentCS)AddDepartmentForm.RepresentedValue;
                t.ID = _serviceManager.AddDepartment(t);

                // обновление интерфейса если нужно
                LocallyAddDepartment(t);
            }
        }

        public void AddEmployeeShowDialog(DepartmentCS toDepartment)
        {
            try
            {
                if (AddEmployeeForm == null) AddEmployeeForm = new AddEmployeeForm();
                this.AddEmployeeForm.DepartmentList = this.GetDepartmentList();
                this.AddEmployeeForm.SelectedDepartment = toDepartment;
                this.AddEmployeeForm.Text = "Добавление сотрудника";
                if (AddEmployeeForm.ShowDialog() == DialogResult.OK)
                {
                    var t = (EmployeeCS)AddEmployeeForm.RepresentedValue;
                    t.ID = _serviceManager.AddEmployee(t);

                    // обновление интерфейса если нужно
                    var selectedDep = (DepartmentCS)_mainForm.DepartmentStructureTreeView.SelectedNode.Tag;
                    if (t.DepartmentID == selectedDep.ID)
                    {
                        UpdateVisibleEmployees(selectedDep);
                    }
                }
            }
            catch (FaultException<DefaultFault> ex) // контролируемая ситуация на сервисе
            {
                // сообщение об ошибке для пользователя
                MessageBox.Show(ex.Detail.Message, ex.Action, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FaultException ex) // непредвидимая проблема на сервисе, см лог на сервисе
            {
                // неизвестная ошибка на сервисе
                MessageBox.Show("Неизвестная ошибка сервиса. Операция не выполнена.", null, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex) // что-то совсем пошло не так (включая CommunicationException и TimeOutException)
            {
                MessageBox.Show("Возникла ошибка: " + ex.Message, null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //!! TODO лог ошибки
            }
        }
        private void LocallyAddDepartment(DepartmentCS department)
        {
            // обновление внутренней структуры данных
            if (department.ParentDepartmentID == null)
            {
                _departmentStructure.Add(department);
            }
            else
            {
                GetDepartmentList().Single(dep => dep.ID == department.ParentDepartmentID).
                    ChildDepartments.Add(department);
            }
            // обновление отображения данных
            _mainForm.DepartmentStructureTreeView.AddDepartment(department);
        }
        #endregion
       
        #region Edit methods

        public void EditDepartmentShowDialog(DepartmentCS department)
        {
            if (AddDepartmentForm == null) AddDepartmentForm = new AddDepartmentForm();
            var allDeps = this.GetDepartmentList();
            allDeps.Remove(department); // чтобы нельзя было указать родительским самого себя 
            this.AddDepartmentForm.DepartmentList = allDeps;
            this.AddDepartmentForm.RepresentedValue = department;
            this.AddDepartmentForm.Text = "Редактирование подразделения";
            if (AddDepartmentForm.ShowDialog() == DialogResult.OK)
            {
                var editedDepartment = (DepartmentCS)this.AddDepartmentForm.RepresentedValue;
                editedDepartment.ID = department.ID;
                _serviceManager.EditDepartment(editedDepartment);

                LoccalyUpdateDepartments(department, editedDepartment);
            }
        }

        public void EditEmployeeShowDialog(EmployeeCS employee)
        {
            if (AddEmployeeForm == null) AddEmployeeForm = new AddEmployeeForm();
            this.AddEmployeeForm.DepartmentList = this.GetDepartmentList();
            this.AddEmployeeForm.RepresentedValue = employee;
            this.AddEmployeeForm.Text = "Редактирование сотрудника";
            if (AddEmployeeForm.ShowDialog() == DialogResult.OK)
            {
                var t = (EmployeeCS)this.AddEmployeeForm.RepresentedValue;
                t.ID = employee.ID;
                _serviceManager.EditEmployee(t);

                // обновление интерфейса если нужно
                var selectedDep = (DepartmentCS)_mainForm.DepartmentStructureTreeView.SelectedNode.Tag;
                if (t.DepartmentID == selectedDep.ID)
                {
                    UpdateVisibleEmployees(selectedDep);
                }
            }
        }

        private void LoccalyUpdateDepartments(DepartmentCS oldVersion, DepartmentCS newVersion)
        {
            // обновление внутренней структуры данных
            var oldDep = GetDepartmentList().Single(dep => dep.ID == oldVersion.ID);
            oldDep.Name = newVersion.Name;
            oldDep.Code = newVersion.Code;

            // обновление отображения данных 
            _mainForm.DepartmentStructureTreeView.EditDepartment(oldVersion, newVersion);
        }

        #endregion

        #region Delete methods
        public void DeleteDepartment(DepartmentCS department)
        {
            _serviceManager.DeleteDepartment(department);

            LocallyDeleteDepartment(department);
        }

        public void DeleteEmployee(EmployeeCS employee)
        {
            _serviceManager.DeleteEmployee(employee);

            // обновление интерфейса если нужно
            var selectedDep = (DepartmentCS)_mainForm.DepartmentStructureTreeView.SelectedNode.Tag;
            if (employee.DepartmentID == selectedDep.ID)
            {
                UpdateVisibleEmployees(selectedDep);
            }
        }

        private void LocallyDeleteDepartment(DepartmentCS department)
        {
            // обновление внутренней структуры данных
            GetDepartmentList().Single(dep => dep.ID == department.ParentDepartmentID)
                .ChildDepartments.Remove(department);

            // обновление отображения данных
            _mainForm.DepartmentStructureTreeView.Nodes.Remove(_mainForm.DepartmentStructureTreeView.SelectedNode);
        }



        #endregion

        #region Update UI methods
        public void Update()
        {
            _mainForm.DepartmentStructureTreeView.UpdateDepartments(this.LoadDepartmentStructure());
        }

        public void UpdateVisibleEmployees(DepartmentCS department)
        {
            var employees = _serviceManager.GetEmployeesByDepartment(department.ID);
            var selectedRows = _mainForm.EmployeeDataGridView.SelectedRows[0].Index;
            _mainForm.EmployeeDataGridView.Rows.Clear();
            _mainForm.EmployeeDataGridView.SelectEmployeeToGrid(employees.ToArray());

            _mainForm.EmployeeDataGridView.ClearSelection();
            _mainForm.EmployeeDataGridView.Rows[selectedRows].Selected = true;
        }

        
        #endregion

        #endregion
    }
}
