using plagiarismModel;
using plagiarismModel.Enums;
using plagiarismModel.TableRequests.Documents;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace plagiarism.WinUI.DocumentsForms
{
    public partial class frmDocumentDetails : Form
    {
        private readonly APIService _packageTypesService = new APIService("packageTypes");
        private readonly APIService _documentsService = new APIService("documents");
        private readonly Documents _documents = null;
        public frmDocumentDetails(Documents documents = null)
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
                // cannot edit existing doc's image
                txtImageInput.Visible = false;
                lblImage.Visible = false;
                pbUpload.Visible = false;
                btnAdd.Visible = false;

                var newDoc = await _packageTypesService.GetById<PackageTypes>(_documents.PackageTypeId);
                _documents.PackageType = newDoc;

                cbNewPackage.Checked = false;
                txtAuthor.Text = _documents.Author;
                txtPublisher.Text = _documents.Publisher;
                txtLink.Text = _documents.Link;
                txtTextLenght.Text = _documents.Text.Length.ToString();
                txtTitle.Text = _documents.Title;
                txtTimesUsed.Text = _documents.TimeUsed.ToString();
                txtPackageType.Text = _documents.PackageType.Name;
                txtExtension.Text = _documents.Extension;
                txtDocType.Text = _documents.Type;
                txtContentText.Text = _documents.Text;

                txtExtension.ReadOnly = true;
                txtDocType.ReadOnly = true;
                txtExtension.ReadOnly = true;

                cbPackageType.Visible = false;
                cbExt.Visible = false;
                cbType.Visible = false;

                txtPackageType.Visible = true;
                txtExtension.Visible = true;
                txtDocType.Visible = true;

            }
            else
            {
                cbNewPackage.Visible = false;

                cbPackageType.Visible = true;
                cbExt.Visible = true;
                cbType.Visible = true;

                txtPackageType.Visible = false;
                txtExtension.Visible = false;
                txtDocType.Visible = false;
            }
        }

        private void cbNewPackage_CheckedChanged(object sender, EventArgs e)
        {
            if (cbNewPackage.Checked)
            {
                cbPackageType.Visible = true;
                txtPackageType.Visible = false;
            }
            else
            {
                cbPackageType.Visible = false;
                txtPackageType.Visible = true;
            }
        }

        readonly DocumentsUpsertRequest request = new DocumentsUpsertRequest();

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                request.Author = txtAuthor.Text;
                request.Publisher = txtPublisher.Text;
                request.Link = txtLink.Text;
                request.Title = txtTitle.Text;
                request.Text = txtContentText.Text;
                request.TimeUsed = 0;

                try
                {
                    if (_documents != null)
                    {
                        request.TimeUsed = (int)_documents.TimeUsed;
                        request.Extension = txtExtension.Text;
                        request.Type = txtDocType.Text;
                        request.Id = _documents.Id;
                        request.Image = _documents.Image;
                        request.ImageThumb = _documents.ImageThumb;

                        // package
                        if (cbNewPackage.Checked)
                        {
                            var packageTypeIdNoValue = 0;
                            var idObjVP = cbPackageType.SelectedValue; //idObj because it is object in service
                            if (int.TryParse(idObjVP.ToString(), out int packageTypeId))//so we need to parse it 
                            {
                                packageTypeIdNoValue = packageTypeId;
                            }

                            request.PackageTypeId = packageTypeIdNoValue;
                        }
                        else
                        {
                            request.PackageTypeId = _documents.PackageTypeId;
                        }

                        await _documentsService.Update<Documents>(_documents.Id, request);
                        MessageBox.Show("Succesfully updated!");
                        this.Close();
                    }
                    else
                    {
                        // package
                        var idObjVP = cbPackageType.SelectedValue; //idObj because it is object in service
                        if (int.TryParse(idObjVP.ToString(), out int typeId))//so we need to parse it 
                        {
                            request.PackageTypeId = typeId;
                        }

                        // doc type   
                        var idObjVPTy = (DocumentExtensionsRequest)cbType.SelectedItem; ; //idObj because it is object in service
                        request.Type = idObjVPTy.Name;

                        // extension
                        var idObjVPEx = (DocumentExtensionsRequest)cbExt.SelectedItem; ; //idObj because it is object in service
                        request.Extension = idObjVPEx.Name;

                        if (idObjVPTy.Id == 1)
                        {
                            request.Extension = "doc";
                        }

                        if (txtImageInput.Text == "")
                        {
                            var filename = "";
                            var file = File.ReadAllBytes(filename);//to get bytes from our filename
                            request.Image = file;
                            request.ImageThumb = file;
                            txtImageInput.Text = filename;
                            Image img = Image.FromFile(filename);
                            pbUpload.Image = img;
                        }

                        await _documentsService.Insert<Documents>(request);
                        MessageBox.Show("Succesfully added!");
                        this.Close();
                    }
                }
                catch
                {
                    MessageBox.Show("Error, try later.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtTitle_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                errorProvider.SetError(txtTitle, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtTitle, null);
            }
        }

        private void txtAuthor_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAuthor.Text))
            {
                errorProvider.SetError(txtAuthor, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtAuthor, null);
            }
        }

        private void txtPublisher_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPublisher.Text))
            {
                errorProvider.SetError(txtPublisher, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtPublisher, null);
            }
        }

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            var idObj = cbType.SelectedValue; //idObj because it is object in service
            if (int.TryParse(idObj.ToString(), out int id))//so we need to parse it 
            {
                if (id == 1)
                {
                    txtContentText.ReadOnly = false;
                    cbExt.Visible = false;
                }
                else
                {
                    txtContentText.ReadOnly = true;
                    cbExt.Visible = true;
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                var filename = openFileDialog.FileName;
                var file = File.ReadAllBytes(filename);//to get bytes from our filename
                request.Image = file;
                request.ImageThumb = file;
                txtImageInput.Text = filename;
                Image img = Image.FromFile(filename);
                pbUpload.Image = img;
            }
        }

        private void txtContentText_TextChanged(object sender, EventArgs e)
        {
            txtTextLenght.Text = txtContentText.Text.Length.ToString();
        }
    }
}
