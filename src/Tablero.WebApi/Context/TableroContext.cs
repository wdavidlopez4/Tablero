using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tablero.WebApi.Models;

namespace Tablero.WebApi.Context
{
    public class TableroContext : DbContext
    {
        public DbSet<Epic> Epics { get; set; }

        public DbSet<Historia> Historias { get; set; }

        public DbSet<Tarea> Tareas { get; set; }

        public DbSet<Bug> Bugs { get; set; }


        public TableroContext(DbContextOptions<TableroContext> options): base (options)
        {
            //comprovar si la db esta creada si no la crea
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //relaciones
            modelBuilder.Entity<Tarea>()
                .HasOne<Historia>(x => x.Historia)
                .WithMany(y => y.Tareas)
                .HasForeignKey(z => z.IdHistoria);

            modelBuilder.Entity<Bug>()
                .HasOne<Historia>(x => x.Historia)
                .WithMany(y => y.Bugs)
                .HasForeignKey(z => z.IdHistoria);

            modelBuilder.Entity<Historia>()
                .HasOne<Epic>(x => x.Epic)
                .WithMany(y => y.Historias)
                .HasForeignKey(z => z.IdEpic);

            //crear ids
            var idTarea1 = Guid.NewGuid();
            var idTarea2 = Guid.NewGuid();

            var idBug1 = Guid.NewGuid();
            var idBug2 = Guid.NewGuid();

            var idHistoria1 = Guid.NewGuid();
            var idHistoria2 = Guid.NewGuid();

            var IdEpi1 = Guid.NewGuid();


            //crear modelos
            modelBuilder.Entity<Tarea>().HasData(
                new Tarea
                {
                    Id = idTarea1,
                    Comentario = "tarea asignada a las 11 pm",
                    Descripcion = "elabarar el diseño del componente grapql para aumentar productividad",
                    Estado = Estados.activo,
                    PersonaEncargado = "aun sin asignar",
                    PersonasAsociadas = new List<string> { "diego", "david"},
                    IdHistoria = idHistoria1,
                    Tipo = TipoTarea.diseño
                },
                new Tarea
                {
                    Id = idTarea2,
                    Comentario = "tarea asignada a las 1 pm",
                    Descripcion = "elabarar el desarrollo del componente QL para aumentar productividad",
                    Estado = Estados.inactivo,
                    PersonaEncargado = "desarrollador junior David",
                    PersonasAsociadas = new List<string> { "pablo", "david" },
                    IdHistoria = idHistoria1,
                    Tipo = TipoTarea.desarrollo
                }
                );

            modelBuilder.Entity<Bug>().HasData(
                new Bug
                {
                    Id = idBug1,
                    Comentario = "none",
                    Descripcion = "error 404 api GL",
                    Encargado = "lopez",
                    Estado = Estados.erronero,
                    Testeres = new List<string> { "camilo", "juan"},
                    IdHistoria = idHistoria1
                },
                new Bug
                {
                    Id = idBug2,
                    Comentario = "none",
                    Descripcion = "el usuario @pablo dice que no le sirve la mensajeria",
                    Encargado = "lopez",
                    Estado = Estados.erronero,
                    Testeres = new List<string> { "camilo", "juan" },
                    IdHistoria = idHistoria2
                }
                );

            modelBuilder.Entity<Historia>().HasData(
                new Historia
                {
                    Id = idHistoria1,
                    Comentario = "none",
                    Descripcion = "el usuario x, solicita que la aplicacion pueda enviar mensajeria en un tienpo menor de 3 minutos",
                    Estado = Estados.faltante,
                    PersonaEncargado = "diretor general William Lopez",
                    Supervisor = "pablito",
                    PersonasAsociadas = new List<string> { "camilo", "juan" },
                    IdEpic = IdEpi1
                },
                new Historia
                {
                    Id = idHistoria2,
                    Comentario = "none",
                    Descripcion = "el usuario y solicita un modulo de compras basico en el que pueda vender sus productos de linpiesa",
                    Estado = Estados.completado,
                    PersonaEncargado = "diretor general William Lopez",
                    Supervisor = "pablito",
                    PersonasAsociadas = new List<string> { "camilo", "juan" },
                    IdEpic = IdEpi1
                }
                );

            modelBuilder.Entity<Epic>().HasData(
                new Epic
                {
                    Id = IdEpi1,
                    Descripcion = "lograr ejecutar las ventas del mesas atraves del modulo de compras",
                    ObjetivoGeneral = "aumentar en un 20% la productividad de la empresa",
                    DuracionDeSpring = 3,
                    Comentario = "none",
                    Estado = Estados.activo
                }
                );
        }
    }
}
