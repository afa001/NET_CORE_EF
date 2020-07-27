using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_NET_CORE_EF.Model
{
    public class AppDbContext : DbContext
    {
        //ct, pasamos la cadena de conexion 
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Banco> Bancos { get; set; }
        public DbSet<Persona> Personas { get; set; }

        //damo a conocer que existe una tabla llamada Banco & Persona
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Banco>().ToTable("Banco");
            modelBuilder.Entity<Persona>().ToTable("Persona");
        }
    }
}
