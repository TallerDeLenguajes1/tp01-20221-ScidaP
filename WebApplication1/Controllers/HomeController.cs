using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.Json;
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

        public IActionResult EjercicioTres() {
            return View();
        }

        public string UsarAPI() {
            string url = $"https://apis.datos.gob.ar/georef/api/provincias?campos=id,nombre";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            string StringProvincias = "";
            try {
                using (WebResponse response = request.GetResponse()) {
                    using (Stream strReader = response.GetResponseStream()) {
                        if (strReader != null) {
                            using (StreamReader objReader = new StreamReader(strReader)) {
                                string responseBody = objReader.ReadToEnd();
                                Provincias ListaProvincias = JsonSerializer.Deserialize<Provincias>(responseBody);
                                for (int i = 0; i < ListaProvincias.provincias.Count; i++) {
                                    StringProvincias += "Provincia: " + ListaProvincias.provincias[i].nombre + " ID: " + ListaProvincias.provincias[i].id + ".\n";
                                }
                            }
                        }
                    }
                }
                return StringProvincias;
            } catch (Exception Ex) {
                return "Error: " + Ex.Message;
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
