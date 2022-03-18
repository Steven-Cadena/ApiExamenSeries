using ApiExamenSeries.Data;
using ApiExamenSeries.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiExamenSeries.Repositories
{
    public class RepositorySerie
    {
        private SerieContext context;
        public RepositorySerie(SerieContext context) 
        {
            this.context = context;
        }

        private int GetMaxIdPersonaje() 
        {
            if (this.context.Personajes.Count() == 0)
            {
                return 1;
            }
            else 
            {
                var consulta = (from datos in this.context.Personajes
                                select datos.IdPersonaje).Max();
                int idPer = consulta + 1;
                return idPer;
            }
        }
        private int GetMaxIdSerie()
        {
            if (this.context.Series.Count() == 0)
            {
                return 1;
            }
            else
            {
                var consulta = (from datos in this.context.Series
                                select datos.IdSerie).Max();
                int idSer = consulta + 1;
                return idSer;
            }
        }

        /*PERSONAJES*/
        public List<Personaje> GetPersonajes() 
        {
            return this.context.Personajes.ToList();
        }
        public Personaje FindPersonaje(int idpersonaje) 
        {
            return this.context.Personajes.SingleOrDefault(x => x.IdPersonaje == idpersonaje);
        }
        public void InsertPersonaje(string nombre,string imagen,int idserie) 
        {
            Personaje per = new Personaje
            {
                IdPersonaje = this.GetMaxIdPersonaje(),
                Nombre = nombre,
                Imagen = imagen,
                IdSerie = idserie
            };
            this.context.Personajes.Add(per);
            this.context.SaveChanges();
        }
        public void UpdatePersonaje(int idpersonaje,string nombre, string imagen) 
        {
            Personaje per = this.FindPersonaje(idpersonaje);
            per.Nombre = nombre;
            per.Imagen = imagen;
            this.context.SaveChanges();
        }

        public void DeletePersonaje(int idpersonaje) 
        {
            Personaje per = this.FindPersonaje(idpersonaje);
            this.context.Personajes.Remove(per);
            this.context.SaveChanges();
        }
        public void ModificarPersonaje(int idpersonaje, int idserie) 
        {
            Personaje per = this.FindPersonaje(idpersonaje);
            per.IdSerie = idserie;
            this.context.SaveChanges();
        }
        /*********************************/
        /*SERIES*/

        public List<Serie> GetSeries() 
        {
            return this.context.Series.ToList();
        }
        public Serie FindSerie(int idserie) 
        {
            return this.context.Series.SingleOrDefault(x => x.IdSerie == idserie);
        }
        public void InsertSerie(string nombre, string imagen, double puntuacion, int anio) 
        {
            Serie serie = new Serie
            {
                IdSerie = this.GetMaxIdSerie(),
                Nombre = nombre,
                Imagen = imagen,
                Puntuacion = puntuacion,
                Anio = anio
            };
            this.context.Series.Add(serie);
            this.context.SaveChanges();
        }
        public void UpdateSerie(int idserie, string nombre, string imagen, double puntuacion, int anio) 
        {
            Serie ser = this.FindSerie(idserie);
            ser.Nombre = nombre;
            ser.Imagen = imagen;
            ser.Puntuacion = puntuacion;
            ser.Anio = anio;

            this.context.SaveChanges();
        }
        public void DeleteSerie(int idserie) 
        {
            Serie ser = this.FindSerie(idserie);
            this.context.Series.Remove(ser);
            this.context.SaveChanges();
        }

        public List<Personaje> GetPersonajesSerie(int idserie) 
        {
            var consulta = from datos in this.context.Personajes
                           where datos.IdSerie == idserie
                           select datos;
            List<Personaje> personajes = new List<Personaje>();
            foreach (Personaje per in consulta) 
            {
                personajes.Add(per);
            }
            return personajes;
        }
    }
}
