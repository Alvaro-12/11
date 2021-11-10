using Escuela.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escuela.Servicio
{
    public interface IStudent
    {
        void Insert(Students S);

        void Update(Students S);

        void Delet(Students S);

        List<Students> ListOfStudents();
    }
}
