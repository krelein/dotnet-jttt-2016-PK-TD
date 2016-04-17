using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DemotMail
{
    public class JtttDbContext : DbContext
    {
        public JtttDbContext() : base("JtttDemotMail_v4_15") { }
   

        public DbSet<Zadanie> Zadania { get; set; }
        public DbSet<Warunek> Warunki { get; set; }
        public DbSet<Akcja> Akcje { get; set; }
        public DbSet<PogodaDane> PogodaDane { get; set; }
        public DbSet<MailDane> MailDane { get; set; }
        public DbSet<KomunikatDane> KomunikatDane { get; set; }
        public DbSet<StronaWwwDane> StronaWwwDane { get; set; }
    }
}
