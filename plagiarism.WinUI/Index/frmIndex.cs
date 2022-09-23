using plagiarism.WinUI.DocumentsForms;
using plagiarism.WinUI.InstitutionsForms;
using plagiarism.WinUI.Reports;
using plagiarism.WinUI.RequestsForm;
using plagiarism.WinUI.Users;
using System;
using System.Windows.Forms;

namespace plagiarism.WinUI.Index
{
    public partial class frmIndex : Form
    {
        private int childFormNumber = 0;

        public frmIndex()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form
            {
                MdiParent = this,
                Text = "Window " + childFormNumber++
            };
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
            };
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                _ = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
            };
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                _ = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void viewAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsers frm = new frmUsers
            {
                MdiParent = this,
                WindowState = FormWindowState.Maximized
            };
            frm.Show();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserDetails frm = new frmUserDetails
            {
                MdiParent = this,
                WindowState = FormWindowState.Maximized
            };
            frm.Show();
        }

        private void viewAllToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmInstitutions frm = new frmInstitutions
            {
                MdiParent = this,
                WindowState = FormWindowState.Maximized
            };
            frm.Show();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReports frm = new frmReports
            {
                MdiParent = this,
                WindowState = FormWindowState.Maximized
            };
            frm.Show();
        }

        private void newToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmDocumentDetails frm = new frmDocumentDetails
            {
                MdiParent = this,
                WindowState = FormWindowState.Maximized
            };
            frm.Show();
        }

        private void viewAllToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmDocuments frm = new frmDocuments
            {
                MdiParent = this,
                WindowState = FormWindowState.Maximized
            };
            frm.Show();
        }

        private void viewAllToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frmRequests frm = new frmRequests
            {
                MdiParent = this,
                WindowState = FormWindowState.Maximized
            };
            frm.Show();
        }
    }
}
