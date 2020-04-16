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
    public class AlunoController : ControllerBase
    {
        private IRepository _repo { get; }
        public AlunoController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _repo.GetAllAlunosAsync(true);
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
                var result = await _repo.GetAlunoByIdAsync(id, true);
                return Ok(result);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro de conexão");
            }
        }

        [HttpGet("professor/{professorId}")]
        public async Task<IActionResult> GetByProfessorId(int professorId)
        {
            try
            {
                var result = await _repo.GetAllAlunosByProfessorIdAsync(professorId, true);
                return Ok(result);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro de conexão");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Aluno model)
        {
            try
            {
                _repo.Add(model);

                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/api/aluno/{model.Id}", model);
                }

                return BadRequest();
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro de conexão");
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Aluno model)
        {
            try
            {
                var aluno = await _repo.GetAlunoByIdAsync(id);

                if (aluno == null) return NotFound();

                _repo.Update(model);

                if (await _repo.SaveChangesAsync())
                {
                    aluno = await _repo.GetAlunoByIdAsync(id, true);
                    return Created($"/api/aluno/{model.Id}", aluno);
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
                var aluno = await _repo.GetAlunoByIdAsync(id);

                if (aluno == null) return NotFound();

                _repo.Delete(aluno);
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