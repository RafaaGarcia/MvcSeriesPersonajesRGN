using Microsoft.AspNetCore.Mvc;
using MvcSeriesPersonajesRGN.Models;
using MvcSeriesPersonajesRGN.Repositories;

namespace MvcSeriesPersonajesRGN.Controllers
{
    public class SeriesController : Controller
    {
        private SeriesRepository repo;
        public SeriesController(SeriesRepository repo)
        {
            this.repo= repo;
        }
        public IActionResult Index()
        {
            List<Serie> serieList = this.repo.GetSeries();
            return View(serieList);
        }
        public IActionResult InsertSerie()
        {
            return View();
        }
        [HttpPost]
        public IActionResult InsertSerie(Serie serie)
        {
            this.repo.InsertSerie(serie.Anyo, serie.Imagen, serie.nombre, serie.Id);
            return RedirectToAction("Index");
        }
        public IActionResult VerPersonajes(int id)
        {
            List<Personaje> ListaPersonajes = this.repo.GetPersonajes(id);
            return View(ListaPersonajes);
        }
        public IActionResult DeleteSerie(int id)
        {
            this.repo.DeleteSerie(id);
            return RedirectToAction("Index");
        }
        public IActionResult DetallesSerie(int id)
        {
            Serie serie = this.repo.FindSerie(id);
            return View(serie);
        }
    }
}
