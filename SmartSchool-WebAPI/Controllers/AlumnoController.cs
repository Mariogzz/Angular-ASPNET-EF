using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmartSchool_WebAPI.Data;
using SmartSchool_WebAPI.Models;

namespace SmartSchool_WebAPI.Controllers{

    [ApiController]
    [Route("api/[controller]")]
    public class AlumnoController : ControllerBase
    {
        private readonly IRepository _repo;

        public AlumnoController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get(){
        
            try{
                var result = await _repo.GetAllAlumnosAsync(true);

                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpGet("{alumnoId}")]
        public async Task<IActionResult> GetByAlumnoId(int alumnoId){
        
            try{
                var result = await _repo.GetAlumnoAsyncById(alumnoId, true);
                
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }
        
        [HttpGet("ByMateria/{materiaId}")]
        public async Task<IActionResult> GetByMateriaId(int materiaId){
        try
        {
            var result = await _repo.GetAlumnosAsyncByMateriaId(materiaId, false);
            return Ok(result);
        }
        catch(Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> post(Alumno model)
        {
            try
            {
                _repo.Add(model);

                if(await _repo.SaveChangesAsync())
                {
                    return Ok(model);
                }
            }
            catch(Exception ex)
            {
                    return BadRequest($"Error: {ex.Message}");
            }

            return BadRequest();
        }

        [HttpPut("{alumnoId}")]
        public async Task<IActionResult> put(int alumnoId ,Alumno model)
        {
            try
            {
                var alumno = await _repo.GetAlumnoAsyncById(alumnoId, false);
                if(alumno == null) return NotFound();
                _repo.Update(model);

                if(await _repo.SaveChangesAsync())
                {
                    return Ok(model);
                }
            }
            catch(Exception ex)
            {
                    return BadRequest($"Error: {ex.Message}");
            }

            return BadRequest();
        }

        [HttpDelete("{alumnoId}")]
        public async Task<IActionResult> delete(int alumnoId)
        {
            try
            {
                var alumno = await _repo.GetAlumnoAsyncById(alumnoId, false);
                if(alumno == null) return NotFound();
                _repo.Delete(alumno);

                if(await _repo.SaveChangesAsync())
                {
                    return Ok(new {message="Eliminado"});
                }
            }
            catch(Exception ex)
            {
                    return BadRequest($"Error: {ex.Message}");
            }

            return BadRequest();
        }
    }
}  