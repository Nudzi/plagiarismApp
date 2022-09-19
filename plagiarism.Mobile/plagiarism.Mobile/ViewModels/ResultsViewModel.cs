using plagiarism.Mobile.Services;
using System;

namespace plagiarism.Mobile.ViewModels
{
    public class ResultsViewModel : BaseViewModel
    {
        private readonly APIService _usersPackageTypesService = new APIService("usersPackageTypes");
        private readonly APIService _documentsService = new APIService("documents");

        string _percentage = string.Empty;
        public string Percentage
        {
            get { return _percentage; }
            set { SetProperty(ref _percentage, value); }
        }

        string _docNames = string.Empty;
        public string DocNames
        {
            get { return _docNames; }
            set { SetProperty(ref _docNames, value); }
        }

        internal void Init()
        {
            foreach (var item in Global.MatchedDocs)
            {
                DocNames += item.Title + ", ";
            }

            Percentage = Math.Round(Global.Percentage, 2).ToString() + "%";
        }
    }
}
