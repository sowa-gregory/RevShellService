using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RevShellService
{
    public partial class welcomeform : Form
    {
        public welcomeform()
        {
            InitializeComponent();
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClosing);
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.TopLevel = true;
            this.Opacity = 1D;
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(0)))), ((int)(((byte)(254)))));

        }
    }
}
