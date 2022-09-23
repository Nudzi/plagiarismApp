using plagiarismModel;
using plagiarismModel.Enums;
using plagiarismModel.TableRequests.Documents;
using plagiarismModel.TableRequests.UsersPackageTypes;
using System.Collections.Generic;
using System.Windows.Forms;

namespace plagiarism.WinUI.RequestsForm
{
    public partial class frmRequestDetails : Form
    {
        private readonly APIService _usersPackageTypesService = new APIService("usersPackageTypes");
        private readonly APIService _requestsService = new APIService("requests");
        private readonly APIService _documentsService = new APIService("documents");
        private readonly Requests _request = null;
        public frmRequestDetails(Requests request)
        {
            InitializeComponent();
            _request = request;
        }

        private void frmRequestDetails_Load(object sender, System.EventArgs e)
        {
            LoadExtensions();
            LoadTypes();
            txtAuthor.Text = _request.Author;
            txtPublisher.Text = _request.Publisher;
            txtLink.Text = _request.Link;
            txtTextLenght.Text = _request.Text.Length.ToString();
            txtTitle.Text = _request.Title;
            txtContentText.Text = _request.Text;

            if (_request.Text == null)
            {
                cbType.Visible = false;
                cbExt.Visible = false;
                lblDocType.Visible = false;
                lblExt.Visible = false;
            }
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
                    Id = 0,
                    Name = "-"
                },
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

        private void cbType_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            {
                var idObj = cbType.SelectedValue; //idObj because it is object in service
                if (int.TryParse(idObj.ToString(), out int id))//so we need to parse it 
                {
                    if (id == 1)
                    {
                        cbExt.Visible = false;
                        lblExt.Visible = false;
                    }
                    else
                    {
                        cbExt.Visible = true;
                        lblExt.Visible = true;
                    }
                }
            }
        }

        private async void btnSave_Click(object sender, System.EventArgs e)
        {
            if (!checkType())
            {
                return;
            }

            var usrPckg = await _usersPackageTypesService.Get<List<plagiarismModel.UsersPackageTypes>>(
                new UsersPackageTypesSearchRequest
                {
                    UserId = Global.LoggedUser.Id
                });

            DocumentsUpsertRequest documentsUpsertRequest = new DocumentsUpsertRequest
            {
                Author = txtAuthor.Text,
                Publisher = txtPublisher.Text,
                Link = txtLink.Text,
                Title = txtTitle.Text,
                Text = txtContentText.Text,
                PackageTypeId = usrPckg[0].PackageTypeId,
                TimeUsed = 0
            };
            // doc type   
            var idObjVPTy = (DocumentExtensionsRequest)cbType.SelectedItem; ; //idObj because it is object in service
            documentsUpsertRequest.Type = idObjVPTy.Name;

            // extension
            var idObjVPEx = (DocumentExtensionsRequest)cbExt.SelectedItem; ; //idObj because it is object in service
            documentsUpsertRequest.Extension = idObjVPEx.Name;

            if (idObjVPTy.Id == 1)
            {
                documentsUpsertRequest.Extension = "doc";
            }

            await _documentsService.Insert<Documents>(documentsUpsertRequest);
            await _requestsService.Delete<Requests>(_request.Id);
            MessageBox.Show("Succesfully added new document!");
            this.Close();
        }

        private bool checkType()
        {
            var idObj = cbType.SelectedValue; //idObj because it is object in service
            if (int.TryParse(idObj.ToString(), out int id))//so we need to parse it 
            {
                if (id == 0)
                {
                    MessageBox.Show("Error, choose Type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }

        private async void btnCancel_Click(object sender, System.EventArgs e)
        {
            if (await _requestsService.Delete<Requests>(_request.Id) != null)
            {
                this.Close();
                MessageBox.Show("Success in removing request.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error, try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
