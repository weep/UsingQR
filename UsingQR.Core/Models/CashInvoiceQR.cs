using UsingQR.Core.Enums;

namespace UsingQR.Core.Models
{
    public class CashInvoiceQR : BaseQR
    {
        public CashInvoiceQR(Version version, string name, string companyId) : base(version, Enums.InvoiceType.Cash, name, companyId)
        {
        }
    }
}