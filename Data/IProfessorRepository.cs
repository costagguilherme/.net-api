using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Data
{
    public interface IProfessorRepository : IRepository
    {
        Professor[] GetAll(bool includeAlunos = false);
        Professor[] GetAllByDisciplinaId(int id, bool includeAlunos = false);
        Professor GetById(int id, bool includeAlunos = false);
    }
}