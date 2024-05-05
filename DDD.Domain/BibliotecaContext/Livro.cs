using DDD.Domain.SecretariaContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.BibliotecaContext
{
    public class Livro
    {
        public int LivroId {  get; set; }
        public string Nome { get; set; }
        public string Autor { get; set; }

        public string Genero { get; set; }

        public int Paginas { get; set; }
        public int Quantidade { get; set; }

        public IList<Aluno>? Alunos { get; set; }





    }
}
