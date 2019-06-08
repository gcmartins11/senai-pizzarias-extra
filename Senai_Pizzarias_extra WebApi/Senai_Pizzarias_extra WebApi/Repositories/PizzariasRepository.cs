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
        public void Cadastrar(Pizzarias pizzaria)
        {
            using (PizzariasFsContext ctx = new PizzariasFsContext())
            {
                ctx.Pizzarias.Add(pizzaria);
                ctx.SaveChanges();
            }
        }

        public List<Pizzarias> Listar()
        {
            using (PizzariasFsContext ctx = new PizzariasFsContext())
            {
                return ctx.Pizzarias.ToList();
            }
        }

        public Pizzarias ListarPorNome(string nome)
        {
            using (PizzariasFsContext ctx = new PizzariasFsContext())
            {
                return ctx.Pizzarias.Where(x => nome == x.Nome).FirstOrDefault();
            }
        }
    }
}
