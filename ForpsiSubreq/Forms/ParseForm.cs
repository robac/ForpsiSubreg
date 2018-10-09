using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using ForpsiSubreq.Data;
using ForpsiSubreq.Utils;

namespace ForpsiSubreq
{
    public partial class ParseForm : Form
    {

        public List<DNSRecord> DNSRecords;
        public string Errors = "";

        
        public ParseForm()
        {
            InitializeComponent();
        }



        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DNSRecords = new List<DNSRecord>();
            StringBuilder errors = new StringBuilder();

            foreach (string line in tbInput.Lines)
            {
                try
                {
                    if (line.Trim() == "")
                    {
                        continue;
                    }
                    DNSRecord record = BindParser.ParseLine(line);
                    this.DNSRecords.Add(record);
                } catch (Exception E)
                {
                    errors.Append(line);
                    errors.Append(Environment.NewLine);
                }

            }

            this.Errors = errors.ToString();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        public void ShowParseDataDialog()
        {
            this.DialogResult = DialogResult.Cancel;
            this.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
