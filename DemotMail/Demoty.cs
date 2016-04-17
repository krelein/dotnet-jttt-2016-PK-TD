using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemotMail
{
    class Demoty
    {
        List<string> Lista = new List<string>();

        public List<string> Szukaj(string Url, string Phrase)
        {
            PicturesFromHtml Pictures = new PicturesFromHtml(Url);
            //List<string> Lista = new List<string>();

            Lista = Pictures.AdFileIf(Phrase);

            return Lista.Count != 0 ? Lista : null;
        }
        public void SlijMaila(string Adres)
        {
            Message M = new Message("demotmailtest@gmail.com", "dotNetC#");

            M.GetAttachmentsUrl(Lista);
            M.Adres = Adres;
            M.About = "DemotReport";
            M.Send();
        }

    }
}
