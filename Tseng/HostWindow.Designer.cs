﻿namespace Tseng
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
            this.BlazorView = new Microsoft.AspNetCore.Components.WebView.WindowsForms.BlazorWebView();
            this.SuspendLayout();
            // 
            // BlazorView
            // 
            this.BlazorView.BackColor = System.Drawing.Color.Black;
            this.BlazorView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BlazorView.Location = new System.Drawing.Point(0, 0);
            this.BlazorView.Name = "BlazorView";
            this.BlazorView.Size = new System.Drawing.Size(890, 535);
            this.BlazorView.TabIndex = 0;
            this.BlazorView.Text = "blazorWebView1";
            // 
            // HostWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(890, 535);
            this.Controls.Add(this.BlazorView);
            this.Name = "HostWindow";
            this.Text = "Tseng";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.AspNetCore.Components.WebView.WindowsForms.BlazorWebView BlazorView;
    }
}