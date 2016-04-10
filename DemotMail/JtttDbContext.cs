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
        public JtttDbContext() : base("JtttDemotMail_1") { }
       
        public DbSet<Zadanie> Zadania { get; set; }
    }
}
