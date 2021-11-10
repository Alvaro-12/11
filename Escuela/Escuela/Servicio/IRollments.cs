using Escuela.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escuela.Servicio
{
   public interface IRollments
    {
        //Aqui se describe como trabaja
        void Insert(Erollement e);

        List<Erollement> UnionDeTablas();

    }
}
