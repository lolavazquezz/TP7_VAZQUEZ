using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP7_VAZQUEZ.Models;

namespace TP7_VAZQUEZ.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult ConfigurarJuego()
    {
        Juego.InicializarJuego();
        ViewBag.Categorias = BD.ObtenerCategorias();
        ViewBag.Dificultades = BD.ObtenerDificultades();
        return View();
    }

    public IActionResult Comenzar(string Username, int Dificultad, int Categoria)
    {
        Juego.CargarPartida(Username, Dificultad, Categoria);
        if (Preguntas.Count()<1) return RedirectToAction("ConfigurarJuego");
        else return RedirectToAction("Jugar");
    }
    
    public IActionResult Jugar()
    {
        ViewBag.PreguntaActual=Juego.ObtenerProximaPregunta();
        if (Preguntas.Count()<1) return View("Fin");
        else {
            ViewBag.RespuestaActual=Juego.ObtenerProximasRespuestas();
            return View("Jugar");
        }
    }

    [HttpPost] public IActionResult VerificarRespuesta(int IdPregunta, int IdRespuesta)
    {
        ViewBag.Correcta=Juego.VerificarRespuesta();
        return View("Respuesta");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
