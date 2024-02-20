using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {

        private IProfessorRepository professorRepository;

        public ProfessorController(IProfessorRepository repository)
        {
            this.professorRepository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(professorRepository.GetAll(true));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var professor = professorRepository.GetById(id, true);
            if (professor == null) return BadRequest();
            return Ok(professor);
        }

        [HttpPost]
        public IActionResult Post(int id, Professor professor)
        {
            professorRepository.Add(professor);
            if (professorRepository.SaveChanges())
            {
                return Ok(professor);
            }
            return BadRequest("Professor não cadastrado");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor)
        {
            var prof = professorRepository.GetById(id);
            if (prof == null) return BadRequest("Professor não existe");
            professorRepository.Update(professor);
            if (professorRepository.SaveChanges())
            {
                return Ok(professor);
            }
            return BadRequest("Professor não cadastrado");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var professor = professorRepository.GetById(id);
            if (professor == null) return BadRequest("Professor não existe");
            professorRepository.Delete(professor);
            if (professorRepository.SaveChanges())
            {
                return Ok(professor);
            }
            return BadRequest("Professor não deletado");
        }
    }
}