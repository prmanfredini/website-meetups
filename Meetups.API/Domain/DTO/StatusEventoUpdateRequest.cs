using System.ComponentModel.DataAnnotations;

namespace Meetups.API.Domain.DTO
{
    public class StatusEventoUpdateRequest
    {
        [Range(1, 4, ErrorMessage = "Digite um status entre 1 e 4")]
        public int IdEventoStatus { get; set; }
        public DateTime DataHoraInicio { get; set; }
        public DateTime DataHoraFim { get; set; }

    }
}
