using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using QRCoder;
using System;
using System.Drawing;
using System.Globalization;

namespace UsingQR.Core.Models
{
    public abstract class BaseQR
    {
        public BaseQR(Enums.Version version, Enums.InvoiceType type, string name, string companyId)
        {
            Version = version;
            Type = type;
            Name = name;
            CompanyId = companyId;
        }

        public string ToJson()
        {
            var settings = new JsonSerializerSettings {
                NullValueHandling = NullValueHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.Ignore,
                DateFormatString = "yyyyMMdd"
            };
            settings.Converters.Add(new DecimalJsonConverter());
            return JsonConvert.SerializeObject(this, Formatting.None, settings);
        }

        public Bitmap GetQR(int pixelsPerModule = 20, QRCodeGenerator.ECCLevel eCCLevel = QRCodeGenerator.ECCLevel.Q)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            var data = ToJson();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(data, eCCLevel);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(pixelsPerModule);
            return qrCodeImage;
        }

        private class DecimalJsonConverter : JsonConverter
        {
            public override bool CanConvert(Type objectType)
            {
                return objectType == typeof(decimal);
            }

            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                throw new NotImplementedException();
            }

            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                writer.WriteRawValue(((decimal)value).ToString("0.##", CultureInfo.InvariantCulture));
            }
        }

        [JsonProperty("uqr")]
        public Enums.Version Version { get; set; }

        [JsonProperty("tp")]
        public Enums.InvoiceType Type { get; set; }

        [JsonProperty("nme")]
        public string Name { get; set; }

        [JsonProperty("cid")]
        public string CompanyId { get; set; }

        [JsonProperty("cc")]
        public string CountryCode { get; set; }

        [JsonProperty("iref")]
        public string InvoiceReference { get; set; }

        [JsonProperty("cr")]
        public string CreditInvoiceReference { get; set; }

        [JsonProperty("idt")]
        public DateTime InvoiceDate { get; set; }

        [JsonProperty("ddt")]
        public DateTime DueDate { get; set; }

        [JsonProperty("due")]
        public decimal DueAmount { get; set; }

        /// <summary>
        /// 1. The total §T amount on the invoice.
        /// 2. The amount can be negative if tp = 2 or 3. In that case, the hyphen shall be directly before the amount.
        /// 3. If tp = 1, the due amount must always be positive.
        /// </summary>
        [JsonProperty("vat")]
        public decimal VAT { get; set; }

        /// <summary>
        /// 1. For countries that define VAT percentages, this field can be used to define the high VAT amount on the invoice.
        /// 2. The amount can be negative if tp = 2 or 3. The hyphen shall be directly before the amount.
        /// 3. If this field is used, the vat field has to be omitted
        /// </summary>
        [JsonProperty("vh")]
        public decimal HighVATAmount { get; set; }

        /// <summary>
        /// 1. For countries that define VAT percentages, this field can be used to define the high VAT amount on the invoice.
        /// 2. The amount can be negative if tp = 2 or 3. The hyphen shall be directly before the amount.
        /// 3. If this field is used, the vat field has to be omitted
        /// </summary>
        [JsonProperty("vm")]
        public decimal MediumVATAmount { get; set; }

        [JsonProperty("cur")]
        public string Currency { get; set; }

        /// <summary>
        /// 1. For countries that define different VAT percentages, this field can be used to define the low VAT amount on the invoice.
        /// 2. The amount can be negative if tp = 2 or 3. The hyphen shall be directly before the amount.
        /// 3. If this field is used, the vat field has to be omitted.
        /// </summary>
        [JsonProperty("vl")]
        public decimal LowVATAmount { get; set; }

        [JsonProperty("pt")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.PaymentType PaymentType { get; set; }

        /// <summary>
        /// 1. Contains the deposit account on the invoice sender in the format specified in pt. Page 11
        /// 2. Formats include BG(Sweden), PG(Sweden), IBAN(International), BBAN (International)
        /// 3. The type of the account is defined in the field pt.
        /// </summary>
        [JsonProperty("acc")]
        public string Account { get; set; }

        [JsonProperty("bc")]
        public string BankCode { get; set; }

        [JsonProperty("adr")]
        public string Address { get; set; }
    }
}