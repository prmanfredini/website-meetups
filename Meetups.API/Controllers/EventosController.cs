using Meetups.API.Domain;
using Meetups.API.Domain.DTO;
using Meetups.API.Services;
using Meetups.API.Services.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Meetups.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventosController : ControllerBase
    {
        private readonly EventosService eventosService;

        public EventosController(EventosService eventosService)
        {
            this.eventosService = eventosService;
        }


        [HttpGet("{page}/{itens}")]
        public IEnumerable<EventoResponse> Get(int page, int itens)
        {
            return eventosService.ListarTodos(page, itens);
        }

        [HttpGet("quantosEventos")]
        public int GetNum()
        {
            return eventosService.ContarTodos();
        }

        [HttpGet("GetId/{idEvento}")]
        public IActionResult GetById(int idEvento)
        {
            var retorno = eventosService.PesquisarPorId(idEvento);

            if (retorno.Sucesso)
            {
                return Ok(retorno.ObjetoRetorno);
            }
            else
            {
                return NotFound(retorno.Mensagem);
            }
        }

        [HttpGet("CategoriaEvento/{idCategoria}")]
        public IActionResult GetByIdCategoriaEvento(int idCategoria)
        {
            var retorno = eventosService.PesquisarPorIdCategoria(idCategoria);

            if (retorno.Sucesso)
            {
                return Ok(retorno.ObjetoRetorno);
            }
            else
            {
                return NotFound(retorno.Mensagem);
            }
        }

        [HttpGet("DataEvento/{dataEvento}")]
        public IActionResult GetByData(DateTime dataEvento)
        {
            var retorno = eventosService.PesquisarPorData(dataEvento);

            if (retorno.Sucesso)
            {
                return Ok(retorno.ObjetoRetorno);
            }
            else
            {
                return NotFound(retorno.Mensagem);
            }
        }


        [HttpPost]
        public IActionResult Post([FromBody] EventoCreateRequest postModel)
        {
            if (ModelState.IsValid)
            {
                var retorno = eventosService.CadastrarNovo(postModel);
                if (!retorno.Sucesso)
                    return BadRequest(retorno.Mensagem);
                else
                    return Ok(retorno);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut("status/{idEvento}")]
        public IActionResult Put(int idEvento, [FromBody] StatusEventoUpdateRequest putModel)
        {
            if (ModelState.IsValid)
            {
                var retorno = eventosService.EditarEvento(idEvento, putModel);
                if (!retorno.Sucesso)
                    return BadRequest(retorno.Mensagem);
                return Ok(retorno.ObjetoRetorno);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }



        [HttpDelete("{idEvento}")]
        public IActionResult Delete(int idEvento)
        {
            var retorno = eventosService.Deletar(idEvento);
            if (!retorno.Sucesso)
                return BadRequest(retorno.Mensagem);
            return Ok();
        }

    }


}
