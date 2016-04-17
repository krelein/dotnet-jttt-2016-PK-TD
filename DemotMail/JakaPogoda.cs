using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;


namespace DemotMail
{
    public class JakaPogoda
    {
        public Pogoda pogoda = new Pogoda();
        public List<string> Sprawdz(string Miasto)
        {
            WebRequest.DefaultWebProxy = null;
            JsonSerializer A = new JsonSerializer();
            List<string> Lista = new List<string>();
            var Klient = new WebClient();
           
            string Adres = "http://api.openweathermap.org/data/2.5/weather?q=";
            string Kod = "&APPID=56acfbc03bccf33c7866f57f145b8784";
            
            try
            {
                pogoda = JsonConvert.DeserializeObject<Pogoda>(Klient.DownloadString(Adres + Miasto + Kod));
                Lista.Add("http://openweathermap.org/img/w/" + pogoda.weather[0].icon + ".png");
                pogoda.main.temp -= 273.15;
            }
            catch (Exception ex)
            {
            }
           
            return Lista;
        }
        public void WyslijMaila(String Adres, List<string> Lista)
        {
            Message M = new Message("demotmailtest@gmail.com", "dotNetC#");

            M.GetAttachmentsUrl(Lista);
            M.Adres = Adres;
            M.About = "Pogoda";
            M.Content = "Temperatura za oknem " + pogoda.main.temp.ToString();
            M.Send();
        }

    }
}
