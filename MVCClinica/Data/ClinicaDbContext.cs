using MVCClinica.Models;//a
using System;
using System.Collections.Generic;
using System.Data.Entity;//a
using System.Linq;
using System.Web;

namespace MVCClinica.Data
{
    //Argreg DbContext
    public class ClinicaDbContext : DbContext
    {
        public ClinicaDbContext() : base("KeyDB") { }
        public DbSet<Medico> Medicos { get; set; }
    }
}