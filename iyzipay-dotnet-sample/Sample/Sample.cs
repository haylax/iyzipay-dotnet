﻿using Iyzipay;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Diagnostics;

namespace IyzipaySample.Sample
{
    [TestClass]
    public class Sample
    {
        protected Options options;

        [TestInitialize()]
        public void Initialize()
        {
            options = new Options();
            options.ApiKey = "apiKey";
            options.SecretKey = "secretKey";
            options.BaseUrl = "baseUrl";
        }

        protected void PrintResponse<T>(T resource)
        {
            Trace.Listeners.Add(new ConsoleTraceListener());
            Trace.WriteLine(JsonConvert.SerializeObject(resource, new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            }));
        }
    }
}
