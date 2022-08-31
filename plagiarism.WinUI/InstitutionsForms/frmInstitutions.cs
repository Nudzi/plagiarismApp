using plagiarism.WinUI.Users;
using plagiarismModel.Requests.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace plagiarism.WinUI.InstitutionsForms
{
    public partial class frmInstitutions : Form
    {
        private readonly APIService _apiService = new APIService("users");

        public frmInstitutions()
        {
            InitializeComponent();
        }

        private async void btnOfficial_Click(object sender, EventArgs e)
        {
            var search = new UsersSearchRequest()
            {
                OfficialName = txtOfficial.Text
            };
            var result = await _apiService.Get<List<plagiarismModel.Users>>(search);

            var results = new List<plagiarismModel.Users>();
            foreach (var item in result)
            {
                if (item.OfficialName != "" && item.FirstName == "" && item.LastName == "")
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
