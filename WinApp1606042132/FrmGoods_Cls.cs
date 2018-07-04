using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinApp1606042132
{
    public partial class FrmGoods_Cls : Form
    {
        public FrmGoods_Cls()
        {
            InitializeComponent();
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void txtBTotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmGoods_Cls_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            string fname = @"D:\\Tea.txt";
            string s;
            StreamReader sr = new StreamReader(fname, Encoding.Default);
            s = sr.ReadToEnd();
            sr.Close();
            string[] sentence = s.Split('\n');
                foreach (string ss in sentence)
                {
                    string[] words = ss.Split(',');
                    listView1.Items.Add(new ListViewItem(words));
                }
        }
    }
}