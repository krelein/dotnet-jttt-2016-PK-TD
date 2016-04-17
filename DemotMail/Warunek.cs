using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace DemotMail
{
    public class Warunek
    {
        public int Id { get; set; }
        public virtual StronaWwwDane StronaWwwDane { get; set; }
        public virtual PogodaDane PogodaDane { get; set; }

        [Required]
        public virtual Zadanie Zadanie { get; set; }

        public override string ToString()
        {
            if (StronaWwwDane != null)
                return "Tekst: <" + StronaWwwDane.Tekst + "> Na stronie <" + StronaWwwDane.Url + ">";
            else if (PogodaDane != null)
                return "Temperatura powyżej: <" + PogodaDane.Temperatura + "> w mieście: <" + PogodaDane.Miasto + ">";
            else
                return null;
        }

    }
}
