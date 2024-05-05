using DDD.Domain.BibliotecaContext;
using DDD.Domain.SecretariaContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.SQLServer.Interfaces
{
    public interface IEmprestimoRepository
    {
        public List<Emprestimo> GetEmprestimos();
        public Emprestimo GetEmprestimoById(int id);
        public Emprestimo InsertEmprestimo( int idAluno,int idLivro);
        public void UpdateEmprestimo(Emprestimo emprestimo);
        public void DeleteEmprestimo(Emprestimo emprestimo);
    }
}
