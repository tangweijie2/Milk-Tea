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
    public partial class FrmChoose_Cls : Form
    {
        public FrmChoose_Cls()
        {
            InitializeComponent();
        }
        string[] UserInfoStore = new string[10];
        DataBase_Cls db;
        int count = 0;  
        string fileName = "";//图片的名称

        private void FrmChoose_Cls_Load(object sender, EventArgs e)
        {
            numericUpDown1.Maximum = 100;//设置允许的最大值
            numericUpDown1.Minimum = 0;//设置允许的最小值
            numericUpDown1.Increment = 1;//设置每单击一下按钮时增加或减少的数量
            NameOfRadioButton[0] = RadioButton1;
            NameOfRadioButton[1] = RadioButton2;
            NameOfRadioButton[2] = RadioButton3;
            NameOfRadioButton[3] = RadioButton4;
            NameOfRadioButton[4] = RadioButton5;
            NameOfRadioButton[5] = RadioButton6;
            NameOfRadioButton[6] = RadioButton7;
            NameOfRadioButton[7] = RadioButton8;
            NameOfRadioButton[8] = RadioButton9;
            NameOfRadioButton[9] = RadioButton10;
            NameOfRadioButton[10] = RadioButton11;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            db = new DataBase_Cls();       //实例化数据库操作对象
            db.SqlCon();
            ReLoadComoBox();
            comboBox1.Text = comboBox1.Items[0].ToString();
            //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;  //设置图像显示方式
        }

        private void ReLoadComoBox()
        {
            //throw new NotImplementedException();
            db.sqlRead(UserInfoStore);       //读取数据库
            comboBox1.Items.Clear();
            foreach (string item in UserInfoStore)      //遍历用户信息以装载comboBox
            {
                if (item != null)
                {
                    string[] temp = item.Split('*');
                    comboBox1.Items.Add(temp[0]);
                    count++;
                }

            }
        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            textBox1.Text = numericUpDown1.Value.ToString();
        }

        RadioButton[] NameOfRadioButton = new RadioButton[11];
        bool[] register = new bool[11];

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Clear();          //先清除文本框
            for (int i = 0; i < 11; i++)
            {
                if (sender.Equals(NameOfRadioButton[i]))
                {
                    if (NameOfRadioButton[i].Checked == true)        //处理爱好的选中情况，并进行登记
                    {
                        register[i] = true;
                    }
                    else if (NameOfRadioButton[i].Checked == false)
                    {
                        register[i] = false;
                    }
                }
            }
            for (int i = 0; i < 11; i++)     //将爱好写入文本框
            {
                if (register[i])
                {
                    textBox2.Text += NameOfRadioButton[i].Text + " ";
                }
            }
            //textBox2.Text = textBox2.Text.Remove(textBox2.Text.Length - 1, 1);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            FrmGoods_Cls f2 = new FrmGoods_Cls();
            f2.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

       // public string _showText = "";
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string select1 = (string)comboBox1.SelectedItem;
            int index = comboBox1.SelectedIndex;
            FileStream fs = new FileStream("D:\\Tea.txt", FileMode.Append);
            StreamWriter streamWriter = new StreamWriter(fs, Encoding.Default);
            streamWriter.Write(select1 + ",");
            foreach (string item in UserInfoStore)
            {
                if (item != null)
                {
                    string[] temp = item.Split('*');
                    if (comboBox1.SelectedItem.ToString().Trim() == temp[0].Trim())
                    {
                        streamWriter.Write(temp[1]+",");
                        textBox3.Text = temp[1];
                        fileName = temp[2];
                        string path = Path.Combine(Directory.GetCurrentDirectory(), @"DataBase\Image\" + temp[2] + ".bmp");
                        pictureBox1.Image = Image.FromFile(@path);
                    }
                }
            }
            streamWriter.Flush();
            streamWriter.Close();
            fs.Close();
        }

        private void FrmChoose_Cls_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string strtxt = textBox1.Text.ToString();
            FileStream fs = new FileStream("D:\\Tea.txt", FileMode.Append);
            StreamWriter streamWriter = new StreamWriter(fs, Encoding.Default);
            streamWriter.Write(strtxt + ",");
            streamWriter.Flush();
            streamWriter.Close();
            fs.Close();
        }
    }
}
