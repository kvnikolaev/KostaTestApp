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

        private void StructureTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var selectedDep = (DepartmentCS)e.Node.Tag;
            Presenter.SelectEmployeeToGrid(EmployeeDataGridView, selectedDep);
        }

        private void DepartmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Presenter.AddDepartmentShowDialog(null);
        }

        private void EmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Presenter.AddEmployeeShowDialog(null);
        }

        
        private void EmployeeDataGridView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hti = EmployeeDataGridView.HitTest(e.X, e.Y);
                EmployeeDataGridView.ClearSelection();
                if (hti.RowIndex >= 0 && hti.RowIndex < EmployeeDataGridView.Rows.Count - 1)
                {
                    EmployeeDataGridView.Rows[hti.RowIndex].Selected = true;
                    contextMenuStrip1.Show(EmployeeDataGridView, e.X, e.Y);
                }
                
            }
        }

        private void EmployeeDataGridView_DoubleClick(object sender, EventArgs e)
        {
            var grid = (DataGridView)sender;
            if (grid.SelectedRows[0].Index == grid.Rows.Count - 1)
            {
                Presenter.AddEmployeeShowDialog((DepartmentCS)DepartmentStructureTreeView.SelectedNode.Tag);
            }
        }
    }
}
