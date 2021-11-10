using Escuela.Dominio;
using Escuela.Servicio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escuela.Controllers
{
    public class CursosController : Controller
    {
        private readonly ILogger<CursosController> _logger;
        private ICourese icourse;
        private IRollments irollements;

        public CursosController(ILogger<CursosController> logger, ICourese icourse,
            IRollments irollements, IStudent istudent)
        {
            this.icourse = icourse;
            this.irollements = irollements;
            _logger = logger;
        }
        public IActionResult VerCursos()
        {

            return View();
        }

        public IActionResult GetAll()
        {
            var DandoFormatoJson = icourse.ListarCursos();

            return Json(new { data = DandoFormatoJson });
        }

        public IActionResult RegistrarCursos()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Registro(Course course)
        {
            Course cr = new Course();

            cr.Title = course.Title;
            cr.Credits = course.Credits;

            icourse.Insertar(cr);
            return Redirect("/Cursos/VerCursos");
        }
    }
}
