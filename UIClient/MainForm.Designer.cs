namespace UIClient
{
    partial class MainForm
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
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.structureTreeView = new System.Windows.Forms.TreeView();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.SurNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirstNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PatronymicColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PositionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateOfBirthColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AgeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DocSeriesColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DocNumberColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.structureTreeView);
            this.splitContainer.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.dataGridView);
            this.splitContainer.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer.Size = new System.Drawing.Size(800, 450);
            this.splitContainer.SplitterDistance = 231;
            this.splitContainer.TabIndex = 0;
            // 
            // structureTreeView
            // 
            this.structureTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.structureTreeView.Location = new System.Drawing.Point(0, 0);
            this.structureTreeView.Name = "structureTreeView";
            this.structureTreeView.Size = new System.Drawing.Size(231, 450);
            this.structureTreeView.TabIndex = 0;
            this.structureTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.StructureTreeView_AfterSelect);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SurNameColumn,
            this.FirstNameColumn,
            this.PatronymicColumn,
            this.PositionColumn,
            this.DateOfBirthColumn,
            this.AgeColumn,
            this.DocSeriesColumn,
            this.DocNumberColumn});
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 0);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(565, 450);
            this.dataGridView.TabIndex = 0;
            // 
            // SurNameColumn
            // 
            this.SurNameColumn.HeaderText = "Фамилия";
            this.SurNameColumn.Name = "SurNameColumn";
            this.SurNameColumn.ReadOnly = true;
            // 
            // FirstNameColumn
            // 
            this.FirstNameColumn.HeaderText = "Имя";
            this.FirstNameColumn.Name = "FirstNameColumn";
            this.FirstNameColumn.ReadOnly = true;
            // 
            // PatronymicColumn
            // 
            this.PatronymicColumn.HeaderText = "Отчество";
            this.PatronymicColumn.Name = "PatronymicColumn";
            this.PatronymicColumn.ReadOnly = true;
            // 
            // PositionColumn
            // 
            this.PositionColumn.HeaderText = "Должность";
            this.PositionColumn.Name = "PositionColumn";
            this.PositionColumn.ReadOnly = true;
            // 
            // DateOfBirthColumn
            // 
            this.DateOfBirthColumn.HeaderText = "Дата рождения";
            this.DateOfBirthColumn.Name = "DateOfBirthColumn";
            this.DateOfBirthColumn.ReadOnly = true;
            // 
            // AgeColumn
            // 
            this.AgeColumn.HeaderText = "Возраст";
            this.AgeColumn.Name = "AgeColumn";
            this.AgeColumn.ReadOnly = true;
            // 
            // DocSeriesColumn
            // 
            this.DocSeriesColumn.HeaderText = "Серия документа";
            this.DocSeriesColumn.Name = "DocSeriesColumn";
            this.DocSeriesColumn.ReadOnly = true;
            // 
            // DocNumberColumn
            // 
            this.DocNumberColumn.HeaderText = "Номер документа";
            this.DocNumberColumn.Name = "DocNumberColumn";
            this.DocNumberColumn.ReadOnly = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.TreeView structureTreeView;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn SurNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PatronymicColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PositionColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateOfBirthColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn AgeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DocSeriesColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DocNumberColumn;
    }
}

