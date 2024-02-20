using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Interfaces;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Repositories
{
    public class AlunoRepository : Repository, IAlunoRepository
    {

        private IQueryable<Aluno> _query;

        public AlunoRepository(SmartContext context) : base(context)
        {
            _query = context.Alunos;

        }

        public Aluno[] GetAll(bool includeProfessor = false)
        {
            if (includeProfessor)
            {
                _query = _query.Include(a => a.AlunosDisciplinas)
                    .ThenInclude(ad => ad.Disciplina)
                    .ThenInclude(d => d.Professor);
            }

            _query = _query.AsNoTracking().OrderBy(a => a.Id);
            return _query.ToArray();
        }

        public Aluno[] GetAllByDisciplinaId(int id, bool includeProfessor = false)
        {
            if (includeProfessor)
            {
                _query = _query.Include(a => a.AlunosDisciplinas)
                    .ThenInclude(ad => ad.Disciplina)
                    .ThenInclude(d => d.Professor);
            }

            _query = _query.AsNoTracking()
                .OrderBy(a => a.Id)
                .Where(a => a.AlunosDisciplinas.Any(ad => ad.DisciplinaId == id));
            return _query.ToArray();
        }

        public Aluno GetById(int id, bool includeProfessor = false)
        {
            if (includeProfessor)
            {
                _query = _query.Include(a => a.AlunosDisciplinas)
                    .ThenInclude(ad => ad.Disciplina)
                    .ThenInclude(d => d.Professor);
            }

            _query = _query.AsNoTracking()
                .OrderBy(a => a.Id)
                .Where(aluno => aluno.Id == id);
            return _query.FirstOrDefault();
        }
    }
}