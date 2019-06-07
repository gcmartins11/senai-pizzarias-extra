using Microsoft.AspNetCore.Mvc;
using Senai_Pizzarias_extra_WebApi.Domains;
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
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                using (PizzariasFsContext ctx = new PizzariasFsContext())
                {
                    return Ok(ctx.Pizzarias.ToList());
                }
            }
            catch (System.Exception ex)
            {
                throw(ex);
            }
        }
    }
}
