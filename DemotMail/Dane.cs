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
    public class PogodaDane
    {
        public int Id { get; set; }
        public string Miasto { get; set; }
        public double Temperatura { get; set; }

        [Required]
        public virtual Warunek Warunek { get; set; }
    }

    public class StronaWwwDane
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Tekst { get; set; }

        [Required]
        public virtual Warunek Warunek { get; set; }
    }

    public class MailDane
    {
        public int Id { get; set; }
        public string Adres { get; set; }


        [Required]
        public virtual Akcja Akcja { get; set; }
    }

    public class KomunikatDane
    {
        public int Id { get; set; }
        public bool CzyWyswietlic { get; set; }

        [Required]
        public virtual Akcja Akcja { get; set; }
    }

}
