using System;
using System.Windows.Forms;

namespace plagiarism.WinUI.DocumentsForms
{
    public partial class frmDocumentDetails : Form
    {
        public frmDocumentDetails()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
