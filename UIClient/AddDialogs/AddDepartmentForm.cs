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

        public override List<DepartmentCS> DepartmentList
        {
            get => base.DepartmentList;
            set
            {
                base.DepartmentList = value;
                department_comboBox.Items.AddRange(new object[]
                {
                    "-Самостоятельный отдел-"
                });
                department_comboBox.SelectedIndex = 0;
                department_comboBox.Items.AddRange(base.DepartmentList.ToArray());
            }
        }

        public override DepartmentCS SelectedDepartment
        {
            get => base.SelectedDepartment;
            set
            {
                base.SelectedDepartment = value;
                if (base.SelectedDepartment != null)
                {
                    var t = this.department_comboBox.Items.IndexOf(base.SelectedDepartment);
                    this.department_comboBox.SelectedIndex = t;
                    this.department_comboBox.Enabled = false;
                }
            }
        }

        #region Events
        public override EntityBase RepresentedValue
        {
            get => base.RepresentedValue;
            set
            {
                base.RepresentedValue = value;
                var department = (DepartmentCS)RepresentedValue;

                this.name_textBox.Text = department.Name;
                this.code_textBox.Text = department.Code;

                for (int i = 1; i < department_comboBox.Items.Count; i++)
                {
                    if (((DepartmentCS)department_comboBox.Items[i]).ID == department.ParentDepartmentID)
                    {
                        this.department_comboBox.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.CleanDialog();
            this.Close();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            RepresentedValue = new DepartmentCS()
            {
                Name = name_textBox.Text,
                ParentDepartmentID = department_comboBox.SelectedIndex <= 0 ? null : //(Nullable<Guid>)dep.ID,
                    (Nullable<Guid>)((DepartmentCS)this.department_comboBox.SelectedItem).ID,
                Code = code_textBox.Text,
                ChildDepartments = new List<DepartmentCS>(),
                Employee = new List<EmployeeCS>()
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
            this.department_comboBox.Items.Clear();
            this.code_textBox.Text = null;
        }

    }
}
