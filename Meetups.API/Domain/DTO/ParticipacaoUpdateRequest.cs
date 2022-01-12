using System.ComponentModel.DataAnnotations;

namespace Meetups.API.Domain.DTO
{
    public class ParticipacaoUpdateRequest
    {
        [Required]
        public bool FlagPresente { get; set; }

    }
}
