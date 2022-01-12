using Meetups.API.Domain;
using Meetups.API.Domain.DTO;
using Meetups.API.Services.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Meetups.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipacoesController : ControllerBase
    {
        private readonly ParticipacaoService participacaoService;

        public ParticipacoesController(ParticipacaoService participacaoService)
        {
            this.participacaoService = participacaoService;
        }


        [HttpGet("{idEvento}")]
        public IActionResult GetById(int idEvento)
        {
            var retorno = participacaoService.PesquisarPorEvento(idEvento);

            if (retorno == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(retorno);
            }
        }

        [HttpGet("Participantes/{LoginParticipante}")]
        public IActionResult GetByLogin(string LoginParticipante)
        {
            var retorno = participacaoService.PesquisarPorLogin(LoginParticipante);

            if (retorno == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(retorno);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] ParticipacaoCreateRequest postModel)
        {
            if (ModelState.IsValid)
            {
                var retorno = participacaoService.CadastrarNovo(postModel);
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
        [HttpGet]
        public IEnumerable<ParticipacaoResponse> Get()
        {
            return participacaoService.ListarTodos();
        }

        [HttpPut("{idUser}")]
        public IActionResult Put(int idUser, [FromBody] ParticipacaoUpdateRequest putModel)
        {
            if (ModelState.IsValid) 
            {
                var retorno = participacaoService.EditarPresenca(idUser, putModel);
                if (!retorno.Sucesso)
                    return BadRequest(retorno.Mensagem);
                return Ok(retorno.ObjetoRetorno);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut("Avaliacao/{idUser}")]
        public IActionResult PutAvaliacao(int idUser, [FromBody] AvaliacaoUpdateRequest putModel)
        {
            if (ModelState.IsValid)
            {
                var retorno = participacaoService.Avaliar(idUser, putModel);
                if (!retorno.Sucesso)
                    return BadRequest(retorno.Mensagem);
                return Ok(retorno.ObjetoRetorno);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet("vagasOcupadas/{idEvent}")]
        public int GetVagas(int idEvent)
        {
            var numVagas = 0;
            if (participacaoService.CountParticipantes(idEvent) != null)
                numVagas = participacaoService.CountParticipantes(idEvent);
            return numVagas;
        }

        [HttpDelete("RemoveParticipante/{idUser}")]
        public IActionResult RemoveParticipante(int idUser)
        {
            var retorno = participacaoService.DeletaPariticipante(idUser);
            if (!retorno.Sucesso)
                return BadRequest(retorno.Mensagem);
            return Ok();
        }


    }


}


