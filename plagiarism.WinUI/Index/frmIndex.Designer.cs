
namespace plagiarism.WinUI.Index
{
    partial class frmIndex
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.userToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.institutionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewAllToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.documentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewAllToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.requestsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewAllToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userToolStripMenuItem,
            this.institutionsToolStripMenuItem,
            this.reportsToolStripMenuItem,
            this.documentsToolStripMenuItem,
            this.requestsToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(948, 33);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // userToolStripMenuItem
            // 
            this.userToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewAllToolStripMenuItem,
            this.newToolStripMenuItem});
            this.userToolStripMenuItem.Name = "userToolStripMenuItem";
            this.userToolStripMenuItem.Size = new System.Drawing.Size(63, 29);
            this.userToolStripMenuItem.Text = "User";
            // 
            // viewAllToolStripMenuItem
            // 
            this.viewAllToolStripMenuItem.Name = "viewAllToolStripMenuItem";
            this.viewAllToolStripMenuItem.Size = new System.Drawing.Size(176, 34);
            this.viewAllToolStripMenuItem.Text = "View All";
            this.viewAllToolStripMenuItem.Click += new System.EventHandler(this.viewAllToolStripMenuItem_Click);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(176, 34);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // institutionsToolStripMenuItem
            // 
            this.institutionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewAllToolStripMenuItem1});
            this.institutionsToolStripMenuItem.Name = "institutionsToolStripMenuItem";
            this.institutionsToolStripMenuItem.Size = new System.Drawing.Size(116, 29);
            this.institutionsToolStripMenuItem.Text = "Institutions";
            // 
            // viewAllToolStripMenuItem1
            // 
            this.viewAllToolStripMenuItem1.Name = "viewAllToolStripMenuItem1";
            this.viewAllToolStripMenuItem1.Size = new System.Drawing.Size(176, 34);
            this.viewAllToolStripMenuItem1.Text = "View All";
            this.viewAllToolStripMenuItem1.Click += new System.EventHandler(this.viewAllToolStripMenuItem1_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem});
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(89, 29);
            this.reportsToolStripMenuItem.Text = "Reports";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(158, 34);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // documentsToolStripMenuItem
            // 
            this.documentsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewAllToolStripMenuItem2,
            this.newToolStripMenuItem1});
            this.documentsToolStripMenuItem.Name = "documentsToolStripMenuItem";
            this.documentsToolStripMenuItem.Size = new System.Drawing.Size(119, 29);
            this.documentsToolStripMenuItem.Text = "Documents";
            // 
            // viewAllToolStripMenuItem2
            // 
            this.viewAllToolStripMenuItem2.Name = "viewAllToolStripMenuItem2";
            this.viewAllToolStripMenuItem2.Size = new System.Drawing.Size(176, 34);
            this.viewAllToolStripMenuItem2.Text = "View All";
            this.viewAllToolStripMenuItem2.Click += new System.EventHandler(this.viewAllToolStripMenuItem2_Click);
            // 
            // newToolStripMenuItem1
            // 
            this.newToolStripMenuItem1.Name = "newToolStripMenuItem1";
            this.newToolStripMenuItem1.Size = new System.Drawing.Size(176, 34);
            this.newToolStripMenuItem1.Text = "New";
            this.newToolStripMenuItem1.Click += new System.EventHandler(this.newToolStripMenuItem1_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 665);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.statusStrip.Size = new System.Drawing.Size(948, 32);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(60, 25);
            this.toolStripStatusLabel.Text = "Status";
            // 
            // requestsToolStripMenuItem
            // 
            this.requestsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewAllToolStripMenuItem3});
            this.requestsToolStripMenuItem.Name = "requestsToolStripMenuItem";
            this.requestsToolStripMenuItem.Size = new System.Drawing.Size(99, 29);
            this.requestsToolStripMenuItem.Text = "Requests";
            // 
            // viewAllToolStripMenuItem3
            // 
            this.viewAllToolStripMenuItem3.Name = "viewAllToolStripMenuItem3";
            this.viewAllToolStripMenuItem3.Size = new System.Drawing.Size(270, 34);
            this.viewAllToolStripMenuItem3.Text = "View All";
            this.viewAllToolStripMenuItem3.Click += new System.EventHandler(this.viewAllToolStripMenuItem3_Click);
            // 
            // frmIndex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 697);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmIndex";
            this.Text = "frmIndex";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem userToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem institutionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewAllToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem documentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewAllToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem requestsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewAllToolStripMenuItem3;
    }
}



