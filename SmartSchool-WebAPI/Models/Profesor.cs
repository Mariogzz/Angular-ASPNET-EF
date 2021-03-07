using System.Collections.Generic;

namespace SmartSchool_WebAPI.Models{

    public class Profesor{

        public Profesor() { }

        public Profesor(int id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;
        }

        public int id { get; set; } 
        public string nombre { get; set; }  
        public IEnumerable<Materia> materias { get; set; } 

    }
}