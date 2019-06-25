﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CobMvc.Core.Client
{
    public interface ICobClient
    {
        T Invoke<T>(string name, Dictionary<string, object> parameters, object state);
    }

}