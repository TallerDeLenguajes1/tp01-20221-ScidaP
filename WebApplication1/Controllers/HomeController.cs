using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger) {
            _logger = logger;
        }

        public IActionResult Index() {
            return View(); 
        }

        public IActionResult Privacy() {
            return View();
        }

        public int EjercicioUno(int a) {
            //Calcular cuadrado /home/EjercicioUno?a={numero}
            return a * a;
        }

        public float EjercicioDos(float a, float b) {
            try {
                return a / b;
            } catch(Exception Ex) { // No sé como imprimir un string en la pantalla, ya que esta función tiene que devolver float si o si. 
                return 0;           // De todas maneras el navegador solito tira un mensaje de división por 0.
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
