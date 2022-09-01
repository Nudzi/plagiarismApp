﻿
namespace plagiarism.WinUI.DocumentsForms
{
    partial class frmDocuments
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.btnShow = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvDocs = new System.Windows.Forms.DataGridView();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.txtPublisher = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocs)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 20);
            this.label1.TabIndex = 13;
            this.label1.Text = "Search by Title: ";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(22, 99);
            this.txtTitle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(376, 26);
            this.txtTitle.TabIndex = 12;
            // 
            // btnShow
            // 
            this.btnShow.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnShow.Location = new System.Drawing.Point(449, 166);
            this.btnShow.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(112, 35);
            this.btnShow.TabIndex = 11;
            this.btnShow.Text = "Show";
            this.btnShow.UseVisualStyleBackColor = false;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvDocs);
            this.groupBox1.Location = new System.Drawing.Point(22, 306);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(832, 288);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Documents";
            // 
            // dgvDocs
            // 
            this.dgvDocs.AllowUserToAddRows = false;
            this.dgvDocs.AllowUserToDeleteRows = false;
            this.dgvDocs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDocs.Location = new System.Drawing.Point(4, 24);
            this.dgvDocs.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvDocs.Name = "dgvDocs";
            this.dgvDocs.ReadOnly = true;
            this.dgvDocs.RowHeadersWidth = 62;
            this.dgvDocs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDocs.Size = new System.Drawing.Size(824, 259);
            this.dgvDocs.TabIndex = 0;
            // 
            // txtAuthor
            // 
            this.txtAuthor.Location = new System.Drawing.Point(22, 170);
            this.txtAuthor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.Size = new System.Drawing.Size(376, 26);
            this.txtAuthor.TabIndex = 14;
            // 
            // txtPublisher
            // 
            this.txtPublisher.Location = new System.Drawing.Point(22, 236);
            this.txtPublisher.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPublisher.Name = "txtPublisher";
            this.txtPublisher.Size = new System.Drawing.Size(376, 26);
            this.txtPublisher.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 211);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 20);
            this.label2.TabIndex = 16;
            this.label2.Text = "Search by Publisher: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 20);
            this.label3.TabIndex = 17;
            this.label3.Text = "Search by Author: ";
            // 
            // frmDocuments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 608);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPublisher);
            this.Controls.Add(this.txtAuthor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmDocuments";
            this.Text = "frmDocuments";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvDocs;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.TextBox txtPublisher;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}