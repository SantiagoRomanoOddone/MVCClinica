using MVCClinica.Data;
using MVCClinica.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCClinica.Admin
{
    public static class AdmMedico
    {
        // Crear Instancia del dbcontext 
        private static ClinicaDbContext context = new ClinicaDbContext();
        public static List<Medico> Listar()
        {
            return context.Medicos.ToList();
        }

        public static Medico Listar(int id)
        {
            return context.Medicos.Find(id);          
        }
        public static Medico Buscar(int id)
        {
            Medico medico = context.Medicos.Find(id);
            context.Entry(medico).State = EntityState.Detached;
            return medico;
        }

        public static void Crear (Medico medico)
        {
            context.Medicos.Add(medico);
            context.SaveChanges();
        }

        public static void Eliminar(Medico medico)
        {
            context.Medicos.Remove(medico);
            context.SaveChanges();
        }

        public static void Modificar(Medico medico)
        {
            context.Medicos.Attach(medico);
            context.SaveChanges();
        }

        public static List <Medico> ListarEspecialidad (int especialidadId)
        {
            List<Medico> medicosEspecialidad = (from m in context.Medicos
                                                where m.EspecialidadId == especialidadId
                                                select m).ToList();
            return medicosEspecialidad;
        }

    }
}