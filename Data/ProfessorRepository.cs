using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Data
{
    public class ProfessorRepository : Repository, IProfessorRepository
    {

        private IQueryable<Professor> _query;

        public ProfessorRepository(SmartContext context) : base(context)
        {
            _query = context.Professores;

        }

        public Professor[] GetAll(bool includeAlunos = false)
        {

            if (includeAlunos)
            {
                _query = _query.Include(p => p.Disciplinas)
                    .ThenInclude(d => d.AlunosDisciplinas)
                    .ThenInclude(ad => ad.Aluno);
            }

            _query = _query.AsNoTracking().OrderBy(p => p.id);
            return _query.ToArray();
        }

        public Professor[] GetAllByDisciplinaId(int id, bool includeAlunos = false)
        {

            if (includeAlunos)
            {
                _query = _query.Include(p => p.Disciplinas)
                    .ThenInclude(d => d.AlunosDisciplinas)
                    .ThenInclude(ad => ad.Aluno);
            }

            _query = _query.AsNoTracking()
                .Where(p => p.Disciplinas.Any(
                    d => d.Id == id)
                ).OrderBy(p => p.id);
            return _query.ToArray();
        }

        public Professor GetById(int id, bool includeAlunos = false)
        {

            if (includeAlunos)
            {
                _query = _query.Include(p => p.Disciplinas)
                    .ThenInclude(d => d.AlunosDisciplinas)
                    .ThenInclude(ad => ad.Aluno);
            }

            _query = _query.AsNoTracking().Where(p => p.id == id);
            return _query.FirstOrDefault();
        }
    }
}