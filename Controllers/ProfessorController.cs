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

        private SmartContext context;
        public ProfessorController(SmartContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(this.context.Professores);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var professor = this.context.Professores.FirstOrDefault(p => p.id == id);
            if (professor == null) return BadRequest();
            return Ok(professor);
        }

        [HttpPost]
        public IActionResult Post(int id, Professor professor)
        {
            this.context.Add(professor);
            this.context.SaveChanges();
            return Ok(professor);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor)
        {
            var prof = this.context.Professores.AsNoTracking().FirstOrDefault(p => p.id == id);
            if (prof == null) return BadRequest("Professor não existe");
            this.context.Update(professor);
            this.context.SaveChanges();
            return Ok(professor);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var professor = this.context.Professores.AsNoTracking().FirstOrDefault(p => p.id == id);
            if (professor == null) return BadRequest("Professor não existe");
            this.context.Remove(professor);
            this.context.SaveChanges();
            return Ok(professor);
        }
    }
}