using ServiceManager.ClientSideClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UIClient.Utility
{
    class EmployeeToGridShaper
    {
        #region Список столбцов таблицы
        DataGridViewTextBoxColumn SurNameColumn = new DataGridViewTextBoxColumn()
        {
            HeaderText = "Фамилия",
            Name = "SurNameColumn",
            ReadOnly = true
        };
        DataGridViewTextBoxColumn FirstNameColumn = new DataGridViewTextBoxColumn()
        {
            HeaderText = "Имя",
            Name = "FirstNameColumn",
            ReadOnly = true
        };
        DataGridViewTextBoxColumn PatronymicColumn = new DataGridViewTextBoxColumn()
        {
            HeaderText = "Отчество",
            Name = "PatronymicColumn",
            ReadOnly = true
        };
        DataGridViewTextBoxColumn PositionColumn = new DataGridViewTextBoxColumn()
        {
            HeaderText = "Должность",
            Name = "PositionColumn",
            ReadOnly = true
        };
        DataGridViewTextBoxColumn DateOfBirthColumn = new DataGridViewTextBoxColumn()
        {
            HeaderText = "Дата рождения",
            Name = "DateOfBirthColumn",
            ReadOnly = true
        };
        DataGridViewTextBoxColumn AgeColumn = new DataGridViewTextBoxColumn()
        {
            HeaderText = "Возраст",
            Name = "AgeColumn",
            ReadOnly = true
        };
        DataGridViewTextBoxColumn DocSeriesColumn = new DataGridViewTextBoxColumn()
        {
            HeaderText = "Серия документа",
            Name = "DocSeriesColumn",
            ReadOnly = true
        };
        DataGridViewTextBoxColumn DocNumberColumn = new DataGridViewTextBoxColumn()
        {
            HeaderText = "Номер документа",
            Name = "DocNumberColumn",
            ReadOnly = true
        };
        #endregion

        public void SetUpGrid(DataGridView grid)
        {
            grid.Columns.AddRange(new DataGridViewColumn[]
            {
                this.SurNameColumn,
                this.FirstNameColumn,
                this.PatronymicColumn,
                this.PositionColumn,
                this.DateOfBirthColumn,
                this.AgeColumn,
                this.DocSeriesColumn,
                this.DocNumberColumn
            });
        }

        public void SelectEmployeeToGrid(DataGridView grid, params EmployeeCS[] employees)
        {
            foreach(var emp in employees)
            {
                grid.Rows.Add(new string[] 
                {
                    emp.SurName?.ToString(),
                    emp.FirstName?.ToString(),
                    emp.Patronymic?.ToString(),
                    emp.Position?.ToString(),
                    emp.DateOfBirth.ToShortDateString(),
                    emp.Age.ToString(),
                    emp.DocSeries?.ToString(),
                    emp.DocNumber?.ToString()
                });
            }
        }
    }
}
