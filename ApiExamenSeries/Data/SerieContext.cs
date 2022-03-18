using ApiExamenSeries.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiExamenSeries.Data
{
    public class SerieContext:DbContext
    {
        public SerieContext(DbContextOptions<SerieContext> options)
            : base(options) { }

        public DbSet<Serie> Series { get; set; }
        public DbSet<Personaje> Personajes { get; set; }

    }
}
