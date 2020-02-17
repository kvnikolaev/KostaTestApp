using ServiceManager;
using ServiceManager.DALServiceReference;
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
        private AddEmployeeForm _addEmployeeForm;
        public MainForm()
        {
            InitializeComponent();
            
        }

        private void StructureTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            EmployeeDataGridView.Rows.Clear();
            var selectedDep = (Department_dto)e.Node.Tag;
            Presenter.SelectEmployeeToGrid(EmployeeDataGridView, selectedDep);
        }

        private void DepartmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var t = new AddDepartmentForm();
            t.ShowDialog();
        }

        private void EmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_addEmployeeForm == null) _addEmployeeForm = new AddEmployeeForm();
            _addEmployeeForm.ShowDialog();
            //Presenter.AddEmployeeShowDialog()
        }
    }
}
