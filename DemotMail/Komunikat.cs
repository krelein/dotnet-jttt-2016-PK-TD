using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net.Mime;
using System.IO;
using System.Net;

namespace DemotMail
{
    public partial class Komunikat : Form
    {
        public Komunikat()
        {
            InitializeComponent();
            textBox1.ReadOnly = true;
        }

        public void Obrazki(List<string> Urls, string Message)
        {
            TabControl Tab = new TabControl();
            Tab.Location = new Point(0, 00);
            Tab.Size = new Size(500, 500);
            Tab.Dock = DockStyle.Fill;

            textBox1.Text = Message;

            foreach (var url in Urls)
            {
                TabPage Page = new TabPage();
                PictureBox P = new PictureBox();

                P.Dock = DockStyle.Fill;
                P.SizeMode = PictureBoxSizeMode.Zoom;
                Page.Text = "Obrazek";

                try
                {
                    var stream = new WebClient().OpenRead(url);
                    P.Image = Bitmap.FromStream(stream);
                }
                catch
                {

                }
                finally
                {
                    if (P.Image != null)
                    {
                        Page.Controls.Add(P);
                        Tab.TabPages.Add(Page);
                    }
                }

            }

            panel2.Controls.Add(Tab);

        }
    }
}
