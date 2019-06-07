using Senai_Pizzarias_extra_WebApi.Domains;
using Senai_Pizzarias_extra_WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Pizzarias_extra_WebApi.Repositories
{
    public class PizzariasRepository : IPizzariasRepository
    {
        public List<Pizzarias> Listar()
        {
            using (PizzariasFsContext ctx = new PizzariasFsContext())
            {
                return ctx.Pizzarias.ToList();
            }
        }
    }
}
