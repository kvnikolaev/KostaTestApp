using ServiceManager.DALServiceReference;
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
using ServiceManager.ClientSideClasses;

namespace UIClient.AddDialogs
{
    public partial class AddEmployeeForm : Form
    {
        public AddEmployeeForm()
        {
            InitializeComponent();
        }
        
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            var t = new DepartmentCS(); t.Name = "olo";
            
            //t.get
            this.comboBox1.Items.Add(t);
        }
    }
}
