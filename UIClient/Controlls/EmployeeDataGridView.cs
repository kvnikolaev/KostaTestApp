using ServiceManager.ClientSideClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UIClient.Controlls
{
    public class EmployeeDataGridView : DataGridView
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

        public void SetUpGrid()
        {
            this.Columns.AddRange(new DataGridViewColumn[]
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

        public void SelectEmployeeToGrid(params EmployeeCS[] employees)
        {
            for (int i = 0; i < employees.Length; i++)
            {
                this.Rows.Add(new string[]
                {
                    employees[i].SurName?.ToString(),
                    employees[i].FirstName?.ToString(),
                    employees[i].Patronymic?.ToString(),
                    employees[i].Position?.ToString(),
                    employees[i].DateOfBirth?.ToShortDateString(),
                    employees[i].Age.ToString(),
                    employees[i].DocSeries?.ToString(),
                    employees[i].DocNumber?.ToString()
                });
                this.Rows[i].Tag = employees[i];
            }
        }

        public void TrySelectRows(DataGridViewSelectedRowCollection rows)
        {

        }
    }
}
