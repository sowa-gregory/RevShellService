using System.Windows.Forms;

namespace RevShellService
{
    partial class welcomeform
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

      

        private void OnClosing(object sender, FormClosingEventArgs e)
        {
            // prevent closing application by hitting alt-f4
            // after user enters activation sequence -> allows to close application,
            // otherwise prevents it
            e.Cancel = true;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x80;
                return cp;
            }
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // welcomeform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::RevShellService.Properties.Resources.teamredsmall;
            this.ClientSize = new System.Drawing.Size(198, 191);
            this.Name = "welcomeform";
            this.Text = "welcomeform";
            this.ResumeLayout(false);

        }

        #endregion
    }
}