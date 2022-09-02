using plagiarismModel.Requests.Documents;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace plagiarism.WinUI.DocumentsForms
{
    public partial class frmDocuments : Form
    {
        private readonly APIService _documentsService = new APIService("documents");
        public frmDocuments()
        {
            InitializeComponent();
        }

        private async void btnShow_Click(object sender, EventArgs e)
        {
            var search = new DocumentsSearchRequest()
            {
                Title = txtTitle.Text,
                Author = txtAuthor.Text,
                Publisher = txtPublisher.Text,
            };
            var results = await _documentsService.Get<List<plagiarismModel.Documents>>(search);

            dgvDocs.AutoGenerateColumns = false;
            dgvDocs.DataSource = results;
        }
    }
}
