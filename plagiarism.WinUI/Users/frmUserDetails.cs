using plagiarismModel;
using plagiarismModel.Enums;
using plagiarismModel.Requests.UserAddresses;
using plagiarismModel.Requests.Users;
using plagiarismModel.Requests.UsersPackageTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserTypes = plagiarismModel.Enums.UserTypes;

namespace plagiarism.WinUI.Users
{
    public partial class frmUserDetails : Form
    {
        private readonly APIService _service = new APIService("users");
        private readonly APIService _userTypesService = new APIService("userTypes");
        private readonly APIService _userAddressesService = new APIService("userAddresses");
        private readonly APIService _packageTypesService = new APIService("packageTypes");
        private readonly APIService _usersPackageTypesService = new APIService("usersPackageTypes");
        private plagiarismModel.Users _user;
        private bool isSaveCliked = false;
        private bool _token;
        public frmUserDetails(plagiarismModel.Users user = null, bool token = false)
        {
            InitializeComponent();
            _user = user;
            _token = token;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!checkPhoneNumber(txtTelephone.Text))
            {
                MessageBox.Show("Telephone number contains letters!");
                return;
            }

            isSaveCliked = true;
            if (ValidateChildren())
            {
                List<int> usertypes = new List<int>();
                if (_token)
                    usertypes.Add((int)UserTypes.User);
                else
                    usertypes = cblUserTypes.CheckedItems.Cast<plagiarismModel.UserTypes>().Select(x => x.Id).ToList();

                var request = new UsersInsertRequest()
                {
                    Email = txtEmail.Text,
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    UserName = txtUserName.Text,
                    Telephone = txtTelephone.Text,
                    Password = txtPassword.Text,
                    PasswordConfirmation = txtPasswordConfirmation.Text,
                    Status = cbStatus.Checked,
                    OfficialName = txtOfficialName.Text,
                    UserTypes = usertypes
                };

                if (_user == null)
                {
                    try
                    {
                        // address
                        UserAddressesUpsertRequest userAddressesUpserRequest = new UserAddressesUpsertRequest
                        {
                            Street = txtStreet.Text,
                            City = txtCity.Text,
                            State = txtState.Text,
                            ZipCode = txtZipCode.Text
                        };
                        var adress = await _userAddressesService.Insert<UserAddresses>(userAddressesUpserRequest);
                        request.UserAddressId = adress.Id;

                        // user
                        var newUser = await _service.Insert<plagiarismModel.Users>(request);

                        // package
                        var packageTypeIdNoValue = 0;
                        var idObjVP = cbPackage.SelectedValue; //idObj because it is object in service
                        if (int.TryParse(idObjVP.ToString(), out int packageTypeId))//so we need to parse it 
                        {
                            packageTypeIdNoValue = packageTypeId;
                        }

                        var idObjVPName = (PackageTypes)cbPackage.SelectedItem;
                        UsersPackageTypesUpsertRequest usersPackageTypesUpsert = new UsersPackageTypesUpsertRequest
                        {
                            IsActive = true,
                            CreatedDate = DateTime.Now,
                            ExpiredDate = buildPackageExpDate(idObjVPName.Name),
                            Discount = buildPackageDisc(idObjVPName.Name),
                            UserId = newUser.Id,
                            PackageTypeId = packageTypeIdNoValue
                        };

                        await _usersPackageTypesService.Insert<UsersPackageTypes>(usersPackageTypesUpsert);
                        MessageBox.Show("Succesfully added!");
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    request.Id = _user.Id;
                    request.UserAddressId = _user.UserAddressId;    
                    try
                    {
                        // address
                        UpdateUserAddress((int)_user.UserAddressId);

                        // user
                        await _service.Update<plagiarismModel.Users>(_user.Id, request);

                        // package
                        var packageTypeIdNoValue = 0;
                        var idObjVP = cbPackage.SelectedValue; //idObj because it is object in service
                        if (int.TryParse(idObjVP.ToString(), out int packageTypeId))//so we need to parse it 
                        {
                            packageTypeIdNoValue = packageTypeId;
                        }

                        var usersPackageTypesSearchRequest = new UsersPackageTypesSearchRequest
                        {
                            UserId = _user.Id
                        };
                        var oldUserPackageTypes = await _usersPackageTypesService.Get<List<UsersPackageTypes>>(usersPackageTypesSearchRequest);

                        var idObjVPName = (PackageTypes)cbPackage.SelectedItem;
                        UsersPackageTypesUpsertRequest usersPackageTypesUpsert = new UsersPackageTypesUpsertRequest
                        {
                            Id = oldUserPackageTypes[0].Id,
                            IsActive = true,
                            CreatedDate = DateTime.Now,
                            ExpiredDate = buildPackageExpDate(idObjVPName.Name),
                            Discount = buildPackageDisc(idObjVPName.Name),
                            UserId = _user.Id,
                            PackageTypeId = packageTypeIdNoValue
                        };
                        await _usersPackageTypesService.Update<UsersPackageTypes>(oldUserPackageTypes[0].Id, usersPackageTypesUpsert);

                        MessageBox.Show("Succesfully updated!");
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private async void frmUserDetails_Load(object sender, EventArgs e)
        {
            await LoadUserTypes();
            await LoadPackages();

            if (_user != null)
            {
                cbPackage.Visible = false;

                txtEmail.Text = _user.Email;
                txtFirstName.Text = _user.FirstName;
                txtLastName.Text = _user.LastName;
                txtTelephone.Text = _user.Telephone;
                txtUserName.Text = _user.UserName;
                cbStatus.Checked = (bool)_user.Status;
                txtOfficialName.Text = _user.OfficialName;

                // addresses
                var userAddresse = await _userAddressesService.GetById<plagiarismModel.UserAddresses>(_user.UserAddressId);

                txtZipCode.Text = userAddresse.ZipCode;
                txtStreet.Text = userAddresse.Street;
                txtState.Text = userAddresse.State;
                txtCity.Text = userAddresse.City;

                // package 
                var usersPackageTypesSearchRequest = new UsersPackageTypesSearchRequest
                {
                    UserId = _user.Id
                };
                var usersPackageTypes = await _usersPackageTypesService.Get<List<UsersPackageTypes>>(usersPackageTypesSearchRequest);

                var packageTypes = await _packageTypesService.GetById<PackageTypes>(usersPackageTypes[0].PackageTypeId);

                txtPackage.Text = packageTypes.Name;
                if (_user.OfficialName == "")
                {
                    txtOfficialName.Visible = false;
                    lblOfficialName.Visible = false;
                    cbkIsUser.Checked = true;
                    cbkIsUser.Enabled = false;
                } else
                {
                    cbkIsUser.Checked = false;
                    cbkIsUser.Enabled = false;
                    txtFirstName.Visible = false;
                    lblFirstName.Visible = false;
                    txtLastName.Visible = false;
                    lblLastName.Visible = false;
                }
            } else
            {
                cbkIsUser.Checked = true;
                txtOfficialName.Visible = false;
                lblOfficialName.Visible = false;
                txtPackage.Visible = false;
                cbNewPackage.Visible = false;
            }
        }

        private async Task LoadUserTypes()
        {
            var userTypes = await _userTypesService.Get<List<plagiarismModel.UserTypes>>(null);
            cblUserTypes.DataSource = userTypes;
            cblUserTypes.DisplayMember = "Name";
        }

        private async Task LoadPackages()
        {
            var result = await _packageTypesService.Get<List<plagiarismModel.PackageTypes>>(null);
            cbPackage.DataSource = result;
            cbPackage.DisplayMember = "Name";
            cbPackage.ValueMember = "Id";
        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUserName.Text))
            {
                errorProvider.SetError(txtUserName, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtUserName, null);
            }
        }

        private void txtTelephone_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTelephone.Text))
            {
                errorProvider.SetError(txtTelephone, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtTelephone, null);
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                errorProvider.SetError(txtEmail, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtEmail, null);
            }
        }

