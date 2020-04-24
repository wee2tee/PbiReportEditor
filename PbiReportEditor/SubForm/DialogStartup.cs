using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace PbiReportEditor.SubForm
{
    public partial class DialogStartup : Form
    {
        public string selected_file_path;

        public DialogStartup()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "PBI report|*.rpbi";
            ofd.Title = "เลือกแฟ้มรายงานที่มีอยู่ เพื่อทำการแก้ไข";
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                this.selected_file_path = ofd.FileName;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PBI report|*.rpbi";
            sfd.DefaultExt = "rpbi";
            sfd.Title = "ระบุตำแหน่ง และ ชื่อแฟ้มรายงานใหม่ที่ต้องการบันทึก";
            
            if(sfd.ShowDialog() == DialogResult.OK)
            {
                if(!File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"Sample\sample_rep.rpbi"))
                {
                    MessageBox.Show("Cannot find sample report folder", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                File.WriteAllText(sfd.FileName, File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"Sample\sample_rep.rpbi"));
                this.selected_file_path = sfd.FileName;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(keyData == Keys.O)
            {
                this.btnOpen.PerformClick();
                return true;
            }

            if(keyData == Keys.C)
            {
                this.btnCreate.PerformClick();
                return true;
            }

            if(keyData == Keys.Escape)
            {
                this.btnClose.PerformClick();
                return true;
            }
            
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
