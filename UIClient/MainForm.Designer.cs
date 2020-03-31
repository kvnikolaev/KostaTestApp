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
            this.components = new System.ComponentModel.Container();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.DepartmentStructureTreeView = new Controlls.DepartmentTreeView();
            this.EmployeeDataGridView = new Controlls.EmployeeDataGridView();
            this.employeeView_contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.departmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.employeeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripDropDownButton();
            this.editDepartment_toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.editEmployee_toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripDropDownButton();
            this.deleteDepartmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteEmployeeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.departmentView_contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.редактироватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EmployeeDataGridView)).BeginInit();
            this.employeeView_contextMenuStrip.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.departmentView_contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer.Location = new System.Drawing.Point(0, 27);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.DepartmentStructureTreeView);
            this.splitContainer.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.EmployeeDataGridView);
            this.splitContainer.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer.Size = new System.Drawing.Size(728, 423);
            this.splitContainer.SplitterDistance = 231;
            this.splitContainer.TabIndex = 0;
            // 
            // DepartmentStructureTreeView
            // 
            this.DepartmentStructureTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DepartmentStructureTreeView.Location = new System.Drawing.Point(0, 0);
            this.DepartmentStructureTreeView.Name = "DepartmentStructureTreeView";
            this.DepartmentStructureTreeView.Size = new System.Drawing.Size(231, 423);
            this.DepartmentStructureTreeView.TabIndex = 0;
            this.DepartmentStructureTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.StructureTreeView_AfterSelect);
            this.DepartmentStructureTreeView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DepartmentStructureTreeView_MouseDown);
            // 
            // EmployeeDataGridView
            // 
            this.EmployeeDataGridView.AllowUserToDeleteRows = false;
            this.EmployeeDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.EmployeeDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.EmployeeDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EmployeeDataGridView.Location = new System.Drawing.Point(0, 0);
            this.EmployeeDataGridView.Name = "EmployeeDataGridView";
            this.EmployeeDataGridView.RowHeadersVisible = false;
            this.EmployeeDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.EmployeeDataGridView.Size = new System.Drawing.Size(493, 423);
            this.EmployeeDataGridView.TabIndex = 0;
            this.EmployeeDataGridView.DoubleClick += new System.EventHandler(this.EmployeeDataGridView_DoubleClick);
            this.EmployeeDataGridView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.EmployeeDataGridView_MouseDown);
            // 
            // employeeView_contextMenuStrip
            // 
            this.employeeView_contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3,
            this.toolStripMenuItem2});
            this.employeeView_contextMenuStrip.Name = "contextMenuStrip1";
            this.employeeView_contextMenuStrip.Size = new System.Drawing.Size(155, 48);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(154, 22);
            this.toolStripMenuItem3.Text = "Редактировать";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.ContextMenu_EmployeeEditItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(154, 22);
            this.toolStripMenuItem2.Text = "Удалить";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.ContextMenu_EmployeeDeleteItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ContextMenuStrip = this.employeeView_contextMenuStrip;
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.reloadStripMenuItem5});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(728, 27);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.departmentToolStripMenuItem,
            this.employeeToolStripMenuItem});
            this.toolStripMenuItem1.Image = global::UIClient.Properties.Resources.add;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(29, 20);
            this.toolStripMenuItem1.Text = "toolStripMenuItem1";
            // 
            // departmentToolStripMenuItem
            // 
            this.departmentToolStripMenuItem.Name = "departmentToolStripMenuItem";
            this.departmentToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.departmentToolStripMenuItem.Text = "Добавить подразделение";
            this.departmentToolStripMenuItem.Click += new System.EventHandler(this.DepartmentToolStripMenuItem_Click);
            // 
            // employeeToolStripMenuItem
            // 
            this.employeeToolStripMenuItem.Name = "employeeToolStripMenuItem";
            this.employeeToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.employeeToolStripMenuItem.Text = "Добавить сотрудника";
            this.employeeToolStripMenuItem.Click += new System.EventHandler(this.EmployeeToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editDepartment_toolStripMenuItem1,
            this.editEmployee_toolStripMenuItem2});
            this.editToolStripMenuItem.Image = global::UIClient.Properties.Resources.pencil3;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(29, 20);
            this.editToolStripMenuItem.Text = "edit";
            this.editToolStripMenuItem.DropDownOpened += new System.EventHandler(this.MenuTray_EditMenuItem_DropDownOpened);
            // 
            // editDepartment_toolStripMenuItem1
            // 
            this.editDepartment_toolStripMenuItem1.Name = "editDepartment_toolStripMenuItem1";
            this.editDepartment_toolStripMenuItem1.Size = new System.Drawing.Size(240, 22);
            this.editDepartment_toolStripMenuItem1.Text = "Редактировать подразделение";
            this.editDepartment_toolStripMenuItem1.Click += new System.EventHandler(this.MenuTray_EditDepartment_Click);
            // 
            // editEmployee_toolStripMenuItem2
            // 
            this.editEmployee_toolStripMenuItem2.Name = "editEmployee_toolStripMenuItem2";
            this.editEmployee_toolStripMenuItem2.Size = new System.Drawing.Size(240, 22);
            this.editEmployee_toolStripMenuItem2.Text = "Редактировать сотрудника";
            this.editEmployee_toolStripMenuItem2.Click += new System.EventHandler(this.MenuTray_EditEmployee_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteDepartmentToolStripMenuItem,
            this.deleteEmployeeToolStripMenuItem});
            this.deleteToolStripMenuItem.Image = global::UIClient.Properties.Resources.delete;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(29, 20);
            this.deleteToolStripMenuItem.Text = "delete";
            this.deleteToolStripMenuItem.DropDownOpened += new System.EventHandler(this.MenuTray_DeleteMenuItem_DropDownOpened);
            // 
            // deleteDepartmentToolStripMenuItem
            // 
            this.deleteDepartmentToolStripMenuItem.Name = "deleteDepartmentToolStripMenuItem";
            this.deleteDepartmentToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.deleteDepartmentToolStripMenuItem.Text = "Удалить подразделение";
            this.deleteDepartmentToolStripMenuItem.Click += new System.EventHandler(this.MenuTray_DeleteDepartment_Click);
            // 
            // deleteEmployeeToolStripMenuItem
            // 
            this.deleteEmployeeToolStripMenuItem.Name = "deleteEmployeeToolStripMenuItem";
            this.deleteEmployeeToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.deleteEmployeeToolStripMenuItem.Text = "Удалить сотрудника";
            this.deleteEmployeeToolStripMenuItem.Click += new System.EventHandler(this.MenuTray_DeleteEmployee_Click);
            // 
            // reloadStripMenuItem5
            // 
            this.reloadStripMenuItem5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.reloadStripMenuItem5.Image = global::UIClient.Properties.Resources.refresh;
            this.reloadStripMenuItem5.Name = "reloadStripMenuItem5";
            this.reloadStripMenuItem5.Size = new System.Drawing.Size(28, 23);
            this.reloadStripMenuItem5.Text = "Обновить";
            this.reloadStripMenuItem5.Click += new System.EventHandler(this.MenuTray_Reload_Click);
            // 
            // departmentView_contextMenuStrip
            // 
            this.departmentView_contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.редактироватьToolStripMenuItem,
            this.toolStripMenuItem4});
            this.departmentView_contextMenuStrip.Name = "departmentView_contextMenuStrip";
            this.departmentView_contextMenuStrip.Size = new System.Drawing.Size(155, 48);
            // 
            // редактироватьToolStripMenuItem
            // 
            this.редактироватьToolStripMenuItem.Name = "редактироватьToolStripMenuItem";
            this.редактироватьToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.редактироватьToolStripMenuItem.Text = "Редактировать";
            this.редактироватьToolStripMenuItem.Click += new System.EventHandler(this.ContextMenu_DepartmentEditItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(154, 22);
            this.toolStripMenuItem4.Text = "Удалить";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.ContextMenu_DepartmentDeleteItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(728, 450);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.EmployeeDataGridView)).EndInit();
            this.employeeView_contextMenuStrip.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.departmentView_contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        public Controlls.DepartmentTreeView DepartmentStructureTreeView;
        public Controlls.EmployeeDataGridView EmployeeDataGridView;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem departmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem employeeToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip employeeView_contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripDropDownButton editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editDepartment_toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem editEmployee_toolStripMenuItem2;
        private System.Windows.Forms.ContextMenuStrip departmentView_contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem редактироватьToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteDepartmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteEmployeeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem reloadStripMenuItem5;
    }
}

