using System;
using System.Collections.Generic;

namespace Meetups.API.Domain.Entity
{
    public partial class Evento
    {
        public Evento()
        {
            Participacoes = new HashSet<Participacao>();
        }

        public int IdEvento { get; set; }
        public int IdEventoStatus { get; set; }
        public int IdCategoriaEvento { get; set; }
        public string Nome { get; set; } = null!;
        public DateTime DataHoraInicio { get; set; }
        public DateTime DataHoraFim { get; set; }
        public string Local { get; set; } = null!;
        public string Descricao { get; set; } = null!;
        public int LimiteVagas { get; set; }

        public virtual CategoriaEvento IdCategoriaEventoNavigation { get; set; } = null!;
        public virtual StatusEvento IdEventoStatusNavigation { get; set; } = null!;
        public virtual ICollection<Participacao> Participacoes { get; set; }


    }
}
