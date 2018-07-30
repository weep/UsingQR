using UsingQR.Core.Enums;

namespace UsingQR.Core.Models
{
    public class CreditInvoiceQR : BaseQR
    {
        public CreditInvoiceQR(Version version, string name, string companyId) : base(version, InvoiceType.Credit, name, companyId)
        {
        }
    }
}