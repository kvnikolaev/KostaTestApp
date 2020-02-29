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
                department_comboBox.Items.AddRange(new object[]
                {
         //           new DepartmentCS() { Name = "-Не выбран-", ParentDepartmentID = Guid.Empty },
                    new DepartmentCS() { Name = "-Самостоятельный отдел-", ParentDepartmentID = null }
                });
                department_comboBox.SelectedIndex = 0;
                department_comboBox.Items.AddRange(_departmentList);
            }
        }

        #region Events
        public override EntityBase RepresentedValue { get; set; }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.CleanDialog();
            this.Close();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            DepartmentCS dep = (DepartmentCS)this.department_comboBox.SelectedItem;
            RepresentedValue = new DepartmentCS()
            {
                Name = name_textBox.Text,
                ParentDepartmentID = department_comboBox.SelectedIndex == 0 ? null : (Nullable<Guid>)dep.ID,
                Code = code_textBox.Text
            };

            try
            {
                if (RepresentedValue.Validate())
                {
                    this.DialogResult = DialogResult.OK;
                    CleanDialog();
                    this.Close();
                }
            }
            catch (AggregateException validatiobExc)
            {
                var stringBuilder = new StringBuilder();
                foreach (Exception exc in validatiobExc.InnerExceptions)
                {
                    stringBuilder.AppendLine(exc.Message);
                }

                MessageBox.Show(
                    stringBuilder.ToString(),
                    "Ошибка заполнения формы",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

            }
        }

        #endregion

        private void CleanDialog()
        {
            this.name_textBox.Text = null;
            this.department_comboBox.SelectedIndex = 0;
            this.code_textBox.Text = null;
        }

    }
}
