using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SmartSchool_WebAPI.Models;
namespace SmartSchool_WebAPI.Data{

    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) { }        
        public DbSet<Alumno> alumnos { get; set; }
        public DbSet<Profesor> profesores { get; set; }
        public DbSet<Materia> materia { get; set; }
        public DbSet<AlumnoMateria> alumnoMateria { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AlumnoMateria>()
                .HasKey(AD => new { AD.alumnoId, AD.materiaId });

            builder.Entity<Profesor>()
                .HasData(new List<Profesor>(){
                    new Profesor(1, "Lauro"),
                    new Profesor(2, "Roberto"),
                    new Profesor(3, "Ronaldo"),
                    new Profesor(4, "Rodrigo"),
                    new Profesor(5, "Alexandre"),
                });
            
            builder.Entity<Materia>()
                .HasData(new List<Materia>{
                    new Materia(1, "Matemática", 1),
                    new Materia(2, "Física", 2),
                    new Materia(3, "Português", 3),
                    new Materia(4, "Inglês", 4),
                    new Materia(5, "Programação", 5)
                });
            
            builder.Entity<Alumno>()
                .HasData(new List<Alumno>(){
                    new Alumno(1, "Marta", "Kent", "33225555"),
                    new Alumno(2, "Paula", "Isabela", "3354288"),
                    new Alumno(3, "Laura", "Antonia", "55668899"),
                    new Alumno(4, "Luiza", "Maria", "6565659"),
                    new Alumno(5, "Lucas", "Machado", "565685415"),
                    new Alumno(6, "Pedro", "Alvares", "456454545"),
                    new Alumno(7, "Paulo", "José", "9874512")
                });

            builder.Entity<AlumnoMateria>()
                .HasData(new List<AlumnoMateria>() {
                    new AlumnoMateria() {alumnoId = 1, materiaId = 2 },
                    new AlumnoMateria() {alumnoId = 1, materiaId = 4 },
                    new AlumnoMateria() {alumnoId = 1, materiaId = 5 },
                    new AlumnoMateria() {alumnoId = 2, materiaId = 1 },
                    new AlumnoMateria() {alumnoId = 2, materiaId = 2 },
                    new AlumnoMateria() {alumnoId = 2, materiaId = 5 },
                    new AlumnoMateria() {alumnoId = 3, materiaId = 1 },
                    new AlumnoMateria() {alumnoId = 3, materiaId = 2 },
                    new AlumnoMateria() {alumnoId = 3, materiaId = 3 },
                    new AlumnoMateria() {alumnoId = 4, materiaId = 1 },
                    new AlumnoMateria() {alumnoId = 4, materiaId = 4 },
                    new AlumnoMateria() {alumnoId = 4, materiaId = 5 },
                    new AlumnoMateria() {alumnoId = 5, materiaId = 4 },
                    new AlumnoMateria() {alumnoId = 5, materiaId = 5 },
                    new AlumnoMateria() {alumnoId = 6, materiaId = 1 },
                    new AlumnoMateria() {alumnoId = 6, materiaId = 2 },
                    new AlumnoMateria() {alumnoId = 6, materiaId = 3 },
                    new AlumnoMateria() {alumnoId = 6, materiaId = 4 },
                    new AlumnoMateria() {alumnoId = 7, materiaId = 1 },
                    new AlumnoMateria() {alumnoId = 7, materiaId = 2 },
                    new AlumnoMateria() {alumnoId = 7, materiaId = 3 },
                    new AlumnoMateria() {alumnoId = 7, materiaId = 4 },
                    new AlumnoMateria() {alumnoId = 7, materiaId = 5 }
                });
        }
    }
}