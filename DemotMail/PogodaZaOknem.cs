using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;


namespace DemotMail
{
    public partial class PogodaZaOknem : Form
    {
        public PogodaZaOknem()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            JakaPogoda jaka = new JakaPogoda();
            List<string> Obrazki = new List<string>();
            if(textBox1.Text != "")
            {
                Obrazki = jaka.Sprawdz(textBox1.Text);
                textBox2.Text = "Temperatura w miescie " + textBox1.Text + " wynosi " +
                    jaka.pogoda.main.temp.ToString() + " stopni Celsjusza. Ciśnienie to: " + jaka.pogoda.main.pressure + " hPa";
                var stream = new WebClient().OpenRead(Obrazki[0]);
                pictureBox1.Image = Bitmap.FromStream(stream);
            }
        }
    }
}
