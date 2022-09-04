using plagiarismModel.TableRequests.Documents;
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

        private void dgvDocs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var id = dgvDocs.SelectedRows[0].DataBoundItem;
                Global.shouldEditRoles = false;
                frmDocumentDetails frm = new frmDocumentDetails(id as plagiarismModel.Documents);
                frm.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Nothing selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
