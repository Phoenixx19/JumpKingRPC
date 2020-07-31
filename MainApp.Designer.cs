using System;
using System.Reflection;


namespace JumpKingRPC
{
    partial class MainApp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainApp));
            this.splitContainerCtrl = new System.Windows.Forms.SplitContainer();
            this.discordStatus = new System.Windows.Forms.Label();
            this.discordStatusText = new System.Windows.Forms.Label();
            this.processText = new System.Windows.Forms.Label();
            this.process = new System.Windows.Forms.Label();
            this.checkSnakeRing = new System.Windows.Forms.CheckBox();
            this.checkGiantBoots = new System.Windows.Forms.CheckBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.ctrlComboboxLabel = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.panelDesc = new System.Windows.Forms.Panel();
            this.Crown = new System.Windows.Forms.PictureBox();
            this.link = new System.Windows.Forms.LinkLabel();
            this.DescTitle = new System.Windows.Forms.Label();
            this.descText = new System.Windows.Forms.Label();
            this.about = new System.Windows.Forms.Label();
            this.panelCtrl = new System.Windows.Forms.Panel();
            this.Head = new System.Windows.Forms.PictureBox();
            this.CtrlTitle = new System.Windows.Forms.Label();
            this.panelCtrl2 = new System.Windows.Forms.Panel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.liveStatsText = new System.Windows.Forms.Label();
            this.liveSession = new System.Windows.Forms.Label();
            this.totalStatsText = new System.Windows.Forms.Label();
            this.panelStats = new System.Windows.Forms.Panel();
            this.Dead = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.totalTimestamp = new System.Windows.Forms.Label();
            this.totalFalls = new System.Windows.Forms.Label();
            this.totalAttempts = new System.Windows.Forms.Label();
            this.totalJumps = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.liveTimestamp = new System.Windows.Forms.Label();
            this.liveJumpsFalls = new System.Windows.Forms.Label();
            this.liveZone = new System.Windows.Forms.Label();
            this.liveLevel = new System.Windows.Forms.Label();
            this.StatsTitle = new System.Windows.Forms.Label();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.menuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripShow = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripQuit = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerCtrl)).BeginInit();
            this.splitContainerCtrl.Panel1.SuspendLayout();
            this.splitContainerCtrl.Panel2.SuspendLayout();
            this.splitContainerCtrl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.panelDesc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Crown)).BeginInit();
            this.panelCtrl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Head)).BeginInit();
            this.panelCtrl2.SuspendLayout();
            this.panelStats.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dead)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerCtrl
            // 
            resources.ApplyResources(this.splitContainerCtrl, "splitContainerCtrl");
            this.splitContainerCtrl.Name = "splitContainerCtrl";
            // 
            // splitContainerCtrl.Panel1
            // 
            this.splitContainerCtrl.Panel1.Controls.Add(this.discordStatus);
            this.splitContainerCtrl.Panel1.Controls.Add(this.discordStatusText);
            this.splitContainerCtrl.Panel1.Controls.Add(this.processText);
            this.splitContainerCtrl.Panel1.Controls.Add(this.process);
            // 
            // splitContainerCtrl.Panel2
            // 
            this.splitContainerCtrl.Panel2.Controls.Add(this.checkSnakeRing);
            this.splitContainerCtrl.Panel2.Controls.Add(this.checkGiantBoots);
            this.splitContainerCtrl.Panel2.Controls.Add(this.comboBox1);
            this.splitContainerCtrl.Panel2.Controls.Add(this.ctrlComboboxLabel);
            // 
            // discordStatus
            // 
            resources.ApplyResources(this.discordStatus, "discordStatus");
            this.discordStatus.ForeColor = System.Drawing.Color.Red;
            this.discordStatus.Name = "discordStatus";
            // 
            // discordStatusText
            // 
            resources.ApplyResources(this.discordStatusText, "discordStatusText");
            this.discordStatusText.Name = "discordStatusText";
            this.toolTip.SetToolTip(this.discordStatusText, resources.GetString("discordStatusText.ToolTip"));
            // 
            // processText
            // 
            resources.ApplyResources(this.processText, "processText");
            this.processText.Name = "processText";
            this.toolTip.SetToolTip(this.processText, resources.GetString("processText.ToolTip"));
            // 
            // process
            // 
            resources.ApplyResources(this.process, "process");
            this.process.ForeColor = System.Drawing.Color.Red;
            this.process.Name = "process";
            // 
            // checkSnakeRing
            // 
            resources.ApplyResources(this.checkSnakeRing, "checkSnakeRing");
            this.checkSnakeRing.Name = "checkSnakeRing";
            this.checkSnakeRing.UseVisualStyleBackColor = true;
            this.checkSnakeRing.CheckStateChanged += new System.EventHandler(this.checkSnakeRing_CheckedChanged);
            // 
            // checkGiantBoots
            // 
            resources.ApplyResources(this.checkGiantBoots, "checkGiantBoots");
            this.checkGiantBoots.Name = "checkGiantBoots";
            this.checkGiantBoots.UseVisualStyleBackColor = true;
            this.checkGiantBoots.CheckStateChanged += new System.EventHandler(this.checkGiantBoots_CheckedChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            resources.GetString("comboBox1.Items"),
            resources.GetString("comboBox1.Items1"),
            resources.GetString("comboBox1.Items2")});
            resources.ApplyResources(this.comboBox1, "comboBox1");
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.SelectionChangeCommitted += new System.EventHandler(this.comboBox1_SelectionChangeCommitted);
            // 
            // ctrlComboboxLabel
            // 
            resources.ApplyResources(this.ctrlComboboxLabel, "ctrlComboboxLabel");
            this.ctrlComboboxLabel.Name = "ctrlComboboxLabel";
            // 
            // pictureBox
            // 
            resources.ApplyResources(this.pictureBox, "pictureBox");
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.TabStop = false;
            // 
            // panelDesc
            // 
            this.panelDesc.AllowDrop = true;
            this.panelDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDesc.Controls.Add(this.Crown);
            this.panelDesc.Controls.Add(this.link);
            this.panelDesc.Controls.Add(this.DescTitle);
            this.panelDesc.Controls.Add(this.descText);
            resources.ApplyResources(this.panelDesc, "panelDesc");
            this.panelDesc.Name = "panelDesc";
            // 
            // Crown
            // 
            resources.ApplyResources(this.Crown, "Crown");
            this.Crown.Name = "Crown";
            this.Crown.TabStop = false;
            // 
            // link
            // 
            this.link.BackColor = System.Drawing.Color.Transparent;
            this.link.LinkVisited = true;
            resources.ApplyResources(this.link, "link");
            this.link.Name = "link";
            this.link.TabStop = true;
            this.toolTip.SetToolTip(this.link, resources.GetString("link.ToolTip"));
            this.link.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_LinkClicked);
            // 
            // DescTitle
            // 
            resources.ApplyResources(this.DescTitle, "DescTitle");
            this.DescTitle.Name = "DescTitle";
            // 
            // descText
            // 
            resources.ApplyResources(this.descText, "descText");
            this.descText.Name = "descText";
            // 
            // about
            // 
            resources.ApplyResources(this.about, "about");
            this.about.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.about.Name = "about";
            this.toolTip.SetToolTip(this.about, resources.GetString("about.ToolTip"));
            // 
            // panelCtrl
            // 
            this.panelCtrl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCtrl.Controls.Add(this.Head);
            this.panelCtrl.Controls.Add(this.CtrlTitle);
            this.panelCtrl.Controls.Add(this.panelCtrl2);
            resources.ApplyResources(this.panelCtrl, "panelCtrl");
            this.panelCtrl.Name = "panelCtrl";
            // 
            // Head
            // 
            resources.ApplyResources(this.Head, "Head");
            this.Head.Name = "Head";
            this.Head.TabStop = false;
            // 
            // CtrlTitle
            // 
            resources.ApplyResources(this.CtrlTitle, "CtrlTitle");
            this.CtrlTitle.Name = "CtrlTitle";
            // 
            // panelCtrl2
            // 
            this.panelCtrl2.Controls.Add(this.splitContainerCtrl);
            resources.ApplyResources(this.panelCtrl2, "panelCtrl2");
            this.panelCtrl2.Name = "panelCtrl2";
            // 
            // liveStatsText
            // 
            resources.ApplyResources(this.liveStatsText, "liveStatsText");
            this.liveStatsText.Name = "liveStatsText";
            this.toolTip.SetToolTip(this.liveStatsText, resources.GetString("liveStatsText.ToolTip"));
            // 
            // liveSession
            // 
            resources.ApplyResources(this.liveSession, "liveSession");
            this.liveSession.Name = "liveSession";
            this.toolTip.SetToolTip(this.liveSession, resources.GetString("liveSession.ToolTip"));
            // 
            // totalStatsText
            // 
            resources.ApplyResources(this.totalStatsText, "totalStatsText");
            this.totalStatsText.Name = "totalStatsText";
            this.toolTip.SetToolTip(this.totalStatsText, resources.GetString("totalStatsText.ToolTip"));
            // 
            // panelStats
            // 
            this.panelStats.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelStats.Controls.Add(this.Dead);
            this.panelStats.Controls.Add(this.panel2);
            this.panelStats.Controls.Add(this.panel1);
            this.panelStats.Controls.Add(this.StatsTitle);
            resources.ApplyResources(this.panelStats, "panelStats");
            this.panelStats.Name = "panelStats";
            // 
            // Dead
            // 
            resources.ApplyResources(this.Dead, "Dead");
            this.Dead.Name = "Dead";
            this.Dead.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.totalTimestamp);
            this.panel2.Controls.Add(this.totalFalls);
            this.panel2.Controls.Add(this.totalAttempts);
            this.panel2.Controls.Add(this.totalJumps);
            this.panel2.Controls.Add(this.totalStatsText);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // totalTimestamp
            // 
            resources.ApplyResources(this.totalTimestamp, "totalTimestamp");
            this.totalTimestamp.Name = "totalTimestamp";
            // 
            // totalFalls
            // 
            resources.ApplyResources(this.totalFalls, "totalFalls");
            this.totalFalls.Name = "totalFalls";
            // 
            // totalAttempts
            // 
            resources.ApplyResources(this.totalAttempts, "totalAttempts");
            this.totalAttempts.Name = "totalAttempts";
            // 
            // totalJumps
            // 
            resources.ApplyResources(this.totalJumps, "totalJumps");
            this.totalJumps.Name = "totalJumps";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.liveTimestamp);
            this.panel1.Controls.Add(this.liveJumpsFalls);
            this.panel1.Controls.Add(this.liveSession);
            this.panel1.Controls.Add(this.liveZone);
            this.panel1.Controls.Add(this.liveLevel);
            this.panel1.Controls.Add(this.liveStatsText);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // liveTimestamp
            // 
            resources.ApplyResources(this.liveTimestamp, "liveTimestamp");
            this.liveTimestamp.Name = "liveTimestamp";
            // 
            // liveJumpsFalls
            // 
            resources.ApplyResources(this.liveJumpsFalls, "liveJumpsFalls");
            this.liveJumpsFalls.Name = "liveJumpsFalls";
            // 
            // liveZone
            // 
            resources.ApplyResources(this.liveZone, "liveZone");
            this.liveZone.Name = "liveZone";
            // 
            // liveLevel
            // 
            resources.ApplyResources(this.liveLevel, "liveLevel");
            this.liveLevel.Name = "liveLevel";
            // 
            // StatsTitle
            // 
            resources.ApplyResources(this.StatsTitle, "StatsTitle");
            this.StatsTitle.Name = "StatsTitle";
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.menuStrip;
            resources.ApplyResources(this.notifyIcon, "notifyIcon");
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripInfo,
            this.toolStripShow,
            this.toolStripAbout,
            this.toolStripSeparator1,
            this.toolStripQuit});
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip.ShowItemToolTips = false;
            resources.ApplyResources(this.menuStrip, "menuStrip");
            // 
            // toolStripInfo
            // 
            resources.ApplyResources(this.toolStripInfo, "toolStripInfo");
            this.toolStripInfo.Name = "toolStripInfo";
            // 
            // toolStripShow
            // 
            this.toolStripShow.Name = "toolStripShow";
            resources.ApplyResources(this.toolStripShow, "toolStripShow");
            this.toolStripShow.Click += new System.EventHandler(this.toolStripShow_Click);
            // 
            // toolStripAbout
            // 
            this.toolStripAbout.Name = "toolStripAbout";
            resources.ApplyResources(this.toolStripAbout, "toolStripAbout");
            this.toolStripAbout.Click += new System.EventHandler(this.toolStripAbout_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // toolStripQuit
            // 
            this.toolStripQuit.Name = "toolStripQuit";
            resources.ApplyResources(this.toolStripQuit, "toolStripQuit");
            this.toolStripQuit.Click += new System.EventHandler(this.toolStripQuit_Click);
            // 
            // MainApp
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelStats);
            this.Controls.Add(this.panelCtrl);
            this.Controls.Add(this.about);
            this.Controls.Add(this.panelDesc);
            this.Controls.Add(this.pictureBox);
            this.MaximizeBox = false;
            this.Name = "MainApp";
            this.ShowIcon = false;
            this.Closing += new System.ComponentModel.CancelEventHandler(this.Form1_Closing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.splitContainerCtrl.Panel1.ResumeLayout(false);
            this.splitContainerCtrl.Panel2.ResumeLayout(false);
            this.splitContainerCtrl.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerCtrl)).EndInit();
            this.splitContainerCtrl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.panelDesc.ResumeLayout(false);
            this.panelDesc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Crown)).EndInit();
            this.panelCtrl.ResumeLayout(false);
            this.panelCtrl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Head)).EndInit();
            this.panelCtrl2.ResumeLayout(false);
            this.panelStats.ResumeLayout(false);
            this.panelStats.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dead)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Panel panelDesc;
        private System.Windows.Forms.Label descText;
        private System.Windows.Forms.Label DescTitle;
        private System.Windows.Forms.LinkLabel link;
        private System.Windows.Forms.PictureBox Crown;
        private System.Windows.Forms.Label about;
        private System.Windows.Forms.Panel panelCtrl;
        private System.Windows.Forms.Panel panelCtrl2;
        private System.Windows.Forms.Label CtrlTitle;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.SplitContainer splitContainerCtrl;
        private System.Windows.Forms.Label processText;
        private System.Windows.Forms.Label ctrlComboboxLabel;
        private System.Windows.Forms.Label process;
        private System.Windows.Forms.Label discordStatusText;
        private System.Windows.Forms.Label discordStatus;
        private System.Windows.Forms.Label liveStatsText;
        private System.Windows.Forms.Label liveSession;
        private System.Windows.Forms.Panel panelStats;
        private System.Windows.Forms.Label StatsTitle;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label liveJumpsFalls;
        private System.Windows.Forms.Label liveZone;
        private System.Windows.Forms.Label liveLevel;
        private System.Windows.Forms.Label liveTimestamp;
        private System.Windows.Forms.Label totalJumps;
        private System.Windows.Forms.Label totalStatsText;
        private System.Windows.Forms.Label totalTimestamp;
        private System.Windows.Forms.Label totalFalls;
        private System.Windows.Forms.Label totalAttempts;
        private System.Windows.Forms.PictureBox Head;
        private System.Windows.Forms.PictureBox Dead;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ContextMenuStrip menuStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripAbout;
        private System.Windows.Forms.ToolStripMenuItem toolStripQuit;
        private System.Windows.Forms.ToolStripMenuItem toolStripInfo;
        private System.Windows.Forms.ToolStripMenuItem toolStripShow;
        private System.Windows.Forms.CheckBox checkSnakeRing;
        private System.Windows.Forms.CheckBox checkGiantBoots;
    }
}

