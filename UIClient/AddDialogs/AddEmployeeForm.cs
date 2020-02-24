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
    public partial class AddEmployeeForm : BaseDialogForm
    {
        public AddEmployeeForm()
        {
            InitializeComponent();
        }

        private DepartmentCS[] _departmentList;
        public override DepartmentCS[] DepartmentList
        {
            get
            {
                return _departmentList;
            }
            set
            {
                _departmentList = value;
                departmentComboBox.Items.Add(new DepartmentCS() { Name = "-Не выбран-" });
                departmentComboBox.SelectedIndex = 0;
                departmentComboBox.Items.AddRange(_departmentList);
            }
        }

        public override EmployeeCS RepresentedEmployee{ get; set; }

        #region Events
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            DepartmentCS dep = (DepartmentCS)this.departmentComboBox.SelectedItem;
            RepresentedEmployee = new EmployeeCS()
            {
                DateOfBirth = DateTime.Now,
                DocSeries = "1001",
                DocNumber = "123456",
                FirstName = "Николавев",
                SurName = "Кирилл",
                Patronymic = "Валерьевич",
                Position = "Нащальника",
                DepartmentID = dep.ID
            };

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        #endregion
    }
}
