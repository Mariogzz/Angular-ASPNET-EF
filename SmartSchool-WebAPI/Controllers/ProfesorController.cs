using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmartSchool_WebAPI.Data;
using SmartSchool_WebAPI.Models;

namespace SmartSchool_WebAPI.Controllers{

    [ApiController]
    [Route("api/[controller]")]
    public class ProfesorController : ControllerBase
    {

        private readonly IRepository _repo;
        public ProfesorController(IRepository repo){
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _repo.GetAllProfesoresAsync(true);

                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpGet("{profesorId}")]
        public async Task<IActionResult> GetByProfesorId(int profesorId){
            try
            {
                var result = await _repo.GetProfesorAsyncById(profesorId, true);

                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpGet("ByAlumno/{alumnoId}")]
        public async Task<IActionResult> GetByAlumnoId(int alumnoId)
        {
            try
            {
                var result = await _repo.GetProfesoresAsyncByAlumnoId(alumnoId, true);

                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> post(Profesor model)
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

        [HttpPut("{profesorId}")]
        public async Task<IActionResult> put(int profesorId, Profesor model)
        {
            try
            {
                var Profesor = await _repo.GetProfesorAsyncById(profesorId,false);

                if(Profesor == null) return NotFound();

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

        [HttpDelete("{profesorId}")]
        public async Task<IActionResult> delete(int profesorId)
        {
            try
            {
                var Profesor = await _repo.GetProfesorAsyncById(profesorId,false);

                if(Profesor == null) return NotFound();

                _repo.Delete(Profesor);

                if(await _repo.SaveChangesAsync())
                {
                    return Ok("Eliminado");
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