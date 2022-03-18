using ApiExamenSeries.Models;
using ApiExamenSeries.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiExamenSeries.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeriesController : ControllerBase
    {
        private RepositorySerie repo;
        public SeriesController(RepositorySerie repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public ActionResult<List<Serie>> GetSeries() 
        {
            return this.repo.GetSeries();
        }
        [HttpGet]
        [Route("{id}")]
        public ActionResult<Serie> FindSerie(int id) 
        {
            return this.repo.FindSerie(id);
        }
        [HttpGet]
        [Route("[action]/{id}")]
        public ActionResult<List<Personaje>> PersonajesSerie(int id) 
        {
            List<Personaje> personajes = this.repo.GetPersonajesSerie(id);
            return personajes;
        }
        [HttpPost]
        public ActionResult InsertarSerie(Serie serie) 
        {
            this.repo.InsertSerie(serie.Nombre, serie.Imagen, serie.Puntuacion, serie.Anio);
            return Ok();
        }
        [HttpPut]
        public ActionResult ModificarSerie(Serie serie) 
        {
            this.repo.UpdateSerie(serie.IdSerie,serie.Nombre, serie.Imagen, serie.Puntuacion, serie.Anio);
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult Eliminarserie(int id) 
        {
            this.repo.DeleteSerie(id);
            return Ok();
        }
    }
}
