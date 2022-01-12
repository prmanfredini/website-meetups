using System;
using System.Collections.Generic;

namespace Meetups.API.Domain.Entity
{
    public partial class StatusEvento
    {
        public StatusEvento()
        {
            Eventos = new HashSet<Evento>();
        }

        public int IdEventoStatus { get; set; }
        public string NomeStatus { get; set; } = null!;

        public virtual ICollection<Evento> Eventos { get; set; }
    }
}
