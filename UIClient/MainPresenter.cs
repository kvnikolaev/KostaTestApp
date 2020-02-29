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

        private IEnumerable<DepartmentCS> _departmentStructure;

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
            mainForm.DepartmentStructureTreeView.Nodes.AddRange(this.GetDepartmentStructure());
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

        #region Business-logic organisation structure Methods
        /// <summary>
        /// Выполняет запрос сервиса к дб
        /// </summary>
        /// <returns></returns>
        public System.Windows.Forms.TreeNode[] GetDepartmentStructure()
        {
            _departmentStructure = _serviceManager.GetDepartmentStructureWithEmployees();
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
                Tag = department,      //!! может IDшники?
                Text = department.Name
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
        public DepartmentCS[] GetDepartmentArray()
        {
            List<DepartmentCS> result = new List<DepartmentCS>();
            foreach(var department in this._departmentStructure)
            {
                GetSubDepartments(result, department);
                //result.AddRange(GetSubDepartments(department));
            }
            return result.ToArray();

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
            employeeToGrid.SelectEmployeeToGrid(grid, department.Employee.ToArray());
        }

        public void AddDepartmentShowDialog()
        {
            if (AddDepartmentForm == null) AddDepartmentForm = new AddDepartmentForm();
            this.AddDepartmentForm.DepartmentList = this.GetDepartmentArray();
            if (AddDepartmentForm.ShowDialog() == DialogResult.OK)
            {
                var t = AddDepartmentForm.RepresentedValue;
                _serviceManager.AddDepartment((DepartmentCS)t);

                Refresh();
            }
        }

        public void AddEmployeeShowDialog()
        {
            if (AddEmployeeForm == null) AddEmployeeForm = new AddEmployeeForm();
            this.AddEmployeeForm.DepartmentList = this.GetDepartmentArray();
            if (AddEmployeeForm.ShowDialog() == DialogResult.OK)
            {
                var t = AddEmployeeForm.RepresentedValue;
                _serviceManager.AddEmployee((EmployeeCS)t);

                Refresh();
            }
        }

       public void Refresh()
        {
            _mainForm.DepartmentStructureTreeView.Nodes.Clear();
            _mainForm.DepartmentStructureTreeView.Nodes.AddRange(this.GetDepartmentStructure());
        }
        #endregion
    }
}
