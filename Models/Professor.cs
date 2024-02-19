
namespace SmartSchool.WebAPI.Models
{
    public class Professor
    {
        public Professor()
        {

        }
        public Professor(int id, string nome)
        {
            this.id = id;
            this.Nome = nome;
        }
        public int id { get; set; }

        public string Nome { get; set; }

        public IEnumerable<Disciplina> Disciplinas { get; set; }
    }
}