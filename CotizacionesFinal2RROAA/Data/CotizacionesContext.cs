using Microsoft.EntityFrameworkCore;
using Cotizaciones.Models;
using System;
using System.Data;
using System.Linq;

//CLase para la creación del contexto (ORM) de la aplicación
//Se agregan listas de personas y cotizaciones para la gestion de OBJETOS.

namespace Cotizaciones.Data {
    public class CotizacionesContext : DbContext
    {
        public CotizacionesContext(DbContextOptions<CotizacionesContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Utilizacion de SQLite como backend
            optionsBuilder.UseSqlite("Data Source=cotizaciones.db");
        }
        public DbSet<Persona> Personas { get; set; }

        public DbSet<Cotizacion> Cotizaciones { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Persona>().HasKey(x => x.Rut);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Cotizaciones.Models.Cotizacion> Cotizacion { get; set; }

    }
}