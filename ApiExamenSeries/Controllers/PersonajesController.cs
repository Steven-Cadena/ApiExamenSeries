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
    public class PersonajesController : ControllerBase
    {
        private RepositorySerie repo;
        public PersonajesController(RepositorySerie repo) 
        {
            this.repo = repo;
        }

        [HttpGet]
        public ActionResult<List<Personaje>> GetPersonajes() 
        {
            return this.repo.GetPersonajes();
        }
        [HttpGet]
        [Route("{id}")]
        public ActionResult<Personaje> FindPersonaje(int id) 
        {
            return this.repo.FindPersonaje(id);
        }
        [HttpPost]
        public ActionResult InsertarPersonaje(Personaje personaje) 
        {
            this.repo.InsertPersonaje(personaje.Nombre, personaje.Imagen, personaje.IdSerie);
            return Ok();
        }
        [HttpPut]
        public ActionResult ModificarPersonaje(Personaje personaje) 
        {
            this.repo.UpdatePersonaje(personaje.IdPersonaje, personaje.Nombre, personaje.Imagen);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult EliminarPersonaje(int id) 
        {
            this.repo.DeletePersonaje(id);
            return Ok();
        }
        [HttpGet]
        [Route("{idpersonaje}/{idserie}")]
        public ActionResult ModificarPersonajeSerie(int idpersonaje, int idserie) 
        {
            this.repo.ModificarPersonaje(idpersonaje, idserie);
            return Ok();
        }
    }
}
