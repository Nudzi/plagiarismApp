using plagiarismModel.TableRequests.Users;
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
                UserName = txtSearch.Text
            };
            var result = await _apiService.Get<List<plagiarismModel.Users>>(search);

            var results = new List<plagiarismModel.Users>();
            foreach (var item in result)
            {
                if (item.OfficialName == "" && item.FirstName != "" && item.LastName != "")
                {
                    results.Add(item);
                }
            }

            dgvUsers.AutoGenerateColumns = false;
            dgvUsers.DataSource = results;
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

    }
}
