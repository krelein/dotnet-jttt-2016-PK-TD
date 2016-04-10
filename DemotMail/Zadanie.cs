using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemotMail
{
    [Serializable]
    public class Zadanie
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public string Url { get; set; }
        public string Adres { get; set; }
        public string Tekst { get; set; }

        public override string ToString()
        {
            return "Nazwa zadania = " + Nazwa + "; Warunek =  " + Tekst + "; Na stronie =  " + Url + "; Wykonaj = " + Adres;
        }
    }
}
