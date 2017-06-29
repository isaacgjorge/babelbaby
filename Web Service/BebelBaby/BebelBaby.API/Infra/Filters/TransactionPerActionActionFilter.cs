using Autofac.Integration.WebApi;
using EasyCare.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace EasyCare.API.Infra.Filters
{
    public class TransactionPerActionActionFilter : IAutofacActionFilter
    {
        private readonly IUnitWork _UnitWork;

        public TransactionPerActionActionFilter(IUnitWork unitWork)
        {
            _UnitWork = unitWork;
        }


        //public void OnActionExecuting(HttpActionContext actionContext)
        //{
        //    session.BeginTransaction();
        //}

        

        public Task OnActionExecutedAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            if (actionExecutedContext.Response != null && actionExecutedContext.Response.IsSuccessStatusCode)
            {
                 _UnitWork.Save();
            }
            else
            {
                 _UnitWork.Dispose();
            }
            return Task.FromResult(0);
        }

        public Task OnActionExecutingAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            return Task.FromResult(0);
        }
    }
}