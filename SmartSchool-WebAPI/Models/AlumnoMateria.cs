namespace SmartSchool_WebAPI.Models{

    public class AlumnoMateria{

        public AlumnoMateria() { }

        public AlumnoMateria(int alumnoId, int materiaId)
        {
            this.alumnoId = alumnoId;
            this.materiaId = materiaId;
        }

        public int alumnoId { get; set; }
        public Alumno alumno { get; set; }
        public int materiaId { get; set; }
        public Materia materia { get; set; }

    }
}