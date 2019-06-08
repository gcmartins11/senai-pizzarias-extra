using Senai_Pizzarias_extra_WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Pizzarias_extra_WebApi.Interfaces
{
    interface IUsuarioRepository
    {
        Usuarios FazerLogin(string email, string senha);
    }
}
