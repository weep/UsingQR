using UsingQR.Core.Models;
using Xunit;

namespace UsingQR.Core.UnitTests
{
    public class DomesticSwedishTests
    {
        [Fact]
        public void ShouldWorkWithExample1()
        {
            var expected = "{\"uqr\":1,\"tp\":1,\"nme\":\"Test company AB\",\"cid\":\"555555-5555\",\"iref\":\"52456\",\"ddt\":\"20130408\",\"due\":5,\"pt\":\"BG\",\"acc\":\"433-8778\"}";

            var a = new PaymentInvoiceQR("Test company AB", "555555-5555") {
                InvoiceReference = "52456",
                DueDate = "20130408",
                DueAmount = 5,
                PaymentType = Enums.PaymentType.BG,
                Account = "433-8778"
            };

            var actual = a.ToJson();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldWorkWithExample2()
        {
            var expected = "{\"uqr\":1,\"tp\":1,\"nme\":\"Test company AB\",\"cid\":\"555555-5555\",\"iref\":\"52456\",\"idt\":\"20130408\",\"ddt\":\"20130508\",\"due\":5,\"pt\":\"BBAN\",\"acc\":\"6000658159712\",\"bc\":\"HANDSESS\"}";

            var a = new PaymentInvoiceQR("Test company AB", "555555-5555") {
                InvoiceReference = "52456",
                InvoiceDate = "20130408",
                DueDate = "20130508",
                DueAmount = 5,
                PaymentType = Enums.PaymentType.BBAN,
                Account = "6000658159712",
                BankCode = "HANDSESS"
            };

            var actual = a.ToJson();
            Assert.Equal(expected, actual);
        }
    }
}