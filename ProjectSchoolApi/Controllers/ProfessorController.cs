using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectSchoolApi.Data;
using ProjectSchoolApi.Models;

namespace ProjectSchoolApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
        private IRepository _repo { get; }
        public ProfessorController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _repo.GetAllProfessorAsync(true);
                return Ok(result);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro de conexão");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var result = await _repo.GetProfessorByIdAsync(id, true);
                return Ok(result);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro de conexão");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Professor model)
        {
            try
            {
                _repo.Add(model);

                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/api/professor/{model.Id}", model);
                }

                return BadRequest();
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro de conexão");
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Professor model)
        {
            try
            {
                var professor = await _repo.GetProfessorByIdAsync(id);

                if (professor == null) return NotFound();

                _repo.Update(model);

                if (await _repo.SaveChangesAsync())
                {
                    professor = await _repo.GetProfessorByIdAsync(id, true);
                    return Created($"/api/professor/{model.Id}", professor);
                }

                return BadRequest();
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro de conexão");
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var professor = await _repo.GetProfessorByIdAsync(id);

                if (professor == null) return NotFound();

                _repo.Delete(professor);
                if (await _repo.SaveChangesAsync())
                {
                    return Ok();
                }
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro de conexão");
            }

            return BadRequest();
        }
    }
}