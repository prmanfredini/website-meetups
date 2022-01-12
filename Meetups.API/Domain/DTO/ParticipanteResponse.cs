namespace Meetups.API.Domain.DTO
{
    public class ParticipanteResponse
    {
        public int IdParticipacao { get; set; }
        public int IdEvento { get; set; }
        public string LoginParticipante { get; set; } = null!;
        public bool FlagPresente { get; set; }
        public int? Nota { get; set; }
        public string? Comentario { get; set; }
        public virtual EventoResponse2 Eventos { get; set; }
        public virtual CategoriaEventoResponse CategoriaEvento { get; set; } = null!;
        public virtual StatusEventoResponse StatusEvento { get; set; } = null!;


    }
}
