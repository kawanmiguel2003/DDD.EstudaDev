using DDD.Domain.BibliotecaContext;
using DDD.Domain.SecretariaContext;
using DDD.Infra.SQLServer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Application.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BibliotecariaController : ControllerBase
    {
        readonly IBibliotecariaRepository _bibliotecariaRepository;

        public BibliotecariaController(IBibliotecariaRepository bibliotecariaRepository)
        {
            _bibliotecariaRepository = bibliotecariaRepository;
        }

        // GET: api/<BibliotecariaController>
        [HttpGet]
        public ActionResult<List<Bibliotecaria>> Get()
        {
            return Ok(_bibliotecariaRepository.GetBibliotecarias());
        }

        [HttpGet("{id}")]
        public ActionResult<Bibliotecaria> GetById(int id)
        {
            return Ok(_bibliotecariaRepository.GetBibliotecariaById(id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Bibliotecaria> CreateBibliotecaria(Bibliotecaria bibliotecaria)
        {
            if (bibliotecaria.Nome.Length < 3 || bibliotecaria.Nome.Length > 30)
            {
                return BadRequest("Nome deve ser maior que 3 e menor que 30 caracteres.");
            }
            _bibliotecariaRepository.InsertBibliotecaria(bibliotecaria);
            return CreatedAtAction(nameof(GetById), new { id = bibliotecaria.UserId }, bibliotecaria);
        }

        [HttpPut]
        public ActionResult Put([FromBody] Bibliotecaria bibliotecaria)
        {
            try
            {
                if (bibliotecaria == null)
                    return NotFound();

                _bibliotecariaRepository.UpdateBibliotecaria(bibliotecaria);
                return Ok("Bibliotecaria Atualizado com sucesso!");
            }
            catch (Exception)
            {

                throw;
            }
        }

        // DELETE api/values/5
        [HttpDelete()]
        public ActionResult Delete([FromBody] Bibliotecaria bibliotecaria)
        {
            try
            {
                if (bibliotecaria == null)
                    return NotFound();

                _bibliotecariaRepository.DeleteBibliotecaria(bibliotecaria);
                return Ok("Bibliotecaria Removido com sucesso!");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
