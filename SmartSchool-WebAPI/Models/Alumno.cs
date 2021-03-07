using System.Collections.Generic;

namespace SmartSchool_WebAPI.Models{

    public class Alumno{

        public Alumno() { }
        
        public Alumno(int id, string nombre, string apellido, string matricula){
            this.id = id;
            this.nombre =nombre;
            this.apellido = apellido;
            this.matricula = matricula;
        }

        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }    
        public string matricula { get; set; }
        public IEnumerable<AlumnoMateria> AlumnosMaterias { get; set; }
    }
}