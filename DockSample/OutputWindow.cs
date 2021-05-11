using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace DBSync
{
    public partial class OutputWindow : DockContent
    {
        public OutputWindow()
        {
            InitializeComponent();
        }
        //public event EventHandler Clicked;

        //public override string ToString()
        //{
        //    return "Hello Foo";
        //}

        public void SetUPOutput(bool addNewLine = true)
        {
            outputWindowEditor.SetUPOutput(outputWindowEditor.UpOutput, addNewLine);
            //InvokeClicked(EventArgs.Empty);
        }
        public void SetDOWNOutput(bool addNewLine = true)
        {
            outputWindowEditor.SetDOWNOutput(outputWindowEditor.DownOutput, addNewLine);
            //InvokeClicked(EventArgs.Empty);
        }
        //private void InvokeClicked(EventArgs e)
        //{
        //    outputWindowEditor.SetUPOutput();
        //    var handler = Clicked;
        //    if (handler != null)
        //        handler(this, e);
        //}
        //private void timer1_Tick(object sender, EventArgs e)
        //{
        //    outputWindowEditor.SetUPOutput();
        //}
    }
}
