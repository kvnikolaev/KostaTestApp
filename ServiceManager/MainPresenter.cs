using ServiceManager.DALServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceManager
{
    public class MainPresenter
    {
        private ServiceConnector _manager = new ServiceConnector();

        private IEnumerable<Department_dto> _departmentStructure;
        public System.Windows.Forms.TreeNode[] GetDepartmentStructure()
        {
            _departmentStructure = _manager.GetDepartmentStructureWithEmployees();
            List<System.Windows.Forms.TreeNode> result = new List<System.Windows.Forms.TreeNode>();
           // DALServiceReference.
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
    }
}
