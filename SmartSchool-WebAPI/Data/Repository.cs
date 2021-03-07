using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartSchool_WebAPI.Models;

namespace SmartSchool_WebAPI.Data{

    public class Repository : IRepository
    {
        private readonly DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Alumno[]> GetAllAlumnosAsync(bool includeMateria = false)
        {
            IQueryable<Alumno> query = _context.alumnos;

            if (includeMateria)
            {
                query = query.Include(pe => pe.AlumnosMaterias)
                             .ThenInclude(ad => ad.materia)
                             .ThenInclude(d => d.profesor);
            }

            query = query.AsNoTracking()
                         .OrderBy(c => c.id);

            return await query.ToArrayAsync();
        }
        public async Task<Alumno> GetAlumnoAsyncById(int alumnoId, bool includeMateria)
        {
            IQueryable<Alumno> query = _context.alumnos;

            if (includeMateria)
            {
                query = query.Include(a => a.AlumnosMaterias)
                             .ThenInclude(ad => ad.materia)
                             .ThenInclude(d => d.profesor);
            }

            query = query.AsNoTracking()
                         .OrderBy(alumno => alumno.id)
                         .Where(alumno => alumno.id == alumnoId);

            return await query.FirstOrDefaultAsync();
        }
        public async Task<Alumno[]> GetAlumnosAsyncByMateriaId(int materiaId, bool includeMateria)
        {
            IQueryable<Alumno> query = _context.alumnos;

            if (includeMateria)
            {
                query = query.Include(p => p.AlumnosMaterias)
                             .ThenInclude(ad => ad.materia)                             
                             .ThenInclude(d => d.profesor);
            }

            query = query.AsNoTracking()
                         .OrderBy(alumno => alumno.id)
                         .Where(alumno => alumno.AlumnosMaterias.
                         //.Contains(new AlumnoMateria(){ materiaId = materiaId }));
                         Any(ad => ad.materiaId == materiaId));

            return await query.ToArrayAsync();
        }

        public async Task<Profesor[]> GetProfesoresAsyncByAlumnoId(int alumnoId, bool includeDisciplina)
        {
            IQueryable<Profesor> query = _context.profesores;

            if (includeDisciplina)
            {
                query = query.Include(p => p.materias);
            }

            query = query.AsNoTracking()
                         .OrderBy(alumno => alumno.id)
                         .Where(alumno => alumno.materias.Any(d => 
                            d.AlumnosMaterias.Any(ad => ad.alumnoId == alumnoId)));

            return await query.ToArrayAsync();
        }

        public async Task<Profesor[]> GetAllProfesoresAsync(bool includeMaterias = true)
        {
            IQueryable<Profesor> query = _context.profesores;

            if (includeMaterias)
            {
                query = query.Include(c => c.materias);
            }

            query = query.AsNoTracking()
                         .OrderBy(profesor => profesor.id);

            return await query.ToArrayAsync();
        }
        public async Task<Profesor> GetProfesorAsyncById(int profesorId, bool includeMaterias = true)
        {
            IQueryable<Profesor> query = _context.profesores;

            if (includeMaterias)
            {
                query = query.Include(pe => pe.materias);
            }

            query = query.AsNoTracking()
                         .OrderBy(profesor => profesor.id)
                         .Where(profesor => profesor.id == profesorId);

            return await query.FirstOrDefaultAsync();
        }
    }
}