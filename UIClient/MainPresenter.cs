using ServiceManager.DALServiceReference;
using ServiceManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UIClient
{
    public class MainPresenter
    {
        private ServiceConnector _manager = new ServiceConnector();

        private IEnumerable<Department_dto> _departmentStructure;

        public MainPresenter(MainForm mainForm)
        {
            mainForm.DepartmentStructureTreeView.Nodes.AddRange(this.GetDepartmentStructure());
            this.SetUpEmployeesView(mainForm.EmployeeDataGridView);
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
            
        }


        //public System.Windows.Forms.DataGridViewRow[] GetEmployeesForDepartment(Department_dto department)
        //{
        //    List<System.Windows.Forms.DataGridViewRow> result = new List<System.Windows.Forms.DataGridViewRow>();
        //    foreach (var employee in department.Employee)
        //    {
        //        result.Add(new System.Windows.Forms.DataGridViewRow() { })
        //    }
        //}
    }
}
