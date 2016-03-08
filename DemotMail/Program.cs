using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Text;
using System.Net.Mime;
namespace DemotMail
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Application.Run(new Form1());
            Message M = new Message();
            M.SetUrl("http://demotywatory.pl");
            M.Send("piry3943@gmail.com", "a");

        }
    }

}
