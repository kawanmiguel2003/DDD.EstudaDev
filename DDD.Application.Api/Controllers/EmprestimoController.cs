using DDD.Domain.BibliotecaContext;
using DDD.Domain.SecretariaContext;
using DDD.Infra.SQLServer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Application.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmprestimoController : ControllerBase
    {
        readonly IEmprestimoRepository _emprestimoRepository;
        public EmprestimoController(IEmprestimoRepository emprestimoRepository)
        {
            _emprestimoRepository = emprestimoRepository;
        }

    

    [HttpGet]
    public ActionResult<List<Emprestimo>> Get()
    {
        return Ok(_emprestimoRepository.GetEmprestimos());
    }

    [HttpGet("{id}")]
    public ActionResult<Aluno> GetById(int id)
    {
        return Ok(_emprestimoRepository.GetEmprestimoById(id));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<Emprestimo> CreateEmprestimo(int idAluno, int idLivro)
    {
        Emprestimo emprestimoIdSaved = _emprestimoRepository.InsertEmprestimo(idAluno,idLivro );
        return CreatedAtAction(nameof(GetById), new { id = emprestimoIdSaved.EmprestimoId }, emprestimoIdSaved);
    }




    }
}
