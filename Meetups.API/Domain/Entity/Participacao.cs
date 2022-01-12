using System;
using System.Collections.Generic;

namespace Meetups.API.Domain.Entity
{
    public partial class Participacao
    {
        public int IdParticipacao { get; set; }
        public int IdEvento { get; set; }
        public string LoginParticipante { get; set; } = null!;
        public bool FlagPresente { get; set; }
        public int? Nota { get; set; }
        public string? Comentario { get; set; }

        public virtual Evento IdEventoNavigation { get; set; } = null!;

    }
}
