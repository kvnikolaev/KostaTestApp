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
        MainPresenter presenter;
        public MainForm()
        {
            InitializeComponent();
            
            presenter = new ServiceManager.MainPresenter();

            structureTreeView.Nodes.AddRange(presenter.GetDepartmentStructure());
            presenter.SetUpEmployeesView(dataGridView);
        }

        private void StructureTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var selectedDep = (Department_dto)e.Node.Tag;

            // dataGridView.Rows.Clear();
            var t = new DataGridViewRow();
            t.CreateCells(dataGridView, 1, 2, 3);
            
            dataGridView.Rows.Add(t);
        }
    }
}
