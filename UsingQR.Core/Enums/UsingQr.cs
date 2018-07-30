namespace UsingQR.Core.Enums
{
    public enum Version
    {
        One = 1,
        Two
    }

    public enum InvoiceType
    {
        Payment = 1,
        Credit,
        Cash
    }

    public enum PaymentType
    {
        IBAN = 1,
        BBAN,
        BG,
        PG
    }
}