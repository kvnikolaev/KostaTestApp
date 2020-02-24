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

namespace UIClient.AddDialogs
{
    public partial class AddDepartmentForm : BaseDialogForm
    {
        public AddDepartmentForm()
        {
            InitializeComponent();
        }

        public override DepartmentCS[] DepartmentList { get; set; }
    }
}
