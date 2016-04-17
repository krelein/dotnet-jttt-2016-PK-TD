using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace DemotMail
{
    class ZadaniaDbContext : DbContext
    {
       
            // Aby podac wlasna nazwe bazy danych, nalezy wywolac konstruktor bazowy z nazwą jako parametrem.
        public ZadaniaDbContext()
                : base("StudiaNaPWr")
            {
                // Użyj klasy StudiaDbInitializer do zainicjalizowania bazy danych.
           //     Database.SetInitializer(new ZadaniaDbInitializer());
            }

            public DbSet<Zadanie> Zadanie { get; set; }

            public DbSet<ListaZadan> Lista { get; set; }
       


    }
}
