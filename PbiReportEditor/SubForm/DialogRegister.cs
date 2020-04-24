using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PbiReportEditor.Misc;

namespace PbiReportEditor.SubForm
{
    public partial class DialogRegister : Form
    {
        private string machine_code = string.Empty;
        private string reg_code = string.Empty;
        private const string admin_code = FormReportEditor.salt;

        public DialogRegister()
        {
            InitializeComponent();
        }

        private void DialogRegister_Load(object sender, EventArgs e)
        {
            this.machine_code = Helper.GetHDDSerialNumber(Helper.GetSystemDriveLetter());

            //MessageBox.Show(AppDomain.CurrentDomain.BaseDirectory);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.reg_code = ((TextBox)sender).Text;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(this.reg_code == admin_code)
            {
                File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @"lic.txt", this.machine_code.AES_Encrypt(FormReportEditor.salt));
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid register code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static bool IsRegister()
        {
            if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"lic.txt"))
            {
                return false;
            }
            else
            {
                string lic = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"lic.txt");
                if(lic.Trim().Length > 0 && Helper.GetHDDSerialNumber(Helper.GetSystemDriveLetter()).CompareTo(lic.AES_Decrypt(FormReportEditor.salt)) == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(keyData == Keys.Enter)
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
    }
}
