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

        internal async Task Init()
        {


        }
    }
}
