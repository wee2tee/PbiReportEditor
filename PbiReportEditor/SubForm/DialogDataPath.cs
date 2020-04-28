using CC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PbiReportEditor.SubForm
{
    public partial class DialogDataPath : Form
    {
        public string data_path = null;

        public DialogDataPath(string data_path = null)
        {
            InitializeComponent();

            if (data_path != null && data_path.Trim().Length > 0)
                this.txtPath.Text = data_path;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fd = new FolderBrowserDialog();
            if(fd.ShowDialog() == DialogResult.OK)
            {
                this.txtPath.Text = fd.SelectedPath;
            }
        }

        private void txtPath_TextChanged(object sender, EventArgs e)
        {
            this.data_path = ((TextBox)sender).Text.Trim().Length > 0 ? ((TextBox)sender).Text : null;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(this.data_path == null)
            {
                XMessageBox.Show("กรุณาระบุที่เก็บข้อมูล", "", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                return;
            }

            if(!(File.Exists(this.data_path + @"\armas.dbf") && File.Exists(this.data_path + @"\apmas.dbf") && File.Exists(this.data_path + @"\stmas.dbf") && File.Exists(this.data_path + @"\glacc.dbf") && File.Exists(this.data_path + @"\oeslm.dbf") && File.Exists(this.data_path + @"\istab.dbf")))
            {
                XMessageBox.Show("กรุณาระบุที่เก็บข้อมูลให้ถูกต้อง", "", MessageBoxButtons.OK, XMessageBoxIcon.Stop);
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(keyData == Keys.F5)
            {
                this.btnOK.PerformClick();
                return true;
            }

            if(keyData == Keys.Escape)
            {
                this.btnCancel.PerformClick();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void DialogDataPath_Shown(object sender, EventArgs e)
        {
            this.ActiveControl = this.txtPath;
        }
    }
}
