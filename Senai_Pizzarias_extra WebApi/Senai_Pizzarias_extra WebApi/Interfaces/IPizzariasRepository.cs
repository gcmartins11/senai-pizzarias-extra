using Senai_Pizzarias_extra_WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Pizzarias_extra_WebApi.Interfaces
{
    interface IPizzariasRepository
    {
        List<Pizzarias> Listar();
        void Cadastrar(Pizzarias pizzaria);
        Pizzarias ListarPorNome(string nome);
    }
}
