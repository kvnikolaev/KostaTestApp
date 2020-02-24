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
            EmployeeDataGridView.Rows.Clear();
            var selectedDep = (DepartmentCS)e.Node.Tag;
            Presenter.SelectEmployeeToGrid(EmployeeDataGridView, selectedDep);
        }

        private void DepartmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Presenter.AddDepartmentShowDialog();
        }

        private void EmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Presenter.AddEmployeeShowDialog();
        }
    }
}
