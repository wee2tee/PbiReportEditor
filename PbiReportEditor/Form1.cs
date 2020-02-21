using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PbiReportEditor.Misc;
using System.IO;

namespace PbiReportEditor
{
    public partial class Form1 : Form
    {
        private string source_filename = string.Empty;
        private string enc_filename = string.Empty;
        private string dec_filename = string.Empty;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Report File (*.rpbi)|*.rpbi";
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                this.txtSource.Text = ofd.FileName;

                this.txtEnc.Text = Directory.GetParent(ofd.FileName) + @"\" + Path.GetFileNameWithoutExtension(ofd.FileName) + "-enc.rpbi";
                this.txtDec.Text = Directory.GetParent(ofd.FileName) + @"\" + Path.GetFileNameWithoutExtension(ofd.FileName) + "-dec.rpbi";
            }
        }

        private void txtSource_TextChanged(object sender, EventArgs e)
        {
            this.source_filename = ((TextBox)sender).Text;
            this.ValidateFormData();
        }

        private void ValidateFormData()
        {
            if(this.source_filename.Trim().Length == 0)
            {
                this.btnEncrypt.Enabled = false;
            }
            else
            {
                this.btnEncrypt.Enabled = true;
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.txtSource.Text = string.Empty;
            this.txtEnc.Text = string.Empty;
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            string source = File.ReadAllText(this.source_filename);

            string encrypted_string = source.AES_Encrypt("esg.co.th");
            File.WriteAllText(this.enc_filename, encrypted_string);
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            string source = File.ReadAllText(this.enc_filename);

            string decrypted_string = source.AES_Decrypt("esg.co.th");
            File.WriteAllText(this.dec_filename, decrypted_string);
        }

        private void txtEnc_TextChanged(object sender, EventArgs e)
        {
            this.enc_filename = ((TextBox)sender).Text;
        }

        private void txtDec_TextChanged(object sender, EventArgs e)
        {
            this.dec_filename = ((TextBox)sender).Text;
        }
    }
}
