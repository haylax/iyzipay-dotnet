﻿using Iyzipay.Request;

namespace Iyzipay.Model
{
    public class ThreeDSAuth : Payment
    {
        public static ThreeDSAuth Create(CreateThreeDSAuthRequest request, Options options)
        {
            return RestHttpClient.Create().Post<ThreeDSAuth>(options.BaseUrl + "/payment/iyzipos/auth3ds/ecom", GetHttpHeaders(request, options), request);
        }

        public static ThreeDSAuth Retrieve(RetrievePaymentRequest request, Options options)
        {
            return RestHttpClient.Create().Post<ThreeDSAuth>(options.BaseUrl + "/payment/detail/", GetHttpHeaders(request, options), request);
        }
    }
}
