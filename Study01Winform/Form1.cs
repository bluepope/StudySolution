using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Study01Winform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void StatusAddNumber(string numStr)
        {
            lblStatus.Text += numStr;
            lblStatus.Text = Convert.ToInt32(lblStatus.Text).ToString();
        }

        private void btnNum_Click(object sender, EventArgs e)
        {
            //(Button)sender
            string numStr = (sender as Button).Text;
            StatusAddNumber(numStr);
        }

        private void btnFunc_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(lblStatus.Text) == true)
                return;

            string funcStr = (sender as Button).Text; // + - / *
            int result = 0;

            if (funcStr == "+")
            {
                result = Convert.ToInt32(lblResult.Text) + Convert.ToInt32(lblStatus.Text);
            }
            else if (funcStr == "-")
            {
                result = Convert.ToInt32(lblResult.Text) - Convert.ToInt32(lblStatus.Text);
            }
            else if (funcStr == "*")
            {
                result = Convert.ToInt32(lblResult.Text) * Convert.ToInt32(lblStatus.Text);
            }
            else if (funcStr == "/")
            {
                result = Convert.ToInt32(lblResult.Text) / Convert.ToInt32(lblStatus.Text);
            }

            lblResult.Text = result.ToString();
            lblStatus.Text = "";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblStatus.Text = "0";
            lblResult.Text = "0";
        }
    }
}
