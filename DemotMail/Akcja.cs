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
    public class Akcja
    {
        public int Id { get; set; }
        public virtual KomunikatDane KomunikatDane { get; set; }
        public virtual MailDane MailDane { get; set; }

        [Required]
        public virtual Zadanie Zadanie { get; set; }

        public override string ToString()
        {
            if (KomunikatDane != null)
                return "Wyswietl komunikat";
            else if (MailDane != null)
                return "Wyslij maila do: <" + MailDane.Adres + ">";
            else
                return null;
        }
    }

}
