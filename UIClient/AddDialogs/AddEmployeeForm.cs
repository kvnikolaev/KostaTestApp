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

        public override EntityBase RepresentedValue{ get; set; }

        #region Events
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.CleanDialog();
            this.Close();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            DepartmentCS dep = (DepartmentCS)this.departmentComboBox.SelectedItem;
            RepresentedValue = new EmployeeCS()
            {
                DateOfBirth = dateTimePicker1.Value,
                DocSeries = series_textBox.Text,
                DocNumber = number_textBox.Text,
                FirstName = firstName_textBox.Text,
                SurName = surName_textBox.Text,
                Patronymic = patronymic_textBox.Text,
                Position = position_textBox.Text,
                DepartmentID = dep.ID
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
        }
    }
}
