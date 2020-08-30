using AutoMapper;
using ControlePlantas.Domain.Contracts;
using ControlePlantas.Domain.Core;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ControlePlantas.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class UsuarioController : BaseController
    {
        private readonly IUsuarioRepository _usuRepo;

        public UsuarioController(IMediator mediator, IMapper map, IUsuarioRepository usuRepo) : base(mediator, map)
        {
            _usuRepo = usuRepo;
        }

        [HttpPost]
        [Route("salvar")]
        public IActionResult Salvar([FromBody] UsuarioDTO usuario) => null;

        [HttpPost]
        [Route("autenticar")]
        [AllowAnonymous]
        public async Task<IActionResult> Autenticar([FromBody] UsuarioDTO usuarioDto)
        {
            var user = await _usuRepo.LocalizarUm(x => x.Login == usuarioDto.Login && x.Senha == usuarioDto.Senha);

            if (user.IsNull()) return Response(success: false, error: "Usuário ou Senha não encontrados!");

            var token = TokenService.GenerateToken(user);

            var usuarioResponse = _map.Map<UsuarioDTO>(user);
            usuarioResponse.Senha = string.Empty;

            return Response(
                   success: true,
                   data: new
                   {
                       usuario = usuarioResponse,
                       token,
                       expiracao = 7200000
                   },
                   mensagem: "Login realizado com Sucesso!");
        }

        [HttpPost]
        [Route("refreshToken")]
        public async Task<IActionResult> RefreshToken()
        {
            var user = await _usuRepo.LocalizarUm(x => x.Id == Guid.Parse(HttpContext.User.Identity.Name));

            if (user.IsNull()) return Response(success: false, error: "Token Inválido!");

            var usuarioResponse = _map.Map<UsuarioDTO>(user);
            usuarioResponse.Senha = string.Empty;

            var token = TokenService.GenerateToken(user);

            return Response(
                   success: true,
                   data: new
                   {
                       usuario = usuarioResponse,
                       token,
                       expiracao = 7200000
                   },
                   mensagem: "Token atualizado realizado com Sucesso!");
        }

    }
}
