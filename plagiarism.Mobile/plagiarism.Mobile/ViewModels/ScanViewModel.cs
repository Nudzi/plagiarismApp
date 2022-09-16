using plagiarism.Mobile.Services;
using plagiarismModel;
using plagiarismModel.Enums;
using plagiarismModel.TableRequests.Documents;
using plagiarismModel.TableRequests.UsersPackageTypes;
using System;
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
            char[] delimiters = new char[] { ' ', '\r', '\n' };
            var aray = Text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            var textLength = Text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).Length;

            // uzmi skup po 3 rijeci i match
            if (textLength < 4)
            {
                var docReq = new DocumentsSearchRequest
                {
                    Text = Text
                };

                var matchedTexts = await _documentsService.Plagiarism<List<Documents>>(docReq);
            }
            else
            {
                List<string> mojArej = new List<string>();
                for (int i = 0; i < textLength; i++)
                {
                    var moj = "";
                    if (i + 2 < textLength)
                    {
                        moj = aray[i] + " " + aray[i + 1] + " " + aray[i + 2];
                        mojArej.Add(moj);
                    }
                    else
                    {
                        break;
                    }
                }
                var docReq = new DocumentsSearchRequest
                {
                    matches = mojArej
                };

                var matchedTexts = await _documentsService.Plagiarism<List<Documents>>(docReq);
            }
        }
    }
}

