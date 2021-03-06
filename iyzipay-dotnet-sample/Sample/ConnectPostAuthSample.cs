﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Iyzipay.Request;
using Iyzipay.Model;

namespace IyzipaySample.Sample
{
    [TestClass]
    public class ConnectPostAuthSample : Sample
    {
        [TestMethod]
        public void Should_Post_Auth()
        {
            CreatePaymentPostAuthRequest request = new CreatePaymentPostAuthRequest();
            request.ConversationId = "123456789";
            request.Locale = Locale.TR.GetName();
            request.PaymentId = "1";
            request.PaidPrice = "0.3";
            request.Ip = "85.34.78.112";
            request.Currency = Currency.TRY.ToString();

            ConnectPaymentPostAuth paymentPostAuth = ConnectPaymentPostAuth.Create(request, options);

            PrintResponse<ConnectPaymentPostAuth>(paymentPostAuth);

            Assert.IsNotNull(paymentPostAuth.SystemTime);
            Assert.AreEqual(Status.SUCCESS.ToString(), paymentPostAuth.Status);
            Assert.AreEqual(Locale.TR.GetName(), paymentPostAuth.Locale);
            Assert.AreEqual("123456789", paymentPostAuth.ConversationId);
            Assert.AreEqual("1", paymentPostAuth.PaymentId);
            Assert.AreEqual("0.3", paymentPostAuth.PaidPrice);
        }
    }
}
