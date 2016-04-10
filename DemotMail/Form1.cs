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
            ReloadListBox();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           

            if (textBox1.Text != "" && textBox2.Text != "" && textBox4.Text != "" && textBox3.Text != "")
            {
                ListaZadanDB.DodajZadanie(textBox3.Text, textBox1.Text, textBox4.Text, textBox2.Text);          
            }

            ReloadListBox();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ListaZadanDB.WykonajZadania();
            MessageBox.Show("Wykonano");
        }

        private void button4_Click(object sender, EventArgs e)
        {
        //    ListaZadan.Serialize();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ListaZadanDB.UsunZadania();
            ReloadListBox();
        }

        private void button5_Click(object sender, EventArgs e)
        {
        //    ListaZadan.Deserialize();
        //    listBox1.DataSource = ListaZadan.lista;
        }

        private void ReloadListBox()
        {
            listBox1.Items.Clear();

             using (var ctx = new JtttDbContext())
             {
                 foreach(var zadanie in ctx.Zadania)
                 {
                     listBox1.Items.Add(zadanie);
                 }
             }
        }
    }
}
