using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using ViewModel.Global;

namespace DBSync.UC
{
    
    public partial class OutputWindowEditor : UserControl
    {
        enum Direction
        {
            All, Next, Previous
        }
        static class SearchDirection
        {
            public static Direction Type { get; set; }

        }

      
        public void SetUPOutput(RichTextBox RTBUPOutput, bool addNewLine = true) {

            RTBUPOutput.SuspendLayout();
            RTBUPOutput.SelectionColor = OutputProperties.ForeColor; 
            RTBUPOutput.AppendText(addNewLine
                ? $"{OutputProperties.Text}{Environment.NewLine}"
                : OutputProperties.Text);
            RTBUPOutput.ScrollToCaret();
            RTBUPOutput.ResumeLayout();


            tbUPSearch.Enabled = !String.IsNullOrEmpty(RTBUPOutput.Text.Trim());
            if (String.IsNullOrEmpty(RTBUPOutput.Text.Trim()))
                tbUPSearch.Text = string.Empty;
            toolStripDropDownUPSearchDirection.Enabled = !String.IsNullOrEmpty(RTBUPOutput.Text.Trim());


            //RTBUPOutput.DeselectAll();
            //int index = RTBUPOutput.TextLength;
            //RTBUPOutput.Select(RTBUPOutput.TextLength, 1);
            //RTBUPOutput.SelectionBackColor = OutputProperties.BackColor;
            //RTBUPOutput.SelectionColor = OutputProperties.ForeColor;

            //if (index == 0)
            //    RTBUPOutput.Text = OutputProperties.Text;
            //else
            //    RTBUPOutput.Text = RTBUPOutput.Text + Environment.NewLine + OutputProperties.Text + " ";

            //RTBUPOutput.Select(index + 1, RTBUPOutput.TextLength);
            //RTBUPOutput.SelectionBackColor = OutputProperties.BackColor;
            //RTBUPOutput.SelectionColor = OutputProperties.ForeColor;


            //RTBUPOutput.DeselectAll();
            //RTBUPOutput.Select(RTBUPOutput.TextLength-1, 1);
            //RTBUPOutput.SelectionColor = Color.Black;
        }

        public void SetDOWNOutput(RichTextBox RTBDownOutput, bool addNewLine = true)
        {
            RTBDownOutput.SuspendLayout();
            RTBDownOutput.SelectionColor = OutputProperties.ForeColor;
            RTBDownOutput.AppendText(addNewLine
                ? $"{OutputProperties.Text}{Environment.NewLine}"
                : OutputProperties.Text);
            RTBDownOutput.ScrollToCaret();
            RTBDownOutput.ResumeLayout();

            tbDOWNSearch.Enabled = !String.IsNullOrEmpty(RTBDownOutput.Text.Trim());
            if (String.IsNullOrEmpty(RTBDownOutput.Text.Trim()))
                tbDOWNSearch.Text = string.Empty;
            toolStripDropDownDownSearchDirection.Enabled = !String.IsNullOrEmpty(RTBDownOutput.Text.Trim());
        }
        public RichTextBox UpOutput { get => RTBUPOutput; set => RTBUPOutput = value; }
        public RichTextBox DownOutput { get => RTBDOWNOutput; set => RTBDOWNOutput = value; }
        public OutputWindowEditor()
        {
            InitializeComponent();
            TSCBOption.SelectedIndex = 0;
            TSCBUpOutputOption.SelectedIndex = 0;
            TSCBDownOutputOption.SelectedIndex = 0;

            toolStripDropDownUPSearchDirection.Image = UPfindAllToolStripMenuItem.Image;
            toolStripDropDownDownSearchDirection.Image = DOWNfindAllToolStripMenuItem.Image;

            SearchDirection.Type = Direction.All;

            tbUPSearch.Enabled = !String.IsNullOrEmpty(RTBUPOutput.Text);
            tbDOWNSearch.Enabled = !String.IsNullOrEmpty(RTBDOWNOutput.Text);

            toolStripDropDownUPSearchDirection.Enabled = !String.IsNullOrEmpty(RTBUPOutput.Text);
            toolStripDropDownDownSearchDirection.Enabled = !String.IsNullOrEmpty(RTBDOWNOutput.Text);
        }

     
        private void TSCBOption_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (TSCBOption.Text == "Both Pannel")
            {
                SCPannel.Panel1Collapsed = false;
                SCPannel.Panel2Collapsed = false;
            }
            else if (TSCBOption.Text == "Upload Pannel")
            {
                SCPannel.Panel1Collapsed = false;
                SCPannel.Panel2Collapsed = true;
            }
            else if (TSCBOption.Text == "Download Pannel")
            {
                SCPannel.Panel1Collapsed = true;
                SCPannel.Panel2Collapsed = false;
            }
        }

