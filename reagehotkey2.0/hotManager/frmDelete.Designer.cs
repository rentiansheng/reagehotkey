﻿namespace hotManager
{
    partial class frmDelete
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timFrmChange = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // timFrmChange
            // 
            this.timFrmChange.Tick += new System.EventHandler(this.timFrmChange_Tick);
            // 
            // frmDelete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDelete";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSetKey";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDelete_FormClosing);
            this.Load += new System.EventHandler(this.frmDelete_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Timer timFrmChange;


    }
}