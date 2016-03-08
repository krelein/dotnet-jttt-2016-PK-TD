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
            M.Send("piry3943@gmail.com");

        }
    }


    public class Message
    {
        private SmtpClient client;

        public Message()
        {
            client = new SmtpClient();
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Port = 587;
            client.Credentials = new System.Net.NetworkCredential("demotmailtest@gmail.com", "*******");
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
        }

        public void Send(string to)
        {  
            MailMessage mail = new MailMessage("demotmailtest@gmail.com", to, "DemotMessage", "Your daily demot report");
            mail.BodyEncoding = UTF8Encoding.UTF8;
            mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;


            string file = "C:\\Users\\Piry\\Desktop\\Projekty własne\\INNE\\ROWER.jpg";
       
            Attachment data = new Attachment(file, MediaTypeNames.Application.Octet);
            // Add time stamp information for the file.
            ContentDisposition disposition = data.ContentDisposition;
            disposition.CreationDate = System.IO.File.GetCreationTime(file);
            disposition.ModificationDate = System.IO.File.GetLastWriteTime(file);
            disposition.ReadDate = System.IO.File.GetLastAccessTime(file);
            // Add the file attachment to this e-mail message.
            mail.Attachments.Add(data);

            client.Send(mail);
        }

    }


}