        int start = 0;
        int indexOfSearchText = 0;


        public void FindAll(ref RichTextBox txtToSearch, string searchStart)
        {
            //Select all text and bring it back to default color values so you
            //can make a new search selection

            txtToSearch.SelectAll();
            //txtToSearch.SelectionColor = Color.Black;

            //Deselect all text to ready selections

            txtToSearch.DeselectAll();



            MatchCollection matches = Regex.Matches(txtToSearch.Text, searchStart);
            if (matches.Count == 0)
            {
                MessageBox.Show("The following specified text was not found:" + Environment.NewLine + searchStart);
            }
            else
            {
                //Apply color to all matching text
                int lastSearchIndex = 0;
                foreach (Match match in matches)
                {
                    txtToSearch.Select(match.Index, match.Length);
                    //richTextBox1.SelectionColor = System.Drawing.Color.Red;
                    txtToSearch.SelectionBackColor = Color.Yellow;
                    lastSearchIndex = match.Length;
                }

                txtToSearch.Select(txtToSearch.TextLength, 0);
                txtToSearch.SelectionBackColor = Color.White;
            }
        }

        static int FwdIndex = 0;
        static int BckIndex = 0;

        

        public void FindForword(ref RichTextBox txtToSearch, string searchStart)
        {
            //Select all text and bring it back to default color values so you
            //can make a new search selection

            txtToSearch.SelectAll();
            //txtToSearch.SelectionColor = Color.Black;

            //Deselect all text to ready selections

            txtToSearch.DeselectAll();

            ClearUpSelection();

            MatchCollection matches = Regex.Matches(txtToSearch.Text, searchStart);

            //Apply color to all matching text
            //int lastSearchIndex = 0;
            if (matches.Count == 0)
            {
                MessageBox.Show("The following specified text was not found:" + Environment.NewLine + searchStart);
            }
            else
            {

                Match match = matches[FwdIndex];
                txtToSearch.Select(match.Index, match.Length);



                txtToSearch.SelectionBackColor = Color.Yellow;
                //lastSearchIndex = match.Length;
                BckIndex = FwdIndex - 1;
                FwdIndex++;
                if (FwdIndex >= matches.Count)
                    FwdIndex = 0;


                txtToSearch.Select(match.Index + match.Length, 0);
                txtToSearch.SelectionBackColor = Color.White;
            }
        }

        public void FindBackword(ref RichTextBox txtToSearch, string searchStart)
        {
            //Select all text and bring it back to default color values so you
            //can make a new search selection


            txtToSearch.SelectAll();
            //txtToSearch.SelectionColor = Color.Black;

            //Deselect all text to ready selections

            txtToSearch.DeselectAll();

            ClearUpSelection();

            MatchCollection matches = Regex.Matches(txtToSearch.Text, searchStart);

            //Apply color to all matching text
            //int lastSearchIndex = 0;
            if (matches.Count == 0)
            {
                MessageBox.Show("The following specified text was not found:" + Environment.NewLine + searchStart);
            }
            else
            {
                if (FwdIndex <= 0 || BckIndex < 0)
                {
                    BckIndex = (matches.Count - 1);
                    FwdIndex = BckIndex + 1;
                }
                //else
                //{
                //    BckIndex = FwdIndex;
                //}

                Match match = matches[BckIndex];
                txtToSearch.Select(match.Index, match.Length);

                txtToSearch.SelectionBackColor = Color.Yellow;
                //lastSearchIndex = match.Length;
                FwdIndex = BckIndex + 1;

                BckIndex--;




                txtToSearch.Select(match.Index + match.Length, 0);
                txtToSearch.SelectionBackColor = Color.White;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ClearUpSelection();
            BckIndex = 0;
            FwdIndex = 0;
        }

        public void ClearUpSelection()
        {
            start = 0;
            indexOfSearchText = 0;
            string temp = RTBUPOutput.Text;
            RTBUPOutput.Text = string.Empty;
            RTBUPOutput.Text = temp;
            RTBUPOutput.SelectionBackColor = Color.White;

            //BckIndex = 0;
            //FwdIndex = 0;
        }
        public void ClearDownSelection()
        {
            start = 0;
            indexOfSearchText = 0;
            string temp = RTBDOWNOutput.Text;
            RTBDOWNOutput.Text = string.Empty;
            RTBDOWNOutput.Text = temp;
            RTBDOWNOutput.SelectionBackColor = Color.White;

            //BckIndex = 0;
            //FwdIndex = 0;
        }
        private void findAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchDirection.Type = 0;
            toolStripDropDownUPSearchDirection.Image = UPfindAllToolStripMenuItem.Image;
        }

