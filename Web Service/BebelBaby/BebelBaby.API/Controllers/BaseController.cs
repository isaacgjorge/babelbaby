using EasyCare.Core;
using EasyCare.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using PagedList;

namespace EasyCare.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*", SupportsCredentials = true)]
    [Route("baseAPI")]
    public class BaseController : ApiController
    {
        public const string urlPaginacaoComplemento = "/{paginar?}/{pagina?}/{itensPorPagina?}";
        public BaseController()
        {

        }

        public HttpResponseMessage MontarResponseMessageOKParaListas<T>(IEnumerable<T> listaAPaginar, 
                bool paginar = false, int pagina = 1, int itensPorPagina = 10)
        {

            HttpResponseMessage response = null;
            itensPorPagina = paginar ? itensPorPagina : listaAPaginar.Count();
            var lista = listaAPaginar.ToPagedList(pagina, itensPorPagina);

            response = Request.CreateResponse(HttpStatusCode.OK, lista);
            response.Headers.Add("Access-Control-Expose-Headers", "X-Pagina, X-ItensPorPagina, X-TotalDeRegistros");
            response.Headers.Add("X-Pagina", pagina.ToString(CultureInfo.InvariantCulture));
            response.Headers.Add("X-ItensPorPagina", itensPorPagina.ToString(CultureInfo.InvariantCulture));
            response.Headers.Add("X-TotalDeRegistros", lista.TotalItemCount.ToString(CultureInfo.InvariantCulture));
            
            return response;
        }
      

    }
    
}
