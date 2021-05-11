using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Interfaces
{
    public interface IOutputProperties
    {
        string Text { get; set; }
        Color ForeColor { get; set; }
        Color BackColor { get; set; }
    }
}
