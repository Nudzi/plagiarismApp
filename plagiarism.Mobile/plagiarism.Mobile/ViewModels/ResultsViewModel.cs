using plagiarism.Mobile.Services;
using plagiarismModel;
using plagiarismModel.TableRequests.Documents;
using plagiarismModel.TableRequests.Results;
using System;

namespace plagiarism.Mobile.ViewModels
{
    public class ResultsViewModel : BaseViewModel
    {
        private readonly APIService _resultsService = new APIService("results");
        private readonly APIService _documentsService = new APIService("documents");
        private int inValidDocuments = 0;

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

        internal async void Init()
        {
            Percentage = Math.Round(Global.Percentage, 2).ToString() + "%";

            ResultsUpsertRequest resultsUpsertRequest = new ResultsUpsertRequest
            {
                UserId = Global.LoggedUser.Id,
                Percentage = (decimal)Global.Percentage,
                RunDate = DateTime.Now
            };

            await _resultsService.Insert<Results>(resultsUpsertRequest);
            inValidDocuments = 0;
            foreach (var item in Global.MatchedDocs)
            {
                DocumentsUpsertRequest request = new DocumentsUpsertRequest
                {
                    Id = item.Id,
                    TimeUsed = (int)(item.TimeUsed + 1)
                };

                await _documentsService.Update<Documents>(item.Id, request);
                CheckDocumentPackage(item);
            }

            if (inValidDocuments != 0)
            {
                DocNames += " and " + inValidDocuments + " documents " +
                    "more. (Buy higher package for info).";
            }

         }

        private void CheckDocumentPackage(Documents item)
        {
            if (item.PackageTypeId <= Global.UsersPackageType.PackageTypeId)
            {
                DocNames += item.Title + " " + "(" + item.Author + "), ";
            }
            else
            {
                inValidDocuments += 1;
            }
        }
    }
}
