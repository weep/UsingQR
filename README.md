# UsingQR

Library for extracting QR images for BBAN, IBAN, Bankgirot and PlusGirot payments.

## Examples

```
PaymentInvoiceQR qr = new PaymentInvoiceQR("Test company AB", "555555-5555") {
    InvoiceReference = "52456",
    InvoiceDate = new DateTime(2018, 7, 30),
    DueDate = new DateTime(2018, 8, 29),
    DueAmount = 200,
    PaymentType = PaymentType.BG,
    Account = "433-8778"
};

Bitmap bmp = qr.GetQR(20);
```

## License

This project is licensed under the [MIT license](LICENSE).

### Contribution

Unless you explicitly state otherwise, any contribution intentionally submitted by you, shall be licensed as MIT, without any additional terms or conditions.
