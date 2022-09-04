using plagiarismModel.TableRequests.Requests;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace plagiarism.WinUI.RequestsForm
{
    public partial class frmRequests : Form
    {
        private readonly APIService _requestsService = new APIService("requests");

        public frmRequests()
        {
            InitializeComponent();
        }

        private async void frmRequests_Load(object sender, EventArgs e)
        {
        }

        private void dgvInst_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var id = dgvUsers.SelectedRows[0].DataBoundItem;
                frmRequestDetails frm = new frmRequestDetails(id as plagiarismModel.Requests);
                frm.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Nothing selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvInst_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                var id = dgvUsers.SelectedRows[0].DataBoundItem;
                frmRequestDetails frm = new frmRequestDetails(id as plagiarismModel.Requests);
                frm.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Nothing selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void btnShow_Click(object sender, EventArgs e)
        {
            var search = new RequestsSearchRequest()
            {
                Title = txtSearch.Text
            };
            var results = await _requestsService.Get<List<plagiarismModel.Requests>>(search);
            dgvUsers.DataSource = results;

            for (int i = 0; i < dgvUsers.Columns.Count; i++)
                dgvUsers.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var id = dgvUsers.SelectedRows[0].DataBoundItem;
                Global.shouldEditRoles = false;
                frmRequestDetails frm = new frmRequestDetails(id as plagiarismModel.Requests);
                frm.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Nothing selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvUsers_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                var id = dgvUsers.SelectedRows[0].DataBoundItem;
                Global.shouldEditRoles = false;
                frmRequestDetails frm = new frmRequestDetails(id as plagiarismModel.Requests);
                frm.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Nothing selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
