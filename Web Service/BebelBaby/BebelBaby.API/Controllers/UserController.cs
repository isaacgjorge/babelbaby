using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BebelBaby.Core;
using BebelBaby.Repository;
using BebelBaby.Util;
using JWT;

namespace BebelBaby.API.Controllers
{

    [RoutePrefix("api/UserController")]
    public class UserController : BaseController
    {
        private readonly IUtilRepository _UtilService;
        private readonly IUsuarioRepository _UsuarioService;
        private readonly IPerfilUsuarioRepository _PerfilUsuarioService;
        
        public UserController(IUtilRepository utilService, 
                                IUsuarioRepository usuarioService,
                                IPerfilUsuarioRepository perfilUsuarioService)
        {
            _UtilService = utilService;
            _UsuarioService = usuarioService;
            _PerfilUsuarioService = perfilUsuarioService;
        }



        [AllowAnonymous]
        [Route("signup/perfil/{idPerfil}")]
        [HttpPost]
        public HttpResponseMessage Register([FromBody] Usuario usuarioCadastro, int idPerfil)
        {
            HttpResponseMessage response;
            try
            {
                var usuario = _UsuarioService.CriarUsuario(usuarioCadastro);
                _PerfilUsuarioService.AddPerfilUsuario(usuario, usuario, idPerfil);
                response = Request.CreateResponse(HttpStatusCode.OK,  "Usuário cadastrado com sucesso" );
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, new { ex.Message });
            }

            return response;
        }

        [AllowAnonymous]
        [Route("signin")]
        [HttpPost]
        public HttpResponseMessage Login([FromBody] Usuario usuarioLogin)
        {
            HttpResponseMessage response = null;
            try
            {
                var usuario = _UsuarioService.GetByLoginSenha(usuarioLogin.Login, usuarioLogin.Senha);
                var token = CreateToken(usuario);

                response = Request.CreateResponse(new { usuario, token });
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, new { ex.Message });
            }

            return response;
        }

        private string CreateToken(Usuario user)
        {
            var unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc); ;
            var expiry = Math.Round((DateTime.UtcNow.AddDays(1) - unixEpoch).TotalSeconds);
            var issuedAt = Math.Round((DateTime.UtcNow - unixEpoch).TotalSeconds);
            var notBefore = Math.Round((DateTime.UtcNow.AddMonths(6) - unixEpoch).TotalSeconds);

            var payload = new Dictionary<string, object>
            {
                {"userId", user.UsuarioId},
                {"name", user.Nome},
                {"roles", user.PerfisUsuario.FirstOrDefault().Perfil.Descricao},
                {"nbf", notBefore},
                {"iat", issuedAt},
                {"exp", expiry}
            };

            string apikey = Constants.jwtSecretKey;

            var token = JsonWebToken.Encode(payload, apikey, JwtHashAlgorithm.HS256);

            return token;
        }



    }
}