using System;
using System.Collections.Generic;

namespace Meetups.API.Domain.Entity
{
    public partial class CategoriaEvento
    {
        public CategoriaEvento()
        {
            Eventos = new HashSet<Evento>();
        }

        public int IdCategoriaEvento { get; set; }
        public string NomeCategoria { get; set; } = null!;

        public virtual ICollection<Evento> Eventos { get; set; }
    }
}
