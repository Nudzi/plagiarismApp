
namespace plagiarism.WinUI.DocumentsForms
{
    partial class frmDocumentDetails
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
            this.lblOfficialName = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPublisher = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTextLenght = new System.Windows.Forms.TextBox();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLink = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbExt = new System.Windows.Forms.ComboBox();
            this.cbPackageType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbNewPackage = new System.Windows.Forms.CheckBox();
            this.txtExtension = new System.Windows.Forms.TextBox();
            this.txtPackageType = new System.Windows.Forms.TextBox();
            this.txtDocType = new System.Windows.Forms.TextBox();
            this.txtTimesUsed = new System.Windows.Forms.TextBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtContentText = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.pbUpload = new System.Windows.Forms.PictureBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.lblImage = new System.Windows.Forms.Label();
            this.txtImageInput = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUpload)).BeginInit();
            this.SuspendLayout();
            // 
            // lblOfficialName
            // 
            this.lblOfficialName.AutoSize = true;
            this.lblOfficialName.ForeColor = System.Drawing.Color.Black;
            this.lblOfficialName.Location = new System.Drawing.Point(20, 209);
            this.lblOfficialName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOfficialName.Name = "lblOfficialName";
            this.lblOfficialName.Size = new System.Drawing.Size(90, 20);
            this.lblOfficialName.TabIndex = 57;
            this.lblOfficialName.Text = "Times used";
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.ForeColor = System.Drawing.Color.Black;
            this.lblLastName.Location = new System.Drawing.Point(20, 88);
            this.lblLastName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(57, 20);
            this.lblLastName.TabIndex = 46;
            this.lblLastName.Text = "Author";
            // 
            // txtAuthor
            // 
            this.txtAuthor.Location = new System.Drawing.Point(148, 84);
            this.txtAuthor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.Size = new System.Drawing.Size(288, 26);
            this.txtAuthor.TabIndex = 45;
            this.txtAuthor.Validating += new System.ComponentModel.CancelEventHandler(this.txtAuthor_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(20, 128);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 20);
            this.label3.TabIndex = 44;
            this.label3.Text = "Publisher";
            // 
            // txtPublisher
            // 
            this.txtPublisher.Location = new System.Drawing.Point(148, 124);
            this.txtPublisher.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPublisher.Name = "txtPublisher";
            this.txtPublisher.Size = new System.Drawing.Size(288, 26);
            this.txtPublisher.TabIndex = 43;
            this.txtPublisher.Validating += new System.ComponentModel.CancelEventHandler(this.txtPublisher_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(20, 168);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 20);
            this.label2.TabIndex = 42;
            this.label2.Text = "Text Length";
            // 
            // txtTextLenght
            // 
            this.txtTextLenght.Location = new System.Drawing.Point(148, 164);
            this.txtTextLenght.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTextLenght.Name = "txtTextLenght";
            this.txtTextLenght.ReadOnly = true;
            this.txtTextLenght.Size = new System.Drawing.Size(288, 26);
            this.txtTextLenght.TabIndex = 41;
            this.txtTextLenght.Text = "4";
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.ForeColor = System.Drawing.Color.Black;
            this.lblFirstName.Location = new System.Drawing.Point(20, 48);
            this.lblFirstName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(38, 20);
            this.lblFirstName.TabIndex = 40;
            this.lblFirstName.Text = "Title";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(148, 44);
            this.txtTitle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(288, 26);
            this.txtTitle.TabIndex = 39;
            this.txtTitle.Validating += new System.ComponentModel.CancelEventHandler(this.txtTitle_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(20, 245);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 20);
            this.label1.TabIndex = 59;
            this.label1.Text = "Link";
            // 
            // txtLink
            // 
            this.txtLink.Location = new System.Drawing.Point(148, 245);
            this.txtLink.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtLink.Name = "txtLink";
            this.txtLink.Size = new System.Drawing.Size(288, 26);
            this.txtLink.TabIndex = 58;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Green;
            this.btnSave.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSave.Location = new System.Drawing.Point(618, 510);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 50);
            this.btnSave.TabIndex = 60;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCancel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCancel.Location = new System.Drawing.Point(781, 510);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 50);
            this.btnCancel.TabIndex = 61;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(479, 50);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 20);
            this.label4.TabIndex = 62;
            this.label4.Text = "Document type";
            // 
            // cbType
            // 
            this.cbType.FormattingEnabled = true;
            this.cbType.Location = new System.Drawing.Point(606, 44);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(288, 28);
            this.cbType.TabIndex = 63;
            this.cbType.SelectedIndexChanged += new System.EventHandler(this.cbType_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(479, 88);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 20);
            this.label5.TabIndex = 64;
            this.label5.Text = "Extension";
            // 
            // cbExt
            // 
            this.cbExt.FormattingEnabled = true;
            this.cbExt.Location = new System.Drawing.Point(606, 83);
            this.cbExt.Name = "cbExt";
            this.cbExt.Size = new System.Drawing.Size(288, 28);
            this.cbExt.TabIndex = 65;
            // 
            // cbPackageType
            // 
            this.cbPackageType.FormattingEnabled = true;
            this.cbPackageType.Location = new System.Drawing.Point(606, 124);
            this.cbPackageType.Name = "cbPackageType";
            this.cbPackageType.Size = new System.Drawing.Size(288, 28);
            this.cbPackageType.TabIndex = 67;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(479, 128);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 20);
            this.label6.TabIndex = 66;
            this.label6.Text = "Package Type";
            // 
            // cbNewPackage
            // 
            this.cbNewPackage.AutoSize = true;
            this.cbNewPackage.Location = new System.Drawing.Point(606, 168);
            this.cbNewPackage.Name = "cbNewPackage";
            this.cbNewPackage.Size = new System.Drawing.Size(166, 24);
            this.cbNewPackage.TabIndex = 68;
            this.cbNewPackage.Text = "Change Package?";
            this.cbNewPackage.UseVisualStyleBackColor = true;
            this.cbNewPackage.CheckedChanged += new System.EventHandler(this.cbNewPackage_CheckedChanged);
            // 
            // txtExtension
            // 
            this.txtExtension.Location = new System.Drawing.Point(607, 84);
            this.txtExtension.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtExtension.Name = "txtExtension";
            this.txtExtension.Size = new System.Drawing.Size(288, 26);
            this.txtExtension.TabIndex = 70;
            // 
            // txtPackageType
            // 
            this.txtPackageType.Location = new System.Drawing.Point(606, 125);
            this.txtPackageType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPackageType.Name = "txtPackageType";
            this.txtPackageType.ReadOnly = true;
            this.txtPackageType.Size = new System.Drawing.Size(288, 26);
            this.txtPackageType.TabIndex = 69;
            // 
            // txtDocType
            // 
            this.txtDocType.Location = new System.Drawing.Point(606, 45);
            this.txtDocType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDocType.Name = "txtDocType";
            this.txtDocType.Size = new System.Drawing.Size(288, 26);
            this.txtDocType.TabIndex = 71;
            // 
            // txtTimesUsed
            // 
            this.txtTimesUsed.Location = new System.Drawing.Point(148, 207);
            this.txtTimesUsed.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTimesUsed.Name = "txtTimesUsed";
            this.txtTimesUsed.ReadOnly = true;
            this.txtTimesUsed.Size = new System.Drawing.Size(288, 26);
            this.txtTimesUsed.TabIndex = 72;
            this.txtTimesUsed.Text = "0";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // txtContentText
            // 
            this.txtContentText.ForeColor = System.Drawing.Color.Black;
            this.txtContentText.Location = new System.Drawing.Point(606, 209);
            this.txtContentText.Name = "txtContentText";
            this.txtContentText.Size = new System.Drawing.Size(289, 257);
            this.txtContentText.TabIndex = 73;
            this.txtContentText.Text = "none";
            this.txtContentText.TextChanged += new System.EventHandler(this.txtContentText_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(479, 213);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 20);
            this.label7.TabIndex = 74;
            this.label7.Text = "Text";
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnAdd.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAdd.Location = new System.Drawing.Point(456, 310);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(83, 36);
            this.btnAdd.TabIndex = 75;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // pbUpload
            // 
            this.pbUpload.Location = new System.Drawing.Point(148, 351);
            this.pbUpload.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pbUpload.Name = "pbUpload";
            this.pbUpload.Size = new System.Drawing.Size(288, 207);
            this.pbUpload.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbUpload.TabIndex = 76;
            this.pbUpload.TabStop = false;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // lblImage
            // 
            this.lblImage.AutoSize = true;
            this.lblImage.ForeColor = System.Drawing.Color.Black;
            this.lblImage.Location = new System.Drawing.Point(23, 315);
            this.lblImage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblImage.Name = "lblImage";
            this.lblImage.Size = new System.Drawing.Size(54, 20);
            this.lblImage.TabIndex = 78;
            this.lblImage.Text = "Image";
            // 
            // txtImageInput
            // 
            this.txtImageInput.Location = new System.Drawing.Point(148, 315);
            this.txtImageInput.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtImageInput.Name = "txtImageInput";
            this.txtImageInput.Size = new System.Drawing.Size(288, 26);
            this.txtImageInput.TabIndex = 77;
            // 
            // frmDocumentDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(933, 572);
            this.Controls.Add(this.lblImage);
            this.Controls.Add(this.txtImageInput);
            this.Controls.Add(this.pbUpload);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtContentText);
            this.Controls.Add(this.txtTimesUsed);
            this.Controls.Add(this.txtDocType);
            this.Controls.Add(this.txtExtension);
            this.Controls.Add(this.txtPackageType);
            this.Controls.Add(this.cbNewPackage);
            this.Controls.Add(this.cbPackageType);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbExt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbType);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLink);
            this.Controls.Add(this.lblOfficialName);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.txtAuthor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPublisher);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTextLenght);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.txtTitle);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "frmDocumentDetails";
            this.Text = "DocumentDetails";
            this.Load += new System.EventHandler(this.frmDocumentDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUpload)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblOfficialName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPublisher;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTextLenght;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLink;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbExt;
        private System.Windows.Forms.ComboBox cbPackageType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox cbNewPackage;
        private System.Windows.Forms.TextBox txtExtension;
        private System.Windows.Forms.TextBox txtPackageType;
        private System.Windows.Forms.TextBox txtDocType;
        private System.Windows.Forms.TextBox txtTimesUsed;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox txtContentText;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.PictureBox pbUpload;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label lblImage;
        private System.Windows.Forms.TextBox txtImageInput;
    }
}