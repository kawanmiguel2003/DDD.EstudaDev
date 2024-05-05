using DDD.Domain.BibliotecaContext;
using DDD.Domain.SecretariaContext;
using DDD.Infra.SQLServer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Application.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        readonly ILivroRepository _livroRepository;
        public LivroController(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        // GET: api/<LivrosController>
        [HttpGet]
        public ActionResult<List<Livro>> Get()
        {
            return Ok(_livroRepository.GetLivros());
        }


        [HttpGet("{id}")]
        public ActionResult<Livro> GetById(int id)
        {
            return Ok(_livroRepository.GetLivroById(id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Livro> CreateAluno(Livro livro)
        {
            if (livro.Nome.Length < 3 || livro.Nome.Length > 30)
            {
                return BadRequest("Nome deve ser maior que 3 e menor que 30 caracteres.");
            }
            _livroRepository.InsertLivro(livro);
            return CreatedAtAction(nameof(GetById), new { id = livro.LivroId }, livro);
        }


        [HttpPut]
        public ActionResult Put([FromBody] Livro livro)
        {
            try
            {
                if (livro == null)
                    return NotFound();

                _livroRepository.InsertLivro(livro);
                return Ok("Livro Atualizado com sucesso!");
            }
            catch (Exception)
            {

                throw;
            }
        }

        // DELETE api/values/5
        [HttpDelete()]
        public ActionResult Delete([FromBody] Livro livro)
        {
            try
            {
                if (livro == null)
                    return NotFound();

                _livroRepository.DeleteLivro(livro);
                return Ok("Livro Removido com sucesso!");
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


    }
}
