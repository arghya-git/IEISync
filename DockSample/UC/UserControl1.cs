using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace DBSync.UC
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
            if (Nodes == null)
            {
                //Nodes = new Items(panel1.Width, 26);
                Nodes = new Items();
                //TreeNode mainNode = new TreeNode();
                //mainNode.Name = "mainNode";
                //mainNode.Text = "aaaa";



                //TreeNode chiledNode1 = new TreeNode();
                //mainNode.Name = "chiledNode";
                //mainNode.Text = "bbbb";



                //TreeNode chiledNode2 = new TreeNode();
                //mainNode.Name = "chiledNode";
                //mainNode.Text = "cccc";

                //Nodes.Nodes.Add(chiledNode1);
                //Nodes.Nodes.Add(chiledNode2);
                //Nodes.Nodes.Add(mainNode);
                this.Controls.Add(Nodes);
            }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Items Nodes { get; set; }
        [Serializable]
        public class Items : TreeView
        {
            private Rectangle buttonRect = new Rectangle(80, 2, 50, 25);
            private Rectangle buttonRect2 = new Rectangle(140, 2, 50, 25);
            private StringFormat stringFormat;

            public Items()
            {
                SetStyle(ControlStyles.AllPaintingInWmPaint, true);

                DrawMode = TreeViewDrawMode.OwnerDrawText;

                //if (Node.Parent != null)
                //{
                    ShowLines = false;
                    FullRowSelect = true;
                    ItemHeight = 30;
                //}

                Dock = DockStyle.Fill;
                stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Near;
                stringFormat.LineAlignment = StringAlignment.Near;
            }
            //public Items(int width, int Height)
            //{
            //    Width = width;
            //    //buttonRect.Height = Height;

            //    SetStyle(ControlStyles.AllPaintingInWmPaint, true);

            //    DrawMode = TreeViewDrawMode.OwnerDrawText;
            //    ShowLines = false;
            //    FullRowSelect = true;


            //    Dock = DockStyle.Fill;
            //    stringFormat = new StringFormat();
            //    stringFormat.Alignment = StringAlignment.Near;
            //    stringFormat.LineAlignment = StringAlignment.Center;
            //}
            protected override void OnDrawNode(DrawTreeNodeEventArgs e)
            {
                e.Graphics.DrawString(e.Node.Text, this.Font, new SolidBrush(this.ForeColor), e.Bounds.X, e.Bounds.Y + ((ItemHeight - this.Font.Height) / 2) );
                //e.Graphics.DrawString(e.Node.Text, this.Font, new SolidBrush(this.ForeColor), e.Bounds.X, e.Bounds.Y + ((ItemHeight - this.Font.Height )/ 2)  );
                if (e.Node.Parent != null)
                {
                    ButtonRenderer.DrawButton(e.Graphics, new Rectangle(e.Node.Bounds.Location + new Size(buttonRect.Location), buttonRect.Size), "btn", this.Font, true, (e.Node.Tag != null) ? (PushButtonState)e.Node.Tag : PushButtonState.Default);
                    ButtonRenderer.DrawButton(e.Graphics, new Rectangle(e.Node.Bounds.Location + new Size(buttonRect2.Location), buttonRect2.Size), "btn", this.Font, true, (e.Node.Tag != null) ? (PushButtonState)e.Node.Tag : PushButtonState.Default);
                }
            }

            protected override void OnNodeMouseClick(TreeNodeMouseClickEventArgs e)
            {
                if (e.Node.Tag != null && (PushButtonState)e.Node.Tag == PushButtonState.Pressed && e.Node.Parent != null)
                {
                    e.Node.Tag = PushButtonState.Normal;
                    MessageBox.Show(e.Node.Text + " clicked");
                    // force redraw
                    e.Node.Text = e.Node.Text;
                }
            }
            protected override void OnMouseDown(MouseEventArgs e)
            {
                TreeNode tnode = GetNodeAt(e.Location);
                if (tnode == null) return;

                Rectangle btnRectAbsolute = new Rectangle(tnode.Bounds.Location + new Size(buttonRect.Location), buttonRect.Size);
                if (btnRectAbsolute.Contains(e.Location))
                {
                    tnode.Tag = PushButtonState.Pressed;
                    tnode.Text = tnode.Text;
                }
            }
        }
    }
}
