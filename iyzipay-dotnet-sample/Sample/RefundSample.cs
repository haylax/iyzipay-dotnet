﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Iyzipay.Request;
using Iyzipay.Model;

namespace IyzipaySample.Sample
{
    [TestClass]
    public class RefundSample : Sample
    {
        [TestMethod]
        public void Should_Refund()
        {
            CreateRefundRequest request = new CreateRefundRequest();
            request.ConversationId = "123456789";
            request.Locale = Locale.TR.GetName();
            request.PaymentTransactionId = "1";
            request.Price = "0.1";
            request.Ip = "85.34.78.112";
            request.Currency = Currency.TRY.ToString();

            Refund refund = Refund.Create(request, options);

            PrintResponse<Refund>(refund);

            Assert.IsNotNull(refund.SystemTime);
            Assert.AreEqual(Status.SUCCESS.ToString(), refund.Status);
            Assert.AreEqual(Locale.TR.GetName(), refund.Locale);
            Assert.AreEqual("123456789", refund.ConversationId);
        }

        [TestMethod]
        public void Should_Refund_Charged_From_Merchant()
        {
            CreateRefundRequest request = new CreateRefundRequest();
            request.ConversationId = "123456789";
            request.Locale = Locale.TR.GetName();
            request.PaymentTransactionId = "1";
            request.Price = "0.1";
            request.Ip = "85.34.78.112";
            request.Currency = Currency.TRY.ToString();

            RefundChargedFromMerchant refundChargedFromMerchant = RefundChargedFromMerchant.Create(request, options);

            PrintResponse<RefundChargedFromMerchant>(refundChargedFromMerchant);

            Assert.IsNotNull(refundChargedFromMerchant.SystemTime);
            Assert.AreEqual(Status.SUCCESS.ToString(), refundChargedFromMerchant.Status);
            Assert.AreEqual(Locale.TR.GetName(), refundChargedFromMerchant.Locale);
            Assert.AreEqual("123456789", refundChargedFromMerchant.ConversationId);
        }
    }
}
