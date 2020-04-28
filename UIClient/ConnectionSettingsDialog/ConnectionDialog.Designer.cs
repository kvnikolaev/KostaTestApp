namespace UIClient.ConnectionSettingsDialog
{
    partial class ConnectionDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.serverInfoPanel = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.datasource_textBox = new System.Windows.Forms.TextBox();
            this.initialcatalog_textBox = new System.Windows.Forms.TextBox();
            this.userPasswordPanel = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.userid_textBox = new System.Windows.Forms.TextBox();
            this.password_textBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cancel_button = new System.Windows.Forms.Button();
            this.save_button = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.serverInfoPanel.SuspendLayout();
            this.userPasswordPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.serverInfoPanel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.userPasswordPanel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(530, 379);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // serverInfoPanel
            // 
            this.serverInfoPanel.AutoSize = true;
            this.serverInfoPanel.ColumnCount = 2;
            this.serverInfoPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.serverInfoPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.serverInfoPanel.Controls.Add(this.label1, 0, 2);
            this.serverInfoPanel.Controls.Add(this.checkBox1, 1, 2);
            this.serverInfoPanel.Controls.Add(this.label2, 0, 1);
            this.serverInfoPanel.Controls.Add(this.label3, 0, 0);
            this.serverInfoPanel.Controls.Add(this.datasource_textBox, 1, 0);
            this.serverInfoPanel.Controls.Add(this.initialcatalog_textBox, 1, 1);
            this.serverInfoPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.serverInfoPanel.Location = new System.Drawing.Point(3, 3);
            this.serverInfoPanel.Name = "serverInfoPanel";
            this.serverInfoPanel.RowCount = 3;
            this.serverInfoPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.serverInfoPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.serverInfoPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.serverInfoPanel.Size = new System.Drawing.Size(524, 72);
            this.serverInfoPanel.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 56);
            this.label1.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Windows Authentication:";
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(158, 55);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(20, 3, 3, 3);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.CheckBox1_CheckedChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 36);
            this.label2.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Initial Catalog:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 10);
            this.label3.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Data source:";
            // 
            // datasource_textBox
            // 
            this.datasource_textBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.datasource_textBox.Location = new System.Drawing.Point(148, 3);
            this.datasource_textBox.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.datasource_textBox.Name = "datasource_textBox";
            this.datasource_textBox.Size = new System.Drawing.Size(250, 20);
            this.datasource_textBox.TabIndex = 4;
            // 
            // initialcatalog_textBox
            // 
            this.initialcatalog_textBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.initialcatalog_textBox.Location = new System.Drawing.Point(148, 29);
            this.initialcatalog_textBox.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.initialcatalog_textBox.Name = "initialcatalog_textBox";
            this.initialcatalog_textBox.Size = new System.Drawing.Size(250, 20);
            this.initialcatalog_textBox.TabIndex = 4;
            // 
            // userPasswordPanel
            // 
            this.userPasswordPanel.AutoSize = true;
            this.userPasswordPanel.ColumnCount = 2;
            this.userPasswordPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.userPasswordPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.userPasswordPanel.Controls.Add(this.label4, 0, 0);
            this.userPasswordPanel.Controls.Add(this.label5, 0, 1);
            this.userPasswordPanel.Controls.Add(this.userid_textBox, 1, 0);
            this.userPasswordPanel.Controls.Add(this.password_textBox, 1, 1);
            this.userPasswordPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userPasswordPanel.Enabled = false;
            this.userPasswordPanel.Location = new System.Drawing.Point(20, 81);
            this.userPasswordPanel.Margin = new System.Windows.Forms.Padding(20, 3, 3, 3);
            this.userPasswordPanel.Name = "userPasswordPanel";
            this.userPasswordPanel.RowCount = 2;
            this.userPasswordPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.userPasswordPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.userPasswordPanel.Size = new System.Drawing.Size(507, 52);
            this.userPasswordPanel.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 10);
            this.label4.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "User id:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 29);
            this.label5.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Password:";
            // 
            // userid_textBox
            // 
            this.userid_textBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.userid_textBox.Location = new System.Drawing.Point(79, 3);
            this.userid_textBox.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.userid_textBox.Name = "userid_textBox";
            this.userid_textBox.Size = new System.Drawing.Size(250, 20);
            this.userid_textBox.TabIndex = 4;
            // 
            // password_textBox
            // 
            this.password_textBox.Location = new System.Drawing.Point(79, 29);
            this.password_textBox.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.password_textBox.Name = "password_textBox";
            this.password_textBox.Size = new System.Drawing.Size(250, 20);
            this.password_textBox.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.cancel_button);
            this.panel1.Controls.Add(this.save_button);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 139);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(524, 237);
            this.panel1.TabIndex = 2;
            // 
            // cancel_button
            // 
            this.cancel_button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel_button.Location = new System.Drawing.Point(323, 3);
            this.cancel_button.Name = "cancel_button";
            this.cancel_button.Size = new System.Drawing.Size(75, 23);
            this.cancel_button.TabIndex = 1;
            this.cancel_button.Text = "Отмена";
            this.cancel_button.UseVisualStyleBackColor = true;
            // 
            // save_button
            // 
            this.save_button.Location = new System.Drawing.Point(242, 3);
            this.save_button.Name = "save_button";
            this.save_button.Size = new System.Drawing.Size(75, 23);
            this.save_button.TabIndex = 0;
            this.save_button.Text = "Сохранить";
            this.save_button.UseVisualStyleBackColor = true;
            this.save_button.Click += new System.EventHandler(this.Save_button_Click);
            // 
            // ConnectionDialog
            // 
            this.AcceptButton = this.save_button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = this.cancel_button;
            this.ClientSize = new System.Drawing.Size(530, 379);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConnectionDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ConnectionDialog";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.serverInfoPanel.ResumeLayout(false);
            this.serverInfoPanel.PerformLayout();
            this.userPasswordPanel.ResumeLayout(false);
            this.userPasswordPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel serverInfoPanel;
        private System.Windows.Forms.TableLayoutPanel userPasswordPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox datasource_textBox;
        private System.Windows.Forms.TextBox initialcatalog_textBox;
        private System.Windows.Forms.TextBox userid_textBox;
        private System.Windows.Forms.TextBox password_textBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button cancel_button;
        private System.Windows.Forms.Button save_button;
    }
}