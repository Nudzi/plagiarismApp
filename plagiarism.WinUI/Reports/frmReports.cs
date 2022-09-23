using plagiarismModel.TableRequests.Documents;
using plagiarismModel.TableRequests.UsersPackageTypes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace plagiarism.WinUI.Reports
{
    public partial class frmReports : Form
    {
        private readonly APIService _usersPackageTypesService = new APIService("usersPackageTypes");
        private readonly APIService _packageTypesService = new APIService("packageTypes");
        private readonly APIService _documentsService = new APIService("documents");
        private readonly string Enable = "Enable";
        private readonly string Disable = "Disable";
        private decimal Summarize = 0;
        public frmReports()
        {
            InitializeComponent();
        }

        private async void btnPaymants_Click(object sender, EventArgs e)
        {
            Summarize = 0;
            var usrpck = await _usersPackageTypesService.Get<List<plagiarismModel.UsersPackageTypes>>(null);

            var reportList = new List<UsersPackageTypesReportRequest>();
            foreach (var item in usrpck)
            {
                if (item.CreatedDate > dtpFrom.Value && item.CreatedDate < dtpTo.Value && item.IsActive)
                {
                    var newReport = new UsersPackageTypesReportRequest
                    {
                        CreatedDate = item.CreatedDate,
                        Discount = item.Discount,
                        ExpiredDate = item.ExpiredDate,
                        PackageName = item.PackageType.Name,
                        Price = item.PackageType.Price,
                        Total = item.PackageType.Price - (item.PackageType.Price * (item.Discount / 100))
                    };
                    Summarize += newReport.Total;
                    reportList.Add(newReport);
                }
            }

            dgvResults.DataSource = reportList;

            for (int i = 0; i < dgvResults.Columns.Count; i++)
                dgvResults.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            txtSum.Text = Summarize.ToString() + " $";
        }

        Bitmap bmp;

        public string Enable1 => Enable;

        private void btnPrint_Click(object sender, EventArgs e)
        {
            int height = dgvResults.Height;
            dgvResults.Height = dgvResults.RowCount * dgvResults.RowTemplate.Height * 2;
            bmp = new Bitmap(dgvResults.Width, dgvResults.Height);
            dgvResults.DrawToBitmap(bmp, new Rectangle(0, 0, dgvResults.Width, dgvResults.Height));
            dgvResults.Height = height;

            txtSum.DrawToBitmap(bmp, new Rectangle(height, height, txtSum.Width, txtSum.Height));
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bmp, 0, 0);
        }

        private void btnFromDisable_Click(object sender, EventArgs e)
        {
            if (btnFromDisable.Text.Equals(Disable))
            {
                dtpFrom.Enabled = false;
                btnFromDisable.Text = Enable1;
                dtpFrom.Value = dtpTo.MinDate;
                return;
            }
            else if (btnFromDisable.Text.Equals(Enable1))
            {
                dtpFrom.Enabled = true;
                btnFromDisable.Text = Disable;
                dtpFrom.Value = DateTime.Now;
                return;
            }
        }

        private void btnToDisable_Click(object sender, EventArgs e)
        {
            if (btnToDisable.Text.Equals(Disable))
            {
                dtpTo.Enabled = false;
                btnToDisable.Text = Enable1;
                dtpTo.Value = dtpTo.MaxDate;
                return;
            }
            else if (btnToDisable.Text.Equals(Enable1))
            {
                dtpTo.Enabled = true;
                btnToDisable.Text = Disable;
                dtpTo.Value = DateTime.Now;
                return;
            }
        }

        private async void btnDoc_Click(object sender, EventArgs e)
        {
            Summarize = 0;
            var doc = await _documentsService.Get<List<plagiarismModel.Documents>>(null);
            var pacTypes = await _packageTypesService.Get<List<plagiarismModel.PackageTypes>>(null);


            var reportList = new List<DocumentsReportRequest>();
            foreach (var item in doc)
            {
                reportList.Add(new DocumentsReportRequest
                {
                    Author = item.Author,
                    Extension = item.Extension,
                    Publisher = item.Publisher,
                    Title = item.Title,
                    TimeUsed = (int)item.TimeUsed,
                    Type = item.Type,
                    PackageName = pacTypes.Find(x => x.Id == item.PackageTypeId).Name
                });
            }

            dgvResults.DataSource = reportList;

            for (int i = 0; i < dgvResults.Columns.Count; i++)
                dgvResults.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            txtSum.Text = Summarize.ToString() + " $";
        }
    }
}
