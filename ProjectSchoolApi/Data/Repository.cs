using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectSchoolApi.Models;

namespace ProjectSchoolApi.Data
{
    public class Repository : IRepository
    {
        private DataContext _db { get; }

        public Repository(DataContext db)
        {
            this._db = db;

        }
        public void Add<T>(T entity) where T : class
        {
            _db.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _db.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _db.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _db.SaveChangesAsync() > 0;
        }

        public async Task<List<Aluno>> GetAllAlunosAsync(bool includeProfessor = false)
        {
            IQueryable<Aluno> query = _db.Alunos;

            if(includeProfessor) {
                query = query.Include(x=> x.Professor);
            }

            return await query.AsNoTracking().OrderBy(x => x.Id).ToListAsync();
        }

        public async Task<List<Aluno>> GetAllAlunosByProfessorIdAsync(int professorId, bool includeProfessor = false)
        {
            IQueryable<Aluno> query = _db.Alunos.Where(x=> x.ProfessorId == professorId);

            if(includeProfessor) {
                query = query.Include(x=> x.Professor);
            }

            return await query.AsNoTracking().OrderBy(x => x.Id).ToListAsync();
        }

        public async Task<Aluno> GetAlunoByIdAsync(int id, bool includeProfessor = false)
        {
            IQueryable<Aluno> query = _db.Alunos;

            if(includeProfessor) {
                query = query.Include(x=> x.Professor);
            }

            return await query.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Professor>> GetAllProfessorAsync(bool includeAluno = false)
        {
            IQueryable<Professor> query = _db.Professores;

            if(includeAluno) {
                query = query.Include(x=> x.Alunos);
            }

            return await query.AsNoTracking().OrderBy(x=>x.Id).ToListAsync();
        }

        public async Task<Professor> GetProfessorByIdAsync(int id, bool includeAluno = false)
        {
            IQueryable<Professor> query = _db.Professores;
            
            if(includeAluno) {
                query = query.Include(x=> x.Alunos);
            }

            return await query.AsNoTracking().FirstOrDefaultAsync(x=> x.Id == id);
        }
    }
}