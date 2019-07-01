﻿using CobMvc.Core;
using CobMvc.Core.Client;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CobMvc.Demo.Contract
{
    [CobService("CobMvcDemo", Path ="/api/test/", Transport = CobRequestTransports.WebSocket, Timeout = 1)]
    [CobStrategy(RetryTimes = 3, ExceptionTypes = new[] { typeof(TimeoutException) })]
    public interface IDemo
    {
        [CobService(Path = "/api/GetNames")]
        string[] GetNames();

        [CobService(Transport = CobRequestTransports.Http)]
        string[] GetOtherNames();

        Task<UserInfo> GetUserInfo(string name);

        //
        Task SaveUserInfo(UserInfo user);

        void Mark(int ms);

        [CobStrategy(FallbackValue = "new string[1]{\"default\"}")]
        string[] Fallback();
  }

    public class UserInfo
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Addr { get; set; }
    }
}
