using ServiceManager.ClientSideClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UIClient.Controlls
{
    public class DepartmentTreeView : TreeView
    {
        public void AddDepartment(DepartmentCS newDepartment)
        {
            var newNode = new System.Windows.Forms.TreeNode()
            {
                Name = newDepartment.Name,
                Tag = newDepartment,
                Text = newDepartment.ToString()
            };

            if (newDepartment.ParentDepartmentID == null)
            {
                this.Nodes.Add(newNode);
            }
            else
            {
                TreeNode node = this.Nodes.FindByTag(new DepartmentCS() { ID = newDepartment.ParentDepartmentID.Value });
                node.Nodes.Add(newNode);
            }
            this.SelectedNode = newNode;
        }

        public void EditDepartment(DepartmentCS oldVersion, DepartmentCS newVersion)
        {
            TreeNode nodeToChange = null, parentNode = null;

            nodeToChange = this.Nodes.FindByTag(oldVersion);
            if (newVersion.ParentDepartmentID.HasValue)
            {
                parentNode = this.Nodes.FindByTag(new DepartmentCS() { ID = newVersion.ParentDepartmentID.Value });
            }

            if (nodeToChange == null) return;

            if (oldVersion.ParentDepartmentID != newVersion.ParentDepartmentID)
            {
                this.Nodes.Remove(nodeToChange);
                if (newVersion.ParentDepartmentID == null)
                {
                    this.Nodes.Add(nodeToChange);
                }
                else
                {
                    parentNode.Nodes.Add(nodeToChange);
                }
            }

            nodeToChange.Text = newVersion.ToString();
            nodeToChange.Tag = newVersion;
            this.SelectedNode = nodeToChange;
        }

        public void UpdateDepartments(TreeNode[] nodes)
        {
            var selectedDepartment = (DepartmentCS)this.SelectedNode.Tag;

            this.Nodes.Clear();
            this.Nodes.AddRange(nodes);
            this.SelectedNode = this.Nodes.FindByTag(selectedDepartment);
        }
    }
}
