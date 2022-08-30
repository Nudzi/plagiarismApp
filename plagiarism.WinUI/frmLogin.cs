using plagiarismModel;
using System;
using System.Windows.Forms;
using plagiarism.WinUI.Index;

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
                    Users user = await _service.Authentication<Users>(textBoxUserName.Text, textBoxPass.Text);

                    checkUserType(user);
                    MessageBox.Show("Welcome:\n " + user.FirstName + " " + user.LastName);
                    DialogResult = DialogResult.OK;
                    this.Hide();
                    if (Global.Admin)
                    {
                        frmIndex frm = new frmIndex();
                        frm.Show();
                    }
                    if (Global.User || Global.Institution)
                    {
                        MessageBox.Show("Wrong username or password", "You do not have permissions!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    if (Global.Employee)
                    {
                        //frmIndexEmployee frm = new frmIndexEmployee(user);
                        //frm.Show();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Wrong username or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private async void checkUserType(Users user)
        {
            int userTypeFirst = 0;
            if (user != null)
            {
                Global.LoggedUser = user;

                foreach (var item in Global.LoggedUser.UserTypes)
                {
                    if (item.IsActive)
                        userTypeFirst = item.UserTypeId;
                }
                role = await _userTypesService.GetById<UserTypes>(userTypeFirst);
                if (role.Id == (int)plagiarismModel.Enums.UserTypes.Admin)
                    Global.Admin = true;
                //if (role.Id == (int)UserTypes.Client)
                //    Global.Client = true;
                if (role.Id == (int)plagiarismModel.Enums.UserTypes.Employee)
                    Global.Employee = true;
                if (role.Id == (int)plagiarismModel.Enums.UserTypes.User)
                    Global.User = true;
            }
        }
    }
}
