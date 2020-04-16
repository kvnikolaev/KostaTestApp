using ServiceManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
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

        public string CurrentConnectionString { get; set; } //!! каким должно быть свойство

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
            string connString = $"data source={datasource_textBox.Text};initial catalog={initialcatalog_textBox.Text};" +
                       $"integrated security={checkBox1.Checked};" +
                       $"User ID={userid_textBox.Text};Password={password_textBox.Text};MultipleActiveResultSets=True";

            try
            {
                 _configLoader.SaveConnectionString(connString);

                this.DialogResult = DialogResult.OK;
            }
            catch(ConfigurationErrorsException ex)
            {
                MessageBox.Show("Ошибка сохранения файла конфигурации.", null, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CurrentConnectionString = connString;
                this.Close();
            }
        }
    }
}
