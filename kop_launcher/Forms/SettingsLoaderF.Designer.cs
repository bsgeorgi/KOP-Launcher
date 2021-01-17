using System.ComponentModel;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace kop_launcher
{
    partial class SettingsLoaderF
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsLoaderF));
            this.thisPanel = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.progressbar = new Guna.UI2.WinForms.Guna2ProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.thisPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // thisPanel
            // 
            this.thisPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(71)))), ((int)(((byte)(95)))));
            this.thisPanel.Controls.Add(this.label3);
            this.thisPanel.Controls.Add(this.guna2Button1);
            this.thisPanel.Controls.Add(this.label2);
            this.thisPanel.Controls.Add(this.label1);
            this.thisPanel.Controls.Add(this.progressbar);
            this.thisPanel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(24)))), ((int)(((byte)(37)))));
            this.thisPanel.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(13)))), ((int)(((byte)(21)))));
            this.thisPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.thisPanel.Location = new System.Drawing.Point(0, 0);
            this.thisPanel.Name = "thisPanel";
            this.thisPanel.ShadowDecoration.Parent = this.thisPanel;
            this.thisPanel.Size = new System.Drawing.Size(502, 156);
            this.thisPanel.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "KOPO";
            // 
            // guna2Button1
            // 
            this.guna2Button1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(62)))), ((int)(((byte)(63)))));
            this.guna2Button1.BorderThickness = 1;
            this.guna2Button1.CheckedState.Parent = this.guna2Button1;
            this.guna2Button1.CustomImages.Parent = this.guna2Button1;
            this.guna2Button1.FillColor = System.Drawing.Color.Transparent;
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.HoverState.Parent = this.guna2Button1;
            this.guna2Button1.Location = new System.Drawing.Point(380, 113);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.ShadowDecoration.Parent = this.guna2Button1;
            this.guna2Button1.Size = new System.Drawing.Size(82, 24);
            this.guna2Button1.TabIndex = 3;
            this.guna2Button1.Text = "Cancel";
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Location = new System.Drawing.Point(36, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Loading Game Settings ...";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(37, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Please, Hang Tight ...";
            // 
            // progressbar
            // 
            this.progressbar.BackColor = System.Drawing.Color.Transparent;
            this.progressbar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(33)))), ((int)(((byte)(47)))));
            this.progressbar.BorderThickness = 1;
            this.progressbar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(34)))));
            this.progressbar.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.progressbar.Location = new System.Drawing.Point(40, 72);
            this.progressbar.Name = "progressbar";
            this.progressbar.ProgressBrushMode = Guna.UI2.WinForms.Enums.BrushMode.SolidTransition;
            this.progressbar.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(96)))), ((int)(((byte)(221)))));
            this.progressbar.ProgressColor2 = System.Drawing.Color.Transparent;
            this.progressbar.ShadowDecoration.Parent = this.progressbar;
            this.progressbar.Size = new System.Drawing.Size(422, 21);
            this.progressbar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressbar.TabIndex = 0;
            this.progressbar.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.progressbar.Value = 25;
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.TargetControl = this.thisPanel;
            // 
            // SettingsLoaderF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 156);
            this.Controls.Add(this.thisPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsLoaderF";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KOPO";
            this.thisPanel.ResumeLayout(false);
            this.thisPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna2GradientPanel thisPanel;
        private Guna2ProgressBar progressbar;
        private Guna2Button guna2Button1;
        private Label label2;
        private Label label1;
        private BackgroundWorker backgroundWorker1;
        private Label label3;
        private Guna2DragControl guna2DragControl1;
    }
}