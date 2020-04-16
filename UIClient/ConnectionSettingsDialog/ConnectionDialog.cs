using ServiceManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UIClient.ConnectionSettingsDialog
{
    public partial class ConnectionDialog : Form
    {
        private IConnectionStringLoader _configLoader;

        public string CurrentConnectionString
        {
            get
            {
                return $"data source={datasource_textBox.Text};initial catalog={initialcatalog_textBox.Text};" +
                       $"integrated security={checkBox1.Checked};" +
                       $"User ID={userid_textBox.Text};Password={password_textBox.Text};MultipleActiveResultSets=True";
            }
            set
            {
                SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder(value);

                this.datasource_textBox.Text = stringBuilder.DataSource;
                this.initialcatalog_textBox.Text = stringBuilder.InitialCatalog;
                this.checkBox1.Checked = stringBuilder.IntegratedSecurity;
                this.userid_textBox.Text = stringBuilder.UserID;
                this.password_textBox.Text = stringBuilder.Password;
            }
        } 

        public ConnectionDialog(IConnectionStringLoader loader)
        {
            InitializeComponent();

            this._configLoader = loader;
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            userPasswordPanel.Enabled = !checkBox1.Checked;
        }

        private void Save_button_Click(object sender, EventArgs e)
        {
            
            try
            {
                 _configLoader.SaveConnectionString(CurrentConnectionString);  //!! сохранять лучше в другом месте

                this.DialogResult = DialogResult.OK;
            }
            catch(ConfigurationErrorsException ex)
            {
                MessageBox.Show("Ошибка сохранения файла конфигурации.", null, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Close();
            }
        }
    }
}
