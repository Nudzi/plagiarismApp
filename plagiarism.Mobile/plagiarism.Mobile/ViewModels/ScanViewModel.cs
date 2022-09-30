using plagiarism.Mobile.Services;
using plagiarism.Mobile.Views;
using plagiarismModel;
using plagiarismModel.Enums;
using plagiarismModel.TableRequests.Documents;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
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


        internal async Task CheckPlagiarism(bool searchPhraze = false)
        {
            char[] delimiters = new char[] { ' ', '\r', '\n' };
            var aray = Text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            var textLength = Text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).Length;
            var docReq = new DocumentsSearchRequest();

            if (textLength < 3 || searchPhraze)
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

        private async void ScanOnline()
        {
            var requestUrl = "https://api.copyleaks.com/v3/downloads/" +
                Global.CustomId +
                "/export/" +
                Global.ExportId;

            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), requestUrl))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", "Bearer " + Global.AccessToken);

                    var data = "{\"results\":[{\"id\":\"my-result-id\",\"verb\":\"POST\",\"headers\"" +
                        ":[[\"header-key\",\"header-value\"]],\"endpoint\"" +
                        ":\"https://yourserver.com/export/export-id/results/my-result-id\"}]," +
                        "\"pdfReport\":{\"verb\":\"POST\",\"headers\":[[\"header-key\",\"header-value\"]]," +
                        "\"endpoint\":\"https://yourserver.com/export/export-id/pdf-report\"},\"crawledVersion\"" +
                        ":{\"verb\":\"POST\",\"headers\":[[\"header-key\",\"header-value\"]],\"endpoint\"" +
                        ":\"https://yourserver.com/export/export-id/crawled-version\"},\"completionWebhook\"" +
                        ":\"https://yourserver.com/export/export-id/completed\",\"maxRetries\":3}";
                    request.Content = new StringContent(data, Encoding.UTF8, "application/json");

                    var response = await httpClient.SendAsync(request);
                }
            }
        }
    }
}
