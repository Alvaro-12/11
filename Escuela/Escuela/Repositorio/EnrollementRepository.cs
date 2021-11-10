using Escuela.Data;
using Escuela.Dominio;
using Escuela.Servicio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escuela.Repositorio
{
    public class EnrollementRepository  :IRollments 
    {
        private ApplicationDbContext bd;

        public EnrollementRepository(ApplicationDbContext bd)
        {
            this.bd = bd;
        }

        public void Insert(Erollement e)
        {
            bd.Add(e);
            bd.SaveChanges();
        }

        public List<Erollement> UnionDeTablas()
        {
            var union = bd.Erollements.Include(e => e.Student).Include(c=>c.Course).ToList();
            return union; 
        }

    }
}
