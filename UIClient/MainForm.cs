using ServiceManager;
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
            var t = this.structureTreeView.Container;
            var t2 = this.structureTreeView.Controls;
            presenter = new ServiceManager.MainPresenter();

            structureTreeView.Nodes.AddRange(presenter.GetDepartmentStructure());
        }
    }
}
