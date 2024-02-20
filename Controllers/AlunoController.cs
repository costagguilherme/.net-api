using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        private IAlunoRepository _alunoRepository;
        public AlunoController(IAlunoRepository repository)
        {
            _alunoRepository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_alunoRepository.GetAll(true));
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var aluno = _alunoRepository.GetById(id, true);
            if (aluno == null) return BadRequest("Aluno não encontrado");
            return Ok(aluno);
        }

        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            _alunoRepository.Add(aluno);
            if (_alunoRepository.SaveChanges())
            {
                return Ok(aluno);
            }
            return BadRequest("Aluno não cadastrado");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            var a = _alunoRepository.GetById(id);
            if (a == null) return BadRequest("Aluno não existe");

            _alunoRepository.Update(aluno);
            if (_alunoRepository.SaveChanges())
            {
                return Ok(aluno);
            }
            return BadRequest("Aluno não cadastrado");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var aluno = _alunoRepository.GetById(id);
            if (aluno == null) return BadRequest("Aluno não existe");

            _alunoRepository.Delete(aluno);
            if (_alunoRepository.SaveChanges())
            {
                return Ok("Aluno deletado");
            }
            return BadRequest("Aluno não deletado");
        }
    }
}