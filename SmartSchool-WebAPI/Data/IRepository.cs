using System.Threading.Tasks;
using SmartSchool_WebAPI.Models;

namespace SmartSchool_WebAPI.Data
{
    public interface IRepository
    {
        //GERAL
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        //ALUmNO
        Task<Alumno[]> GetAllAlumnosAsync(bool includeProfesor);        
        Task<Alumno[]> GetAlumnosAsyncByMateriaId(int materiaId, bool includeMateria);
        Task<Alumno> GetAlumnoAsyncById(int alumnoId, bool includeProfesor);
        
        //PROFESOR
        Task<Profesor[]> GetAllProfesoresAsync(bool includeAlumno);
        Task<Profesor> GetProfesorAsyncById(int profesorId, bool includeAlumno);
        Task<Profesor[]> GetProfesoresAsyncByAlumnoId(int alumnoId, bool includeMateria);
    }
}