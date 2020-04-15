
using Microsoft.EntityFrameworkCore;
using ProjectSchoolApi.Models;

namespace ProjectSchoolApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Professor> Professores { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) {
            builder.Entity<Professor>().HasData(
                new Professor[] {
                    new Professor() {
                        Id = 1,
                        Nome = "Dumbledore"
                    },
                    new Professor() {
                        Id = 2,
                        Nome = "Snape"
                    },
                    new Professor() {
                        Id = 3,
                        Nome = "Minerva"
                    }
                }
            );

            builder.Entity<Aluno>() .HasData(
                new Aluno[] {
                    new Aluno() {
                        Id = 1,
                        Nome = "Harry",
                        Sobrenome = "Potter",
                        DataNasc = "31/07/1980",
                        ProfessorId = 1
                    },
                    new Aluno() {
                        Id = 2,
                        Nome = "Rony",
                        Sobrenome = "Weasley",
                        DataNasc = "01/03/1980",
                        ProfessorId = 1
                    },
                    new Aluno() {
                        Id = 3,
                        Nome = "Hermione",
                        Sobrenome = "Granger",
                        DataNasc = "19/07/1979",
                        ProfessorId = 1
                    }
                }
            );
        }
    }
}