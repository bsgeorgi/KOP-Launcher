using System.ComponentModel;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace kop_launcher.Forms
{
    partial class SettingsF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsF));
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.settingsPanel = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.label35 = new System.Windows.Forms.Label();
            this.guna2CustomCheckBox14 = new Guna.UI2.WinForms.Guna2CustomCheckBox();
            this.label34 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.guna2CustomCheckBox13 = new Guna.UI2.WinForms.Guna2CustomCheckBox();
            this.label31 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.guna2CustomCheckBox12 = new Guna.UI2.WinForms.Guna2CustomCheckBox();
            this.label27 = new System.Windows.Forms.Label();
            this.guna2CustomCheckBox11 = new Guna.UI2.WinForms.Guna2CustomCheckBox();
            this.guna2PictureBox4 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.label25 = new System.Windows.Forms.Label();
            this.guna2CustomCheckBox10 = new Guna.UI2.WinForms.Guna2CustomCheckBox();
            this.ResetButton = new Guna.UI2.WinForms.Guna2GradientButton();
            this.ApplyButton = new Guna.UI2.WinForms.Guna2GradientButton();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.label12 = new System.Windows.Forms.Label();
            this.guna2CustomCheckBox7 = new Guna.UI2.WinForms.Guna2CustomCheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.guna2CustomCheckBox6 = new Guna.UI2.WinForms.Guna2CustomCheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.guna2CustomCheckBox5 = new Guna.UI2.WinForms.Guna2CustomCheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.guna2CustomCheckBox4 = new Guna.UI2.WinForms.Guna2CustomCheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.guna2CustomCheckBox3 = new Guna.UI2.WinForms.Guna2CustomCheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.guna2CustomCheckBox1 = new Guna.UI2.WinForms.Guna2CustomCheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cameraUHighCheckbox = new Guna.UI2.WinForms.Guna2CustomRadioButton();
            this.cameraHighCheckbox = new Guna.UI2.WinForms.Guna2CustomRadioButton();
            this.cameraMedCheckbox = new Guna.UI2.WinForms.Guna2CustomRadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.cameraLowCheckbox = new Guna.UI2.WinForms.Guna2CustomRadioButton();
            this.guna2CustomCheckBox2 = new Guna.UI2.WinForms.Guna2CustomCheckBox();
            this.guna2PictureBox2 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.minimiseButton = new Guna.UI2.WinForms.Guna2ControlBox();
            this.closeButton = new Guna.UI2.WinForms.Guna2ControlBox();
            this.settingsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.ContainerControl = this;
            this.guna2DragControl1.TargetControl = this.settingsPanel;
            // 
            // settingsPanel
            // 
            this.settingsPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(62)))), ((int)(((byte)(63)))));
            this.settingsPanel.BorderThickness = 1;
            this.settingsPanel.Controls.Add(this.label35);
            this.settingsPanel.Controls.Add(this.guna2CustomCheckBox14);
            this.settingsPanel.Controls.Add(this.label34);
            this.settingsPanel.Controls.Add(this.label33);
            this.settingsPanel.Controls.Add(this.guna2CustomCheckBox13);
            this.settingsPanel.Controls.Add(this.label31);
            this.settingsPanel.Controls.Add(this.label29);
            this.settingsPanel.Controls.Add(this.guna2CustomCheckBox12);
            this.settingsPanel.Controls.Add(this.label27);
            this.settingsPanel.Controls.Add(this.guna2CustomCheckBox11);
            this.settingsPanel.Controls.Add(this.guna2PictureBox4);
            this.settingsPanel.Controls.Add(this.label25);
            this.settingsPanel.Controls.Add(this.guna2CustomCheckBox10);
            this.settingsPanel.Controls.Add(this.ResetButton);
            this.settingsPanel.Controls.Add(this.ApplyButton);
            this.settingsPanel.Controls.Add(this.guna2PictureBox1);
            this.settingsPanel.Controls.Add(this.label12);
            this.settingsPanel.Controls.Add(this.guna2CustomCheckBox7);
            this.settingsPanel.Controls.Add(this.label11);
            this.settingsPanel.Controls.Add(this.guna2CustomCheckBox6);
            this.settingsPanel.Controls.Add(this.label10);
            this.settingsPanel.Controls.Add(this.guna2CustomCheckBox5);
            this.settingsPanel.Controls.Add(this.label9);
            this.settingsPanel.Controls.Add(this.guna2CustomCheckBox4);
            this.settingsPanel.Controls.Add(this.label8);
            this.settingsPanel.Controls.Add(this.guna2CustomCheckBox3);
            this.settingsPanel.Controls.Add(this.label7);
            this.settingsPanel.Controls.Add(this.guna2CustomCheckBox1);
            this.settingsPanel.Controls.Add(this.label6);
            this.settingsPanel.Controls.Add(this.label5);
            this.settingsPanel.Controls.Add(this.label4);
            this.settingsPanel.Controls.Add(this.label3);
            this.settingsPanel.Controls.Add(this.label2);
            this.settingsPanel.Controls.Add(this.cameraUHighCheckbox);
            this.settingsPanel.Controls.Add(this.cameraHighCheckbox);
            this.settingsPanel.Controls.Add(this.cameraMedCheckbox);
            this.settingsPanel.Controls.Add(this.label1);
            this.settingsPanel.Controls.Add(this.cameraLowCheckbox);
            this.settingsPanel.Controls.Add(this.guna2CustomCheckBox2);
            this.settingsPanel.Controls.Add(this.guna2PictureBox2);
            this.settingsPanel.Controls.Add(this.minimiseButton);
            this.settingsPanel.Controls.Add(this.closeButton);
            this.settingsPanel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(43)))), ((int)(((byte)(44)))));
            this.settingsPanel.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.settingsPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.settingsPanel.Location = new System.Drawing.Point(0, 0);
            this.settingsPanel.Name = "settingsPanel";
            this.settingsPanel.ShadowDecoration.Color = System.Drawing.Color.Transparent;
            this.settingsPanel.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.settingsPanel.ShadowDecoration.Parent = this.settingsPanel;
            this.settingsPanel.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0);
            this.settingsPanel.Size = new System.Drawing.Size(1056, 582);
            this.settingsPanel.TabIndex = 0;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.BackColor = System.Drawing.Color.Transparent;
            this.label35.Font = new System.Drawing.Font("Roboto Medium", 8F);
            this.label35.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(124)))));
            this.label35.Location = new System.Drawing.Point(764, 153);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(162, 17);
            this.label35.TabIndex = 87;
            this.label35.Text = "Render Vertical Skill Bar";
            // 
            // guna2CustomCheckBox14
            // 
            this.guna2CustomCheckBox14.Animated = true;
            this.guna2CustomCheckBox14.BackColor = System.Drawing.Color.Transparent;
            this.guna2CustomCheckBox14.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(9)))), ((int)(((byte)(10)))));
            this.guna2CustomCheckBox14.CheckedState.BorderRadius = 2;
            this.guna2CustomCheckBox14.CheckedState.BorderThickness = 2;
            this.guna2CustomCheckBox14.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(242)))));
            this.guna2CustomCheckBox14.CheckedState.Parent = this.guna2CustomCheckBox14;
            this.guna2CustomCheckBox14.CheckMarkColor = System.Drawing.Color.Transparent;
            this.guna2CustomCheckBox14.Location = new System.Drawing.Point(738, 151);
            this.guna2CustomCheckBox14.Name = "guna2CustomCheckBox14";
            this.guna2CustomCheckBox14.ShadowDecoration.BorderRadius = 0;
            this.guna2CustomCheckBox14.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(73)))), ((int)(((byte)(176)))));
            this.guna2CustomCheckBox14.ShadowDecoration.Parent = this.guna2CustomCheckBox14;
            this.guna2CustomCheckBox14.Size = new System.Drawing.Size(20, 20);
            this.guna2CustomCheckBox14.TabIndex = 86;
            this.guna2CustomCheckBox14.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(65)))), ((int)(((byte)(66)))));
            this.guna2CustomCheckBox14.UncheckedState.BorderRadius = 2;
            this.guna2CustomCheckBox14.UncheckedState.BorderThickness = 2;
            this.guna2CustomCheckBox14.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(4)))), ((int)(((byte)(5)))));
            this.guna2CustomCheckBox14.UncheckedState.Parent = this.guna2CustomCheckBox14;
            this.guna2CustomCheckBox14.UseTransparentBackground = true;
            this.guna2CustomCheckBox14.CheckedChanged += new System.EventHandler(this.guna2CustomCheckBox1_CheckedChanged);
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.BackColor = System.Drawing.Color.Transparent;
            this.label34.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label34.Font = new System.Drawing.Font("Roboto Medium", 8F, System.Drawing.FontStyle.Underline);
            this.label34.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(124)))));
            this.label34.Location = new System.Drawing.Point(32, 466);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(147, 17);
            this.label34.TabIndex = 85;
            this.label34.Text = "Manage Game Logins";
            this.label34.Click += new System.EventHandler(this.label34_Click_1);
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.BackColor = System.Drawing.Color.Transparent;
            this.label33.Font = new System.Drawing.Font("Roboto Medium", 8F);
            this.label33.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(124)))));
            this.label33.Location = new System.Drawing.Point(764, 125);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(146, 17);
            this.label33.TabIndex = 84;
            this.label33.Text = "Render Stall Captions";
            // 
            // guna2CustomCheckBox13
            // 
            this.guna2CustomCheckBox13.Animated = true;
            this.guna2CustomCheckBox13.BackColor = System.Drawing.Color.Transparent;
            this.guna2CustomCheckBox13.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(9)))), ((int)(((byte)(10)))));
            this.guna2CustomCheckBox13.CheckedState.BorderRadius = 2;
            this.guna2CustomCheckBox13.CheckedState.BorderThickness = 2;
            this.guna2CustomCheckBox13.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(242)))));
            this.guna2CustomCheckBox13.CheckedState.Parent = this.guna2CustomCheckBox13;
            this.guna2CustomCheckBox13.CheckMarkColor = System.Drawing.Color.Transparent;
            this.guna2CustomCheckBox13.Location = new System.Drawing.Point(738, 123);
            this.guna2CustomCheckBox13.Name = "guna2CustomCheckBox13";
            this.guna2CustomCheckBox13.ShadowDecoration.BorderRadius = 0;
            this.guna2CustomCheckBox13.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(73)))), ((int)(((byte)(176)))));
            this.guna2CustomCheckBox13.ShadowDecoration.Parent = this.guna2CustomCheckBox13;
            this.guna2CustomCheckBox13.Size = new System.Drawing.Size(20, 20);
            this.guna2CustomCheckBox13.TabIndex = 83;
            this.guna2CustomCheckBox13.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(65)))), ((int)(((byte)(66)))));
            this.guna2CustomCheckBox13.UncheckedState.BorderRadius = 2;
            this.guna2CustomCheckBox13.UncheckedState.BorderThickness = 2;
            this.guna2CustomCheckBox13.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(4)))), ((int)(((byte)(5)))));
            this.guna2CustomCheckBox13.UncheckedState.Parent = this.guna2CustomCheckBox13;
            this.guna2CustomCheckBox13.UseTransparentBackground = true;
            this.guna2CustomCheckBox13.CheckedChanged += new System.EventHandler(this.guna2CustomCheckBox1_CheckedChanged);
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.BackColor = System.Drawing.Color.Transparent;
            this.label31.ForeColor = System.Drawing.Color.DimGray;
            this.label31.Location = new System.Drawing.Point(929, 556);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(115, 17);
            this.label31.TabIndex = 82;
            this.label31.Text = "Settings Saved...";
            this.label31.Visible = false;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.BackColor = System.Drawing.Color.Transparent;
            this.label29.Font = new System.Drawing.Font("Roboto Medium", 8F);
            this.label29.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(124)))));
            this.label29.Location = new System.Drawing.Point(411, 98);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(202, 17);
            this.label29.TabIndex = 81;
            this.label29.Text = "Render Launcher Notifications";
            // 
            // guna2CustomCheckBox12
            // 
            this.guna2CustomCheckBox12.Animated = true;
            this.guna2CustomCheckBox12.BackColor = System.Drawing.Color.Transparent;
            this.guna2CustomCheckBox12.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(9)))), ((int)(((byte)(10)))));
            this.guna2CustomCheckBox12.CheckedState.BorderRadius = 2;
            this.guna2CustomCheckBox12.CheckedState.BorderThickness = 2;
            this.guna2CustomCheckBox12.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(242)))));
            this.guna2CustomCheckBox12.CheckedState.Parent = this.guna2CustomCheckBox12;
            this.guna2CustomCheckBox12.CheckMarkColor = System.Drawing.Color.Transparent;
            this.guna2CustomCheckBox12.Location = new System.Drawing.Point(385, 96);
            this.guna2CustomCheckBox12.Name = "guna2CustomCheckBox12";
            this.guna2CustomCheckBox12.ShadowDecoration.BorderRadius = 0;
            this.guna2CustomCheckBox12.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(73)))), ((int)(((byte)(176)))));
            this.guna2CustomCheckBox12.ShadowDecoration.Parent = this.guna2CustomCheckBox12;
            this.guna2CustomCheckBox12.Size = new System.Drawing.Size(20, 20);
            this.guna2CustomCheckBox12.TabIndex = 80;
            this.guna2CustomCheckBox12.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(65)))), ((int)(((byte)(66)))));
            this.guna2CustomCheckBox12.UncheckedState.BorderRadius = 2;
            this.guna2CustomCheckBox12.UncheckedState.BorderThickness = 2;
            this.guna2CustomCheckBox12.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(4)))), ((int)(((byte)(5)))));
            this.guna2CustomCheckBox12.UncheckedState.Parent = this.guna2CustomCheckBox12;
            this.guna2CustomCheckBox12.UseTransparentBackground = true;
            this.guna2CustomCheckBox12.CheckedChanged += new System.EventHandler(this.guna2CustomCheckBox1_CheckedChanged);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.BackColor = System.Drawing.Color.Transparent;
            this.label27.Font = new System.Drawing.Font("Roboto Medium", 8F);
            this.label27.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(124)))));
            this.label27.Location = new System.Drawing.Point(764, 97);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(180, 17);
            this.label27.TabIndex = 79;
            this.label27.Text = "Override Game Animations";
            // 
            // guna2CustomCheckBox11
            // 
            this.guna2CustomCheckBox11.Animated = true;
            this.guna2CustomCheckBox11.BackColor = System.Drawing.Color.Transparent;
            this.guna2CustomCheckBox11.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(9)))), ((int)(((byte)(10)))));
            this.guna2CustomCheckBox11.CheckedState.BorderRadius = 2;
            this.guna2CustomCheckBox11.CheckedState.BorderThickness = 2;
            this.guna2CustomCheckBox11.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(242)))));
            this.guna2CustomCheckBox11.CheckedState.Parent = this.guna2CustomCheckBox11;
            this.guna2CustomCheckBox11.CheckMarkColor = System.Drawing.Color.Transparent;
            this.guna2CustomCheckBox11.Location = new System.Drawing.Point(738, 95);
            this.guna2CustomCheckBox11.Name = "guna2CustomCheckBox11";
            this.guna2CustomCheckBox11.ShadowDecoration.BorderRadius = 0;
            this.guna2CustomCheckBox11.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(73)))), ((int)(((byte)(176)))));
            this.guna2CustomCheckBox11.ShadowDecoration.Parent = this.guna2CustomCheckBox11;
            this.guna2CustomCheckBox11.Size = new System.Drawing.Size(20, 20);
            this.guna2CustomCheckBox11.TabIndex = 78;
            this.guna2CustomCheckBox11.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(65)))), ((int)(((byte)(66)))));
            this.guna2CustomCheckBox11.UncheckedState.BorderRadius = 2;
            this.guna2CustomCheckBox11.UncheckedState.BorderThickness = 2;
            this.guna2CustomCheckBox11.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(4)))), ((int)(((byte)(5)))));
            this.guna2CustomCheckBox11.UncheckedState.Parent = this.guna2CustomCheckBox11;
            this.guna2CustomCheckBox11.UseTransparentBackground = true;
            this.guna2CustomCheckBox11.CheckedChanged += new System.EventHandler(this.guna2CustomCheckBox1_CheckedChanged);
            // 
            // guna2PictureBox4
            // 
            this.guna2PictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox4.Image")));
            this.guna2PictureBox4.Location = new System.Drawing.Point(740, 53);
            this.guna2PictureBox4.Name = "guna2PictureBox4";
            this.guna2PictureBox4.ShadowDecoration.Parent = this.guna2PictureBox4;
            this.guna2PictureBox4.Size = new System.Drawing.Size(283, 25);
            this.guna2PictureBox4.TabIndex = 77;
            this.guna2PictureBox4.TabStop = false;
            this.guna2PictureBox4.UseTransparentBackground = true;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.BackColor = System.Drawing.Color.Transparent;
            this.label25.Font = new System.Drawing.Font("Roboto Medium", 8F);
            this.label25.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(124)))));
            this.label25.Location = new System.Drawing.Point(61, 409);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(128, 17);
            this.label25.TabIndex = 76;
            this.label25.Text = "Render State Icons";
            // 
            // guna2CustomCheckBox10
            // 
            this.guna2CustomCheckBox10.Animated = true;
            this.guna2CustomCheckBox10.BackColor = System.Drawing.Color.Transparent;
            this.guna2CustomCheckBox10.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(9)))), ((int)(((byte)(10)))));
            this.guna2CustomCheckBox10.CheckedState.BorderRadius = 2;
            this.guna2CustomCheckBox10.CheckedState.BorderThickness = 2;
            this.guna2CustomCheckBox10.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(242)))));
            this.guna2CustomCheckBox10.CheckedState.Parent = this.guna2CustomCheckBox10;
            this.guna2CustomCheckBox10.CheckMarkColor = System.Drawing.Color.Transparent;
            this.guna2CustomCheckBox10.Location = new System.Drawing.Point(35, 407);
            this.guna2CustomCheckBox10.Name = "guna2CustomCheckBox10";
            this.guna2CustomCheckBox10.ShadowDecoration.BorderRadius = 0;
            this.guna2CustomCheckBox10.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(73)))), ((int)(((byte)(176)))));
            this.guna2CustomCheckBox10.ShadowDecoration.Parent = this.guna2CustomCheckBox10;
            this.guna2CustomCheckBox10.Size = new System.Drawing.Size(20, 20);
            this.guna2CustomCheckBox10.TabIndex = 75;
            this.guna2CustomCheckBox10.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(65)))), ((int)(((byte)(66)))));
            this.guna2CustomCheckBox10.UncheckedState.BorderRadius = 2;
            this.guna2CustomCheckBox10.UncheckedState.BorderThickness = 2;
            this.guna2CustomCheckBox10.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(4)))), ((int)(((byte)(5)))));
            this.guna2CustomCheckBox10.UncheckedState.Parent = this.guna2CustomCheckBox10;
            this.guna2CustomCheckBox10.UseTransparentBackground = true;
            this.guna2CustomCheckBox10.CheckedChanged += new System.EventHandler(this.guna2CustomCheckBox1_CheckedChanged);
            // 
            // ResetButton
            // 
            this.ResetButton.Animated = true;
            this.ResetButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(100)))));
            this.ResetButton.BorderThickness = 1;
            this.ResetButton.CheckedState.Parent = this.ResetButton;
            this.ResetButton.CustomImages.Parent = this.ResetButton;
            this.ResetButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(63)))), ((int)(((byte)(69)))));
            this.ResetButton.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(94)))));
            this.ResetButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ResetButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(172)))), ((int)(((byte)(173)))));
            this.ResetButton.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.ResetButton.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(63)))), ((int)(((byte)(69)))));
            this.ResetButton.HoverState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(94)))));
            this.ResetButton.HoverState.ForeColor = System.Drawing.Color.White;
            this.ResetButton.HoverState.Parent = this.ResetButton;
            this.ResetButton.Location = new System.Drawing.Point(560, 515);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.ShadowDecoration.Parent = this.ResetButton;
            this.ResetButton.Size = new System.Drawing.Size(110, 34);
            this.ResetButton.TabIndex = 74;
            this.ResetButton.Text = "Reset";
            this.ResetButton.UseWaitCursor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // ApplyButton
            // 
            this.ApplyButton.Animated = true;
            this.ApplyButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(100)))));
            this.ApplyButton.BorderThickness = 1;
            this.ApplyButton.CheckedState.Parent = this.ApplyButton;
            this.ApplyButton.CustomImages.Parent = this.ApplyButton;
            this.ApplyButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(63)))), ((int)(((byte)(69)))));
            this.ApplyButton.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(94)))));
            this.ApplyButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ApplyButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(172)))), ((int)(((byte)(173)))));
            this.ApplyButton.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.ApplyButton.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(63)))), ((int)(((byte)(69)))));
            this.ApplyButton.HoverState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(94)))));
            this.ApplyButton.HoverState.ForeColor = System.Drawing.Color.White;
            this.ApplyButton.HoverState.Parent = this.ApplyButton;
            this.ApplyButton.Location = new System.Drawing.Point(387, 515);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.ShadowDecoration.Parent = this.ApplyButton;
            this.ApplyButton.Size = new System.Drawing.Size(110, 34);
            this.ApplyButton.TabIndex = 73;
            this.ApplyButton.Text = "Apply";
            this.ApplyButton.UseWaitCursor = true;
            this.ApplyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox1.Image")));
            this.guna2PictureBox1.Location = new System.Drawing.Point(387, 53);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.ShadowDecoration.Parent = this.guna2PictureBox1;
            this.guna2PictureBox1.Size = new System.Drawing.Size(283, 25);
            this.guna2PictureBox1.TabIndex = 37;
            this.guna2PictureBox1.TabStop = false;
            this.guna2PictureBox1.UseTransparentBackground = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Roboto Medium", 8F);
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(124)))));
            this.label12.Location = new System.Drawing.Point(61, 381);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(195, 17);
            this.label12.TabIndex = 34;
            this.label12.Text = "Enforce High Quality Settings";
            // 
            // guna2CustomCheckBox7
            // 
            this.guna2CustomCheckBox7.Animated = true;
            this.guna2CustomCheckBox7.BackColor = System.Drawing.Color.Transparent;
            this.guna2CustomCheckBox7.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(9)))), ((int)(((byte)(10)))));
            this.guna2CustomCheckBox7.CheckedState.BorderRadius = 2;
            this.guna2CustomCheckBox7.CheckedState.BorderThickness = 2;
            this.guna2CustomCheckBox7.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(242)))));
            this.guna2CustomCheckBox7.CheckedState.Parent = this.guna2CustomCheckBox7;
            this.guna2CustomCheckBox7.CheckMarkColor = System.Drawing.Color.Transparent;
            this.guna2CustomCheckBox7.Location = new System.Drawing.Point(35, 379);
            this.guna2CustomCheckBox7.Name = "guna2CustomCheckBox7";
            this.guna2CustomCheckBox7.ShadowDecoration.BorderRadius = 0;
            this.guna2CustomCheckBox7.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(73)))), ((int)(((byte)(176)))));
            this.guna2CustomCheckBox7.ShadowDecoration.Parent = this.guna2CustomCheckBox7;
            this.guna2CustomCheckBox7.Size = new System.Drawing.Size(20, 20);
            this.guna2CustomCheckBox7.TabIndex = 33;
            this.guna2CustomCheckBox7.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(65)))), ((int)(((byte)(66)))));
            this.guna2CustomCheckBox7.UncheckedState.BorderRadius = 2;
            this.guna2CustomCheckBox7.UncheckedState.BorderThickness = 2;
            this.guna2CustomCheckBox7.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(4)))), ((int)(((byte)(5)))));
            this.guna2CustomCheckBox7.UncheckedState.Parent = this.guna2CustomCheckBox7;
            this.guna2CustomCheckBox7.UseTransparentBackground = true;
            this.guna2CustomCheckBox7.CheckedChanged += new System.EventHandler(this.guna2CustomCheckBox1_CheckedChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Roboto Medium", 8F);
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(124)))));
            this.label11.Location = new System.Drawing.Point(61, 353);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(143, 17);
            this.label11.TabIndex = 32;
            this.label11.Text = "Render Game Effects";
            // 
            // guna2CustomCheckBox6
            // 
            this.guna2CustomCheckBox6.Animated = true;
            this.guna2CustomCheckBox6.BackColor = System.Drawing.Color.Transparent;
            this.guna2CustomCheckBox6.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(9)))), ((int)(((byte)(10)))));
            this.guna2CustomCheckBox6.CheckedState.BorderRadius = 2;
            this.guna2CustomCheckBox6.CheckedState.BorderThickness = 2;
            this.guna2CustomCheckBox6.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(242)))));
            this.guna2CustomCheckBox6.CheckedState.Parent = this.guna2CustomCheckBox6;
            this.guna2CustomCheckBox6.CheckMarkColor = System.Drawing.Color.Transparent;
            this.guna2CustomCheckBox6.Location = new System.Drawing.Point(35, 351);
            this.guna2CustomCheckBox6.Name = "guna2CustomCheckBox6";
            this.guna2CustomCheckBox6.ShadowDecoration.BorderRadius = 0;
            this.guna2CustomCheckBox6.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(73)))), ((int)(((byte)(176)))));
            this.guna2CustomCheckBox6.ShadowDecoration.Parent = this.guna2CustomCheckBox6;
            this.guna2CustomCheckBox6.Size = new System.Drawing.Size(20, 20);
            this.guna2CustomCheckBox6.TabIndex = 31;
            this.guna2CustomCheckBox6.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(65)))), ((int)(((byte)(66)))));
            this.guna2CustomCheckBox6.UncheckedState.BorderRadius = 2;
            this.guna2CustomCheckBox6.UncheckedState.BorderThickness = 2;
            this.guna2CustomCheckBox6.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(4)))), ((int)(((byte)(5)))));
            this.guna2CustomCheckBox6.UncheckedState.Parent = this.guna2CustomCheckBox6;
            this.guna2CustomCheckBox6.UseTransparentBackground = true;
            this.guna2CustomCheckBox6.CheckedChanged += new System.EventHandler(this.guna2CustomCheckBox1_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Roboto Medium", 8F);
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(124)))));
            this.label10.Location = new System.Drawing.Point(61, 325);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(155, 17);
            this.label10.TabIndex = 30;
            this.label10.Text = "Render Game Apparels";
            // 
            // guna2CustomCheckBox5
            // 
            this.guna2CustomCheckBox5.Animated = true;
            this.guna2CustomCheckBox5.BackColor = System.Drawing.Color.Transparent;
            this.guna2CustomCheckBox5.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(9)))), ((int)(((byte)(10)))));
            this.guna2CustomCheckBox5.CheckedState.BorderRadius = 2;
            this.guna2CustomCheckBox5.CheckedState.BorderThickness = 2;
            this.guna2CustomCheckBox5.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(242)))));
            this.guna2CustomCheckBox5.CheckedState.Parent = this.guna2CustomCheckBox5;
            this.guna2CustomCheckBox5.CheckMarkColor = System.Drawing.Color.Transparent;
            this.guna2CustomCheckBox5.Location = new System.Drawing.Point(35, 323);
            this.guna2CustomCheckBox5.Name = "guna2CustomCheckBox5";
            this.guna2CustomCheckBox5.ShadowDecoration.BorderRadius = 0;
            this.guna2CustomCheckBox5.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(73)))), ((int)(((byte)(176)))));
            this.guna2CustomCheckBox5.ShadowDecoration.Parent = this.guna2CustomCheckBox5;
            this.guna2CustomCheckBox5.Size = new System.Drawing.Size(20, 20);
            this.guna2CustomCheckBox5.TabIndex = 29;
            this.guna2CustomCheckBox5.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(65)))), ((int)(((byte)(66)))));
            this.guna2CustomCheckBox5.UncheckedState.BorderRadius = 2;
            this.guna2CustomCheckBox5.UncheckedState.BorderThickness = 2;
            this.guna2CustomCheckBox5.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(4)))), ((int)(((byte)(5)))));
            this.guna2CustomCheckBox5.UncheckedState.Parent = this.guna2CustomCheckBox5;
            this.guna2CustomCheckBox5.UseTransparentBackground = true;
            this.guna2CustomCheckBox5.CheckedChanged += new System.EventHandler(this.guna2CustomCheckBox1_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Roboto Medium", 8F);
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(124)))));
            this.label9.Location = new System.Drawing.Point(61, 297);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(172, 17);
            this.label9.TabIndex = 28;
            this.label9.Text = "Use 32-bit Colour Scheme";
            // 
            // guna2CustomCheckBox4
            // 
            this.guna2CustomCheckBox4.Animated = true;
            this.guna2CustomCheckBox4.BackColor = System.Drawing.Color.Transparent;
            this.guna2CustomCheckBox4.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(9)))), ((int)(((byte)(10)))));
            this.guna2CustomCheckBox4.CheckedState.BorderRadius = 2;
            this.guna2CustomCheckBox4.CheckedState.BorderThickness = 2;
            this.guna2CustomCheckBox4.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(242)))));
            this.guna2CustomCheckBox4.CheckedState.Parent = this.guna2CustomCheckBox4;
            this.guna2CustomCheckBox4.CheckMarkColor = System.Drawing.Color.Transparent;
            this.guna2CustomCheckBox4.Location = new System.Drawing.Point(35, 295);
            this.guna2CustomCheckBox4.Name = "guna2CustomCheckBox4";
            this.guna2CustomCheckBox4.ShadowDecoration.BorderRadius = 0;
            this.guna2CustomCheckBox4.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(73)))), ((int)(((byte)(176)))));
            this.guna2CustomCheckBox4.ShadowDecoration.Parent = this.guna2CustomCheckBox4;
            this.guna2CustomCheckBox4.Size = new System.Drawing.Size(20, 20);
            this.guna2CustomCheckBox4.TabIndex = 27;
            this.guna2CustomCheckBox4.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(65)))), ((int)(((byte)(66)))));
            this.guna2CustomCheckBox4.UncheckedState.BorderRadius = 2;
            this.guna2CustomCheckBox4.UncheckedState.BorderThickness = 2;
            this.guna2CustomCheckBox4.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(4)))), ((int)(((byte)(5)))));
            this.guna2CustomCheckBox4.UncheckedState.Parent = this.guna2CustomCheckBox4;
            this.guna2CustomCheckBox4.UseTransparentBackground = true;
            this.guna2CustomCheckBox4.CheckedChanged += new System.EventHandler(this.guna2CustomCheckBox1_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Roboto Medium", 8F);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(124)))));
            this.label8.Location = new System.Drawing.Point(61, 269);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(151, 17);
            this.label8.TabIndex = 26;
            this.label8.Text = "Enforce High FPS Rate";
            // 
            // guna2CustomCheckBox3
            // 
            this.guna2CustomCheckBox3.Animated = true;
            this.guna2CustomCheckBox3.BackColor = System.Drawing.Color.Transparent;
            this.guna2CustomCheckBox3.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(9)))), ((int)(((byte)(10)))));
            this.guna2CustomCheckBox3.CheckedState.BorderRadius = 2;
            this.guna2CustomCheckBox3.CheckedState.BorderThickness = 2;
            this.guna2CustomCheckBox3.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(242)))));
            this.guna2CustomCheckBox3.CheckedState.Parent = this.guna2CustomCheckBox3;
            this.guna2CustomCheckBox3.CheckMarkColor = System.Drawing.Color.Transparent;
            this.guna2CustomCheckBox3.Location = new System.Drawing.Point(35, 267);
            this.guna2CustomCheckBox3.Name = "guna2CustomCheckBox3";
            this.guna2CustomCheckBox3.ShadowDecoration.BorderRadius = 0;
            this.guna2CustomCheckBox3.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(73)))), ((int)(((byte)(176)))));
            this.guna2CustomCheckBox3.ShadowDecoration.Parent = this.guna2CustomCheckBox3;
            this.guna2CustomCheckBox3.Size = new System.Drawing.Size(20, 20);
            this.guna2CustomCheckBox3.TabIndex = 25;
            this.guna2CustomCheckBox3.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(65)))), ((int)(((byte)(66)))));
            this.guna2CustomCheckBox3.UncheckedState.BorderRadius = 2;
            this.guna2CustomCheckBox3.UncheckedState.BorderThickness = 2;
            this.guna2CustomCheckBox3.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(4)))), ((int)(((byte)(5)))));
            this.guna2CustomCheckBox3.UncheckedState.Parent = this.guna2CustomCheckBox3;
            this.guna2CustomCheckBox3.UseTransparentBackground = true;
            this.guna2CustomCheckBox3.CheckedChanged += new System.EventHandler(this.guna2CustomCheckBox1_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Roboto Medium", 8F);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(124)))));
            this.label7.Location = new System.Drawing.Point(61, 241);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(203, 17);
            this.label7.TabIndex = 24;
            this.label7.Text = "Enforce High Game Resolution";
            // 
            // guna2CustomCheckBox1
            // 
            this.guna2CustomCheckBox1.Animated = true;
            this.guna2CustomCheckBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2CustomCheckBox1.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(9)))), ((int)(((byte)(10)))));
            this.guna2CustomCheckBox1.CheckedState.BorderRadius = 2;
            this.guna2CustomCheckBox1.CheckedState.BorderThickness = 2;
            this.guna2CustomCheckBox1.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(242)))));
            this.guna2CustomCheckBox1.CheckedState.Parent = this.guna2CustomCheckBox1;
            this.guna2CustomCheckBox1.CheckMarkColor = System.Drawing.Color.Transparent;
            this.guna2CustomCheckBox1.Location = new System.Drawing.Point(35, 239);
            this.guna2CustomCheckBox1.Name = "guna2CustomCheckBox1";
            this.guna2CustomCheckBox1.ShadowDecoration.BorderRadius = 0;
            this.guna2CustomCheckBox1.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(73)))), ((int)(((byte)(176)))));
            this.guna2CustomCheckBox1.ShadowDecoration.Parent = this.guna2CustomCheckBox1;
            this.guna2CustomCheckBox1.Size = new System.Drawing.Size(20, 20);
            this.guna2CustomCheckBox1.TabIndex = 23;
            this.guna2CustomCheckBox1.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(65)))), ((int)(((byte)(66)))));
            this.guna2CustomCheckBox1.UncheckedState.BorderRadius = 2;
            this.guna2CustomCheckBox1.UncheckedState.BorderThickness = 2;
            this.guna2CustomCheckBox1.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(4)))), ((int)(((byte)(5)))));
            this.guna2CustomCheckBox1.UncheckedState.Parent = this.guna2CustomCheckBox1;
            this.guna2CustomCheckBox1.UseTransparentBackground = true;
            this.guna2CustomCheckBox1.CheckedChanged += new System.EventHandler(this.guna2CustomCheckBox1_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Roboto Medium", 8F);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(124)))));
            this.label6.Location = new System.Drawing.Point(61, 213);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(250, 17);
            this.label6.TabIndex = 22;
            this.label6.Text = "Always Run Game in Full Screen Mode";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Roboto Medium", 8F);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(124)))));
            this.label5.Location = new System.Drawing.Point(224, 177);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 17);
            this.label5.TabIndex = 21;
            this.label5.Text = "Ultra High";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Roboto Medium", 8F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(124)))));
            this.label4.Location = new System.Drawing.Point(224, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 17);
            this.label4.TabIndex = 20;
            this.label4.Text = "High";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Roboto Medium", 8F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(124)))));
            this.label3.Location = new System.Drawing.Point(224, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 17);
            this.label3.TabIndex = 19;
            this.label3.Text = "Medium";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Roboto Medium", 8F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(124)))));
            this.label2.Location = new System.Drawing.Point(224, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 17);
            this.label2.TabIndex = 18;
            this.label2.Text = "Low";
            // 
            // cameraUHighCheckbox
            // 
            this.cameraUHighCheckbox.Animated = true;
            this.cameraUHighCheckbox.BackColor = System.Drawing.Color.Transparent;
            this.cameraUHighCheckbox.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(9)))), ((int)(((byte)(10)))));
            this.cameraUHighCheckbox.CheckedState.BorderThickness = 2;
            this.cameraUHighCheckbox.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(242)))));
            this.cameraUHighCheckbox.CheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.cameraUHighCheckbox.CheckedState.Parent = this.cameraUHighCheckbox;
            this.cameraUHighCheckbox.Location = new System.Drawing.Point(198, 174);
            this.cameraUHighCheckbox.Name = "cameraUHighCheckbox";
            this.cameraUHighCheckbox.ShadowDecoration.BorderRadius = 0;
            this.cameraUHighCheckbox.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(73)))), ((int)(((byte)(176)))));
            this.cameraUHighCheckbox.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.cameraUHighCheckbox.ShadowDecoration.Parent = this.cameraUHighCheckbox;
            this.cameraUHighCheckbox.Size = new System.Drawing.Size(20, 20);
            this.cameraUHighCheckbox.TabIndex = 17;
            this.cameraUHighCheckbox.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(65)))), ((int)(((byte)(66)))));
            this.cameraUHighCheckbox.UncheckedState.BorderThickness = 2;
            this.cameraUHighCheckbox.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(4)))), ((int)(((byte)(5)))));
            this.cameraUHighCheckbox.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.cameraUHighCheckbox.UncheckedState.Parent = this.cameraUHighCheckbox;
            this.cameraUHighCheckbox.UseTransparentBackground = true;
            this.cameraUHighCheckbox.CheckedChanged += new System.EventHandler(this.guna2CustomRadioButton1_CheckedChanged);
            // 
            // cameraHighCheckbox
            // 
            this.cameraHighCheckbox.Animated = true;
            this.cameraHighCheckbox.BackColor = System.Drawing.Color.Transparent;
            this.cameraHighCheckbox.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(9)))), ((int)(((byte)(10)))));
            this.cameraHighCheckbox.CheckedState.BorderThickness = 2;
            this.cameraHighCheckbox.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(242)))));
            this.cameraHighCheckbox.CheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.cameraHighCheckbox.CheckedState.Parent = this.cameraHighCheckbox;
            this.cameraHighCheckbox.Location = new System.Drawing.Point(198, 148);
            this.cameraHighCheckbox.Name = "cameraHighCheckbox";
            this.cameraHighCheckbox.ShadowDecoration.BorderRadius = 0;
            this.cameraHighCheckbox.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(73)))), ((int)(((byte)(176)))));
            this.cameraHighCheckbox.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.cameraHighCheckbox.ShadowDecoration.Parent = this.cameraHighCheckbox;
            this.cameraHighCheckbox.Size = new System.Drawing.Size(20, 20);
            this.cameraHighCheckbox.TabIndex = 16;
            this.cameraHighCheckbox.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(65)))), ((int)(((byte)(66)))));
            this.cameraHighCheckbox.UncheckedState.BorderThickness = 2;
            this.cameraHighCheckbox.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(4)))), ((int)(((byte)(5)))));
            this.cameraHighCheckbox.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.cameraHighCheckbox.UncheckedState.Parent = this.cameraHighCheckbox;
            this.cameraHighCheckbox.UseTransparentBackground = true;
            this.cameraHighCheckbox.CheckedChanged += new System.EventHandler(this.guna2CustomRadioButton1_CheckedChanged);
            // 
            // cameraMedCheckbox
            // 
            this.cameraMedCheckbox.Animated = true;
            this.cameraMedCheckbox.BackColor = System.Drawing.Color.Transparent;
            this.cameraMedCheckbox.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(9)))), ((int)(((byte)(10)))));
            this.cameraMedCheckbox.CheckedState.BorderThickness = 2;
            this.cameraMedCheckbox.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(242)))));
            this.cameraMedCheckbox.CheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.cameraMedCheckbox.CheckedState.Parent = this.cameraMedCheckbox;
            this.cameraMedCheckbox.Location = new System.Drawing.Point(198, 122);
            this.cameraMedCheckbox.Name = "cameraMedCheckbox";
            this.cameraMedCheckbox.ShadowDecoration.BorderRadius = 0;
            this.cameraMedCheckbox.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(73)))), ((int)(((byte)(176)))));
            this.cameraMedCheckbox.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.cameraMedCheckbox.ShadowDecoration.Parent = this.cameraMedCheckbox;
            this.cameraMedCheckbox.Size = new System.Drawing.Size(20, 20);
            this.cameraMedCheckbox.TabIndex = 15;
            this.cameraMedCheckbox.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(65)))), ((int)(((byte)(66)))));
            this.cameraMedCheckbox.UncheckedState.BorderThickness = 2;
            this.cameraMedCheckbox.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(4)))), ((int)(((byte)(5)))));
            this.cameraMedCheckbox.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.cameraMedCheckbox.UncheckedState.Parent = this.cameraMedCheckbox;
            this.cameraMedCheckbox.UseTransparentBackground = true;
            this.cameraMedCheckbox.CheckedChanged += new System.EventHandler(this.guna2CustomRadioButton1_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Roboto Medium", 7F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(124)))));
            this.label1.Location = new System.Drawing.Point(32, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 14);
            this.label1.TabIndex = 14;
            this.label1.Text = "Camera View Range:";
            // 
            // cameraLowCheckbox
            // 
            this.cameraLowCheckbox.Animated = true;
            this.cameraLowCheckbox.BackColor = System.Drawing.Color.Transparent;
            this.cameraLowCheckbox.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(9)))), ((int)(((byte)(10)))));
            this.cameraLowCheckbox.CheckedState.BorderThickness = 2;
            this.cameraLowCheckbox.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(242)))));
            this.cameraLowCheckbox.CheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.cameraLowCheckbox.CheckedState.Parent = this.cameraLowCheckbox;
            this.cameraLowCheckbox.Location = new System.Drawing.Point(198, 96);
            this.cameraLowCheckbox.Name = "cameraLowCheckbox";
            this.cameraLowCheckbox.ShadowDecoration.BorderRadius = 0;
            this.cameraLowCheckbox.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(73)))), ((int)(((byte)(176)))));
            this.cameraLowCheckbox.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.cameraLowCheckbox.ShadowDecoration.Parent = this.cameraLowCheckbox;
            this.cameraLowCheckbox.Size = new System.Drawing.Size(20, 20);
            this.cameraLowCheckbox.TabIndex = 13;
            this.cameraLowCheckbox.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(65)))), ((int)(((byte)(66)))));
            this.cameraLowCheckbox.UncheckedState.BorderThickness = 2;
            this.cameraLowCheckbox.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(4)))), ((int)(((byte)(5)))));
            this.cameraLowCheckbox.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.cameraLowCheckbox.UncheckedState.Parent = this.cameraLowCheckbox;
            this.cameraLowCheckbox.UseTransparentBackground = true;
            this.cameraLowCheckbox.CheckedChanged += new System.EventHandler(this.guna2CustomRadioButton1_CheckedChanged);
            // 
            // guna2CustomCheckBox2
            // 
            this.guna2CustomCheckBox2.Animated = true;
            this.guna2CustomCheckBox2.BackColor = System.Drawing.Color.Transparent;
            this.guna2CustomCheckBox2.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(9)))), ((int)(((byte)(10)))));
            this.guna2CustomCheckBox2.CheckedState.BorderRadius = 2;
            this.guna2CustomCheckBox2.CheckedState.BorderThickness = 2;
            this.guna2CustomCheckBox2.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(242)))));
            this.guna2CustomCheckBox2.CheckedState.Parent = this.guna2CustomCheckBox2;
            this.guna2CustomCheckBox2.CheckMarkColor = System.Drawing.Color.Transparent;
            this.guna2CustomCheckBox2.Location = new System.Drawing.Point(35, 211);
            this.guna2CustomCheckBox2.Name = "guna2CustomCheckBox2";
            this.guna2CustomCheckBox2.ShadowDecoration.BorderRadius = 0;
            this.guna2CustomCheckBox2.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(73)))), ((int)(((byte)(176)))));
            this.guna2CustomCheckBox2.ShadowDecoration.Parent = this.guna2CustomCheckBox2;
            this.guna2CustomCheckBox2.Size = new System.Drawing.Size(20, 20);
            this.guna2CustomCheckBox2.TabIndex = 12;
            this.guna2CustomCheckBox2.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(65)))), ((int)(((byte)(66)))));
            this.guna2CustomCheckBox2.UncheckedState.BorderRadius = 2;
            this.guna2CustomCheckBox2.UncheckedState.BorderThickness = 2;
            this.guna2CustomCheckBox2.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(4)))), ((int)(((byte)(5)))));
            this.guna2CustomCheckBox2.UncheckedState.Parent = this.guna2CustomCheckBox2;
            this.guna2CustomCheckBox2.UseTransparentBackground = true;
            this.guna2CustomCheckBox2.CheckedChanged += new System.EventHandler(this.guna2CustomCheckBox1_CheckedChanged);
            // 
            // guna2PictureBox2
            // 
            this.guna2PictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox2.Image")));
            this.guna2PictureBox2.Location = new System.Drawing.Point(35, 53);
            this.guna2PictureBox2.Name = "guna2PictureBox2";
            this.guna2PictureBox2.ShadowDecoration.Parent = this.guna2PictureBox2;
            this.guna2PictureBox2.Size = new System.Drawing.Size(283, 25);
            this.guna2PictureBox2.TabIndex = 11;
            this.guna2PictureBox2.TabStop = false;
            this.guna2PictureBox2.UseTransparentBackground = true;
            // 
            // minimiseButton
            // 
            this.minimiseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.minimiseButton.BorderColor = System.Drawing.Color.Transparent;
            this.minimiseButton.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.minimiseButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(43)))), ((int)(((byte)(44)))));
            this.minimiseButton.HoverState.Parent = this.minimiseButton;
            this.minimiseButton.IconColor = System.Drawing.Color.White;
            this.minimiseButton.Location = new System.Drawing.Point(965, 1);
            this.minimiseButton.Name = "minimiseButton";
            this.minimiseButton.ShadowDecoration.Parent = this.minimiseButton;
            this.minimiseButton.Size = new System.Drawing.Size(45, 29);
            this.minimiseButton.TabIndex = 7;
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(43)))), ((int)(((byte)(44)))));
            this.closeButton.HoverState.Parent = this.closeButton;
            this.closeButton.IconColor = System.Drawing.Color.White;
            this.closeButton.Location = new System.Drawing.Point(1010, 1);
            this.closeButton.Name = "closeButton";
            this.closeButton.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.closeButton.ShadowDecoration.Parent = this.closeButton;
            this.closeButton.Size = new System.Drawing.Size(45, 29);
            this.closeButton.TabIndex = 6;
            // 
            // SettingsF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 582);
            this.Controls.Add(this.settingsPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsF";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KOPO";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsF_FormClosing);
            this.Load += new System.EventHandler(this.SettingsF_Load);
            this.settingsPanel.ResumeLayout(false);
            this.settingsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna2DragControl guna2DragControl1;
        private Guna2GradientPanel settingsPanel;
        private Label label34;
        private Label label33;
        private Guna2CustomCheckBox guna2CustomCheckBox13;
        private Label label31;
        private Label label29;
        private Guna2CustomCheckBox guna2CustomCheckBox12;
        private Label label27;
        private Guna2CustomCheckBox guna2CustomCheckBox11;
        private Guna2PictureBox guna2PictureBox4;
        private Label label25;
        private Guna2CustomCheckBox guna2CustomCheckBox10;
        private Guna2GradientButton ResetButton;
        private Guna2GradientButton ApplyButton;
        private Guna2PictureBox guna2PictureBox1;
        private Label label12;
        private Guna2CustomCheckBox guna2CustomCheckBox7;
        private Label label11;
        private Guna2CustomCheckBox guna2CustomCheckBox6;
        private Label label10;
        private Guna2CustomCheckBox guna2CustomCheckBox5;
        private Label label9;
        private Guna2CustomCheckBox guna2CustomCheckBox4;
        private Label label8;
        private Guna2CustomCheckBox guna2CustomCheckBox3;
        private Label label7;
        private Guna2CustomCheckBox guna2CustomCheckBox1;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Guna2CustomRadioButton cameraUHighCheckbox;
        private Guna2CustomRadioButton cameraHighCheckbox;
        private Guna2CustomRadioButton cameraMedCheckbox;
        private Label label1;
        private Guna2CustomRadioButton cameraLowCheckbox;
        private Guna2CustomCheckBox guna2CustomCheckBox2;
        private Guna2PictureBox guna2PictureBox2;
        private Guna2ControlBox minimiseButton;
        private Guna2ControlBox closeButton;
        private Label label35;
        private Guna2CustomCheckBox guna2CustomCheckBox14;
    }
}