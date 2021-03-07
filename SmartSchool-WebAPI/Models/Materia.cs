using System.Collections.Generic;

namespace SmartSchool_WebAPI.Models{

    public class Materia{

        public Materia() { }

        public Materia(int id, string nombre, int profesorId)
        {
            this.id = id;
            this.nombre = nombre;
            this.profesorId = profesorId;
        }

        public int id { get; set; } 
        public string nombre { get; set; }  
        public int profesorId { get; set; } 
        public Profesor profesor { get; set; }
        public IEnumerable<AlumnoMateria> AlumnosMaterias { get; set; }

    }
}