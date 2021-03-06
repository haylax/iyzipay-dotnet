﻿using Iyzipay.Request;
using System;
using System.Threading.Tasks;

namespace Iyzipay.Model
{
    public class BKMInitialize : IyzipayResource
    {
        public String HtmlContent { get; set; }
        public String Token { get; set; }
        
        public static BKMInitialize Create(CreateBKMInitializeRequest request, Options options)
        {
            BKMInitialize response = RestHttpClient.Create().Post<BKMInitialize>(options.BaseUrl + "/payment/iyzipos/bkm/initialize/ecom", GetHttpHeaders(request, options), request);

            if (response != null)
            {
                response.HtmlContent = DigestHelper.decodeString(response.HtmlContent);
            }
            return response;
        }
    }
}
