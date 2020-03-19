using ServiceManager.DALServiceReference;
using ServiceManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UIClient.Utility;
using UIClient.AddDialogs;
using ServiceManager.ClientSideClasses;

namespace UIClient
{
    public class MainPresenter
    {
        #region Privates
        private readonly ServiceConnector _serviceManager = new ServiceConnector();

        private List<DepartmentCS> _departmentStructure;

        private MainForm _mainForm;

        private readonly EmployeeToGridShaper employeeToGrid = new EmployeeToGridShaper();
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
            // Подготовка DataGrid для списка сотрудников
            this.SetUpEmployeesView(mainForm.EmployeeDataGridView);
            mainForm.Presenter = this;
            Application.Run(mainForm);
        }

        /// <summary>
        /// Настройка столбцов таблицы контрола, отображающего данные сотрудников
        /// </summary>
        /// <param name="dataGridView"></param>
        public void SetUpEmployeesView(DataGridView dataGridView)
        {
            employeeToGrid.SetUpGrid(dataGridView);
        }

        #region To Service Methods
        /// <summary>
        /// Выполняет запрос сервиса к дб
        /// </summary>
        /// <returns></returns>
        public System.Windows.Forms.TreeNode[] LoadDepartmentStructure()
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
        public void SelectEmployeeToGrid(DataGridView grid, DepartmentCS department)
        {
            grid.Rows.Clear();
            var employees = _serviceManager.GetEmployeesByDepartment(department.ID);
            employeeToGrid.SelectEmployeeToGrid(grid, employees.ToArray());
        }



        #region Add methods
        public void AddDepartmentShowDialog(DepartmentCS toDepartment)
        {
            if (AddDepartmentForm == null) AddDepartmentForm = new AddDepartmentForm();
            this.AddDepartmentForm.DepartmentList = this.GetDepartmentList();
            this.AddDepartmentForm.SelectedDepartment = toDepartment;
            if (AddDepartmentForm.ShowDialog() == DialogResult.OK)
            {
                var t = (DepartmentCS)AddDepartmentForm.RepresentedValue;
                t.ID = _serviceManager.AddDepartment(t);

                // обновление интерфейса если нужно
                //UpdateVisibleDepartments(null, t);
                LocallyAddDepartment(t);
            }
        }

        public void AddEmployeeShowDialog(DepartmentCS toDepartment)
        {
            if (AddEmployeeForm == null) AddEmployeeForm = new AddEmployeeForm();
            this.AddEmployeeForm.DepartmentList = this.GetDepartmentList();
            this.AddEmployeeForm.SelectedDepartment = toDepartment;
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
            // обновление отображения двнных
            var newNode = new System.Windows.Forms.TreeNode()
            {
                Name = department.Name,
                Tag = department,
                Text = department.ToString()
            };

            if (department.ParentDepartmentID == null)
            {
                _mainForm.DepartmentStructureTreeView.Nodes.Add(newNode);
            }
            else
            {
                TreeNode node = _mainForm.DepartmentStructureTreeView.Nodes.FindByTag(new DepartmentCS() { ID = department.ParentDepartmentID.Value });
                node.Nodes.Add(newNode);
            }
        }
        #endregion
       
        #region Edit methods

        public void EditDepartmentShowDialog(DepartmentCS department)
        {
            if (AddDepartmentForm == null) AddDepartmentForm = new AddDepartmentForm();
            var allDeps = this.GetDepartmentList();
            allDeps.Remove(department);
            this.AddDepartmentForm.DepartmentList = allDeps;
            this.AddDepartmentForm.RepresentedValue = department;
            if (AddDepartmentForm.ShowDialog() == DialogResult.OK)
            {
                var editedDepartment = (DepartmentCS)this.AddDepartmentForm.RepresentedValue;
                editedDepartment.ID = department.ID;
                _serviceManager.EditDepartment(editedDepartment);

                UpdateVisibleDepartments(department, editedDepartment);
            }
        }

        public void EditEmployeeShowDialog(EmployeeCS employee)
        {
            if (AddEmployeeForm == null) AddEmployeeForm = new AddEmployeeForm();
            this.AddEmployeeForm.DepartmentList = this.GetDepartmentList();
            this.AddEmployeeForm.RepresentedValue = employee;
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


        #endregion

        #region Delete methods
        public void DeleteDepartment(DepartmentCS department)
        {
            _serviceManager.DeleteDepartment(department);

            _mainForm.DepartmentStructureTreeView.Nodes.Remove(_mainForm.DepartmentStructureTreeView.SelectedNode);
            _departmentStructure.Remove(department);
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




        #endregion

        #region Update UI methods
        public void Update()
        {
            _mainForm.DepartmentStructureTreeView.Nodes.Clear();
            _mainForm.DepartmentStructureTreeView.Nodes.AddRange(this.LoadDepartmentStructure());
        }
        public void UpdateVisibleEmployees(DepartmentCS department)
        {
            var employees = _serviceManager.GetEmployeesByDepartment(department.ID);
            var selectedRows = _mainForm.EmployeeDataGridView.SelectedRows[0].Index;
            _mainForm.EmployeeDataGridView.Rows.Clear();
            employeeToGrid.SelectEmployeeToGrid(_mainForm.EmployeeDataGridView, employees.ToArray());

            _mainForm.EmployeeDataGridView.ClearSelection();
            _mainForm.EmployeeDataGridView.Rows[selectedRows].Selected = true;
        }

        public void UpdateVisibleDepartments(DepartmentCS oldVersion, DepartmentCS newVersion)
        {
            TreeNode nodeToChange = null, parentNode = null;

            nodeToChange = _mainForm.DepartmentStructureTreeView.Nodes.FindByTag(oldVersion);
            if (newVersion.ParentDepartmentID.HasValue)
            {
                parentNode = _mainForm.DepartmentStructureTreeView.Nodes.FindByTag(new DepartmentCS() { ID = newVersion.ParentDepartmentID.Value });
            }

            if (nodeToChange == null) return;

            if (oldVersion.ParentDepartmentID != newVersion.ParentDepartmentID)
            {
                _mainForm.DepartmentStructureTreeView.Nodes.Remove(nodeToChange);
                if (newVersion.ParentDepartmentID == null)
                {
                    _mainForm.DepartmentStructureTreeView.Nodes.Add(nodeToChange);
                }
                else
                {
                    parentNode.Nodes.Add(nodeToChange);
                }
            }

            nodeToChange.Text = newVersion.ToString();
            nodeToChange.Tag = newVersion;
            
        }
        #endregion

        #endregion
    }
}
