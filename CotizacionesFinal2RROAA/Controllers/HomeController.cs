using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cotizaciones.Models;

//Controlador para gestión de vistas a partir de "Home"
//En este controlador se designa un namespace dentro del cuál se gestionan las vistas iniciales
//incluídas en el proyecto (About, Contact y Index) para hacer los llamados correspondientes 
//a cada una de estas desde layout principal 

namespace Cotizaciones.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Inicio()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
