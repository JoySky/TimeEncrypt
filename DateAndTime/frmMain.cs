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
using System.Text.RegularExpressions;
namespace DateAndTime
{
    public partial class frmMain : Form
    {
        private DateTime startTime;
        private DateTime endTime;
        private DateTime firstDate;
        private DateTime lastDate;
        public frmMain()
        {
            InitializeComponent();
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            RegistryKey rsk = null;
            rsk = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft", true);
            //判断Date键是否有值
            CPU getID = new CPU();
            string strMacCode = getID.GetCpuID();//获得CPU序列号：BFEBFBFF000306A9
            //先判断是否注册
            if (rsk.GetValue("Key") != null)
            {
                string strGetCode = rsk.GetValue("Key").ToString();
                MyDESEncrypt mde = new MyDESEncrypt();
                if (mde.DESDecrypt(strGetCode, "DARMSYZX") == strMacCode)
                {
                    //有注册码，表示注册成功。无需做任何动作。
                }
                else
                {
                    //有注册码，但是注册码被修改过。
                    MessageBox.Show("注册信息已经丢失，请重新注册。", "警告");
                    RegistryKey rskDelete = null;
                    rskDelete = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft", true);
                    rskDelete.DeleteValue("Key");
                    rskDelete.Close();
                    Close();
                }
            }
            else
            {
                startTime = DateTime.Now;
                if (rsk.GetValue("Date") != null)
                {
                    //读取Date键值，然后解密，如果解密后转成DateTime格式异常，说明原值不是日期格式。即修改过第一次运行日期。
                    try
                    {
                        //应该添加有值情况下的判断
                        string dateValue = rsk.GetValue("Date").ToString();
                        MyDESEncrypt des = new MyDESEncrypt();
                        string strFirstDate = des.DESDecrypt(dateValue, "DARMSYZX");
                        firstDate = DateTime.Parse(strFirstDate);
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show("由于您私自修改了软件运行时间，导致必须需要注册，否则无法继续使用软件。", "警告");
                        //需弹出注册对话框，不注册直接关闭程序。
                        frmEncrypt fet = new frmEncrypt();
                        if (fet.ShowDialog()==DialogResult.OK)
                        {
                            Application.Exit();
                            return;
                        }
                    }

                }
                else
                {
                    DateTime onlyOne = DateTime.Now;
                    MyDESEncrypt des = new MyDESEncrypt();
                    string encryDate = des.DESEncrypt(onlyOne.ToString(), "DARMSYZX");
                    rsk.SetValue("Date", encryDate);
                    firstDate = onlyOne;
                }
                if (rsk.GetValue("Last")!=null)
                {
                    try
                    {
                        string strLast = rsk.GetValue("Last").ToString();
                        MyDESEncrypt des = new MyDESEncrypt();
                        string strLastDate = des.DESDecrypt(strLast, "DARMSYZX");
                        lastDate = DateTime.Parse(strLastDate);
                        if (lastDate>=firstDate)
                        {
                            if (startTime>=lastDate)
                            {
                                TimeSpan tsZero = new TimeSpan(0,0,0,0);
                                TimeSpan ts720 = new TimeSpan();
                                int dayPers = (startTime.Date - firstDate.Date).Days;
                                ts720 = new TimeSpan(6 - dayPers, 0, 0, 0);
                                if (ts720>tsZero)
                                {
                                    MessageBox.Show("您还可以继续试用" + (6 - dayPers) + "天", "提示");
                                }
                                else if (ts720==tsZero)
                                {
                                    MessageBox.Show("这是您试用期的最后一天，请及时注册。", "提示");
                                }
                                else
                                {
                                    MessageBox.Show("您的试用期已到，请您注册。", "提示");
                                    //需弹出注册对话框，不注册直接关闭程序。
                                    frmEncrypt fet = new frmEncrypt();
                                    if (fet.ShowDialog() == DialogResult.OK)
                                    {
                                        Application.Exit();
                                        return;
                                    }
                                }
                                
                            }
                            else
                            {
                                MessageBox.Show("由于您私自修改了软件运行时间，导致必须需要注册，否则无法继续使用软件。", "警告");
                                //需弹出注册对话框，不注册直接关闭程序。
                                frmEncrypt fet = new frmEncrypt();
                                if (fet.ShowDialog() == DialogResult.OK)
                                {
                                    Application.Exit();
                                    return;
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("由于您私自修改了软件运行时间，导致必须需要注册，否则无法继续使用软件。", "警告");
                            //需弹出注册对话框，不注册直接关闭程序。
                            frmEncrypt fet = new frmEncrypt();
                            if (fet.ShowDialog() == DialogResult.OK)
                            {
                                Application.Exit();
                                return;
                            }
                        }
                        
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show("由于您私自修改了软件运行时间，导致必须需要注册，否则无法继续使用软件。", "警告");
                        //需弹出注册对话框，不注册直接关闭程序。
                        frmEncrypt fet = new frmEncrypt();
                        if (fet.ShowDialog() == DialogResult.OK)
                        {
                            Application.Exit();
                            return;
                        }
                    }
                    
                }
                else
                {
                    MessageBox.Show("程序第一次运行，您将有30天的试用期。过期后请购买许可，否则无法继续使用。", "提示");
                }
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            frmEncrypt myEncryForm = new frmEncrypt();
            myEncryForm.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            endTime = DateTime.Now;
            RegistryKey rsk = null;
            rsk = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft", true);
            MyDESEncrypt mdeEnc = new MyDESEncrypt();
            string strLast = mdeEnc.DESEncrypt(endTime.ToString(), "DARMSYZX");
            rsk.SetValue("Last", strLast);
            rsk.Close();
            this.Close();
        }
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            endTime = DateTime.Now;
            RegistryKey rsk = null;
            rsk = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft", true);
            MyDESEncrypt mdeEnc = new MyDESEncrypt();
            string strLast = mdeEnc.DESEncrypt(endTime.ToString(), "DARMSYZX");
            rsk.SetValue("Last", strLast);
            rsk.Close();
        }
    }
}
