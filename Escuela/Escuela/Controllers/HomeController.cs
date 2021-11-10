using Escuela.Dominio;
using Escuela.Models;
using Escuela.Servicio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Escuela.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ICourese icourse;
        private IRollments irollements;
        private IStudent istudent;


        public HomeController(ILogger<HomeController> logger, ICourese icourse, 
            IRollments irollements, IStudent istudent)
        {
            this.icourse = icourse;
            this.irollements = irollements;
            this.istudent = istudent;
            _logger = logger;
        }
       


        public IActionResult Index()
        {
            
           var listado = irollements.UnionDeTablas();
            //return Json(new { data = listado });
            return View();
        }

        public IActionResult GetAllForJoinJsonLinq ()
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



            return Json(new { CombinacionDeArreglos});
        }

        public IActionResult ComboBox() 
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

        public IActionResult GetAll() {

            var DandoFormatoJson = icourse.ListarCursos();


            return Json(new { data = DandoFormatoJson });
        }


        public IActionResult Students()
        {
            var listado = irollements.UnionDeTablas();

            return View(listado);
        }


        public IActionResult getinformationcombobox(Erollement e)
        {
            //
             _ = e;
                


            return View("ComboBox");
        }

       
        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
