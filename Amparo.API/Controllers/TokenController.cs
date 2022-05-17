using Amparo.API.Models;
using Amparo.Aplicacao.DTO;
using Amparo.Aplicacao.Models;
using Amparo.Aplicacao.Servicos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Amparo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly UsuariosServico servico;
        private readonly Ambiente ambiente;

        public TokenController(UsuariosServico servico, Ambiente ambiente)
        {
            this.servico = servico;
            this.ambiente = ambiente;
        }

        [HttpPost]
        public IActionResult Token([FromBody] Credencial credencial)
        {
            var usuario = servico.Autenticar(credencial);
            if (usuario != null)
                return Ok(GerarTokenJWT());

            return Unauthorized();
        }

        private JWT GerarTokenJWT()
        {
            var issuer = ambiente.JWT.Issuer;
            var audience = ambiente.JWT.Audience;
            var expiry = DateTime.Now.AddMinutes(120);
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ambiente.JWT.Key));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(issuer: issuer, audience: audience, expires: expiry, signingCredentials: credentials);
            var tokenHandler = new JwtSecurityTokenHandler();
            var stringToken = tokenHandler.WriteToken(token);
            return new JWT
            {
                expire = expiry,
                Token = stringToken
            };
        }
    }
}
