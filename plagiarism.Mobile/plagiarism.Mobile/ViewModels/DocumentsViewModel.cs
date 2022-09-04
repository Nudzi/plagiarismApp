using plagiarism.Mobile.Services;
using plagiarismModel;
using plagiarismModel.TableRequests.Documents;
using plagiarismModel.TableRequests.UsersPackageTypes;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace plagiarism.Mobile.ViewModels
{
    public class DocumentsViewModel : BaseViewModel
    {
        private readonly APIService _documentsService = new APIService("documents");
        private readonly APIService _usersPackageTypesService = new APIService("usersPackageTypes");
        public ObservableCollection<Documents> DocList { get; set; } = new ObservableCollection<Documents>();

        public int pkcgUs = new int();
        Users _user = new Users();
        public Users User
        {
            get { return _user; }
            set { SetProperty(ref _user, value); }
        }

        bool _isText = true;
        public bool IsText
        {
            get { return _isText; }
            set { SetProperty(ref _isText, value); }
        }

        byte[] _image;
        public byte[] Image
        {
            get { return _image; }
            set { SetProperty(ref _image, value); }
        }

        string _title = string.Empty;
        public string DocTitle
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        string _publisher = string.Empty;
        public string Publisher
        {
            get { return _publisher; }
            set { SetProperty(ref _publisher, value); }
        }
        string _author = string.Empty;
        public string Author
        {
            get { return _author; }
            set { SetProperty(ref _author, value); }
        }

        string _link = string.Empty;
        public string Link
        {
            get { return _link; }
            set { SetProperty(ref _link, value); }
        }

        string _text = string.Empty;
        public string Text
        {
            get { return _text; }
            set { SetProperty(ref _text, value); }
        }

        public async Task Init()
        {
            User = Global.LoggedUser;
            var usersPackageTypesSearchRequest = new UsersPackageTypesSearchRequest
            {
                UserId = User.Id
            };
            var usersPackageTypes = await _usersPackageTypesService.Get<List<UsersPackageTypes>>(usersPackageTypesSearchRequest);

            pkcgUs = usersPackageTypes[0].PackageTypeId;
            DocumentsSearchRequest request = new DocumentsSearchRequest
            {
                PackageTypeId = pkcgUs
            };

            var documents = await _documentsService.Get<List<Documents>>(request);
            DocList.Clear();

            foreach (var item in documents)
            {
                DocList.Add(item);
            }
        }

        public async Task SearchByTitle(string title)
        {
            DocumentsSearchRequest request = new DocumentsSearchRequest
            {
                PackageTypeId = pkcgUs,
                Title = title
            };

            var documents = await _documentsService.Get<List<Documents>>(request);
            DocList.Clear();

            foreach (var item in documents)
            {
                DocList.Add(item);
            }
        }

        public async Task SearchByAuthor(string author)
        {
            DocumentsSearchRequest request = new DocumentsSearchRequest
            {
                PackageTypeId = pkcgUs,
                Author = author
            };

            var documents = await _documentsService.Get<List<Documents>>(request);
            DocList.Clear();

            foreach (var item in documents)
            {
                DocList.Add(item);
            }
        }

        public async Task SaveProposal()
        {

        }
    }
}