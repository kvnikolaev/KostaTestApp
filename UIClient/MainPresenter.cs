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
        private readonly ServiceConnector _manager = new ServiceConnector();

        private IEnumerable<DepartmentCS> _departmentStructure;

        private readonly EmployeeToGridShaper employeeToGrid = new EmployeeToGridShaper();
        #endregion

        #region Dependencies Properties
        public Form AddEmployeeForm { get; set; }
        public Form AddDepartmentForm { get; set; }
        #endregion

        public MainPresenter(MainForm mainForm)
        {
            mainForm.DepartmentStructureTreeView.Nodes.AddRange(this.GetDepartmentStructure());
            this.SetUpEmployeesView(mainForm.EmployeeDataGridView);
            mainForm.Presenter = this;
            Application.Run(mainForm);
        }

        #region GetDepartmentStructure
        /// <summary>
        /// Выполняет запрос сервиса к дб
        /// </summary>
        /// <returns></returns>
        public System.Windows.Forms.TreeNode[] GetDepartmentStructure()
        {
            _departmentStructure = _manager.GetDepartmentStructureWithEmployees();
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
        #endregion

        /// <summary>
        /// Настройка контрола, отображающего данные сотрудников
        /// </summary>
        /// <param name="dataGridView"></param>
        public void SetUpEmployeesView(DataGridView dataGridView)
        {
            employeeToGrid.SetUpGrid(dataGridView);
        }

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
            AddDepartmentForm.ShowDialog();
        }

        public void AddEmployeeShowDialog()
        {
            if (AddEmployeeForm == null) AddEmployeeForm = new AddEmployeeForm();
            //var t = 
            AddEmployeeForm.ShowDialog();
        }

        //private 

    }
}
