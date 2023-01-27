using MvcSeriesPersonajesRGN.Data;
using MvcSeriesPersonajesRGN.Models;

namespace MvcSeriesPersonajesRGN.Repositories
{
    public class SeriesRepository
    {
        private SeriesContext context;
        public SeriesRepository(SeriesContext context)
        {
            this.context = context;
        }
        public List<Serie> GetSeries()
        {
            var comando = from datos in this.context.Series
                          select datos;
            return comando.ToList();
        }
        public Serie FindSerie(int id)
        {
            var comando = from datos in this.context.Series
                           where datos.Id == id
                           select datos;
            return comando.FirstOrDefault();
        }
        public void InsertSerie(int id, string nombre, string imagen, int anyo)
        {
            Serie serie = new Serie();
            serie.Id = id;
            serie.nombre = nombre;
            serie.Imagen = imagen;
            serie.Anyo = anyo;
            this.context.Series.Add(serie);
            this.context.SaveChanges();
        }
        public List<Personaje> GetPersonajes(int id)
        {
            var comando = from datos in this.context.Personajes
                          where datos.IdSerie == id
                          select datos;
            return comando.ToList();
        }
        public void DeleteSerie(int id)
        {
            Serie serie = this.FindSerie(id);
            this.context.Series.Remove(serie);
            this.context.SaveChanges();
        }

    }
}