        private void findNextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchDirection.Type = Direction.Next;
            toolStripDropDownUPSearchDirection.Image = UPfindNextToolStripMenuItem.Image;
        }

        private void findPreviousToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchDirection.Type = Direction.Previous;
            toolStripDropDownUPSearchDirection.Image = UPfindPreviousToolStripMenuItem.Image;
        }

        private void tbUPSearch_KeyDown(object sender, KeyEventArgs e)
        {
            //RTBUPOutput.SuspendLayout();
            if (e.KeyCode == Keys.Enter)
            {
               
                if (SearchDirection.Type == Direction.All)
                {
                    if (tbUPSearch.Text.Trim() != "")
                        FindAll(ref RTBUPOutput, tbUPSearch.Text);
                }
                if (SearchDirection.Type == Direction.Previous)
                {
                    if (tbUPSearch.Text.Trim() != "")
                        FindBackword(ref RTBUPOutput, tbUPSearch.Text);
                }
                if (SearchDirection.Type == Direction.Next)
                {
                    if (tbUPSearch.Text.Trim() != "")
                        FindForword(ref RTBUPOutput, tbUPSearch.Text);
                }

            }
        }

        private void RTBUPOutput_KeyUp(object sender, KeyEventArgs e)
        {

            tbUPSearch.Enabled = !String.IsNullOrEmpty(RTBUPOutput.Text.Trim());
            if (String.IsNullOrEmpty(RTBUPOutput.Text.Trim()))
                tbUPSearch.Text = string.Empty;
            toolStripDropDownUPSearchDirection.Enabled = !String.IsNullOrEmpty(RTBUPOutput.Text.Trim());
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            RTBUPOutput.Text = string.Empty;
            tbUPSearch.Enabled = false;
            toolStripDropDownUPSearchDirection.Enabled = false;
            tbUPSearch.Text = string.Empty;
        }

        private void tbDOWNSearch_KeyDown(object sender, KeyEventArgs e)
        {
            //RTBUPOutput.SuspendLayout();
            if (e.KeyCode == Keys.Enter)
            {

                if (SearchDirection.Type == Direction.All)
                {
                    if (tbDOWNSearch.Text.Trim() != "")
                        FindAll(ref RTBDOWNOutput, tbDOWNSearch.Text);
                }
                if (SearchDirection.Type == Direction.Previous)
                {
                    if (tbDOWNSearch.Text.Trim() != "")
                        FindBackword(ref RTBDOWNOutput, tbDOWNSearch.Text);
                }
                if (SearchDirection.Type == Direction.Next)
                {
                    if (tbDOWNSearch.Text.Trim() != "")
                        FindForword(ref RTBDOWNOutput, tbDOWNSearch.Text);
                }

            }
        }

        private void tbDOWNSearch_TextChanged(object sender, EventArgs e)
        {
            ClearDownSelection();
            BckIndex = 0;
            FwdIndex = 0;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            RTBDOWNOutput.Text = string.Empty;
            tbDOWNSearch.Enabled = false;
            toolStripDropDownUPSearchDirection.Enabled = false;
            tbDOWNSearch.Text = string.Empty;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            SearchDirection.Type = 0;
            toolStripDropDownDownSearchDirection.Image = DOWNfindAllToolStripMenuItem.Image;
        }

        private void DOWNfindNextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchDirection.Type = Direction.Next;
            toolStripDropDownDownSearchDirection.Image = DOWNfindNextToolStripMenuItem.Image;
        }

        private void DOWNfindPreviousToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchDirection.Type = Direction.Previous;
            toolStripDropDownDownSearchDirection.Image = DOWNfindPreviousToolStripMenuItem.Image;
        }

        private void RTBDOWNOutput_KeyUp(object sender, KeyEventArgs e)
        {
            tbDOWNSearch.Enabled = !String.IsNullOrEmpty(RTBDOWNOutput.Text.Trim());
            if (String.IsNullOrEmpty(RTBDOWNOutput.Text.Trim()))
                tbDOWNSearch.Text = string.Empty;
            toolStripDropDownDownSearchDirection.Enabled = !String.IsNullOrEmpty(RTBDOWNOutput.Text.Trim());
        }
    }
}
