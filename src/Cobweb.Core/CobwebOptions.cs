﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Cobweb.Core
{
    public class CobwebOptions
    {
        public string ServiceName { get; set; }

        /// <summary>
        /// 服务地址，
        /// </summary>
        public string ServiceAddress { get; set; }

        //public int Port { get; set; }

        public string HealthCheck { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int MaxJump { get; set; }
    }
}
