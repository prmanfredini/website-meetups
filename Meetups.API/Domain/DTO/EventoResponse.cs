using Meetups.API.Domain.Entity;

namespace Meetups.API.Domain.DTO
{
    public class EventoResponse
    {
        public int IdEvento { get; set; }
        public int IdEventoStatus { get; set; }
        public int IdCategoriaEvento { get; set; }
        public string Nome { get; set; } = null!;
        public DateTime DataHoraInicio { get; set; }
        public DateTime DataHoraFim { get; set; }
        public string Local { get; set; } = null!;
        public string Descricao { get; set; } = null!;
        public int LimiteVagas { get; set; }

        public virtual CategoriaEventoResponse CategoriaEvento { get; set; } = null!;
        public virtual StatusEventoResponse StatusEvento { get; set; } = null!;
        public virtual ICollection<ParticipacaoResponse> Participacoes { get; set; }

    }
}
