using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Interfaces;

namespace ViewModel.Global
{
    public static class OutputProperties 
    {
        static string _Text = string.Empty;
        static Color _ForeColor = Color.Empty;
        static Color _BackColor = Color.Empty;
        //OutputWindow _OutputWindow
        public static string Text { get => _Text; set => _Text = value; }
        public static Color ForeColor { get => _ForeColor; set => _ForeColor = value; }
        public static Color BackColor { get => _BackColor; set => _BackColor = value; }
    }
}
