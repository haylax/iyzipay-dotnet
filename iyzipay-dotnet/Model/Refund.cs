﻿using Iyzipay.Request;
using System;

namespace Iyzipay.Model
{
    public class Refund : IyzipayResource
    {
        public String PaymentId { get; set; }
        public String PaymentTransactionId { get; set; }
        public String Price { get; set; }
        public String Currency { get; set; }

        public static Refund Create(CreateRefundRequest request, Options options)
        {
            return RestHttpClient.Create().Post<Refund>(options.BaseUrl + "/payment/iyzipos/refund", GetHttpHeaders(request, options), request);
        }
    }
}
