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
using NLog;

namespace UIClient
{
    public class MainPresenter
    {
        #region Privates
        private ILogger _logger;

        #endregion

        #region Dependencies Properties
        private readonly ServiceConnector _serviceManager = new ServiceConnector();

        private List<DepartmentCS> _departmentStructure = new List<DepartmentCS>();

        public MainForm MainForm { get; private set; }
        public BaseDialogForm AddEmployeeForm { get; set; }
        public BaseDialogForm AddDepartmentForm { get; set; }
        #endregion

        public MainPresenter(MainForm mainForm, ILogger logger)
        {
            _logger = logger;
            MainForm = mainForm;
            // Подготовка столбцов DataGrid для списка сотрудников
            mainForm.EmployeeDataGridView.SetUpGrid();

            mainForm.Presenter = this;
            mainForm.Load += new EventHandler(MainForm_Load);
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            // Добавление древо подразделений на форму, список сотрудников отображается через событие AfterSelect
            MainForm.DepartmentStructureTreeView.Nodes.AddRange(await this.LoadDepartmentStructure());
        }

        #region Department Structure Methods
        /// <summary>
        /// Выполняет запрос сервиса к дб
        /// </summary>
        /// <returns></returns>
        private async Task<System.Windows.Forms.TreeNode[]> LoadDepartmentStructure()
        {
            List<System.Windows.Forms.TreeNode> result = new List<System.Windows.Forms.TreeNode>();
            try 
            {
                _departmentStructure = (await _serviceManager.GetDepartmentStructureWithEmployees()).ToList();
            }

            // форматировать для метода 
            catch (FaultException<DefaultFault> ex) // контролируемая ситуация на сервисе
            {
                // сообщение об ошибке для пользователя
                MessageBox.Show(ex.Detail.Message, ex.Action, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FaultException ex) // непредвиденная проблема на сервисе, см лог на сервисе
            {
                // неизвестная ошибка на сервисе
                MessageBox.Show("Неизвестная ошибка сервиса. Операция не выполнена.", null, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex) // что-то совсем пошло не так (включая CommunicationException и TimeOutException)
            {
                MessageBox.Show("Возникла ошибка: " + ex.Message, null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                _logger.Error(ex, "Ошибка во время зарузки");
            }


            foreach (var dep in _departmentStructure)
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
        public async void SelectEmployeeToGrid(DepartmentCS department)
        {
            try
            {
                MainForm.EmployeeDataGridView.Rows.Clear();
                var employees = await _serviceManager.GetEmployeesByDepartment(department.ID);
                MainForm.EmployeeDataGridView.SelectEmployeeToGrid(employees.ToArray());
            }
            catch (FaultException<DefaultFault> ex) // контролируемая ситуация на сервисе
            {
                // сообщение об ошибке для пользователя
                MessageBox.Show(ex.Detail.Message, ex.Action, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FaultException ex) // непредвиденная проблема на сервисе, см лог на сервисе
            {
                // неизвестная ошибка на сервисе
                MessageBox.Show("Неизвестная ошибка сервиса. Операция не выполнена.", null, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex) // что-то совсем пошло не так (включая CommunicationException и TimeOutException)
            {
                MessageBox.Show("Возникла ошибка: " + ex.Message, null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                _logger.Error(ex, "Ошибка в загрузке сотрудников");
            }
        }



        #region Add methods
        public async void AddDepartmentShowDialog(DepartmentCS toDepartment)
        {
            try
            {
                if (AddDepartmentForm == null) AddDepartmentForm = new AddDepartmentForm();
                this.AddDepartmentForm.DepartmentList = this.GetDepartmentList();
                this.AddDepartmentForm.SelectedDepartment = toDepartment;
                this.AddDepartmentForm.Text = "Новое подразделение";
                if (AddDepartmentForm.ShowDialog() == DialogResult.OK)
                {
                    var t = (DepartmentCS)AddDepartmentForm.RepresentedValue;
                    t.ID = await _serviceManager.AddDepartment(t);

                    // обновление интерфейса если нужно
                    LocallyAddDepartment(t);
                }
            }
            catch (FaultException<DefaultFault> ex) // контролируемая ситуация на сервисе
            {
                // сообщение об ошибке для пользователя
                MessageBox.Show(ex.Detail.Message, ex.Action, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FaultException ex) // непредвиденная проблема на сервисе, см лог на сервисе
            {
                // неизвестная ошибка на сервисе
                MessageBox.Show("Неизвестная ошибка сервиса. Операция не выполнена.", null, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex) // что-то совсем пошло не так (включая CommunicationException и TimeOutException)
            {
                MessageBox.Show("Возникла ошибка: " + ex.Message, null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                _logger.Error(ex, "Ошибка в добавлении подразделения");
            }
        }

        public async void AddEmployeeShowDialog(DepartmentCS toDepartment)
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
                    t.ID = await _serviceManager.AddEmployee(t);

                    // обновление интерфейса если нужно
                    var selectedDep = (DepartmentCS)MainForm.DepartmentStructureTreeView.SelectedNode.Tag;
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
            catch (FaultException ex) // непредвиденная проблема на сервисе, см лог на сервисе
            {
                // неизвестная ошибка на сервисе
                MessageBox.Show("Неизвестная ошибка сервиса. Операция не выполнена.", null, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex) // что-то совсем пошло не так (включая CommunicationException и TimeOutException)
            {
                MessageBox.Show("Возникла ошибка: " + ex.Message, null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                _logger.Error(ex, "Ошибка в добавлении сотрудников");
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
            MainForm.DepartmentStructureTreeView.AddDepartment(department);
        }
        #endregion
       
        #region Edit methods

        public async void EditDepartmentShowDialog(DepartmentCS department)
        {
            try
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
                    await _serviceManager.EditDepartment(editedDepartment);

                    LoccalyUpdateDepartments(department, editedDepartment);
                }
            }
            catch (FaultException<DefaultFault> ex) // контролируемая ситуация на сервисе
            {
                // сообщение об ошибке для пользователя
                MessageBox.Show(ex.Detail.Message, ex.Action, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FaultException ex) // непредвиденная проблема на сервисе, см лог на сервисе
            {
                // неизвестная ошибка на сервисе
                MessageBox.Show("Неизвестная ошибка сервиса. Операция не выполнена.", null, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex) // что-то совсем пошло не так (включая CommunicationException и TimeOutException)
            {
                MessageBox.Show("Возникла ошибка: " + ex.Message, null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                _logger.Error(ex, "Ошибка в редактировании подразделения");
            }
        }

        public async void EditEmployeeShowDialog(EmployeeCS employee)
        {
            try
            {
                if (AddEmployeeForm == null) AddEmployeeForm = new AddEmployeeForm();
                this.AddEmployeeForm.DepartmentList = this.GetDepartmentList();
                this.AddEmployeeForm.RepresentedValue = employee;
                this.AddEmployeeForm.Text = "Редактирование сотрудника";
                if (AddEmployeeForm.ShowDialog() == DialogResult.OK)
                {
                    var t = (EmployeeCS)this.AddEmployeeForm.RepresentedValue;
                    t.ID = employee.ID;
                    await _serviceManager.EditEmployee(t);

                    // обновление интерфейса если нужно
                    var selectedDep = (DepartmentCS)MainForm.DepartmentStructureTreeView.SelectedNode.Tag;
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
            catch (FaultException ex) // непредвиденная проблема на сервисе, см лог на сервисе
            {
                // неизвестная ошибка на сервисе
                MessageBox.Show("Неизвестная ошибка сервиса. Операция не выполнена.", null, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex) // что-то совсем пошло не так (включая CommunicationException и TimeOutException)
            {
                MessageBox.Show("Возникла ошибка: " + ex.Message, null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                _logger.Error(ex, "Ошибка в редактировании сотрудника");
            }
        }

        private void LoccalyUpdateDepartments(DepartmentCS oldVersion, DepartmentCS newVersion)
        {
            // обновление внутренней структуры данных
            var oldDep = GetDepartmentList().Single(dep => dep.ID == oldVersion.ID);
            oldDep.Name = newVersion.Name;
            oldDep.Code = newVersion.Code;

            // обновление отображения данных 
            MainForm.DepartmentStructureTreeView.EditDepartment(oldVersion, newVersion);
        }

        #endregion

        #region Delete methods
        public async void DeleteDepartment(DepartmentCS department)
        {
            try
            {
                await _serviceManager.DeleteDepartment(department);

                LocallyDeleteDepartment(department);
            }
            catch (FaultException<DefaultFault> ex) // контролируемая ситуация на сервисе
            {
                // сообщение об ошибке для пользователя
                MessageBox.Show(ex.Detail.Message, ex.Action, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FaultException ex) // непредвиденная проблема на сервисе, см лог на сервисе
            {
                // неизвестная ошибка на сервисе
                MessageBox.Show("Неизвестная ошибка сервиса. Операция не выполнена.", null, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex) // что-то совсем пошло не так (включая CommunicationException и TimeOutException)
            {
                MessageBox.Show("Возникла ошибка: " + ex.Message, null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                _logger.Error(ex, "Ошибка в удалении подразделения");
            }
        }

        public async void DeleteEmployee(EmployeeCS employee)
        {
            try
            {
                await _serviceManager.DeleteEmployee(employee);

                // обновление интерфейса если нужно
                var selectedDep = (DepartmentCS)MainForm.DepartmentStructureTreeView.SelectedNode.Tag;
                if (employee.DepartmentID == selectedDep.ID)
                {
                    UpdateVisibleEmployees(selectedDep);
                }
            }
            catch (FaultException<DefaultFault> ex) // контролируемая ситуация на сервисе
            {
                // сообщение об ошибке для пользователя
                MessageBox.Show(ex.Detail.Message, ex.Action, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FaultException ex) // непредвиденная проблема на сервисе, см лог на сервисе
            {
                // неизвестная ошибка на сервисе
                MessageBox.Show("Неизвестная ошибка сервиса. Операция не выполнена.", null, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex) // что-то совсем пошло не так (включая CommunicationException и TimeOutException)
            {
                MessageBox.Show("Возникла ошибка: " + ex.Message, null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                _logger.Error(ex, "Ошибка в удалении сотрудника");
            }
        }

        private void LocallyDeleteDepartment(DepartmentCS department)
        {
            // обновление внутренней структуры данных
            GetDepartmentList().Single(dep => dep.ID == department.ParentDepartmentID)
                .ChildDepartments.Remove(department);

            // обновление отображения данных
            MainForm.DepartmentStructureTreeView.Nodes.Remove(MainForm.DepartmentStructureTreeView.SelectedNode);
        }



        #endregion

        #region Update UI methods
        public void Update()
        {
            //_mainForm.DepartmentStructureTreeView.UpdateDepartments(this.LoadDepartmentStructure());
        }

        public async void UpdateVisibleEmployees(DepartmentCS department)
        {
            try
            {
                var employees = await _serviceManager.GetEmployeesByDepartment(department.ID);
                var selectedRows = MainForm.EmployeeDataGridView.SelectedRows[0].Index;
                MainForm.EmployeeDataGridView.Rows.Clear();
                MainForm.EmployeeDataGridView.SelectEmployeeToGrid(employees.ToArray());

                MainForm.EmployeeDataGridView.ClearSelection();
                MainForm.EmployeeDataGridView.Rows[selectedRows].Selected = true;
            }
            catch (FaultException<DefaultFault> ex) // контролируемая ситуация на сервисе
            {
                // сообщение об ошибке для пользователя
                MessageBox.Show(ex.Detail.Message, ex.Action, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FaultException ex) // непредвиденная проблема на сервисе, см лог на сервисе
            {
                // неизвестная ошибка на сервисе
                MessageBox.Show("Неизвестная ошибка сервиса. Операция не выполнена.", null, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex) // что-то совсем пошло не так (включая CommunicationException и TimeOutException)
            {
                MessageBox.Show("Возникла ошибка: " + ex.Message, null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                _logger.Error(ex, "Ошибка обновления данных");
            }
        }

        
        #endregion

        #endregion
    }
}
