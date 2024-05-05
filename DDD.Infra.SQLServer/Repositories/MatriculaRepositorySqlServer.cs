using DDD.Domain.BibliotecaContext;
using DDD.Domain.SecretariaContext;
using DDD.Infra.SQLServer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SQLServer.Repositories
{
    public class MatriculaRepositorySqlServer : IMatriculaRepository
    {
        private readonly SqlContext _context;

        public MatriculaRepositorySqlServer(SqlContext context)
        {
            _context = context;
        }


        public void DeleteMatricula(Matricula matricula)
        {
            _context.Set<Matricula>().Remove(matricula);
            _context.SaveChanges();
        }

        public Matricula GetMatriculaById(int id)
        {
            return _context.Matriculas.Find(id);
        }

        public List<Matricula> GetMatriculas()
        {
            return _context.Matriculas.ToList();
        }

        public Matricula InsertMatricula(int idAluno, int idDisciplina)
        {
            var aluno = _context.Alunos .First(i => i.UserId == idAluno);
            var disciplina = _context.Disciplinas.First(i => i.DisciplinaId == idDisciplina);

            var matricula = new Matricula
            {
                Aluno = aluno,
                Disciplina = disciplina
            };

            try
            {

                _context.Add(matricula);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                var msg = ex.InnerException;
                throw;
            }

            return matricula;
        }

        public void UpdateMatricula(Matricula matricula)
        {
            try
            {
                _context.Entry(matricula).State = EntityState.Modified;
                _context.SaveChanges();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
