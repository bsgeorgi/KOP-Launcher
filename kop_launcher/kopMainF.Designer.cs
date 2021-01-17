using System.ComponentModel;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace kop_launcher
{
    partial class KopmainF
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KopmainF));
			this.mainPanel = new Guna.UI2.WinForms.Guna2Panel();
			this.label24 = new System.Windows.Forms.Label();
			this.label23 = new System.Windows.Forms.Label();
			this.label22 = new System.Windows.Forms.Label();
			this.package4 = new Guna.UI2.WinForms.Guna2PictureBox();
			this.package3 = new Guna.UI2.WinForms.Guna2PictureBox();
			this.package2 = new Guna.UI2.WinForms.Guna2PictureBox();
			this.package1 = new Guna.UI2.WinForms.Guna2PictureBox();
			this.regionsBox = new Guna.UI2.WinForms.Guna2ComboBox();
			this.label19 = new System.Windows.Forms.Label();
			this.label20 = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.itemShopPanel = new Guna.UI2.WinForms.Guna2PictureBox();
			this.rankingPanel = new Guna.UI2.WinForms.Guna2PictureBox();
			this.label15 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.StartGameButton = new Guna.UI2.WinForms.Guna2PictureBox();
			this.leftSidebar = new Guna.UI2.WinForms.Guna2Panel();
			this.settingsButton = new System.Windows.Forms.PictureBox();
			this.forumButton = new System.Windows.Forms.PictureBox();
			this.mailButton = new System.Windows.Forms.PictureBox();
			this.instagramButton = new System.Windows.Forms.PictureBox();
			this.facebookButton = new System.Windows.Forms.PictureBox();
			this.faDiscordBtn = new System.Windows.Forms.PictureBox();
			this.mainBanner = new Guna.UI2.WinForms.Guna2PictureBox();
			this.topContainer = new Guna.UI2.WinForms.Guna2Panel();
			this.label21 = new System.Windows.Forms.Label();
			this.minimiseButton = new Guna.UI2.WinForms.Guna2ControlBox();
			this.closeButton = new Guna.UI2.WinForms.Guna2ControlBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
			this.guna2DragControl2 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
			this.guna2DragControl3 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
			this.guna2DragControl4 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
			this.guna2DragControl5 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
			this.guna2DragControl6 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
			this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.updateStatisticsTimer = new System.Windows.Forms.Timer(this.components);
			this.SecurityTimer = new System.Windows.Forms.Timer(this.components);
			this.SecurityBackgroundWorker = new System.ComponentModel.BackgroundWorker();
			this.CheckHasheshBW = new System.ComponentModel.BackgroundWorker();
			this.UpdateHashesTimer = new System.Windows.Forms.Timer(this.components);
			this.mainPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.package4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.package3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.package2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.package1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.itemShopPanel)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.rankingPanel)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.StartGameButton)).BeginInit();
			this.leftSidebar.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.settingsButton)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.forumButton)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.mailButton)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.instagramButton)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.facebookButton)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.faDiscordBtn)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.mainBanner)).BeginInit();
			this.topContainer.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainPanel
			// 
			this.mainPanel.Controls.Add(this.label24);
			this.mainPanel.Controls.Add(this.label23);
			this.mainPanel.Controls.Add(this.label22);
			this.mainPanel.Controls.Add(this.package4);
			this.mainPanel.Controls.Add(this.package3);
			this.mainPanel.Controls.Add(this.package2);
			this.mainPanel.Controls.Add(this.package1);
			this.mainPanel.Controls.Add(this.regionsBox);
			this.mainPanel.Controls.Add(this.label19);
			this.mainPanel.Controls.Add(this.label20);
			this.mainPanel.Controls.Add(this.label18);
			this.mainPanel.Controls.Add(this.label17);
			this.mainPanel.Controls.Add(this.itemShopPanel);
			this.mainPanel.Controls.Add(this.rankingPanel);
			this.mainPanel.Controls.Add(this.label15);
			this.mainPanel.Controls.Add(this.label16);
			this.mainPanel.Controls.Add(this.label13);
			this.mainPanel.Controls.Add(this.label14);
			this.mainPanel.Controls.Add(this.label11);
			this.mainPanel.Controls.Add(this.label12);
			this.mainPanel.Controls.Add(this.label9);
			this.mainPanel.Controls.Add(this.label10);
			this.mainPanel.Controls.Add(this.label7);
			this.mainPanel.Controls.Add(this.label8);
			this.mainPanel.Controls.Add(this.label6);
			this.mainPanel.Controls.Add(this.label5);
			this.mainPanel.Controls.Add(this.StartGameButton);
			this.mainPanel.Controls.Add(this.leftSidebar);
			this.mainPanel.Controls.Add(this.mainBanner);
			this.mainPanel.Controls.Add(this.topContainer);
			this.mainPanel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(13)))), ((int)(((byte)(21)))));
			this.mainPanel.Location = new System.Drawing.Point(0, 0);
			this.mainPanel.Name = "mainPanel";
			this.mainPanel.ShadowDecoration.Parent = this.mainPanel;
			this.mainPanel.Size = new System.Drawing.Size(1160, 640);
			this.mainPanel.TabIndex = 0;
			// 
			// label24
			// 
			this.label24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(26)))), ((int)(((byte)(39)))));
			this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
			this.label24.ForeColor = System.Drawing.Color.White;
			this.label24.Location = new System.Drawing.Point(103, 443);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(387, 21);
			this.label24.TabIndex = 29;
			this.label24.Text = "Ranking is based on experience, gold and overall play time";
			// 
			// label23
			// 
			this.label23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(26)))), ((int)(((byte)(39)))));
			this.label23.Cursor = System.Windows.Forms.Cursors.Hand;
			this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
			this.label23.ForeColor = System.Drawing.Color.LightSalmon;
			this.label23.Location = new System.Drawing.Point(911, 427);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(118, 21);
			this.label23.TabIndex = 28;
			this.label23.Text = "kingofpirates.net";
			this.label23.Click += new System.EventHandler(this.label23_Click);
			// 
			// label22
			// 
			this.label22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(26)))), ((int)(((byte)(39)))));
			this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
			this.label22.ForeColor = System.Drawing.Color.White;
			this.label22.Location = new System.Drawing.Point(549, 443);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(548, 21);
			this.label22.TabIndex = 27;
			this.label22.Text = "To do so, please login your account and click on «Item Shop» category on account " +
    "menu";
			// 
			// package4
			// 
			this.package4.BackColor = System.Drawing.Color.Transparent;
			this.package4.Cursor = System.Windows.Forms.Cursors.Hand;
			this.package4.Image = ((System.Drawing.Image)(resources.GetObject("package4.Image")));
			this.package4.Location = new System.Drawing.Point(961, 485);
			this.package4.Name = "package4";
			this.package4.ShadowDecoration.Parent = this.package4;
			this.package4.Size = new System.Drawing.Size(104, 118);
			this.package4.TabIndex = 26;
			this.package4.TabStop = false;
			this.package4.UseTransparentBackground = true;
			this.package4.Click += new System.EventHandler(this.package4_Click);
			this.package4.MouseEnter += new System.EventHandler(this.package1_MouseEnter);
			this.package4.MouseLeave += new System.EventHandler(this.package1_MouseLeave);
			this.package4.MouseHover += new System.EventHandler(this.package1_MouseEnter);
			// 
			// package3
			// 
			this.package3.BackColor = System.Drawing.Color.Transparent;
			this.package3.Cursor = System.Windows.Forms.Cursors.Hand;
			this.package3.Image = ((System.Drawing.Image)(resources.GetObject("package3.Image")));
			this.package3.Location = new System.Drawing.Point(826, 485);
			this.package3.Name = "package3";
			this.package3.ShadowDecoration.Parent = this.package3;
			this.package3.Size = new System.Drawing.Size(104, 118);
			this.package3.TabIndex = 25;
			this.package3.TabStop = false;
			this.package3.UseTransparentBackground = true;
			this.package3.Click += new System.EventHandler(this.package4_Click);
			this.package3.MouseEnter += new System.EventHandler(this.package1_MouseEnter);
			this.package3.MouseLeave += new System.EventHandler(this.package1_MouseLeave);
			this.package3.MouseHover += new System.EventHandler(this.package1_MouseEnter);
			// 
			// package2
			// 
			this.package2.BackColor = System.Drawing.Color.Transparent;
			this.package2.Cursor = System.Windows.Forms.Cursors.Hand;
			this.package2.Image = ((System.Drawing.Image)(resources.GetObject("package2.Image")));
			this.package2.Location = new System.Drawing.Point(689, 485);
			this.package2.Name = "package2";
			this.package2.ShadowDecoration.Parent = this.package2;
			this.package2.Size = new System.Drawing.Size(104, 118);
			this.package2.TabIndex = 24;
			this.package2.TabStop = false;
			this.package2.UseTransparentBackground = true;
			this.package2.Click += new System.EventHandler(this.package4_Click);
			this.package2.MouseEnter += new System.EventHandler(this.package1_MouseEnter);
			this.package2.MouseLeave += new System.EventHandler(this.package1_MouseLeave);
			this.package2.MouseHover += new System.EventHandler(this.package1_MouseEnter);
			// 
			// package1
			// 
			this.package1.BackColor = System.Drawing.Color.Transparent;
			this.package1.Cursor = System.Windows.Forms.Cursors.Hand;
			this.package1.Image = ((System.Drawing.Image)(resources.GetObject("package1.Image")));
			this.package1.Location = new System.Drawing.Point(552, 485);
			this.package1.Name = "package1";
			this.package1.ShadowDecoration.Parent = this.package1;
			this.package1.Size = new System.Drawing.Size(104, 118);
			this.package1.TabIndex = 23;
			this.package1.TabStop = false;
			this.package1.UseTransparentBackground = true;
			this.package1.Click += new System.EventHandler(this.package4_Click);
			this.package1.MouseEnter += new System.EventHandler(this.package1_MouseEnter);
			this.package1.MouseLeave += new System.EventHandler(this.package1_MouseLeave);
			this.package1.MouseHover += new System.EventHandler(this.package1_MouseEnter);
			// 
			// regionsBox
			// 
			this.regionsBox.BackColor = System.Drawing.Color.Transparent;
			this.regionsBox.BorderThickness = 0;
			this.regionsBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.regionsBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.regionsBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(36)))), ((int)(((byte)(52)))));
			this.regionsBox.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
			this.regionsBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
			this.regionsBox.FocusedState.Parent = this.regionsBox;
			this.regionsBox.Font = new System.Drawing.Font("Segoe UI", 10F);
			this.regionsBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(199)))), ((int)(((byte)(202)))));
			this.regionsBox.HoverState.BorderColor = System.Drawing.Color.Transparent;
			this.regionsBox.HoverState.Parent = this.regionsBox;
			this.regionsBox.ItemHeight = 30;
			this.regionsBox.Items.AddRange(new object[] {
            "Select Region"});
			this.regionsBox.ItemsAppearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(51)))), ((int)(((byte)(68)))));
			this.regionsBox.ItemsAppearance.Parent = this.regionsBox;
			this.regionsBox.Location = new System.Drawing.Point(513, 243);
			this.regionsBox.Name = "regionsBox";
			this.regionsBox.ShadowDecoration.Parent = this.regionsBox;
			this.regionsBox.Size = new System.Drawing.Size(154, 36);
			this.regionsBox.TabIndex = 22;
			this.regionsBox.SelectedIndexChanged += new System.EventHandler(this.regionsBox_SelectedIndexChanged);
			// 
			// label19
			// 
			this.label19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(26)))), ((int)(((byte)(39)))));
			this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
			this.label19.ForeColor = System.Drawing.Color.White;
			this.label19.Location = new System.Drawing.Point(549, 427);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(370, 21);
			this.label19.TabIndex = 21;
			this.label19.Text = "You can purchase the following packages on our website at";
			// 
			// label20
			// 
			this.label20.AutoSize = true;
			this.label20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(26)))), ((int)(((byte)(39)))));
			this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label20.ForeColor = System.Drawing.Color.White;
			this.label20.Location = new System.Drawing.Point(548, 406);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(82, 15);
			this.label20.TabIndex = 20;
			this.label20.Text = "ITEM SHOP";
			// 
			// label18
			// 
			this.label18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(26)))), ((int)(((byte)(39)))));
			this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
			this.label18.ForeColor = System.Drawing.Color.White;
			this.label18.Location = new System.Drawing.Point(103, 427);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(387, 21);
			this.label18.TabIndex = 19;
			this.label18.Text = "The ranking below displays the best 3 players in King of Pirates";
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(26)))), ((int)(((byte)(39)))));
			this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label17.ForeColor = System.Drawing.Color.White;
			this.label17.Location = new System.Drawing.Point(102, 406);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(120, 15);
			this.label17.TabIndex = 18;
			this.label17.Text = "PIRATE RANKING";
			// 
			// itemShopPanel
			// 
			this.itemShopPanel.BackColor = System.Drawing.Color.Transparent;
			this.itemShopPanel.Image = ((System.Drawing.Image)(resources.GetObject("itemShopPanel.Image")));
			this.itemShopPanel.Location = new System.Drawing.Point(528, 391);
			this.itemShopPanel.Name = "itemShopPanel";
			this.itemShopPanel.ShadowDecoration.Parent = this.itemShopPanel;
			this.itemShopPanel.Size = new System.Drawing.Size(569, 222);
			this.itemShopPanel.TabIndex = 17;
			this.itemShopPanel.TabStop = false;
			this.itemShopPanel.UseTransparentBackground = true;
			this.itemShopPanel.WaitOnLoad = true;
			// 
			// rankingPanel
			// 
			this.rankingPanel.BackColor = System.Drawing.Color.Transparent;
			this.rankingPanel.Image = ((System.Drawing.Image)(resources.GetObject("rankingPanel.Image")));
			this.rankingPanel.Location = new System.Drawing.Point(83, 391);
			this.rankingPanel.Name = "rankingPanel";
			this.rankingPanel.ShadowDecoration.Parent = this.rankingPanel;
			this.rankingPanel.Size = new System.Drawing.Size(416, 222);
			this.rankingPanel.TabIndex = 16;
			this.rankingPanel.TabStop = false;
			this.rankingPanel.UseTransparentBackground = true;
			this.rankingPanel.WaitOnLoad = true;
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(21)))), ((int)(((byte)(38)))));
			this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label15.ForeColor = System.Drawing.Color.White;
			this.label15.Location = new System.Drawing.Point(984, 356);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(11, 13);
			this.label15.TabIndex = 15;
			this.label15.Text = "-";
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(21)))), ((int)(((byte)(38)))));
			this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
			this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(114)))), ((int)(((byte)(190)))));
			this.label16.Location = new System.Drawing.Point(984, 339);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(89, 13);
			this.label16.TabIndex = 14;
			this.label16.Text = "Game Version:";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(21)))), ((int)(((byte)(38)))));
			this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label13.ForeColor = System.Drawing.Color.LimeGreen;
			this.label13.Location = new System.Drawing.Point(847, 356);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(11, 13);
			this.label13.TabIndex = 13;
			this.label13.Text = "-";
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(21)))), ((int)(((byte)(38)))));
			this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
			this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(114)))), ((int)(((byte)(190)))));
			this.label14.Location = new System.Drawing.Point(847, 339);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(97, 13);
			this.label14.TabIndex = 12;
			this.label14.Text = "Website Status:";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(21)))), ((int)(((byte)(38)))));
			this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label11.ForeColor = System.Drawing.Color.LimeGreen;
			this.label11.Location = new System.Drawing.Point(709, 356);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(11, 13);
			this.label11.TabIndex = 11;
			this.label11.Text = "-";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(21)))), ((int)(((byte)(38)))));
			this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
			this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(114)))), ((int)(((byte)(190)))));
			this.label12.Location = new System.Drawing.Point(709, 339);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(88, 13);
			this.label12.TabIndex = 10;
			this.label12.Text = "Server Status:";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(21)))), ((int)(((byte)(38)))));
			this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label9.ForeColor = System.Drawing.Color.White;
			this.label9.Location = new System.Drawing.Point(364, 356);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(14, 13);
			this.label9.TabIndex = 9;
			this.label9.Text = "0";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(21)))), ((int)(((byte)(38)))));
			this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
			this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(114)))), ((int)(((byte)(190)))));
			this.label10.Location = new System.Drawing.Point(364, 339);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(105, 13);
			this.label10.TabIndex = 8;
			this.label10.Text = "Total Characters:";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(21)))), ((int)(((byte)(38)))));
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label7.ForeColor = System.Drawing.Color.White;
			this.label7.Location = new System.Drawing.Point(241, 356);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(14, 13);
			this.label7.TabIndex = 7;
			this.label7.Text = "0";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(21)))), ((int)(((byte)(38)))));
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
			this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(114)))), ((int)(((byte)(190)))));
			this.label8.Location = new System.Drawing.Point(241, 339);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(97, 13);
			this.label8.TabIndex = 6;
			this.label8.Text = "Total Accounts:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(21)))), ((int)(((byte)(38)))));
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label6.ForeColor = System.Drawing.Color.White;
			this.label6.Location = new System.Drawing.Point(100, 356);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(14, 13);
			this.label6.TabIndex = 5;
			this.label6.Text = "0";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(21)))), ((int)(((byte)(38)))));
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
			this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(114)))), ((int)(((byte)(190)))));
			this.label5.Location = new System.Drawing.Point(100, 339);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(101, 13);
			this.label5.TabIndex = 4;
			this.label5.Text = "Currently Online:";
			// 
			// StartGameButton
			// 
			this.StartGameButton.BackColor = System.Drawing.Color.Transparent;
			this.StartGameButton.Image = ((System.Drawing.Image)(resources.GetObject("StartGameButton.Image")));
			this.StartGameButton.Location = new System.Drawing.Point(489, 290);
			this.StartGameButton.Name = "StartGameButton";
			this.StartGameButton.ShadowDecoration.Parent = this.StartGameButton;
			this.StartGameButton.Size = new System.Drawing.Size(203, 60);
			this.StartGameButton.TabIndex = 3;
			this.StartGameButton.TabStop = false;
			this.StartGameButton.UseTransparentBackground = true;
			this.StartGameButton.Click += new System.EventHandler(this.StartGameButton_Click);
			this.StartGameButton.MouseEnter += new System.EventHandler(this.StartGameButton_MouseHover);
			this.StartGameButton.MouseLeave += new System.EventHandler(this.StartGameButton_MouseLeave);
			this.StartGameButton.MouseHover += new System.EventHandler(this.StartGameButton_MouseHover);
			// 
			// leftSidebar
			// 
			this.leftSidebar.BackColor = System.Drawing.Color.Transparent;
			this.leftSidebar.Controls.Add(this.settingsButton);
			this.leftSidebar.Controls.Add(this.forumButton);
			this.leftSidebar.Controls.Add(this.mailButton);
			this.leftSidebar.Controls.Add(this.instagramButton);
			this.leftSidebar.Controls.Add(this.facebookButton);
			this.leftSidebar.Controls.Add(this.faDiscordBtn);
			this.leftSidebar.FillColor = System.Drawing.Color.Transparent;
			this.leftSidebar.Location = new System.Drawing.Point(0, 3);
			this.leftSidebar.Name = "leftSidebar";
			this.leftSidebar.ShadowDecoration.Parent = this.leftSidebar;
			this.leftSidebar.Size = new System.Drawing.Size(83, 640);
			this.leftSidebar.TabIndex = 0;
			// 
			// settingsButton
			// 
			this.settingsButton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.settingsButton.Image = ((System.Drawing.Image)(resources.GetObject("settingsButton.Image")));
			this.settingsButton.Location = new System.Drawing.Point(0, 500);
			this.settingsButton.Name = "settingsButton";
			this.settingsButton.Size = new System.Drawing.Size(84, 52);
			this.settingsButton.TabIndex = 5;
			this.settingsButton.TabStop = false;
			this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
			this.settingsButton.MouseEnter += new System.EventHandler(this.ButtonS_MouseEnter);
			this.settingsButton.MouseLeave += new System.EventHandler(this.ButtonS_MouseLeave);
			this.settingsButton.MouseHover += new System.EventHandler(this.ButtonS_MouseEnter);
			// 
			// forumButton
			// 
			this.forumButton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.forumButton.Image = ((System.Drawing.Image)(resources.GetObject("forumButton.Image")));
			this.forumButton.Location = new System.Drawing.Point(0, 266);
			this.forumButton.Name = "forumButton";
			this.forumButton.Size = new System.Drawing.Size(84, 52);
			this.forumButton.TabIndex = 4;
			this.forumButton.TabStop = false;
			this.forumButton.Click += new System.EventHandler(this.forumButton_Click);
			this.forumButton.MouseEnter += new System.EventHandler(this.ButtonS_MouseEnter);
			this.forumButton.MouseLeave += new System.EventHandler(this.ButtonS_MouseLeave);
			this.forumButton.MouseHover += new System.EventHandler(this.ButtonS_MouseEnter);
			// 
			// mailButton
			// 
			this.mailButton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.mailButton.Image = ((System.Drawing.Image)(resources.GetObject("mailButton.Image")));
			this.mailButton.Location = new System.Drawing.Point(0, 215);
			this.mailButton.Name = "mailButton";
			this.mailButton.Size = new System.Drawing.Size(84, 52);
			this.mailButton.TabIndex = 3;
			this.mailButton.TabStop = false;
			this.mailButton.Click += new System.EventHandler(this.mailButton_Click);
			this.mailButton.MouseEnter += new System.EventHandler(this.ButtonS_MouseEnter);
			this.mailButton.MouseLeave += new System.EventHandler(this.ButtonS_MouseLeave);
			this.mailButton.MouseHover += new System.EventHandler(this.ButtonS_MouseEnter);
			// 
			// instagramButton
			// 
			this.instagramButton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.instagramButton.Image = ((System.Drawing.Image)(resources.GetObject("instagramButton.Image")));
			this.instagramButton.Location = new System.Drawing.Point(0, 164);
			this.instagramButton.Name = "instagramButton";
			this.instagramButton.Size = new System.Drawing.Size(84, 52);
			this.instagramButton.TabIndex = 2;
			this.instagramButton.TabStop = false;
			this.instagramButton.Click += new System.EventHandler(this.instagramButton_Click);
			this.instagramButton.MouseEnter += new System.EventHandler(this.ButtonS_MouseEnter);
			this.instagramButton.MouseLeave += new System.EventHandler(this.ButtonS_MouseLeave);
			this.instagramButton.MouseHover += new System.EventHandler(this.ButtonS_MouseEnter);
			// 
			// facebookButton
			// 
			this.facebookButton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.facebookButton.Image = ((System.Drawing.Image)(resources.GetObject("facebookButton.Image")));
			this.facebookButton.Location = new System.Drawing.Point(0, 113);
			this.facebookButton.Name = "facebookButton";
			this.facebookButton.Size = new System.Drawing.Size(84, 52);
			this.facebookButton.TabIndex = 1;
			this.facebookButton.TabStop = false;
			this.facebookButton.Click += new System.EventHandler(this.facebookButton_Click);
			this.facebookButton.MouseEnter += new System.EventHandler(this.ButtonS_MouseEnter);
			this.facebookButton.MouseLeave += new System.EventHandler(this.ButtonS_MouseLeave);
			this.facebookButton.MouseHover += new System.EventHandler(this.ButtonS_MouseEnter);
			// 
			// faDiscordBtn
			// 
			this.faDiscordBtn.Cursor = System.Windows.Forms.Cursors.Hand;
			this.faDiscordBtn.Image = ((System.Drawing.Image)(resources.GetObject("faDiscordBtn.Image")));
			this.faDiscordBtn.Location = new System.Drawing.Point(0, 62);
			this.faDiscordBtn.Name = "faDiscordBtn";
			this.faDiscordBtn.Size = new System.Drawing.Size(84, 52);
			this.faDiscordBtn.TabIndex = 0;
			this.faDiscordBtn.TabStop = false;
			this.faDiscordBtn.Click += new System.EventHandler(this.faDiscordBtn_Click);
			// 
			// mainBanner
			// 
			this.mainBanner.BackColor = System.Drawing.Color.Transparent;
			this.mainBanner.Image = ((System.Drawing.Image)(resources.GetObject("mainBanner.Image")));
			this.mainBanner.Location = new System.Drawing.Point(83, 65);
			this.mainBanner.Name = "mainBanner";
			this.mainBanner.ShadowDecoration.Parent = this.mainBanner;
			this.mainBanner.Size = new System.Drawing.Size(1014, 313);
			this.mainBanner.TabIndex = 2;
			this.mainBanner.TabStop = false;
			this.mainBanner.WaitOnLoad = true;
			// 
			// topContainer
			// 
			this.topContainer.Controls.Add(this.label21);
			this.topContainer.Controls.Add(this.minimiseButton);
			this.topContainer.Controls.Add(this.closeButton);
			this.topContainer.Controls.Add(this.label4);
			this.topContainer.Controls.Add(this.label3);
			this.topContainer.Controls.Add(this.label2);
			this.topContainer.Controls.Add(this.label1);
			this.topContainer.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(21)))), ((int)(((byte)(33)))));
			this.topContainer.Location = new System.Drawing.Point(83, 0);
			this.topContainer.Name = "topContainer";
			this.topContainer.ShadowDecoration.Parent = this.topContainer;
			this.topContainer.Size = new System.Drawing.Size(1077, 163);
			this.topContainer.TabIndex = 1;
			// 
			// label21
			// 
			this.label21.AutoSize = true;
			this.label21.BackColor = System.Drawing.Color.Transparent;
			this.label21.Cursor = System.Windows.Forms.Cursors.Hand;
			this.label21.Font = new System.Drawing.Font("Segoe UI", 10F);
			this.label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(138)))), ((int)(((byte)(172)))));
			this.label21.Location = new System.Drawing.Point(807, 23);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(141, 19);
			this.label21.TabIndex = 6;
			this.label21.Text = "Server Time: 00:00:00";
			// 
			// minimiseButton
			// 
			this.minimiseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.minimiseButton.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
			this.minimiseButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(21)))), ((int)(((byte)(33)))));
			this.minimiseButton.HoverState.Parent = this.minimiseButton;
			this.minimiseButton.IconColor = System.Drawing.Color.White;
			this.minimiseButton.Location = new System.Drawing.Point(987, 0);
			this.minimiseButton.Name = "minimiseButton";
			this.minimiseButton.ShadowDecoration.Parent = this.minimiseButton;
			this.minimiseButton.Size = new System.Drawing.Size(45, 29);
			this.minimiseButton.TabIndex = 5;
			// 
			// closeButton
			// 
			this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.closeButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(21)))), ((int)(((byte)(33)))));
			this.closeButton.HoverState.Parent = this.closeButton;
			this.closeButton.IconColor = System.Drawing.Color.White;
			this.closeButton.Location = new System.Drawing.Point(1032, 0);
			this.closeButton.Name = "closeButton";
			this.closeButton.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
			this.closeButton.ShadowDecoration.Parent = this.closeButton;
			this.closeButton.Size = new System.Drawing.Size(45, 29);
			this.closeButton.TabIndex = 4;
			this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.BackColor = System.Drawing.Color.Transparent;
			this.label4.Cursor = System.Windows.Forms.Cursors.Hand;
			this.label4.Font = new System.Drawing.Font("Segoe UI", 10F);
			this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(138)))), ((int)(((byte)(172)))));
			this.label4.Location = new System.Drawing.Point(540, 23);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(58, 19);
			this.label4.TabIndex = 3;
			this.label4.Text = "Support";
			this.label4.Click += new System.EventHandler(this.mailButton_Click);
			this.label4.MouseEnter += new System.EventHandler(this.label4_MouseEnter);
			this.label4.MouseLeave += new System.EventHandler(this.label4_MouseLeave);
			this.label4.MouseHover += new System.EventHandler(this.label4_MouseEnter);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
			this.label3.Font = new System.Drawing.Font("Segoe UI", 10F);
			this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(138)))), ((int)(((byte)(172)))));
			this.label3.Location = new System.Drawing.Point(280, 23);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(181, 19);
			this.label3.TabIndex = 2;
			this.label3.Text = "Frequently Asked Questions";
			this.label3.MouseEnter += new System.EventHandler(this.label4_MouseEnter);
			this.label3.MouseLeave += new System.EventHandler(this.label4_MouseLeave);
			this.label3.MouseHover += new System.EventHandler(this.label4_MouseEnter);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
			this.label2.Font = new System.Drawing.Font("Segoe UI", 10F);
			this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(138)))), ((int)(((byte)(172)))));
			this.label2.Location = new System.Drawing.Point(148, 23);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(81, 19);
			this.label2.TabIndex = 1;
			this.label2.Text = "Game Rules";
			this.label2.MouseEnter += new System.EventHandler(this.label4_MouseEnter);
			this.label2.MouseLeave += new System.EventHandler(this.label4_MouseLeave);
			this.label2.MouseHover += new System.EventHandler(this.label4_MouseEnter);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 10F);
			this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(138)))), ((int)(((byte)(172)))));
			this.label1.Location = new System.Drawing.Point(28, 23);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(57, 19);
			this.label1.TabIndex = 0;
			this.label1.Text = "Website";
			this.label1.Click += new System.EventHandler(this.label1_Click);
			this.label1.MouseEnter += new System.EventHandler(this.label4_MouseEnter);
			this.label1.MouseLeave += new System.EventHandler(this.label4_MouseLeave);
			this.label1.MouseHover += new System.EventHandler(this.label4_MouseEnter);
			// 
			// guna2DragControl1
			// 
			this.guna2DragControl1.ContainerControl = this;
			this.guna2DragControl1.TargetControl = this.mainPanel;
			// 
			// guna2DragControl2
			// 
			this.guna2DragControl2.ContainerControl = this;
			this.guna2DragControl2.TargetControl = this.leftSidebar;
			// 
			// guna2DragControl3
			// 
			this.guna2DragControl3.ContainerControl = this;
			this.guna2DragControl3.TargetControl = this.topContainer;
			// 
			// guna2DragControl4
			// 
			this.guna2DragControl4.ContainerControl = this;
			this.guna2DragControl4.TargetControl = this.mainBanner;
			// 
			// guna2DragControl5
			// 
			this.guna2DragControl5.ContainerControl = this;
			this.guna2DragControl5.TargetControl = this.rankingPanel;
			// 
			// guna2DragControl6
			// 
			this.guna2DragControl6.ContainerControl = this;
			this.guna2DragControl6.TargetControl = this.itemShopPanel;
			// 
			// notifyIcon
			// 
			this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
			this.notifyIcon.BalloonTipText = "KOP Launcher is now running in the background";
			this.notifyIcon.BalloonTipTitle = "King of Pirates";
			this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
			this.notifyIcon.Text = "King of Pirates Launcher";
			this.notifyIcon.Visible = true;
			this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 1000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// updateStatisticsTimer
			// 
			this.updateStatisticsTimer.Interval = 300000;
			this.updateStatisticsTimer.Tick += new System.EventHandler(this.updateStatisticsTimer_Tick);
			// 
			// SecurityTimer
			// 
			this.SecurityTimer.Interval = 10000;
			this.SecurityTimer.Tick += new System.EventHandler(this.SecurityTimer_Tick);
			// 
			// UpdateHashesTimer
			// 
			this.UpdateHashesTimer.Interval = 10000;
			this.UpdateHashesTimer.Tick += new System.EventHandler(this.UpdateHashesTimer_Tick);
			// 
			// KopmainF
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Yellow;
			this.ClientSize = new System.Drawing.Size(1160, 640);
			this.Controls.Add(this.mainPanel);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "KopmainF";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "King of Pirates Online";
			this.TransparencyKey = System.Drawing.Color.Yellow;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.kopmainF_FormClosing);
			this.mainPanel.ResumeLayout(false);
			this.mainPanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.package4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.package3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.package2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.package1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.itemShopPanel)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.rankingPanel)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.StartGameButton)).EndInit();
			this.leftSidebar.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.settingsButton)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.forumButton)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.mailButton)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.instagramButton)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.facebookButton)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.faDiscordBtn)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.mainBanner)).EndInit();
			this.topContainer.ResumeLayout(false);
			this.topContainer.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private Guna2Panel mainPanel;
        private Guna2DragControl guna2DragControl1;
        private Guna2DragControl guna2DragControl2;
        private Guna2Panel leftSidebar;
        private Guna2DragControl guna2DragControl3;
        private Guna2DragControl guna2DragControl4;
        private Guna2Panel topContainer;
        private Label label1;
        private Label label4;
        private Label label3;
        private Label label2;
        private Guna2PictureBox StartGameButton;
        private Label label5;
        private Label label6;
        private Label label9;
        private Label label10;
        private Label label7;
        private Label label8;
        private Label label15;
        private Label label16;
        private Label label13;
        private Label label14;
        private Label label11;
        private Label label12;
        private PictureBox faDiscordBtn;
        private PictureBox facebookButton;
        private PictureBox settingsButton;
        private PictureBox forumButton;
        private PictureBox mailButton;
        private PictureBox instagramButton;
        private Guna2PictureBox rankingPanel;
        private Guna2PictureBox itemShopPanel;
        private Guna2DragControl guna2DragControl5;
        private Guna2DragControl guna2DragControl6;
        private Label label17;
        private Label label18;
        private Label label19;
        private Label label20;
        private Guna2ControlBox minimiseButton;
        private Guna2ControlBox closeButton;
        private NotifyIcon notifyIcon;
        private Guna2ComboBox regionsBox;
        private Guna2PictureBox package4;
        private Guna2PictureBox package3;
        private Guna2PictureBox package2;
        private Guna2PictureBox package1;
        private Label label21;
        private Timer timer1;
        private Timer updateStatisticsTimer;
        private Label label22;
        private Label label23;
        private Label label24;
        private Timer SecurityTimer;
        private BackgroundWorker SecurityBackgroundWorker;
        private BackgroundWorker CheckHasheshBW;
        private Timer UpdateHashesTimer;
        private Guna2PictureBox mainBanner;
    }
}

