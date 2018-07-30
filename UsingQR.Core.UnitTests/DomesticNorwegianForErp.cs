using UsingQR.Core.Models;
using Xunit;

namespace UsingQR.Core.UnitTests
{
    public class DomesticNorwegianForErp
    {
        [Fact]
        public void First()
        {
            var expected = "{\"uqr\":1,\"tp\":1,\"nme\":\"Test Company AS\",\"cid\":\"123456789MVA\",\"iref\":\"00001\",\"idt\":\"20130424\",\"ddt\":\"20130524\",\"due\":240,\"vh\":25,\"vm\":15,\"cur\":\"NOK\",\"pt\":\"BBAN\",\"acc\":\"86011117947\",\"bc\":\"DNBANOKK332\",\"adr\":\"0687 Oslo\"}";

            var a = new PaymentInvoiceQR("Test Company AS", "123456789MVA") {
                InvoiceReference = "00001",
                InvoiceDate = "20130424",
                DueDate = "20130524",
                DueAmount = 240,
                HighVATAmount = 25,
                MediumVATAmount = 15,
                Currency = "NOK",
                PaymentType = Enums.PaymentType.BBAN,
                Account = "86011117947",
                BankCode = "DNBANOKK332",
                Address = "0687 Oslo"
            };

            var actual = a.ToJson();
            Assert.Equal(expected, actual);
        }
    }
}