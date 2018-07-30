# UsingQR

Library for extracting QR images for BBAN, IBAN, Bankgirot and PlusGirot payments.

## Examples

```
PaymentInvoiceQR qr = new PaymentInvoiceQR("Test company AB", "555555-5555") {
    InvoiceReference = "52456",
    InvoiceDate = _invoiceDate.ToString("YYYYMMDD"),
    DueDate = _invoiceDate.AddDays(_invoiceDaysToPay).ToString("YYYYMMDD"),
    DueAmount = 200,
    PaymentType = PaymentType.BG,
    Account = "433-8778"
};

Bitmap bmp = qr.GetQR(100);
```

## License

This project is licensed under the [MIT license](LICENSE).

### Contribution

Unless you explicitly state otherwise, any contribution intentionally submitted
for inclusion in Tokio by you, shall be licensed as MIT, without any additional
terms or conditions.