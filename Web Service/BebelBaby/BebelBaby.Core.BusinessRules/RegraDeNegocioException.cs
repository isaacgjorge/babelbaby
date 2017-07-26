using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BebelBaby.Core.BusinessRules
{
    public class RegraDeNegocioException : Exception
    {
        public RegraDeNegocioException(string message) : base(message)
        {
            
        }
        
    }
}
