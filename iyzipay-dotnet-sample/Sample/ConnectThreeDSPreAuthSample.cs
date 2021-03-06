﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Iyzipay.Request;
using Iyzipay.Model;

namespace IyzipaySample.Sample
{
    [TestClass]
    public class ConnectThreeDSPreAuthSample : Sample
    {
        [TestMethod]
        public void Should_Initialize_Threeds_With_Card()
        {
            CreateConnectThreeDSInitializeRequest request = new CreateConnectThreeDSInitializeRequest();
            request.Locale = Locale.TR.GetName();
            request.ConversationId = "123456789";
            request.BuyerEmail = "email@email.com";
            request.BuyerId = "B2323";
            request.BuyerIp = "85.34.78.112";
            request.ConnectorName = "connector name";
            request.Installment = 1;
            request.PaidPrice = "1.0";
            request.Price = "1.0";
            request.CallbackUrl = "https://www.merchant.com/callbackUrl";
            request.Currency = Currency.TRY.ToString();

            PaymentCard paymentCard = new PaymentCard();
            paymentCard.CardHolderName = "John Doe";
            paymentCard.CardNumber = "5528790000000008";
            paymentCard.ExpireMonth = "12";
            paymentCard.ExpireYear = "2030";
            paymentCard.Cvc = "123";
            paymentCard.RegisterCard = 0;
            request.PaymentCard = paymentCard;

            ConnectThreeDSInitializePreAuth connectThreeDSInitializePreAuth = ConnectThreeDSInitializePreAuth.Create(request, options);

            PrintResponse<ConnectThreeDSInitializePreAuth>(connectThreeDSInitializePreAuth);

            Assert.IsNotNull(connectThreeDSInitializePreAuth.SystemTime);
            Assert.AreEqual(Status.SUCCESS.ToString(), connectThreeDSInitializePreAuth.Status);
            Assert.AreEqual(Locale.TR.GetName(), connectThreeDSInitializePreAuth.Locale);
            Assert.AreEqual("123456789", connectThreeDSInitializePreAuth.ConversationId);
        }

        [TestMethod]
        public void Should_Initialize_Threeds_With_Card_Token()
        {
            CreateConnectThreeDSInitializeRequest request = new CreateConnectThreeDSInitializeRequest();
            request.Locale = Locale.TR.GetName();
            request.ConversationId = "123456789";
            request.BuyerEmail = "email@email.com";
            request.BuyerId = "B2323";
            request.BuyerIp = "85.34.78.112";
            request.ConnectorName = "connector name";
            request.Installment = 1;
            request.PaidPrice = "1.0";
            request.Price = "1.0";
            request.CallbackUrl = "https://www.merchant.com/callbackUrl";
            request.Currency = Currency.TRY.ToString();

            PaymentCard paymentCard = new PaymentCard();
            paymentCard.CardToken = "card token";
            paymentCard.CardUserKey = "card user key";
            request.PaymentCard = paymentCard;

            ConnectThreeDSInitializePreAuth connectThreeDSInitializePreAuth = ConnectThreeDSInitializePreAuth.Create(request, options);

            PrintResponse<ConnectThreeDSInitializePreAuth>(connectThreeDSInitializePreAuth);

            Assert.IsNotNull(connectThreeDSInitializePreAuth.SystemTime);
            Assert.AreEqual(Status.SUCCESS.ToString(), connectThreeDSInitializePreAuth.Status);
            Assert.AreEqual(Locale.TR.GetName(), connectThreeDSInitializePreAuth.Locale);
            Assert.AreEqual("123456789", connectThreeDSInitializePreAuth.ConversationId);
        }

        [TestMethod]
        public void Should_Auth_Threeds()
        {
            CreateConnectThreeDSAuthRequest request = new CreateConnectThreeDSAuthRequest();
            request.Locale = Locale.TR.GetName();
            request.ConversationId = "123456789";
            request.PaymentId = "12345";

            ConnectThreeDSAuth connectThreeDSAuth = ConnectThreeDSAuth.Create(request, options);

            PrintResponse<ConnectThreeDSAuth>(connectThreeDSAuth);

            Assert.IsNotNull(connectThreeDSAuth.SystemTime);
            Assert.AreEqual(Status.SUCCESS.ToString(), connectThreeDSAuth.Status);
            Assert.AreEqual(Locale.TR.GetName(), connectThreeDSAuth.Locale);
            Assert.AreEqual("123456789", connectThreeDSAuth.ConversationId);
        }
    }
}
