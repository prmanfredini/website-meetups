using System.ComponentModel.DataAnnotations;

namespace Meetups.API.Domain.DTO
{
    public class EventoCreateRequest
    {
        [Required]
        [Range(1, 9, ErrorMessage = "Digite uma categoria entre 1 e 9")]
        public int IdCategoriaEvento { get; set; } //
        //public int IdEventoStatus { get; set; }//
        [Required]
        [MaxLength(250, ErrorMessage = "Digite no máximo 250 caracteres")]
        public string Nome { get; set; } = null!;
        [Required]
        public DateTime DataHoraInicio { get; set; }
        [Required]
        public DateTime DataHoraFim { get; set; }
        [Required]
        [MaxLength(250, ErrorMessage = "Digite no máximo 250 caracteres")]
        public string Local { get; set; } = null!;
        [Required]
        [MaxLength(1000, ErrorMessage = "Digite no máximo 1000 caracteres")]
        public string Descricao { get; set; } = null!;
        [Required]
        [Range(1, 1000, ErrorMessage = "Digite um valor entre 1 e 1000")]
        public int LimiteVagas { get; set; }

    }
}
