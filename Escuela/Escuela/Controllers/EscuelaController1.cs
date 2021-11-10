using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Escuela.Dominio;
using Escuela.Models;
using Escuela.Servicio;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Escuela.Controllers
{
    public class EscuelaController1 : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
    }
}
