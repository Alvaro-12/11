using Escuela.Data;
using Escuela.Dominio;
using Escuela.Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escuela.Repositorio
{
    public class StudentsRepository : IStudent
    {
        private ApplicationDbContext app;

        public StudentsRepository(ApplicationDbContext app)
        {
            this.app = app;
        }

        public void Delet(Students S)
        {
            app.Remove(S);
        }

        public void Insert(Students S)
        {
            app.Add(S);
            app.SaveChanges();
        }

        public List<Students> ListOfStudents()
        {
            return app.Students.ToList();
        }

        public void Update(Students S)
        {
            app.Update(S);
            app.SaveChanges();
        }
    }
}
