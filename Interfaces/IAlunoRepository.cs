using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Interfaces
{
    public interface IAlunoRepository : IRepository
    {

        Aluno[] GetAll(bool includeProfessor = false);
        Aluno[] GetAllByDisciplinaId(int id, bool includeProfessor = false);
        Aluno GetById(int id, bool includeProfessor = false);

    }
}