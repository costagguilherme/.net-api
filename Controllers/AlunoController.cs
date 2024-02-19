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
        private SmartContext context;
        public AlunoController(SmartContext context)
        {
            context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(context.Alunos);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var aluno = context.Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null) return BadRequest("Aluno não encontrado");
            return Ok(aluno);
        }

        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            this.context.Add(aluno);
            this.context.SaveChanges();
            return Ok(aluno);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            var a = context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (a == null) return BadRequest("Aluno não existe");
            this.context.Update(aluno);
            this.context.SaveChanges();
            return Ok(aluno);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var aluno = context.Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null) return BadRequest("Aluno não existe");
            this.context.Remove(aluno);
            this.context.SaveChanges();
            return Ok(aluno);
        }
    }
}