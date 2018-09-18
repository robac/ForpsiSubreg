using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ForpsiSubreq
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            ForpsiRequest request = new ForpsiRequest(tbUsername.Text.Trim(), tbPassword.Text.Trim());
            string res = request.PerformLogin().Result;
            res = request.AddDomainRecord(tbDomainID.Text.Trim(), "testx", "212.80.80.2").Result;
            tbResult.Text = res;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] lines = tbResult.Text.Split( new[] { Environment.NewLine }, StringSplitOptions.None);

            StringBuilder sb = new StringBuilder();

            foreach (string line in lines)
            {
                string[] items = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string item in items)
                {
                    sb.Append(item+";");
                }
                sb.Append(Environment.NewLine);
            }

            textBox1.Text = sb.ToString();
        }
    }
}
