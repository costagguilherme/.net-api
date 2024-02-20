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

        private IRepository _repo;

        public ProfessorController(IRepository repository)
        {
            this._repo = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repo.GetAllProfessores(true));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var professor = _repo.GetProfessorById(id, true);
            if (professor == null) return BadRequest();
            return Ok(professor);
        }

        [HttpPost]
        public IActionResult Post(int id, Professor professor)
        {
            _repo.Add(professor);
            if (_repo.SaveChanges())
            {
                return Ok(professor);
            }
            return BadRequest("Professor não cadastrado");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor)
        {
            var prof = _repo.GetProfessorById(id);
            if (prof == null) return BadRequest("Professor não existe");
            _repo.Update(professor);
            if (_repo.SaveChanges())
            {
                return Ok(professor);
            }
            return BadRequest("Professor não cadastrado");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var professor = _repo.GetProfessorById(id);
            if (professor == null) return BadRequest("Professor não existe");
            _repo.Delete(professor);
            if (_repo.SaveChanges())
            {
                return Ok(professor);
            }
            return BadRequest("Professor não deletado");
        }
    }
}