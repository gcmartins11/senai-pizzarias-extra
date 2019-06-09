using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Senai_Pizzarias_extra_WebApi.Domains;
using Senai_Pizzarias_extra_WebApi.Interfaces;
using Senai_Pizzarias_extra_WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Pizzarias_extra_WebApi.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class PizzariasController : ControllerBase
    {
        private IPizzariasRepository PizzariasRepository { get; set; }

        public PizzariasController()
        {
            PizzariasRepository = new PizzariasRepository();
        }

        [Authorize(Roles = "administrador, usuario")]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(PizzariasRepository.Listar());
            }
            catch (System.Exception ex)
            {
                throw (ex);
            }
        }

        [Authorize(Roles = "administrador")]
        [HttpPost]
        public IActionResult Post(Pizzarias pizzaria)
        {
            try
            {
                PizzariasRepository.Cadastrar(pizzaria);
                return Ok();
            }
            catch (System.Exception ex)
            {
                throw (ex);
            }
        }

        [Authorize(Roles = "administrador, usuario")]
        [HttpGet("{nome}")]
        public IActionResult ListarPorNome(string nome)
        {
            try
            {
                return Ok(PizzariasRepository.ListarPorNome(nome));
            }
            catch (System.Exception ex)
            {
                throw(ex);
            }
        }
    }
}
