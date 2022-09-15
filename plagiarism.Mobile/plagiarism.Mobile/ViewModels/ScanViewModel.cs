using plagiarism.Mobile.Services;
using plagiarismModel;
using plagiarismModel.Enums;
using plagiarismModel.TableRequests.Documents;
using plagiarismModel.TableRequests.UsersPackageTypes;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace plagiarism.Mobile.ViewModels
{
    public class ScanViewModel : BaseViewModel
    {
        private readonly APIService _usersPackageTypesService = new APIService("usersPackageTypes");
        private readonly APIService _documentsService = new APIService("documents");

        int pckgUsr = 0;

        string _text = string.Empty;
        public string Text
        {
            get { return _text; }
            set { SetProperty(ref _text, value); }
        }

        string _textError = string.Empty;
        public string TextError
        {
            get { return _textError; }
            set { SetProperty(ref _textError, value); }
        }

        Users _user = new Users();
        public Users User
        {
            get { return _user; }
            set { SetProperty(ref _user, value); }
        }

        internal async Task<bool> CheckAllowedTextSize()
        {
            User = Global.LoggedUser;
            var usersPackageTypesSearchRequest = new UsersPackageTypesSearchRequest
            {
                UserId = User.Id
            };
            var usersPackageTypes = await _usersPackageTypesService.Get<List<UsersPackageTypes>>(usersPackageTypesSearchRequest);

            pckgUsr = usersPackageTypes[0].PackageTypeId;
            var maxTextSize = generateMaxTextSizeByPackage(pckgUsr);
            TextError = "Your maximum Text size is: " + maxTextSize + ", but you inserted: " + Text.Length;
            return Text.Length > maxTextSize;
        }

        private int generateMaxTextSizeByPackage(int packageTypeId)
        {
            if (packageTypeId.Equals((int)PackageTypesTypes.Basic))
                return 1000;
            if (packageTypeId.Equals((int)PackageTypesTypes.Silver))
                return 2500;
            else return 80000;
        }


        internal async Task CheckPlagiarism()
        {
            var docReq = new DocumentsSearchRequest
            {
                Text = Text
            };

            var matchedTexts = await _documentsService.Plagiarism<List<Documents>>(docReq);

            await Application.Current.MainPage.DisplayAlert("", matchedTexts[0].Title, "OK");
        }
    }
}
