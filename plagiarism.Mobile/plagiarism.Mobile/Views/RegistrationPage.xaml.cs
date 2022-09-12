using plagiarism.Mobile.Services;
using plagiarism.Mobile.ViewModels;
using plagiarismModel;
using plagiarismModel.TableRequests.PackageTypes;
using Plugin.Media;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace plagiarism.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage
    {
        RegisterViewModel model = null;
        APIService _usersService = new APIService("users");
        public RegistrationPage()
        {
            InitializeComponent();
            BindingContext = model = new RegisterViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }

        private async void ButtonRegister_Clicked(object sender, EventArgs e)
        {
            model.SelectedPackageTypes = new PackageTypesRegistrationSearchRequest("Basic", "Basic - 0$", 1);
            await Register();
        }

        private void ButtonRegister_Clicked_1(object sender, EventArgs e)
        {

        }

        private async Task Register()
        {
            bool doubleUserName = false;
            bool doubleEmail = false;
            bool doubleTelephone = false;

            List<Users> lista = await _usersService.Get<List<Users>>(null);

            foreach (var item in lista)
            {
                if (item.UserName.Equals(inputUserName.Text) == true)
                {
                    doubleUserName = true;
                }
                if (item.Email.Equals(inputEmail.Text) == true)
                {
                    doubleEmail = true;
                }
                if (item.Telephone.Equals(inputTelephone.Text) == true)
                {
                    doubleTelephone = true;
                }
            }
            if (validateRegistration() == true)
            {

                if (doubleUserName == true)
                {
                    await DisplayAlert("Error", "User name already exists!", "OK");
                    userNameError.Text = "User name already exists!";
                    userNameError.IsVisible = true;
                }
                else if (doubleEmail == true)
                {
                    await DisplayAlert("Error", "Email already exists!", "OK");
                    emailError.Text = "Email already exists!";
                    emailError.IsVisible = true;

                }
                else if (doubleTelephone == true)
                {
                    await DisplayAlert("Error", "Telephone already exists!", "OK");
                    telephoneError.Text = "Telephone already exists!";
                    telephoneError.IsVisible = true;

                }
                else
                {
                    await model.Register();
                }
            }
            else
            {
                await DisplayAlert("Error", "Wrong input!", "OK");
            }
        }

        private bool validateRegistration()
        {
            bool valid = true;
            if (validateEmail() == false)
                valid = false;
            if (validateUserName() == false)
                valid = false;
            if (validatePassword() == false)
                valid = false;
            if (validateTelephone() == false)
                valid = false;
            if (validatePasswordConf() == false)
                valid = false;
            if (validateAddress() == false)
                valid = false;
            if (validateCity() == false)
                valid = false;
            if (validateCountry() == false)
                valid = false;
            if (validateZipCode() == false)
                valid = false;
            if (validateImage() == false)
                valid = false;

            return valid;
        }

        private bool validateTelephone()
        {
            if (inputTelephone.Text == "")
            {
                telephoneError.Text = "Must insert Telephone!";
                telephoneError.IsVisible = true;
                return false;
            }
            else
            {
                telephoneError.IsVisible = false;
                telephoneError.Text = "";
                return true;
            }
        }

        private bool validateEmail()
        {
            try
            {
                MailAddress mail = new MailAddress(inputEmail.Text);
            }
            catch (Exception)
            {
                emailError.Text = "Email not in the correct format!";
                emailError.IsVisible = true;
                return false;
            }

            if (inputEmail.Text == "")
            {
                emailError.Text = "Must insert Email!";
                emailError.IsVisible = true;
                return false;
            }
            else
            {
                emailError.IsVisible = false;
                emailError.Text = "";
                return true;
            }
        }

        private bool validateAddress()
        {
            if (inputAddress.Text == "")
            {
                addressError.Text = "Must insert Address!";
                addressError.IsVisible = true;
                return false;
            }
            else
            {
                addressError.IsVisible = false;
                addressError.Text = "";
                return true;
            }
        }

        private bool validateCity()
        {
            if (inputCity.Text == "")
            {
                cityError.Text = "Must insert City!";
                cityError.IsVisible = true;
                return false;
            }
            else
            {
                cityError.IsVisible = false;
                cityError.Text = "";
                return true;
            }
        }

        private bool validateCountry()
        {
            if (inputCountry.Text == "")
            {
                countryError.Text = "Must insert Country!";
                countryError.IsVisible = true;
                return false;
            }
            else
            {
                countryError.IsVisible = false;
                countryError.Text = "";
                return true;
            }
        }

        private bool validateZipCode()
        {
            if (inputZipCode.Text == "")
            {
                zipcodeError.Text = "Must insert ZipCode!";
                countryError.IsVisible = true;
                return false;
            }
            else
            {
                zipcodeError.IsVisible = false;
                zipcodeError.Text = "";
                return true;
            }
        }

        private bool validateUserName()
        {
            if (inputUserName.Text == "")
            {
                userNameError.Text = "Must insert User name!";
                userNameError.IsVisible = true;
                return false;
            }
            if (inputUserName.Text.Count() < 2)
            {
                userNameError.Text = "User name must be above 2 characters";
                userNameError.IsVisible = true;
                return false;
            }
            else
            {
                userNameError.IsVisible = false;
                userNameError.Text = "";
                return true;
            }
        }

        private bool validatePassword()
        {
            if (inputPassword.Text == "")
            {
                passwordError.Text = "Must insert password!";
                passwordError.IsVisible = true;
                return false;
            }
            if (inputPassword.Text == inputUserName.Text)
            {
                passwordError.Text = "Password and User name must be differente!";
                passwordError.IsVisible = true;
                return false;
            }
            else
            {
                passwordError.IsVisible = false;
                passwordError.Text = "";
                return true;
            }
        }

        private bool validatePasswordConf()
        {
            if (inputPassword.Text != inputConf.Text)
            {

                passwordConfError.Text = "Passwords do not match!";
                passwordConfError.IsVisible = true;
                return false;
            }
            else
            {
                passwordConfError.Text = "";
                passwordConfError.IsVisible = false;
                return true;
            }
        }

        private bool validateImage()
        {
            if (resultImage.Source == null)
            {
                imageError.Text = "Must upload Image!";
                imageError.IsVisible = true;
                return false;
            }
            else
            {
                imageError.IsVisible = false;
                imageError.Text = "";
                return true;
            }
        }

        private void Remove_Picture(object sender, System.EventArgs e)
        {
            resultImage.Source = null;
        }

        private async void Add_Picture(object sender, System.EventArgs e)
        {
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Photos Not Supported", ":( Permission not granted to photos.", "OK");
                return;
            }
            var file = await CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
            {
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Small
            });

            if (file == null)
                return;
            var stream = file.GetStream();

            resultImage.Source = ImageSource.FromStream(() => stream);
            var memoryStream = new MemoryStream();
            file.GetStream().CopyTo(memoryStream);
            file.Dispose();
            model.byteImage = memoryStream.ToArray();
        }

        private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            bool isUserChecked = isUser_Check.IsChecked;
            if (isUserChecked)
            {
                officialNameVisible.IsVisible = false;
                inputOfficialName.IsVisible = false;
                firstNameVisible.IsVisible = true;
                lastNameVisible.IsVisible = true;
                inputLastName.IsVisible = true;
                inputFirstName.IsVisible = true;
            }
            else
            {
                officialNameVisible.IsVisible = true;
                inputOfficialName.IsVisible = true;
                firstNameVisible.IsVisible = false;
                lastNameVisible.IsVisible = false;
                inputLastName.IsVisible = false;
                inputFirstName.IsVisible = false;
            }
        }
    }
}