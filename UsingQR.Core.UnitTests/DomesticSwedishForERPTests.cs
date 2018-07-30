using System;
using UsingQR.Core.Models;
using Xunit;

namespace UsingQR.Core.UnitTests
{
    public class DomesticSwedishForErpTests
    {
        [Fact]
        public void First()
        {
            var expected = "{\"uqr\":1,\"tp\":1,\"nme\":\"Test Company AB\",\"cid\":\"555555-5555\",\"iref\":\"0470-706000\",\"idt\":\"20130424\",\"ddt\":\"20130524\",\"due\":4500,\"vat\":900,\"cur\":\"SEK\",\"pt\":\"BG\",\"acc\":\"433-8778\"}";

            var a = new PaymentInvoiceQR("Test Company AB", "555555-5555") {
                InvoiceReference = "0470-706000",
                InvoiceDate = new DateTime(2013, 4, 24),
                DueDate = new DateTime(2013, 5, 24),
                DueAmount = 4500,
                VAT = 900,
                Currency = "SEK",
                PaymentType = Enums.PaymentType.BG,
                Account = "433-8778"
            };

            var actual = a.ToJson();
            Assert.Equal(expected, actual);
        }
    }
}