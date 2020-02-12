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
            var selectedDep = (Department_dto)e.Node.Tag;
            Presenter.SelectEmployeeToGrid(EmployeeDataGridView, selectedDep);
        }
    }
}
