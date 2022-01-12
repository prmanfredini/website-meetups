using System.ComponentModel.DataAnnotations;

namespace Meetups.API.Domain
{
    public class AvaliacaoUpdateRequest
    {
        [Range(1, 5, ErrorMessage = "Digite uma nota entre 1 e 5")]
        public int? Nota { get; set; }
        [MaxLength(1000, ErrorMessage = "Digite no máximo 1000 caracteres")]
        public string? Comentario { get; set; }
    }
}
