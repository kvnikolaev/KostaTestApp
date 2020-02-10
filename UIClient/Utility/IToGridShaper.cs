using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UIClient.Utility
{
    interface IToGridShaper //!!
    {
        void SetUpControlView<T>(T control);
    }
}
