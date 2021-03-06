﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BebelBaby.Util
{
    public interface IUtilRepository
    {
        bool CPFIsValid(string cpf);
        T Execute<T>(string url, object data = null, string method = "POST", string pass = "", string token = "", string contentType = "application/json");
    }
}
