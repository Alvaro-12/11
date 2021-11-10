using Escuela.Dominio;
using Escuela.Servicio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escuela.Controllers
{
    public class InscripcionController : Controller
    {
        private readonly ILogger<InscripcionController> _logger;
        private ICourese icourse;
        private IRollments irollements;
        private IStudent istudent;


        public InscripcionController(ILogger<InscripcionController> logger, ICourese icourse,
            IRollments irollements, IStudent istudent)
        {
            this.icourse = icourse;
            this.irollements = irollements;
            this.istudent = istudent;
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAllForJoinJsonLinq()
        {
            var listado = irollements.UnionDeTablas();

            var CombinacionDeArreglos = (from union in listado
                                         select new
                                         {
                                             union.Course.Title,
                                             union.Student.LastName,
                                             union.Student.FirstMidName,
                                             union.Grade

                                         }).ToList();



            return Json(new { CombinacionDeArreglos });
        }

        public IActionResult inscripcion()
        {
            var informaciondecombo = icourse.ListarCursos();
            var informaciondecomboDeEstudiantes = istudent.ListOfStudents();

            List<SelectListItem> listsofCourse = new List<SelectListItem>();
            List<SelectListItem> ListStudents = new List<SelectListItem>();

            foreach (var iterarinformacion in informaciondecombo)
            {
                listsofCourse.Add
                  (
                    new SelectListItem
                    {
                        Text = iterarinformacion.Title,
                        Value = Convert.ToString(iterarinformacion.CouserId)
                    }
                  );
                ViewBag.estadolistcourse = listsofCourse;
            }
            foreach (var iterarinformacion in informaciondecomboDeEstudiantes)
            {
                ListStudents.Add
                  (
                    new SelectListItem
                    {
                        Text = iterarinformacion.FirstMidName,
                        Value = Convert.ToString(iterarinformacion.StudentId)
                    }
                  );
                ViewBag.estadolsitestudents = ListStudents;
            }
            return View();
        }

        public IActionResult Registrar(Erollement e)
        {
            Erollement er = new Erollement();

            er.Course = e.Course;
            er.Student = e.Student;
            er.CourseID = e.CourseID;
            er.StudentID = e.StudentID;
            er.Grade = e.Grade;

            irollements.Insert(er);
            return Redirect("/Home/Students");
        }
    }
}

