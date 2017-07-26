using BebelBaby.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BebelBaby.Service
{
    public class BaseService
    {
        public readonly IUnitWork _UnitWork;
        public BaseService(IUnitWork unitWork)
        {
            _UnitWork = unitWork;
        }
        

    }
}
