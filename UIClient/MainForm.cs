using ServiceManager;
using ServiceManager.ClientSideClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UIClient.AddDialogs;

namespace UIClient
{
    public partial class MainForm : Form
    {
        public MainPresenter Presenter { get; set; }
        
        public MainForm()
        {
            InitializeComponent();
            
        }
        private bool _enableActions = true;
        public bool EnableActions
        {
            get
            {
                return _enableActions;
            }
            set
            {
                this.add_toolStripMenuItem1.Enabled = value;
                this.editToolStripMenuItem.Enabled = value;
                this.deleteToolStripMenuItem.Enabled = value;
                this.reloadStripMenuItem5.Enabled = value;
                this.settingsStripMenuItem.Enabled = value;
                this.loading_toolStripMenuItem.EnableAnimation = !value;
                _enableActions = value;
            }
        }

        private void StructureTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var selectedDep = (DepartmentCS)e.Node.Tag;
            Presenter.SelectEmployeeToGrid(selectedDep);
        }
        
        private void EmployeeDataGridView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hit = EmployeeDataGridView.HitTest(e.X, e.Y);
                EmployeeDataGridView.ClearSelection();
                if (hit.RowIndex >= 0 && hit.RowIndex < EmployeeDataGridView.Rows.Count - 1)
                {
                    EmployeeDataGridView.Rows[hit.RowIndex].Selected = true;
                    employeeView_contextMenuStrip.Show(EmployeeDataGridView, e.X, e.Y);
                }
                
            }
        }

        private void DepartmentStructureTreeView_MouseDown(object sender, MouseEventArgs e)
        {
            var hite = DepartmentStructureTreeView.HitTest(e.X, e.Y);
            if (hite.Location == TreeViewHitTestLocations.Label && e.Button == MouseButtons.Right)
            {
                DepartmentStructureTreeView.SelectedNode = hite.Node;
                departmentView_contextMenuStrip.Show(DepartmentStructureTreeView, e.X, e.Y);
            }
        }

        private void EmployeeDataGridView_DoubleClick(object sender, EventArgs e)
        {
            if (EnableActions == false || DepartmentStructureTreeView.SelectedNode == null) return;
            var grid = (DataGridView)sender;
            if (grid.SelectedRows.Count > 0)
            {
                if (grid.SelectedRows[0].Index == grid.Rows.Count - 1)
                {
                    Presenter.AddEmployeeShowDialog((DepartmentCS)DepartmentStructureTreeView.SelectedNode.Tag);
                }
                else
                {
                    Presenter.EditEmployeeShowDialog((EmployeeCS)grid.SelectedRows[0].Tag);
                }
            }
        }

        private void MenuTray_AddDepartment_Click(object sender, EventArgs e)
        {
            Presenter.AddDepartmentShowDialog(null);
        }

        private void MenuTray_AddEmployee_Click(object sender, EventArgs e)
        {
            Presenter.AddEmployeeShowDialog(null);
        }

        private void MenuTray_EditMenuItem_DropDownOpened(object sender, EventArgs e)
        {
            DepartmentCS selectedDepartment = null;
            if (DepartmentStructureTreeView.SelectedNode != null)
            {
                selectedDepartment = (DepartmentCS)DepartmentStructureTreeView.SelectedNode.Tag;
                editDepartment_toolStripMenuItem1.Text = $"Редактировать подразделение \"{selectedDepartment.ToString()}\"";
                editDepartment_toolStripMenuItem1.Enabled = true;
            }
            else
            {
                editDepartment_toolStripMenuItem1.Text = "Подразделение не выбрано";
                editDepartment_toolStripMenuItem1.Enabled = false;
            }

            EmployeeCS selectedEmpl = null;
            if (EmployeeDataGridView.SelectedRows.Count > 0 && EmployeeDataGridView.SelectedRows[0].Index != EmployeeDataGridView.Rows.Count - 1)
            {
                selectedEmpl = (EmployeeCS)EmployeeDataGridView.SelectedRows[0].Tag;
                editEmployee_toolStripMenuItem2.Text = $"Редактирование сотрудника \"{selectedEmpl.SurName} {selectedEmpl.FirstName} - {selectedEmpl.Position}\"";
                editEmployee_toolStripMenuItem2.Enabled = true;
            }
            else
            {
                editEmployee_toolStripMenuItem2.Text = "Сотрудник не выбран";
                editEmployee_toolStripMenuItem2.Enabled = false;
            }

        }

        private void MenuTray_DeleteMenuItem_DropDownOpened(object sender, EventArgs e)
        {
            DepartmentCS selectedDepartment = null;
            if (DepartmentStructureTreeView.SelectedNode != null)
            {
                selectedDepartment = (DepartmentCS)DepartmentStructureTreeView.SelectedNode.Tag;
                deleteDepartmentToolStripMenuItem.Text = $"Удаление подразделение \"{selectedDepartment.ToString()}\"";
                deleteDepartmentToolStripMenuItem.Enabled = true;
            }
            else
            {
                deleteDepartmentToolStripMenuItem.Text = "Подразделение не выбрано";
                deleteDepartmentToolStripMenuItem.Enabled = false;
            }

            EmployeeCS selectedEmpl = null;
            if (EmployeeDataGridView.SelectedRows.Count > 0 && EmployeeDataGridView.SelectedRows[0].Index != EmployeeDataGridView.Rows.Count - 1)
            {
                selectedEmpl = (EmployeeCS)EmployeeDataGridView.SelectedRows[0].Tag;
                deleteEmployeeToolStripMenuItem.Text = $"Удаление сотрудника \"{selectedEmpl.SurName} {selectedEmpl.FirstName} - {selectedEmpl.Position}\"";
                deleteEmployeeToolStripMenuItem.Enabled = true;
            }
            else
            {
                deleteEmployeeToolStripMenuItem.Text = "Сотрудник не выбран";
                deleteEmployeeToolStripMenuItem.Enabled = false;
            }
        }

        private void MenuTray_EditDepartment_Click(object sender, EventArgs e)
        {
            Presenter.EditDepartmentShowDialog((DepartmentCS)DepartmentStructureTreeView.SelectedNode.Tag);
        }

        private void MenuTray_EditEmployee_Click(object sender, EventArgs e)
        {
            Presenter.EditEmployeeShowDialog((EmployeeCS)EmployeeDataGridView.SelectedRows[0].Tag);
        }

        private void MenuTray_DeleteDepartment_Click(object sender, EventArgs e)
        {
            string message = string.Format("Вы уверены, что хотите удалить подразделение \"{0}\"?", DepartmentStructureTreeView.SelectedNode.Tag.ToString());
            var result = MessageBox.Show(message, "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
            if (result == DialogResult.Yes)
            {
                Presenter.DeleteDepartment((DepartmentCS)DepartmentStructureTreeView.SelectedNode.Tag);
            }
        }

        private void MenuTray_DeleteEmployee_Click(object sender, EventArgs e)
        {
            string message = string.Format("Вы уверены, что хотите удалить сотрудника \"{0}\"?", EmployeeDataGridView.SelectedRows[0].Tag.ToString());
            var result = MessageBox.Show(message, "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
            if (result == DialogResult.Yes)
            {
                Presenter.DeleteEmployee((EmployeeCS)EmployeeDataGridView.SelectedRows[0].Tag);
            }
        }

        private void MenuTray_Reload_Click(object sender, EventArgs e)
        {
            Presenter.Update();
        }

        private void MenuTray_Setting_Click(object sender, EventArgs e)
        {
            Presenter.ShowSettings();
        }


        private void ContextMenu_DepartmentEditItem_Click(object sender, EventArgs e)
        {
            Presenter.EditDepartmentShowDialog((DepartmentCS)DepartmentStructureTreeView.SelectedNode.Tag);
        }

        private void ContextMenu_DepartmentDeleteItem_Click(object sender, EventArgs e)
        {
            string message = string.Format("Вы уверены, что хотите удалить подразделение \"{0}\"?", DepartmentStructureTreeView.SelectedNode.Tag.ToString());
            var result = MessageBox.Show(message, "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
            if (result == DialogResult.Yes)
            {
                Presenter.DeleteDepartment((DepartmentCS)DepartmentStructureTreeView.SelectedNode.Tag);
            }
        }

        private void ContextMenu_EmployeeEditItem_Click(object sender, EventArgs e)
        {
            Presenter.EditEmployeeShowDialog((EmployeeCS)EmployeeDataGridView.SelectedRows[0].Tag);
        }

        private void ContextMenu_EmployeeDeleteItem_Click(object sender, EventArgs e)
        {
            string message = string.Format("Вы уверены, что хотите удалить сотрудника \"{0}\"?", EmployeeDataGridView.SelectedRows[0].Tag.ToString());
            var result = MessageBox.Show(message, "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
            if (result == DialogResult.Yes)
            {
                Presenter.DeleteEmployee((EmployeeCS)EmployeeDataGridView.SelectedRows[0].Tag);
            }
        }
    }
}
