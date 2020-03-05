using ServiceManager.ClientSideClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UIClient.Utility
{
    public static class TreeNodeCollectionExtension
    {
        public static TreeNode FindByTag(this TreeNodeCollection nc, DepartmentCS department)
        {
            TreeNode result = null;
            foreach(TreeNode node in nc)
            {
                result = SearchIn(node, department);
            }
            return result;
        }

        private static TreeNode SearchIn(TreeNode node, DepartmentCS department)
        {
            var t = (DepartmentCS)node.Tag;
            if (t.ID == department.ParentDepartmentID)
            {
                return node;
            }
            foreach(TreeNode subNode in node.Nodes)
            {
                var result = SearchIn(subNode, department);
                if (result != null)
                {
                    return result;
                }
            }
            return null;
        }
    }
}
