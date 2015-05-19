using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using MyEncrypt;
using GetUniqueID;

namespace DateAndTime
{
    public partial class frmEncrypt : Form
    {
        public frmEncrypt()
        {
            InitializeComponent();
        }

        private void frmEncrypt_Load(object sender, EventArgs e)
        {
            CPU getID = new CPU();
            string strMacCode = getID.GetCpuID();//获得CPU序列号：BFEBFBFF000306A9
            txtMacCode.Text = strMacCode;
        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            if (txtRegCode.Text == "")
            {
                MessageBox.Show("请填写注册码。", "提示");
                return;
            }

            MyDESEncrypt mdeEnc = new MyDESEncrypt();
            string strRegCode = mdeEnc.DESEncrypt(txtMacCode.Text, "DARMSYZX");//xLaDs84qVINN95zvKBGh1K85yggCZImR
            if (txtRegCode.Text == strRegCode)
            {
                MessageBox.Show("恭喜您注册成功。", "提示");
                RegistryKey rsk = null;
                rsk = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft", true);
                rsk.SetValue("Key", txtRegCode.Text);
                rsk.Close();
            }
            else
            {
                MessageBox.Show("您输入的注册码不正确，请重新输入。", "提示");
                return;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void frmEncrypt_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            //this.Close();
        }

    }
}
