using plagiarismModel.Requests.Users;
using System.Collections.Generic;
using System.Windows.Forms;

namespace plagiarism.WinUI.Users
{
    public partial class frmUsers : Form
    {
        private readonly APIService _apiService = new APIService("users");
        public frmUsers()
        {
            InitializeComponent();
        }

        private async void btnShow_Click(object sender, System.EventArgs e)
        {
            var search = new UsersSearchRequest()
            {
                FirstName = txtSearch.Text
            };
            var result = await _apiService.Get<List<plagiarismModel.Users>>(search);
            dgvUsers.AutoGenerateColumns = false;
            dgvUsers.DataSource = result;
        }

        private void dgvUsers_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                var id = dgvUsers.SelectedRows[0].DataBoundItem;
                Global.shouldEditRoles = false;
                frmUserDetails frm = new frmUserDetails(id as plagiarismModel.Users);
                frm.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Nothing selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var id = dgvUsers.SelectedRows[0].DataBoundItem;
                Global.shouldEditRoles = false;
                frmUserDetails frm = new frmUserDetails(id as plagiarismModel.Users);
                frm.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Nothing selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void btnOfficial_Click(object sender, System.EventArgs e)
        {
            var search = new UsersSearchRequest()
            {
                OfficialName = txtOfficial.Text
            };
            var result = await _apiService.Get<List<plagiarismModel.Users>>(search);
            dgvUsers.AutoGenerateColumns = false;
            dgvUsers.DataSource = result;
        }
    }
}
