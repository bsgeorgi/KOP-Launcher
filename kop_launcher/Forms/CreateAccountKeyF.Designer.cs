namespace kop_launcher.Forms
{
    partial class CreateAccountKeyF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateAccountKeyF));
            this.thisPanel = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.secureKey = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.thisPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // thisPanel
            // 
            this.thisPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(27)))), ((int)(((byte)(41)))));
            this.thisPanel.Controls.Add(this.secureKey);
            this.thisPanel.Controls.Add(this.label1);
            this.thisPanel.Controls.Add(this.label3);
            this.thisPanel.Controls.Add(this.guna2Button1);
            this.thisPanel.Cursor = System.Windows.Forms.Cursors.Default;
            this.thisPanel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(24)))), ((int)(((byte)(37)))));
            this.thisPanel.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(13)))), ((int)(((byte)(21)))));
            this.thisPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.thisPanel.Location = new System.Drawing.Point(0, 0);
            this.thisPanel.Name = "thisPanel";
            this.thisPanel.ShadowDecoration.Parent = this.thisPanel;
            this.thisPanel.Size = new System.Drawing.Size(604, 254);
            this.thisPanel.TabIndex = 3;
            // 
            // secureKey
            // 
            this.secureKey.BackColor = System.Drawing.Color.Transparent;
            this.secureKey.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(62)))), ((int)(((byte)(63)))));
            this.secureKey.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.secureKey.DefaultText = "";
            this.secureKey.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.secureKey.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.secureKey.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.secureKey.DisabledState.Parent = this.secureKey;
            this.secureKey.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.secureKey.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(24)))), ((int)(((byte)(37)))));
            this.secureKey.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.secureKey.FocusedState.Parent = this.secureKey;
            this.secureKey.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.secureKey.ForeColor = System.Drawing.Color.White;
            this.secureKey.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.secureKey.HoverState.Parent = this.secureKey;
            this.secureKey.Location = new System.Drawing.Point(31, 189);
            this.secureKey.MaxLength = 128;
            this.secureKey.Name = "secureKey";
            this.secureKey.PasswordChar = '*';
            this.secureKey.PlaceholderForeColor = System.Drawing.Color.White;
            this.secureKey.PlaceholderText = "Please enter your code here...";
            this.secureKey.SelectedText = "";
            this.secureKey.ShadowDecoration.Parent = this.secureKey;
            this.secureKey.Size = new System.Drawing.Size(425, 24);
            this.secureKey.TabIndex = 6;
            this.secureKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.secureKey_KeyDown);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(27, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(550, 123);
            this.label1.TabIndex = 5;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(174, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "KOPO - Create Secure Password";
            // 
            // guna2Button1
            // 
            this.guna2Button1.Animated = true;
            this.guna2Button1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(62)))), ((int)(((byte)(63)))));
            this.guna2Button1.BorderThickness = 1;
            this.guna2Button1.CheckedState.Parent = this.guna2Button1;
            this.guna2Button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2Button1.CustomImages.Parent = this.guna2Button1;
            this.guna2Button1.FillColor = System.Drawing.Color.Transparent;
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.HoverState.Parent = this.guna2Button1;
            this.guna2Button1.Location = new System.Drawing.Point(495, 189);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.ShadowDecoration.Parent = this.guna2Button1;
            this.guna2Button1.Size = new System.Drawing.Size(82, 24);
            this.guna2Button1.TabIndex = 3;
            this.guna2Button1.Text = "Apply";
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // CreateAccountKeyF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 254);
            this.Controls.Add(this.thisPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CreateAccountKeyF";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CreateAccountKeyF";
            this.thisPanel.ResumeLayout(false);
            this.thisPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientPanel thisPanel;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2TextBox secureKey;
        private System.Windows.Forms.Label label1;
    }
}