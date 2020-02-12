using ServiceManager.DALServiceReference;
using ServiceManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UIClient.Utility;

namespace UIClient
{
    public class MainPresenter
    {
        private ServiceConnector _manager = new ServiceConnector();

        private IEnumerable<Department_dto> _departmentStructure;

        private EmployeeToGridShaper employeeToGrid = new EmployeeToGridShaper();

        public MainPresenter(MainForm mainForm)
        {
            mainForm.DepartmentStructureTreeView.Nodes.AddRange(this.GetDepartmentStructure());
            this.SetUpEmployeesView(mainForm.EmployeeDataGridView);
            mainForm.Presenter = this;
            Application.Run(mainForm);
        }

        #region GetDepartmentStructure
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

        private System.Windows.Forms.TreeNode GetSubNodes(Department_dto department)
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

        public void SetUpEmployeesView(DataGridView dataGridView)
        {
            employeeToGrid.SetUpGrid(dataGridView);
        }

        /// <summary>
        /// Вывести список сотрудников на контрол DataGridView, настроенный через SetUpGrid. Не очищает имеющиеся элементы. 
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="department"></param>
        public void SelectEmployeeToGrid(DataGridView grid, Department_dto department)
        {
            employeeToGrid.SelectEmployeeToGrid(grid, department.Employee);
        }
    }
}
