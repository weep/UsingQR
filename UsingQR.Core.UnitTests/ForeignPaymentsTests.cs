using UsingQR.Core.Models;
using Xunit;

namespace UsingQR.Core.UnitTests
{
    public class ForeignPaymentsTests
    {
        [Fact]
        public void First()
        {
            var expected = "{\"uqr\":1,\"tp\":1,\"nme\":\"Test company AB\",\"cid\":\"555555-5555\",\"cc\":\"SE\",\"iref\":\"934000000000159\",\"idt\":\"20120215\",\"ddt\":\"20120215\",\"due\":10.75,\"cur\":\"DKK\",\"pt\":\"IBAN\",\"acc\":\"DK4830004073013895\",\"bc\":\"DABADKKK\",\"adr\":\"1092 Köpenhamn\"}";

            var a = new PaymentInvoiceQR("Test company AB", "555555-5555") {
                InvoiceReference = "934000000000159",
                InvoiceDate = "20120215",
                DueDate = "20120215",
                CountryCode = "SE",
                DueAmount = 10.75m,
                Currency = "DKK",
                PaymentType = Enums.PaymentType.IBAN,
                Account = "DK4830004073013895",
                BankCode = "DABADKKK",
                Address = "1092 Köpenhamn"
            };

            var actual = a.ToJson();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Second()
        {
            var expected = "{\"uqr\":1,\"tp\":1,\"nme\":\"Test Company\",\"cid\":\"98-0202855\",\"cc\":\"US\",\"iref\":\"934000000000159\",\"ddt\":\"20120215\",\"due\":1.75,\"cur\":\"USD\",\"pt\":\"BBAN\",\"acc\":\"6000658159712\",\"bc\":\"ACIXUS33XXX\",\"adr\":\"12405,Acra\"}";

            var a = new PaymentInvoiceQR("Test Company", "98-0202855") {
                InvoiceReference = "934000000000159",
                DueDate = "20120215",
                CountryCode = "US",
                DueAmount = 1.75m,
                Currency = "USD",
                PaymentType = Enums.PaymentType.BBAN,
                Account = "6000658159712",
                BankCode = "ACIXUS33XXX",
                Address = "12405,Acra"
            };

            var actual = a.ToJson();
            Assert.Equal(expected, actual);
        }
    }
}