
using Microsoft.AspNetCore.Mvc;
using webapi.event_.Domains;
using webapi.event_.Interfaces;
using webapi.event_.Repositories;

namespace eventplus_webapi.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PresencasEventoController : ControllerBase
    {
        private IPresencasEventoRepository _presencasEventoRepository;

        
        public PresencasEventoController()
        {
            _presencasEventoRepository = new PresencasEventoRepository();
        }


        [HttpPost]
        public IActionResult Post(PresencasEvento presencasEvento)
        {
            try
            {
                _presencasEventoRepository.Cadastrar(presencasEvento);

                return StatusCode(201);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

   
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_presencasEventoRepository.Listar());
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }
        /// <summary>
        /// minha lista
        /// </summary>
        /// <param name="id"></param>
        /// <returns>minha lista</returns>

        [HttpGet("{id}")]
        public IActionResult GetByUser(Guid id)
        {
            try
            {
                return Ok(_presencasEventoRepository.ListarMinhas(id));

            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

    
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, PresencasEvento presencaEvento)
        {
            try
            {
                _presencasEventoRepository.Atualizar(id, presencaEvento);

                return Ok();
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

  
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _presencasEventoRepository.Deletar(id);

                return Ok();
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
