using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemotMail
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "" && textBox2.Text != "" && textBox4.Text != "")
            {
                   Message M = new Message("demotmailtest@gmail.com", "dotNetC#");
                   M.SetUrl(textBox1.Text);
                   M.Send(textBox4.Text, textBox2.Text);

                   MessageBox.Show("Wysłano");
            }
        
        }
    }
}
