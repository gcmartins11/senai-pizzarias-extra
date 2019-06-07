using System;
using System.Collections.Generic;

namespace Senai_Pizzarias_extra_WebApi.Domains
{
    public partial class Usuarios
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int? IdCredencial { get; set; }

        public virtual Credenciais IdCredencialNavigation { get; set; }
    }
}
