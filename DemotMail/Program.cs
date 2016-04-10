using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Text;
using System.Net.Mime;
using System.IO;
using System.ComponentModel;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;


namespace DemotMail
{
    static class Program
    {
        [STAThread]
        static void Main()
        {     
            LogFile.StartLog();
          
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());  
        }
    }

  

    
  


}
