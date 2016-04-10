using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemotMail
{
    public static class ListaZadanDB
    {

        public static void DodajZadanie(string nazwa, string url, string adres, string tekst)
        {
            using (var ctx = new JtttDbContext())
            {          
                Zadanie Zad = new Zadanie() {Nazwa = nazwa, Url = url, Adres = adres, Tekst = tekst };
                ctx.Zadania.Add(Zad);   
                ctx.SaveChanges();
            }
        }

        public static void UsunZadania()
        {
            using (var ctx = new JtttDbContext())
            {
                foreach (var row in ctx.Zadania)
                    ctx.Zadania.Remove(row);

                ctx.SaveChanges();
            }
        }

        public static void WykonajZadania()
        {
            using (var ctx = new JtttDbContext())
            {
                Message M = new Message("demotmailtest@gmail.com", "dotNetC#");

                foreach (var row in ctx.Zadania)
                {           
                       M.SetUrl(row.Url);
                       M.Send(row.Adres, row.Tekst);        
                }
            }
        }

    }
}
