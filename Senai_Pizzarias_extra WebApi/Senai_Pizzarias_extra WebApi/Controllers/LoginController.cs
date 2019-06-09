using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai_Pizzarias_extra_WebApi.Domains;
using Senai_Pizzarias_extra_WebApi.Interfaces;
using Senai_Pizzarias_extra_WebApi.Repositories;
using Senai_Pizzarias_extra_WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Senai_Pizzarias_extra_WebApi.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {

        private IUsuarioRepository UsuarioRepository { get; set; }

        public LoginController()
        {
            UsuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            try
            {
                Usuarios usuarioBuscado = UsuarioRepository.FazerLogin(login.Email, login.Senha);

                if (usuarioBuscado == null)
                {
                    return NotFound(new
                    {
                        mensagem = "Email ou senha inválido",
                        //usuarioBuscado
                    });
                }

                //Define os dados que serão fornecidos no token - PayLoad
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                    //new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.Id.ToString()),
                    //new Claim(ClaimTypes.Role, usuarioBuscado.IdCredencialNavigation.Credencial.ToString()),
                    new Claim("role", usuarioBuscado.IdCredencialNavigation.Credencial.ToString()),
                };

                // Chave de acesso do token SpMedGroup.WebApi
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("SpMedGroup.WebApi"));

                //Credenciais do Token - Header
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                //Gera o token
                var token = new JwtSecurityToken(
                    issuer: "Fs.Pizzarias",
                    audience: "Fs.Pizzarias",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds
                );

                //Retorna Ok com o Token
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }

}

