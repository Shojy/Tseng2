namespace Tseng
{
    partial class HostWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HostWindow));
            this.BlazorView = new Microsoft.AspNetCore.Components.WebView.WindowsForms.BlazorWebView();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BlazorView
            // 
            this.BlazorView.BackColor = System.Drawing.Color.Black;
            this.BlazorView.Dock = System.Windows.Forms.DockStyle.Left;
            this.BlazorView.Location = new System.Drawing.Point(0, 0);
            this.BlazorView.Name = "BlazorView";
            this.BlazorView.Size = new System.Drawing.Size(890, 750);
            this.BlazorView.TabIndex = 0;
            this.BlazorView.Text = "blazorWebView1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1152, 140);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 34);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // HostWindow
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(1622, 750);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.BlazorView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(615, 300);
            this.Name = "HostWindow";
            this.Text = "Tseng";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(8)))), ((int)(((byte)(0)))));
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.AspNetCore.Components.WebView.WindowsForms.BlazorWebView BlazorView;
        private Button button1;
    }
}