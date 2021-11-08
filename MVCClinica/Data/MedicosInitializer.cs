using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;//A
using MVCClinica.Models;//a

namespace MVCClinica.Data
{
    public class MedicosInitializer : DropCreateDatabaseAlways<ClinicaDbContext>
    {
        //protected override void Seed(ClinicaDbContext context)
        //{
        //    base.Seed(context);
        //}

        //esto sería el polimorfismo
        protected override void Seed(ClinicaDbContext context)
        {
            var operas = new List<Medico>
            {
               new Medico {
                   Nombre = "Carlos",
                   Apellido = "Sosa", 
                   Matricula = 254,
                   EspecialidadId = 2
               }
            };
            operas.ForEach(s => context.Medicos.Add(s));
            context.SaveChanges();


        }
    }
}