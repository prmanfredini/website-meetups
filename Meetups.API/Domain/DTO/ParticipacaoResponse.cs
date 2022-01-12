namespace Meetups.API.Domain.DTO
{
    public class ParticipacaoResponse
    {
        public int IdParticipacao { get; set; }
        public int IdEvento { get; set; }
        public string LoginParticipante { get; set; } = null!;
        public bool FlagPresente { get; set; }
        public int? Nota { get; set; }
        public string? Comentario { get; set; }
    }
}
