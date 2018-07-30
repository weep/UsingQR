using UsingQR.Core.Enums;

namespace UsingQR.Core.Models
{
    public class PaymentInvoiceQR : BaseQR
    {
        public PaymentInvoiceQR(string name, string companyId, Version version = Version.One) : base(version, InvoiceType.Payment, name, companyId)
        {
        }
    }
}