        private void txtLastName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLastName.Text) && cbkIsUser.Checked == true)
            {
                errorProvider.SetError(txtLastName, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtLastName, null);
            }
        }

        private void txtFirstName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) && isSaveCliked == true && cbkIsUser.Checked == true)
            {
                errorProvider.SetError(txtFirstName, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
                isSaveCliked = false;
            }
            else
            {
                errorProvider.SetError(txtFirstName, null);
            }
        }

        private void cbkIsUser_CheckedChanged(object sender, EventArgs e)
        {
            if (cbkIsUser.Checked)
            {
                txtOfficialName.Visible = false;
                lblOfficialName.Visible = false;
                txtFirstName.Visible = true;
                lblFirstName.Visible = true;
                txtLastName.Visible = true;
                lblLastName.Visible = true;
            } else
            {
                txtOfficialName.Visible = true;
                lblOfficialName.Visible = true;
                txtFirstName.Visible = false;
                lblFirstName.Visible = false;
                txtLastName.Visible = false;
                lblLastName.Visible = false;
            }
        }

        private bool checkPhoneNumber(string telephoneNumber)
        {
            foreach (char item in telephoneNumber)
            {
                if (!char.IsDigit(item))
                    return false;
            }
            return true;
        }

        private void txtOfficialName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtOfficialName.Text) && cbkIsUser.Checked == false)
            {
                errorProvider.SetError(txtOfficialName, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtOfficialName, null);
            }
        }

        private void txtState_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtState.Text))
            {
                errorProvider.SetError(txtState, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtState, null);
            }
        }

        private void txtCity_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCity.Text))
            {
                errorProvider.SetError(txtCity, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtCity, null);
            }
        }

        private void txtStreet_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtStreet.Text))
            {
                errorProvider.SetError(txtStreet, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtStreet, null);
            }
        }

        private void txtZipCode_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtZipCode.Text))
            {
                errorProvider.SetError(txtZipCode, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtZipCode, null);
            }
        }

        private async void UpdateUserAddress(int id)
        {
            UserAddressesUpsertRequest userAddressesUpserRequest = new UserAddressesUpsertRequest
            {
                Id = id,
                Street = txtStreet.Text,
                City = txtCity.Text,
                State = txtState.Text,
                ZipCode = txtZipCode.Text
            };
            await _userAddressesService.Update<UserAddresses>(id, userAddressesUpserRequest);

        }

        private void cbNewPackage_CheckedChanged(object sender, EventArgs e)
        {
            if (cbNewPackage.Checked)
            {
                txtPackage.Visible = false;
                cbPackage.Visible = true;
            } else
            {
                txtPackage.Visible = true;
                cbPackage.Visible = false;
            }
        }

        public decimal buildPackageDisc(string package)
        {
            if (PackageTypesTypes.Basic.ToString().Equals(package))
            {
                return (decimal)PackageTypesDisc.Basic;
            }
            if (PackageTypesTypes.Silver.ToString().Equals(package))
            {
                return (decimal)PackageTypesDisc.Silver;
            }
            else
            {
                return (decimal)PackageTypesDisc.Premium;
            }
        }

        public DateTime buildPackageExpDate(string package)
        {
            if (PackageTypesExpDate.Basic.ToString().Equals(package))
                return DateTime.Now.AddMonths((int)(PackageTypesExpDate.Basic));
            if (PackageTypesExpDate.Silver.ToString().Equals(package))
                return DateTime.Now.AddMonths((int)(PackageTypesExpDate.Silver));
            else return DateTime.Now.AddMonths((int)(PackageTypesExpDate.Premium));
        }
    }
}
