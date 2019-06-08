using System;
using System.Collections.Generic;

namespace Senai_Pizzarias_extra_WebApi.Domains
{
    public partial class Pizzarias
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public int Numero { get; set; }
        public string Telefone { get; set; }
        public bool Vegana { get; set; }
        public int? IdCategoria { get; set; }

        public virtual Categorias IdCategoriaNavigation { get; set; }
    }
}
