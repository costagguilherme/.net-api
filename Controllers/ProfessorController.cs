using Microsoft.AspNetCore.Mvc;
using SmartSchool.WebAPI.Interfaces;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {

        private IProfessorRepository _professorRepository;

        public ProfessorController(IProfessorRepository repository)
        {
            _professorRepository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_professorRepository.GetAll(true));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var professor = _professorRepository.GetById(id, true);
            if (professor == null) return BadRequest("Professor não existe");
            return Ok(professor);
        }

        [HttpPost]
        public IActionResult Post(int id, Professor professor)
        {
            _professorRepository.Add(professor);
            if (_professorRepository.SaveChanges())
            {
                return Ok(professor);
            }
            return BadRequest("Professor não cadastrado");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor)
        {
            var prof = _professorRepository.GetById(id);
            if (prof == null) return BadRequest("Professor não existe");
            _professorRepository.Update(professor);
            if (_professorRepository.SaveChanges())
            {
                return Ok(professor);
            }
            return BadRequest("Professor não cadastrado");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var professor = _professorRepository.GetById(id);
            if (professor == null) return BadRequest("Professor não existe");
            _professorRepository.Delete(professor);
            if (_professorRepository.SaveChanges())
            {
                return Ok(professor);
            }
            return BadRequest("Professor não deletado");
        }
    }
}