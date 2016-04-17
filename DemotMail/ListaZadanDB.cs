using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemotMail
{
    public static class ListaZadanDB
    {
        public static void DodajZadanie(Zadanie Zad)
        {
            using (var ctx = new JtttDbContext())
            {
                ctx.Zadania.Add(Zad);
                ctx.SaveChanges();
            }
        }
        public static void UsunZadania()
        {
            using (var ctx = new JtttDbContext())
            {
                foreach (var row in ctx.PogodaDane)
                    ctx.PogodaDane.Remove(row);

                foreach (var row in ctx.MailDane)
                    ctx.MailDane.Remove(row);

                foreach (var row in ctx.KomunikatDane)
                    ctx.KomunikatDane.Remove(row);

                foreach (var row in ctx.StronaWwwDane)
                    ctx.StronaWwwDane.Remove(row);

                foreach (var row in ctx.Warunki)
                    ctx.Warunki.Remove(row);

                foreach (var row in ctx.Akcje)
                    ctx.Akcje.Remove(row);

                foreach (var row in ctx.Zadania)
                    ctx.Zadania.Remove(row);

                ctx.SaveChanges();
            }
        }
        public static void WykonajZadania()
        {
            using (var ctx = new JtttDbContext())
            {           
                foreach (var zad in ctx.Zadania)
                {
                    zad.Wykonaj();
                }
            }
        }
    }
}
