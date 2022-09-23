using plagiarism.Mobile.Services;
using plagiarism.Mobile.Views;
using plagiarismModel;
using plagiarismModel.Enums;
using plagiarismModel.TableRequests.Documents;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace plagiarism.Mobile.ViewModels
{
    public class ScanViewModel : BaseViewModel
    {
        private readonly APIService _documentsService = new APIService("documents");

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

        internal bool CheckAllowedTextSize()
        {
            var maxTextSize = generateMaxTextSizeByPackage(Global.UsersPackageType.PackageTypeId);
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
            var docReq = new DocumentsSearchRequest();

            if (textLength < 3)
            {
                docReq.Text = Text;

                Global.MatchedDocs = await _documentsService.Get<List<Documents>>(docReq);
            }
            else
            {
                List<string> requestMatches = new List<string>();
                for (int i = 0; i < textLength; i++)
                {
                    if (i + 2 < textLength)
                    {
                        string requestMatchesString = aray[i] + " " + aray[i + 1] + " " + aray[i + 2];
                        if (!requestMatches.Contains(requestMatchesString))
                        {
                            requestMatches.Add(requestMatchesString);
                        }
                    }
                }
                docReq.matches = requestMatches;

                Global.MatchedDocs = await _documentsService.Plagiarism<List<Documents>>(docReq);

                double Total = 0;
                foreach (var item in Global.MatchedDocs)
                {
                    Total += Text.Length / (double)item.Text.Length;
                }

                Global.Percentage = (Total / Global.MatchedDocs.Count) * 100;

                if (Global.Percentage >= 100) Global.Percentage = 100;
                Application.Current.MainPage = new ResultsPage();
            }
        }
    }
}
