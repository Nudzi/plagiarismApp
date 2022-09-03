using plagiarismModel;
using plagiarismModel.Enums;
using plagiarismModel.Requests.Documents;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace plagiarism.WinUI.DocumentsForms
{
    public partial class frmDocumentDetails : Form
    {
        private readonly APIService _packageTypesService = new APIService("packageTypes");
        private Documents _documents = null;
        public frmDocumentDetails(Documents documents)
        {
            InitializeComponent();
            _documents = documents;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void LoadExtensions()
        {
            var extenstionTypesList = new List<DocumentExtensionsRequest>
            {
                new DocumentExtensionsRequest
                {
                    Id = (int)ExtensionTypes.doc,
                    Name = ExtensionTypes.doc.ToString()
                },
                new DocumentExtensionsRequest
                {
                    Id = (int)ExtensionTypes.pdf,
                    Name = ExtensionTypes.pdf.ToString()
                }
            };
            cbExt.DataSource = extenstionTypesList;
            cbExt.DisplayMember = "Name";
            cbExt.ValueMember = "Id";
        }

        private void LoadTypes()
        {
            var extenstionTypesList = new List<DocumentExtensionsRequest>
            {
                new DocumentExtensionsRequest
                {
                    Id = 1,
                    Name = "Text"
                },
                new DocumentExtensionsRequest
                {
                    Id = 2,
                    Name = "Doc"
                }
            };
            cbType.DataSource = extenstionTypesList;
            cbType.DisplayMember = "Name";
            cbType.ValueMember = "Id";
        }

        private async Task LoadPackages()
        {
            var result = await _packageTypesService.Get<List<plagiarismModel.PackageTypes>>(null);
            cbPackageType.DataSource = result;
            cbPackageType.DisplayMember = "Name";
            cbPackageType.ValueMember = "Id";
        }

        private async void frmDocumentDetails_Load(object sender, EventArgs e)
        {
            LoadExtensions();
            LoadTypes();
            await LoadPackages();
            if (_documents != null)
            {
                txtAuthor.Text = _documents.Author;
                txtPublisher.Text = _documents.Publisher;
                txtLink.Text = _documents.Link;
                txtTextLenght.Text = _documents.Text.Length.ToString();
                txtTitle.Text = _documents.Title;
                txtTimesUsed.Text = _documents.TimeUsed.ToString();
            } else {

            }
        }
    }
}
