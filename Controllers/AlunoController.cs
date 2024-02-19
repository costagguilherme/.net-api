using Microsoft.AspNetCore.Mvc;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        public AlunoController()
        {
        }

        public List<Aluno> Alunos = new List<Aluno> {
            new Aluno() {
                Id = 1,
                Nome = "Guilherme",
                Sobrenome = "Lopes",
                Telefone = "71988232332"
            },
                        new Aluno() {
                Id = 2,
                Nome = "Marta",
                Sobrenome = "Medeiros",
                Telefone = "85991458930"
            }
        };

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(this.Alunos);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var aluno = Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null) return BadRequest("Aluno não encontrado");
            return Ok(aluno);
        }

        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            return Ok(aluno);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            return Ok(aluno);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}