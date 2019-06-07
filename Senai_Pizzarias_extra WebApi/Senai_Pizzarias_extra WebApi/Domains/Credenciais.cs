using System;
using System.Collections.Generic;

namespace Senai_Pizzarias_extra_WebApi.Domains
{
    public partial class Credenciais
    {
        public Credenciais()
        {
            Usuarios = new HashSet<Usuarios>();
        }

        public int Id { get; set; }
        public string Credencial { get; set; }

        public virtual ICollection<Usuarios> Usuarios { get; set; }
    }
}
