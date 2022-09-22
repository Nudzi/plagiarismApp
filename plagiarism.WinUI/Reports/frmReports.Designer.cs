
namespace plagiarism.WinUI.Reports
{
    partial class frmReports
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReports));
            this.btnPaymants = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.dgvResults = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.btnToDisable = new System.Windows.Forms.Button();
            this.btnFromDisable = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSum = new System.Windows.Forms.TextBox();
            this.btnDoc = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPaymants
            // 
            this.btnPaymants.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnPaymants.Location = new System.Drawing.Point(27, 142);
            this.btnPaymants.Name = "btnPaymants";
            this.btnPaymants.Size = new System.Drawing.Size(138, 60);
            this.btnPaymants.TabIndex = 21;
            this.btnPaymants.Text = "Payments";
            this.btnPaymants.UseVisualStyleBackColor = false;
            this.btnPaymants.Click += new System.EventHandler(this.btnPaymants_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnPrint.Location = new System.Drawing.Point(27, 395);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(229, 58);
            this.btnPrint.TabIndex = 20;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // dgvResults
            // 
            this.dgvResults.AllowUserToAddRows = false;
            this.dgvResults.AllowUserToDeleteRows = false;
            this.dgvResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResults.Location = new System.Drawing.Point(262, 142);
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.ReadOnly = true;
            this.dgvResults.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvResults.RowTemplate.Height = 28;
            this.dgvResults.Size = new System.Drawing.Size(843, 311);
            this.dgvResults.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(670, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 20);
            this.label3.TabIndex = 18;
            this.label3.Text = "To date:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(670, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 20);
            this.label2.TabIndex = 17;
            this.label2.Text = "From date:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 52);
            this.label1.TabIndex = 16;
            this.label1.Text = "Reports";
            // 
            // dtpTo
            // 
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(791, 83);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(200, 26);
            this.dtpTo.TabIndex = 14;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(791, 36);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(200, 26);
            this.dtpFrom.TabIndex = 15;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.printDocument1;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // btnToDisable
            // 
            this.btnToDisable.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnToDisable.Location = new System.Drawing.Point(1014, 75);
            this.btnToDisable.Name = "btnToDisable";
            this.btnToDisable.Size = new System.Drawing.Size(91, 37);
            this.btnToDisable.TabIndex = 26;
            this.btnToDisable.Text = "Disable";
            this.btnToDisable.UseVisualStyleBackColor = false;
            this.btnToDisable.Click += new System.EventHandler(this.btnToDisable_Click);
            // 
            // btnFromDisable
            // 
            this.btnFromDisable.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnFromDisable.Location = new System.Drawing.Point(1014, 32);
            this.btnFromDisable.Name = "btnFromDisable";
            this.btnFromDisable.Size = new System.Drawing.Size(91, 35);
            this.btnFromDisable.TabIndex = 25;
            this.btnFromDisable.Text = "Disable";
            this.btnFromDisable.UseVisualStyleBackColor = false;
            this.btnFromDisable.Click += new System.EventHandler(this.btnFromDisable_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(258, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 20);
            this.label4.TabIndex = 24;
            this.label4.Text = "Results to print:";
            // 
            // txtSum
            // 
            this.txtSum.ForeColor = System.Drawing.Color.Black;
            this.txtSum.Location = new System.Drawing.Point(855, 485);
            this.txtSum.Name = "txtSum";
            this.txtSum.ReadOnly = true;
            this.txtSum.Size = new System.Drawing.Size(250, 26);
            this.txtSum.TabIndex = 28;
            this.txtSum.Text = "0$";
            this.txtSum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnDoc
            // 
            this.btnDoc.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDoc.Location = new System.Drawing.Point(27, 241);
            this.btnDoc.Name = "btnDoc";
            this.btnDoc.Size = new System.Drawing.Size(138, 60);
            this.btnDoc.TabIndex = 29;
            this.btnDoc.Text = "Documents";
            this.btnDoc.UseVisualStyleBackColor = false;
            this.btnDoc.Click += new System.EventHandler(this.btnDoc_Click);
            // 
            // frmReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(1133, 545);
            this.Controls.Add(this.btnDoc);
            this.Controls.Add(this.txtSum);
            this.Controls.Add(this.btnPaymants);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.dgvResults);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.dtpFrom);
            this.Controls.Add(this.btnToDisable);
            this.Controls.Add(this.btnFromDisable);
            this.Controls.Add(this.label4);
            this.Name = "frmReports";
            this.Text = "Reports";
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnPaymants;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.DataGridView dgvResults;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.Button btnToDisable;
        private System.Windows.Forms.Button btnFromDisable;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSum;
        private System.Windows.Forms.Button btnDoc;
    }
}