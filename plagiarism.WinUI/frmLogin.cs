using plagiarism.WinUI.Index;
using plagiarismModel;
using System;
using System.Windows.Forms;

namespace plagiarism.WinUI
{
    public partial class frmLogin : Form
    {
        protected APIService _service = new APIService("users");
        protected APIService _userTypesService = new APIService("userTypes");
        UserTypes role = null;
        public frmLogin()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            APIService.userName = textBoxUserName.Text;
            APIService.password = textBoxPass.Text;
            try
            {
                if (string.IsNullOrEmpty(textBoxUserName.Text) || string.IsNullOrEmpty(textBoxPass.Text))
                {
                    MessageBox.Show("All fields are required! Try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                else
                {
                    plagiarismModel.Users user = await _service.Authentication<plagiarismModel.Users>(textBoxUserName.Text, textBoxPass.Text);

                    if (checkUserType(user))
                    {
                        MessageBox.Show("Welcome:\n " + user.FirstName + " " + user.LastName);
                        DialogResult = DialogResult.OK;
                        this.Hide();
                        frmIndex frm = new frmIndex();
                        frm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Wrong username or password", "You do not have permissions!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Wrong username or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private bool checkUserType(plagiarismModel.Users user)
        {
            if (user != null)
            {
                Global.LoggedUser = user;

                foreach (var item in Global.LoggedUser.UserTypes)
                {
                    if (item.IsActive && item.UserTypeId == (int)plagiarismModel.Enums.UserTypes.Admin)
                    {
                        Global.Admin = true;
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
