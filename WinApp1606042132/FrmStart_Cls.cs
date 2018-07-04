using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinApp1606042132
{
    public partial class FrmStart_Cls : Form
    {
        public FrmStart_Cls()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            FrmChoose_Cls frm = new FrmChoose_Cls();
            frm.Show();
            this.timer1.Stop();
            this.Hide();
        }

        private void FrmStart_Cls_Load(object sender, EventArgs e)
        {
            this.timer1.Start();
            this.timer1.Interval = 4000;
            timer1.Enabled = true;
        }
    }
}
