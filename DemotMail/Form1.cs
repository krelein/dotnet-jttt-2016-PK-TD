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
            Zadanie Zad = new Zadanie() { Nazwa = textBox3.Text};
            Warunek W = new Warunek();
            Akcja A = new Akcja();
            // Warunki
            if(tabPage1 == tabControl1.SelectedTab)
            {
                StronaWwwDane Str = new StronaWwwDane();
                Str.Url = textBox1.Text;
                Str.Tekst = textBox2.Text;
                W.StronaWwwDane = Str;
            }
            else if (tabPage2 == tabControl1.SelectedTab)
            {
                PogodaDane Pog = new PogodaDane();
                Pog.Miasto = textBox5.Text;            
                Pog.Temperatura = Int16.Parse(textBox6.Text);
                W.PogodaDane = Pog;
            }
            // Akcje
            if (tabPage3 == tabControl2.SelectedTab)
            {
                MailDane Mai = new MailDane();
                Mai.Adres = textBox4.Text;
                A.MailDane = Mai;
            }
            else if (tabPage4 == tabControl2.SelectedTab)
            {
                KomunikatDane Kom = new KomunikatDane();
                Kom.CzyWyswietlic = true;
                A.KomunikatDane = Kom;
            }
            Zad.Warunek = W;
            Zad.Akcja = A;
            ListaZadanDB.DodajZadanie(Zad);
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
                 foreach (var zadanie in ctx.Zadania)
                 {
                     listBox1.Items.Add(zadanie.ToString());
                 }
             }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            PogodaZaOknem pogoda = new PogodaZaOknem();
            pogoda.Show();
        }
    }
}
