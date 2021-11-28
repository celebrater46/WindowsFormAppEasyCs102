using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppEasyCs102
{
    public partial class Form1 : Form
    {
        private TextBox tb;
        private Button bt1, bt2;
        private FlowLayoutPanel flp;
        
        // [STAThread]
        
        public Form1()
        {
            InitializeComponent();
            this.Text = "Text Editor";
            tb = new TextBox();
            tb.Multiline = true;
            tb.Width = this.Width;
            tb.Height = this.Height - 100;
            tb.Dock = DockStyle.Top;

            bt1 = new Button();
            bt2 = new Button();
            bt1.Text = "Open";
            bt2.Text = "Save";

            flp = new FlowLayoutPanel();
            flp.Dock = DockStyle.Bottom;

            bt1.Parent = flp;
            bt2.Parent = flp;
            flp.Parent = this;
            tb.Parent = this;

            bt1.Click += new EventHandler(BtClick);
            bt2.Click += new EventHandler(BtClick);
        }

        public void BtClick(Object sender, EventArgs e)
        {
            if (sender == bt1)
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Text File | *.txt";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    // StreamReader sr = new StreamReader(ofd.FileName, System.Text.Encoding.Default);
                    StreamReader sr = new StreamReader(ofd.FileName, System.Text.Encoding.UTF8);
                    tb.Text = sr.ReadToEnd();
                    sr.Close();
                }
            }
            else if (sender == bt2)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Text File | *.txt";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter sw = new StreamWriter(sfd.FileName);
                    sw.WriteLine(tb.Text);
                    sw.Close();
                }
            }
        }
    }
}