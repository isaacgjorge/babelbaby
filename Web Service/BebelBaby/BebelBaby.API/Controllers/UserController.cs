using System.Web.Http;
using BebelBaby.Util;

namespace BebelBaby.API.Controllers
{

    [RoutePrefix("user")]
    public class UserController
    {
        private readonly IUtilRepository _UtilService;


        public UserController(IUtilRepository utilService)
        {
            _UtilService = utilService;
        }



        //[AllowAnonymous]
        //[Route("signup/perfil/{idPerfil}")]
        //[HttpPost]
        //public HttpResponseMessage Register([FromBody] Usuario usuarioCadastro, int idPerfil)
        //{
        //    HttpResponseMessage response;
        //    try
        //    {
        //        _ExecutorDeRegras.Executar(typeof(RegraUsuarioNaoPodeExistir), usuarioCadastro);
        //        //_ExecutorDeRegras.Executar(typeof(RegraUsuarioCPFTemQueSerValido), usuario);                
        //        var usuario = _UsuarioService.CriarUsuario(usuarioCadastro);
        //        _PerfilUsuarioService.AddPerfilUsuario(usuario, usuario, idPerfil);
        //        usuario = _UsuarioService.GetByEmail(usuario.Email);
        //        var token = CreateToken(usuario);
        //        response = Request.CreateResponse(HttpStatusCode.OK, new { usuario, token });
        //    }
        //    catch (Exception ex)
        //    {
        //        response = Request.CreateResponse(HttpStatusCode.BadRequest, new { ex.Message });
        //    }

        //    return response;
        //}

        //[AllowAnonymous]
        //[Route("signin")]
        //[HttpPost]
        //public HttpResponseMessage Login([FromBody] Usuario usuarioLogin)
        //{
        //    HttpResponseMessage response = null;
        //    try
        //    {
        //        _ExecutorDeRegras.Executar(typeof(RegraUsuarioTemQueExistir), new Usuario { Email = usuarioLogin.Email });
        //        var usuario = _UsuarioService.GetByEmail(usuarioLogin.Email);
        //        _ExecutorDeRegras.Executar(typeof(RegraUsuarioSenhaTemQueSerValida), usuario, usuarioLogin.Senha);
        //        var token = CreateToken(usuario);

        //        response = Request.CreateResponse(new { usuario, token });
        //    }
        //    catch (Exception ex)
        //    {
        //        response = Request.CreateResponse(HttpStatusCode.BadRequest, new { ex.Message });
        //    }

        //    return response;
        //}

        //private string CreateToken(Usuario user)
        //{
        //    var unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        //    //var expiry = Math.Round((DateTime.UtcNow.AddHours(1) - unixEpoch).TotalSeconds);
        //    var expiry = Math.Round((DateTime.UtcNow.AddDays(1) - unixEpoch).TotalSeconds);
        //    var issuedAt = Math.Round((DateTime.UtcNow - unixEpoch).TotalSeconds);
        //    var notBefore = Math.Round((DateTime.UtcNow.AddMonths(6) - unixEpoch).TotalSeconds);

        //    var payload = new Dictionary<string, object>
        //    {
        //        {"userId", user.IdUsuario},
        //        {"name", user.Nome},
        //        {"email", user.Email},
        //        {"roles", user.PerfisUsuario.FirstOrDefault().Perfil.Descricao},
        //        {"nbf", notBefore},
        //        {"iat", issuedAt},
        //        {"exp", expiry}
        //    };

        //    string apikey = Constants.jwtSecretKey;

        //    var token = JsonWebToken.Encode(payload, apikey, JwtHashAlgorithm.HS256);

        //    return token;
        //}

    

    }
}