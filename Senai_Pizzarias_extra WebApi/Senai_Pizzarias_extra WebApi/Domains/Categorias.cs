using System;
using System.Collections.Generic;

namespace Senai_Pizzarias_extra_WebApi.Domains
{
    public partial class Categorias
    {
        public Categorias()
        {
            Pizzarias = new HashSet<Pizzarias>();
        }

        public int Id { get; set; }
        public string Categoria { get; set; }

        public virtual ICollection<Pizzarias> Pizzarias { get; set; }
    }
}
