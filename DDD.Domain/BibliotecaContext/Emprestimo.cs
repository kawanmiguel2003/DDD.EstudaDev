using DDD.Domain.SecretariaContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.BibliotecaContext
{
    public class Emprestimo
    {
        public int EmprestimoId { get; set; }
        public int AlunoId { get; set; }
        public Aluno Aluno { get; set; }
        public int LivroId { get; set; }

        public Livro Livro { get; set; }

        

        public DateTime Data {get; set;}



        


    }
}
