namespace SmartSchool.WebAPI.Models
{
    public class AlunoDisciplina
    {
        public int AlunoId { get; set; }
        public int DisciplinaId { get; set; }
        public Aluno Aluno { get; set; }
        public Disciplina Disciplina { get; set; }
        public AlunoDisciplina()
        {

        }
        public AlunoDisciplina(int alunoId, int disciplinaId)
        {
            this.AlunoId = alunoId;
            this.DisciplinaId = disciplinaId;

        }
    }
}