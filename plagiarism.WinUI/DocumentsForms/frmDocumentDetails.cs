using plagiarismModel;
using plagiarismModel.Enums;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace plagiarism.WinUI.DocumentsForms
{
    public partial class frmDocumentDetails : Form
    {
        private Documents _documents = null;
        public frmDocumentDetails(Documents documents)
        {
            InitializeComponent();
            _documents = documents;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void LoadExtensions()
        {
            var extenstionTypesList = new List<string>
                {
                    ExtensionTypes.doc.ToString(),
                    ExtensionTypes.pdf.ToString()
                };
            cbExt.DataSource = extenstionTypesList;
            cbExt.DisplayMember = "Name";
            cbExt.ValueMember = "Id";
        }

        private void frmDocumentDetails_Load(object sender, EventArgs e)
        {
            if (_documents == null)
            {
                

                

            } else {

            }
        }
    }
}
