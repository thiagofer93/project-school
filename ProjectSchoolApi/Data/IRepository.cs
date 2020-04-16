using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectSchoolApi.Models;

namespace ProjectSchoolApi.Data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();
        Task<List<Aluno>> GetAllAlunosAsync(bool includeProfessor = false);
        Task<List<Aluno>> GetAllAlunosByProfessorIdAsync(int professorId, bool includeProfessor = false);
        Task<Aluno> GetAlunoByIdAsync(int id, bool includeProfessor = false);
        Task<List<Professor>> GetAllProfessorAsync(bool includeAluno = false);
        Task<Professor> GetProfessorByIdAsync(int id, bool includeAluno = false);
    }
}