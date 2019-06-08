using Senai_Pizzarias_extra_WebApi.Domains;
using Senai_Pizzarias_extra_WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Senai_Pizzarias_extra_WebApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public Usuarios FazerLogin(string email, string senha)
        {
            using (PizzariasFsContext ctx = new PizzariasFsContext())
            {
                Usuarios usuarioBuscado = ctx.Usuarios.Where(u => u.Email == email && u.Senha == senha).Include(x => x.IdCredencialNavigation).FirstOrDefault();

                if ( usuarioBuscado != null )
                {
                    return usuarioBuscado;
                }

                return null;
            }
        }
    }
}
