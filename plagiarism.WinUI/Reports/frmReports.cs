using plagiarismModel.Requests.UsersPackageTypes;
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
        private string Enable = "Enable";
        private string Disable = "Disable";
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
                btnFromDisable.Text = Enable;
                dtpFrom.Value = dtpTo.MinDate;
                return;
            }
            else if (btnFromDisable.Text.Equals(Enable))
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
                btnToDisable.Text = Enable;
                dtpTo.Value = dtpTo.MaxDate;
                return;
            }
            else if (btnToDisable.Text.Equals(Enable))
            {
                dtpTo.Enabled = true;
                btnToDisable.Text = Disable;
                dtpTo.Value = DateTime.Now;
                return;
            }
        }
    }
}
