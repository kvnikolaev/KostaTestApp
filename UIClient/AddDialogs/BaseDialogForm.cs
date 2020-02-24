using ServiceManager.ClientSideClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UIClient.AddDialogs
{
    // Пришлось сделать класс не абстрактным чисто потому, 
    // что визуальный дизайнер не умеет рисовать формы на основе абстрактных классов
    public /*abstract*/ class BaseDialogForm: Form
    {
        public virtual DepartmentCS[] DepartmentList { get; set; }
        public virtual EmployeeCS RepresentedEmployee { get; set; }
    }
}
