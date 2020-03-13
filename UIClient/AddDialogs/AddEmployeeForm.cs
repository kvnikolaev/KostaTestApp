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

        public override DepartmentCS[] DepartmentList
        {
            get => base.DepartmentList;
            set
            {
                base.DepartmentList = value;
                departmentComboBox.Items.Add("-Не выбран-");
                departmentComboBox.SelectedIndex = 0;
                departmentComboBox.Items.AddRange(base.DepartmentList);
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
                    var t = this.departmentComboBox.Items.IndexOf(base.SelectedDepartment);
                    this.departmentComboBox.SelectedIndex = t;
                    this.departmentComboBox.Enabled = false;
                }
            }
        }

        public override EntityBase RepresentedValue
        {
            get => base.RepresentedValue;
            set
            {
                base.RepresentedValue = value;
                var employee = (EmployeeCS)RepresentedValue;

                this.dateTimePicker1.Value = employee.DateOfBirth.GetValueOrDefault(DateTime.Now);
                this.number_textBox.Text = employee.DocNumber;
                this.series_textBox.Text = employee.DocSeries;
                this.firstName_textBox.Text = employee.FirstName;
                this.surName_textBox.Text = employee.SurName;
                this.patronymic_textBox.Text = employee.Patronymic;
                this.position_textBox.Text = employee.Position;

                for (int i = 1; i < departmentComboBox.Items.Count; i++)
                {
                    if (((DepartmentCS)departmentComboBox.Items[i]).ID == employee.DepartmentID)
                    {
                        this.departmentComboBox.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        #region Events
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.CleanDialog();
            this.Close();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            RepresentedValue = new EmployeeCS()
            {
                DateOfBirth = dateTimePicker1.Value,
                DocSeries = series_textBox.Text,
                DocNumber = number_textBox.Text,
                FirstName = firstName_textBox.Text,
                SurName = surName_textBox.Text,
                Patronymic = patronymic_textBox.Text,
                Position = position_textBox.Text,
                DepartmentID = departmentComboBox.SelectedIndex == 0 ? null :
                    (Nullable<Guid>)((DepartmentCS)departmentComboBox.SelectedItem).ID
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
            this.firstName_textBox.Text = null;
            this.surName_textBox.Text = null;
            this.number_textBox.Text = null;
            this.patronymic_textBox.Text = null;
            this.departmentComboBox.SelectedIndex = 0;
            this.position_textBox.Text = null;
            this.series_textBox.Text = null;
            this.dateTimePicker1.Value = DateTime.Now;
            this.departmentComboBox.Items.Clear();
            this.departmentComboBox.Enabled = true;
        }
    }
}
