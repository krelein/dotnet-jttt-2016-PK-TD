using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Windows.Forms;

namespace DemotMail
{
    public class Zadanie
    {

        public int Id { get; set; }
        public string Nazwa { get; set; }
        public virtual Warunek Warunek { get; set; }
        public virtual Akcja Akcja { get; set; }

        public override string ToString()
        {
            return Nazwa + ". JESLI - " + Warunek.ToString() + " TO - " + Akcja.ToString();
        }

        public void Wykonaj()
        {
            List<string> Dane = new List<string>();
            Demoty D = null;
            JakaPogoda P = null;

            if (Warunek.StronaWwwDane != null)
            {
                D = new Demoty();
                Dane = D.Szukaj(Warunek.StronaWwwDane.Url, Warunek.StronaWwwDane.Tekst);
            }
            else if (Warunek.PogodaDane != null)
            {
                P = new JakaPogoda();
                Dane = P.Sprawdz(Warunek.PogodaDane.Miasto);
            }

            if (Dane.Count() != 0)
            {
                if (Akcja.MailDane != null)
                {
                    if (D != null)
                        D.SlijMaila(Akcja.MailDane.Adres);
                    else if (P != null)
                    {
                        if (P.pogoda.main.temp > Warunek.PogodaDane.Temperatura)
                            P.WyslijMaila(Akcja.MailDane.Adres, Dane);             
                    }
                }
                else if (Akcja.KomunikatDane != null)
                {
                    Komunikat Kom = new Komunikat();
                    Kom.Show();
                    if (D != null)
                        Kom.Obrazki(Dane, Warunek.StronaWwwDane.Tekst);
                    else if (P != null)
                        Kom.Obrazki(Dane, "Temperatura za oknem" + P.pogoda.main.temp.ToString());
                }


            }

        }

    }
}
