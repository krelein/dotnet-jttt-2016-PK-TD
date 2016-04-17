using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net.Mime;
using System.IO;
using System.Net;

namespace DemotMail
{
    class Message
    {
        private SmtpClient Client = new SmtpClient();
        private List<Attachment> Attachments = new List<Attachment>();

        public string Adres { get; set; }
        public string About { get; set; }
        public string Content { get; set; }


        public Message(string GmailAcount, string pass)
        {
            Client.Host = "smtp.gmail.com";
            Client.EnableSsl = true;
            Client.Port = 587;
            Client.Credentials = new System.Net.NetworkCredential(GmailAcount, pass);
            Client.Timeout = 10000;
            Client.DeliveryMethod = SmtpDeliveryMethod.Network;
        }
        private string GetNameFromPath(string path)
        {
            string[] Separator = new string[] { "/" };
            string[] name = (path.Split(Separator, StringSplitOptions.None));
            return name[name.Length - 1];
        }
        public void GetAttachmentsUrl(List<string> Urls)
        {
            LogFile.AddLog("Rozpoczęto dodawanie załączników");
            foreach (string file in Urls)
            {
                try
                {
                    var name = GetNameFromPath(file);
                    var stream = new WebClient().OpenRead(file);
                    Attachment data = new Attachment(stream, name);
                    Attachments.Add(data);

                    LogFile.AddLog("Prawidłowo dodano załącznik - " + name);
                }
                catch
                {
                    LogFile.AddLog("Dodawanie załącznika nie powiodło sie - " + file);
                }
            }
            LogFile.AddLog("Zakończono dodawanie załączników");
        }
        public void Send()
        {
            if (Adres != "")
            {
                MailMessage mail = new MailMessage("demotmailtest@gmail.com", Adres, About, Content);
                mail.BodyEncoding = UTF8Encoding.UTF8;
                mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

                foreach (Attachment data in Attachments) // dodaje załączniki do maila
                    mail.Attachments.Add(data);

                try
                {
                    Client.Send(mail);
                }
                catch
                {
                    LogFile.AddLog("Próba wysłania maila nie powiodła sie");
                }
            }
            else
            {
                LogFile.AddLog("Próba wysłania maila nie powiodła sie. Brak adresu");
            }
        }


    }
}
