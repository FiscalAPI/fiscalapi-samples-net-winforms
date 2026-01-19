using Fiscalapi.Common;
using Fiscalapi.Models;
using Fiscalapi.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FiscalApi.Samples.NetFramework
{
    public partial class PaymentComplementInvoiceReferenceForm : Form
    {
        private FiscalapiSettings _settings;
        public PaymentComplementInvoiceReferenceForm(FiscalapiSettings settings)
        {
            InitializeComponent();
            _settings = settings;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            // Crear fiscalapi client
            var fiscalApi = FiscalApiClient.Create(_settings);

            // Emisor KARLA FUENTE NOLASCO
            var issuer = new InvoiceIssuer
            {
                Id = "0e82a655-5f0c-4e07-abab-8f322e4123ef"
            };

            // Receptor ESCUELA KEMPER URGATE
            var recipient = new InvoiceRecipient
            {
                Id = "bd199ed8-02ef-47c0-919c-9479dd8ecae7"
            };

            var complement = new Complement
            {
                Payment = new InvoicePayment
                {
                    PaymentDate = DateTime.Parse("2022-09-09T17:33:38"),
                    PaymentFormCode = "01",
                    CurrencyCode = "MXN",
                    ExchangeRate = 1m,
                    Amount = 6778.00m,
                    PaidInvoices = new List<PaidInvoice>()
                    {
                        new PaidInvoice
                        {
                            Uuid = "b7c8d2bf-cb4e-4f84-af89-c68b6731206a",
                            Series = "FA",
                            Number = "N0000216349",
                            CurrencyCode = "MXN",
                            PartialityNumber = 2,
                            PreviousBalance = 6777.41m,
                            PaymentAmount = 6777.41m,
                            RemainingBalance = 0.00m,
                            TaxObjectCode = "02",
                            Equivalence = 1m,
                            Subtotal = 5842.600000m,
                            PaidInvoiceTaxes = new List<PaidInvoiceTax>
                            {
                                new PaidInvoiceTax
                                {
                                    TaxCode = "002",
                                    TaxTypeCode = "Tasa",
                                    TaxRate = 0.160000m,
                                     TaxFlagCode = "T"
                                }
                            }
                        },
                        new PaidInvoice
                        {
                            Uuid = "94f4e541-bb38-4355-b779-02d337dc9720",
                            Series = "FA",
                            Number = "SI000032690",
                            CurrencyCode = "MXN",
                            PartialityNumber = 1,
                            PreviousBalance = 9610.81m,
                            PaymentAmount = 0.59m,
                            RemainingBalance = 9610.22m,
                            TaxObjectCode = "02",
                            Equivalence = 1m,
                            Subtotal = 0.510000m,
                            PaidInvoiceTaxes = new List<PaidInvoiceTax>
                            {
                                new PaidInvoiceTax
                                {
                                    TaxCode = "002",
                                    TaxTypeCode = "Tasa",
                                    TaxRate = 0.160000m,
                                     TaxFlagCode = "T"
                                }
                            }
                        }
                    }
                }
            };



            // Crear la factura 
            var invoice = new Invoice
            {
                VersionCode = "4.0",
                Series = "SDK-F",
                Date = DateTime.Now,
                CurrencyCode = "XXX",
                TypeCode = "P",
                ExpeditionZipCode = "75700",
                Issuer = issuer,
                Recipient = recipient,
                Complement = complement,
                ExportCode = "01",
                PaymentMethodCode = ""
            };


            // Timbrar la factura
            var apiResponse = await fiscalApi.Invoices.CreateAsync(invoice);


            if (apiResponse.Succeeded)
            {
                // Guardar el XML de la factura
                var xml = apiResponse.Data.Responses.FirstOrDefault()?.InvoiceBase64.DecodeFromBase64();
                File.WriteAllText($@"C:\facturas\{apiResponse.Data.Number}.xml", xml);

                MessageBox.Show($@"Factura {apiResponse.Data.Number} creada");
            }
            else
            {
                MessageBox.Show(apiResponse.Message);
                MessageBox.Show(apiResponse.Details);
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            // Crear fiscalapi client
            var fiscalApi = FiscalApiClient.Create(_settings);

            // Emisor KARLA FUENTE NOLASCO
            var issuer = new InvoiceIssuer
            {
                Id = "0e82a655-5f0c-4e07-abab-8f322e4123ef"
            };

            // Receptor ESCUELA KEMPER URGATE
            var recipient = new InvoiceRecipient
            {
                Id = "bd199ed8-02ef-47c0-919c-9479dd8ecae7"
            };

            var complement = new Complement
            {
                Payment = new InvoicePayment
                {
                    PaymentDate = DateTime.Parse("2022-09-09T17:33:38"),
                    PaymentFormCode = "01",
                    CurrencyCode = "MXN",
                    ExchangeRate = 1m,
                    Amount = 323,
                    PaidInvoices = new List<PaidInvoice>()
                    {
                        new PaidInvoice
                        {
                            Uuid = "b7c8d2bf-cb4e-4f84-af89-c68b6731206a",
                            Series = "FA",
                            Number = "N0000216349",
                            CurrencyCode = "MXN",
                            PartialityNumber = 2,
                            PreviousBalance = 200.00m,
                            PaymentAmount = 100.00m,
                            RemainingBalance = 100.00m,
                            TaxObjectCode = "02",
                            Equivalence = 1m,
                            Subtotal = 10.00m,
                            PaidInvoiceTaxes = new List<PaidInvoiceTax>
                            {
                                new PaidInvoiceTax
                                {
                                    TaxCode = "002",
                                    TaxTypeCode = "Tasa",
                                    TaxRate = 0.160000m,
                                     TaxFlagCode = "T"
                                }
                            }
                        },
                        new PaidInvoice
                        {
                            Uuid = "94f4e541-bb38-4355-b779-02d337dc9720",
                            Series = "FA",
                            Number = "SI000032690",
                            CurrencyCode = "MXN",
                            PartialityNumber = 1,
                            PreviousBalance = 100.00m,
                            PaymentAmount = 100.00m,
                            RemainingBalance = 0.00m,
                            TaxObjectCode = "02",
                            Equivalence = 1m,
                            Subtotal = 100.00m,
                            PaidInvoiceTaxes = new List<PaidInvoiceTax>
                            {
                                new PaidInvoiceTax
                                {
                                    TaxCode = "002",
                                    TaxTypeCode = "Tasa",
                                    TaxRate = 0.160000m,
                                     TaxFlagCode = "T"
                                }
                            }
                        }
                    }
                }
            };



            // Crear la factura 
            var invoice = new Invoice
            {
                VersionCode = "4.0",
                Series = "SDK-F",
                Date = DateTime.Now,
                CurrencyCode = "XXX",
                TypeCode = "P",
                ExpeditionZipCode = "75700",
                Issuer = issuer,
                Recipient = recipient,
                Complement = complement,
                ExportCode = "01",
                PaymentMethodCode = ""
            };


            // Timbrar la factura
            var apiResponse = await fiscalApi.Invoices.CreateAsync(invoice);


            if (apiResponse.Succeeded)
            {
                // Guardar el XML de la factura
                var xml = apiResponse.Data.Responses.FirstOrDefault()?.InvoiceBase64.DecodeFromBase64();
                File.WriteAllText($@"C:\facturas\{apiResponse.Data.Number}.xml", xml);

                MessageBox.Show($@"Factura {apiResponse.Data.Number} creada");
            }
            else
            {
                MessageBox.Show(apiResponse.Message);
                MessageBox.Show(apiResponse.Details);
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            // Crear fiscalapi client
            var fiscalApi = FiscalApiClient.Create(_settings);

            // Emisor KARLA FUENTE NOLASCO
            var issuer = new InvoiceIssuer
            {
                Id = "0e82a655-5f0c-4e07-abab-8f322e4123ef"
            };

            // Receptor ESCUELA KEMPER URGATE
            var recipient = new InvoiceRecipient
            {
                Id = "bd199ed8-02ef-47c0-919c-9479dd8ecae7"
            };

            var complement = new Complement
            {
                Payment = new InvoicePayment
                {
                    PaymentDate = DateTime.Parse("2022-06-06T00:00:00"),
                    PaymentFormCode = "01",
                    CurrencyCode = "MXN",
                    ExchangeRate = 1m,
                    Amount = 100.00m,
                    PaidInvoices = new List<PaidInvoice>()
                    {
                        new PaidInvoice
                        {
                            Uuid = "bfc36522-4b8e-45c4-8f14-d11b289f9eb7",
                            CurrencyCode = "MXN",
                            PartialityNumber = 1,
                            PreviousBalance = 100.00m,
                            PaymentAmount = 100.00m,
                            RemainingBalance = 0.00m,
                            TaxObjectCode = "02",
                            Equivalence = 1m,
                            Subtotal = 100.00m,
                            PaidInvoiceTaxes = new List<PaidInvoiceTax>
                            {
                                new PaidInvoiceTax
                                {
                                    TaxCode = "001",
                                    TaxTypeCode = "Tasa",
                                    TaxRate = 0.000000m,
                                     TaxFlagCode = "R"
                                },
                                new PaidInvoiceTax
                                {
                                    TaxCode = "001",
                                    TaxTypeCode = "Tasa",
                                    TaxRate = 0.350000m,
                                     TaxFlagCode = "R"
                                },
                                new PaidInvoiceTax
                                {
                                    TaxCode = "002",
                                    TaxTypeCode = "Tasa",
                                    TaxRate = 0.000000m,
                                     TaxFlagCode = "R"
                                },
                                new PaidInvoiceTax
                                {
                                    TaxCode = "002",
                                    TaxTypeCode = "Tasa",
                                    TaxRate = 0.160000m,
                                     TaxFlagCode = "R"
                                },
                                new PaidInvoiceTax
                                {
                                    TaxCode = "003",
                                    TaxTypeCode = "Cuota",
                                    TaxRate = 0.000000m,
                                     TaxFlagCode = "R"
                                },
                                new PaidInvoiceTax
                                {
                                    TaxCode = "003",
                                    TaxTypeCode = "Tasa",
                                    TaxRate = 0.304000m,
                                     TaxFlagCode = "R"
                                },
                                new PaidInvoiceTax
                                {
                                    TaxCode = "003",
                                    TaxTypeCode = "Cuota",
                                    TaxRate = 0.040000m,
                                     TaxFlagCode = "R"
                                }
                            }
                        }
                    }
                }
            };



            // Crear la factura 
            var invoice = new Invoice
            {
                VersionCode = "4.0",
                Series = "SDK-F",
                Date = DateTime.Now,
                CurrencyCode = "XXX",
                TypeCode = "P",
                ExpeditionZipCode = "20000",
                Issuer = issuer,
                Recipient = recipient,
                Complement = complement,
                ExportCode = "01",
                PaymentMethodCode = ""
            };


            // Timbrar la factura
            var apiResponse = await fiscalApi.Invoices.CreateAsync(invoice);


            if (apiResponse.Succeeded)
            {
                // Guardar el XML de la factura
                var xml = apiResponse.Data.Responses.FirstOrDefault()?.InvoiceBase64.DecodeFromBase64();
                File.WriteAllText($@"C:\facturas\{apiResponse.Data.Number}.xml", xml);

                MessageBox.Show($@"Factura {apiResponse.Data.Number} creada");
            }
            else
            {
                MessageBox.Show(apiResponse.Message);
                MessageBox.Show(apiResponse.Details);
            }
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            var fiscalApi = FiscalApiClient.Create(_settings);

            // Emisor KARLA FUENTE NOLASCO
            var issuer = new InvoiceIssuer
            {
                Id = "0e82a655-5f0c-4e07-abab-8f322e4123ef"
            };

            // Receptor ESCUELA KEMPER URGATE
            var recipient = new InvoiceRecipient
            {
                Id = "bd199ed8-02ef-47c0-919c-9479dd8ecae7"
            };

            var complement = new Complement
            {
                Payment = new InvoicePayment
                {
                    PaymentDate = DateTime.Parse("2021-12-15T00:00:00"),
                    PaymentFormCode = "01",
                    CurrencyCode = "MXN",
                    ExchangeRate = 1m,
                    Amount = 200.0m,
                    PaidInvoices = new List<PaidInvoice>()
                    {
                        new PaidInvoice
                        {
                            Uuid = "bfc36522-4b8e-45c4-8f14-d11b289f9eb7",
                            Number = "N0000216349",
                            CurrencyCode = "MXN",
                            PartialityNumber = 1,
                            PreviousBalance = 200.00m,
                            PaymentAmount = 200.00m,
                            RemainingBalance = 0.00m,
                            TaxObjectCode = "01",
                            Equivalence = 1m,
                            Subtotal = 20.00m
                        }
                    }
                }
            };



            // Crear la factura 
            var invoice = new Invoice
            {
                VersionCode = "4.0",
                Series = "SDK-F",
                Date = DateTime.Now,
                CurrencyCode = "XXX",
                TypeCode = "P",
                ExpeditionZipCode = "20000",
                Issuer = issuer,
                Recipient = recipient,
                Complement = complement,
                ExportCode = "01",
                PaymentMethodCode = ""
            };


            // Timbrar la factura
            var apiResponse = await fiscalApi.Invoices.CreateAsync(invoice);


            if (apiResponse.Succeeded)
            {
                // Guardar el XML de la factura
                var xml = apiResponse.Data.Responses.FirstOrDefault()?.InvoiceBase64.DecodeFromBase64();
                File.WriteAllText($@"C:\facturas\{apiResponse.Data.Number}.xml", xml);

                MessageBox.Show($@"Factura {apiResponse.Data.Number} creada");
            }
            else
            {
                MessageBox.Show(apiResponse.Message);
                MessageBox.Show(apiResponse.Details);
            }
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            var fiscalApi = FiscalApiClient.Create(_settings);

            // Emisor KARLA FUENTE NOLASCO
            var issuer = new InvoiceIssuer
            {
                Id = "0e82a655-5f0c-4e07-abab-8f322e4123ef"
            };

            // Receptor ESCUELA KEMPER URGATE
            var recipient = new InvoiceRecipient
            {
                Id = "bd199ed8-02ef-47c0-919c-9479dd8ecae7"
            };

            var complement = new Complement
            {
                Payment = new InvoicePayment
                {
                    PaymentDate = DateTime.Parse("2021-12-15T00:00:00"),
                    PaymentFormCode = "01",
                    CurrencyCode = "MXN",
                    ExchangeRate = 1m,
                    Amount = 116.0m,
                    PaidInvoices = new List<PaidInvoice>()
                    {
                        new PaidInvoice
                        {
                            Uuid = "bfc36522-4b8e-45c4-8f14-d11b289f9eb7",
                            Number = "N0000216349",
                            CurrencyCode = "MXN",
                            PartialityNumber = 1,
                            PreviousBalance = 200.00m,
                            PaymentAmount = 100.00m,
                            RemainingBalance = 100.00m,
                            TaxObjectCode = "02",
                            Equivalence = 1m,
                            Subtotal = 100.00m,
                            PaidInvoiceTaxes = new List<PaidInvoiceTax>
                            {
                                new PaidInvoiceTax
                                {
                                    TaxCode = "002",
                                    TaxTypeCode = "Tasa",
                                    TaxRate = 0.160000m,
                                    TaxFlagCode = "T"
                                }
                            }
                        }
                    }
                }
            };



            // Crear la factura 
            var invoice = new Invoice
            {
                VersionCode = "4.0",
                Series = "SDK-F",
                Date = DateTime.Now,
                CurrencyCode = "XXX",
                TypeCode = "P",
                ExpeditionZipCode = "20000",
                Issuer = issuer,
                Recipient = recipient,
                Complement = complement,
                ExportCode = "01",
                PaymentMethodCode = ""
            };


            // Timbrar la factura
            var apiResponse = await fiscalApi.Invoices.CreateAsync(invoice);


            if (apiResponse.Succeeded)
            {
                // Guardar el XML de la factura
                var xml = apiResponse.Data.Responses.FirstOrDefault()?.InvoiceBase64.DecodeFromBase64();
                File.WriteAllText($@"C:\facturas\{apiResponse.Data.Number}.xml", xml);

                MessageBox.Show($@"Factura {apiResponse.Data.Number} creada");
            }
            else
            {
                MessageBox.Show(apiResponse.Message);
                MessageBox.Show(apiResponse.Details);
            }
        }

        private async void button6_Click(object sender, EventArgs e)
        {
            var fiscalApi = FiscalApiClient.Create(_settings);

            // Emisor KARLA FUENTE NOLASCO
            var issuer = new InvoiceIssuer
            {
                Id = "0e82a655-5f0c-4e07-abab-8f322e4123ef"
            };

            // Receptor ESCUELA KEMPER URGATE
            var recipient = new InvoiceRecipient
            {
                Id = "bd199ed8-02ef-47c0-919c-9479dd8ecae7"
            };

            var complement = new Complement
            {
                Payment = new InvoicePayment
                {
                    PaymentDate = DateTime.Parse("2022-01-31T17:49:04"),
                    PaymentFormCode = "03",
                    CurrencyCode = "EUR",
                    ExchangeRate = 25.00m,
                    Amount = 100.0m,
                    PaidInvoices = new List<PaidInvoice>()
                    {
                        new PaidInvoice
                        {
                            Uuid = "4a5d025b-813a-4acf-9f32-8fb61f4918ac",
                            CurrencyCode = "USD",
                            PartialityNumber = 1,
                            PreviousBalance = 116.00m,
                            PaymentAmount = 116.00m,
                            RemainingBalance = 0.00m,
                            TaxObjectCode = "02",
                            Equivalence = 1.160m,
                            Subtotal = 100.00m,
                            PaidInvoiceTaxes = new List<PaidInvoiceTax>
                            {
                                new PaidInvoiceTax
                                {
                                    TaxCode = "002",
                                    TaxTypeCode = "Tasa",
                                    TaxRate = 0.160000m,
                                    TaxFlagCode = "T"
                                }
                            }
                        }
                    }
                }
            };



            // Crear la factura 
            var invoice = new Invoice
            {
                VersionCode = "4.0",
                Series = "SDK-F",
                Date = DateTime.Now,
                CurrencyCode = "XXX",
                TypeCode = "P",
                ExpeditionZipCode = "20000",
                Issuer = issuer,
                Recipient = recipient,
                Complement = complement,
                ExportCode = "01",
                PaymentMethodCode = ""
            };


            // Timbrar la factura
            var apiResponse = await fiscalApi.Invoices.CreateAsync(invoice);


            if (apiResponse.Succeeded)
            {
                // Guardar el XML de la factura
                var xml = apiResponse.Data.Responses.FirstOrDefault()?.InvoiceBase64.DecodeFromBase64();
                File.WriteAllText($@"C:\facturas\{apiResponse.Data.Number}.xml", xml);

                MessageBox.Show($@"Factura {apiResponse.Data.Number} creada");
            }
            else
            {
                MessageBox.Show(apiResponse.Message);
                MessageBox.Show(apiResponse.Details);
            }
        }

        private async void button7_Click(object sender, EventArgs e)
        {
            var fiscalApi = FiscalApiClient.Create(_settings);

            // Emisor KARLA FUENTE NOLASCO
            var issuer = new InvoiceIssuer
            {
                Id = "0e82a655-5f0c-4e07-abab-8f322e4123ef"
            };

            // Receptor ESCUELA KEMPER URGATE
            var recipient = new InvoiceRecipient
            {
                Id = "bd199ed8-02ef-47c0-919c-9479dd8ecae7"
            };

            var complement = new Complement
            {
                Payment = new InvoicePayment
                {
                    PaymentDate = DateTime.Parse("2022-01-31T17:49:04"),
                    PaymentFormCode = "03",
                    CurrencyCode = "USD",
                    ExchangeRate = 20.64m,
                    Amount = 5.62m,
                    PaidInvoices = new List<PaidInvoice>()
                    {
                        new PaidInvoice
                        {
                            Uuid = "4a5d025b-813a-4acf-9f32-8fb61f4918ac",
                            CurrencyCode = "MXN",
                            PartialityNumber = 1,
                            PreviousBalance = 116.00m,
                            PaymentAmount = 116.00m,
                            RemainingBalance = 0.00m,
                            TaxObjectCode = "02",
                            Equivalence = 20.64m,
                            Subtotal = 100.00m,
                            PaidInvoiceTaxes = new List<PaidInvoiceTax>
                            {
                                new PaidInvoiceTax
                                {
                                    TaxCode = "002",
                                    TaxTypeCode = "Tasa",
                                    TaxRate = 0.160000m,
                                    TaxFlagCode = "T"
                                }
                            }
                        }
                    }
                }
            };



            // Crear la factura 
            var invoice = new Invoice
            {
                VersionCode = "4.0",
                Series = "SDK-F",
                Date = DateTime.Now,
                CurrencyCode = "XXX",
                TypeCode = "P",
                ExpeditionZipCode = "20000",
                Issuer = issuer,
                Recipient = recipient,
                Complement = complement,
                ExportCode = "01",
                PaymentMethodCode = ""
            };


            // Timbrar la factura
            var apiResponse = await fiscalApi.Invoices.CreateAsync(invoice);


            if (apiResponse.Succeeded)
            {
                // Guardar el XML de la factura
                var xml = apiResponse.Data.Responses.FirstOrDefault()?.InvoiceBase64.DecodeFromBase64();
                File.WriteAllText($@"C:\facturas\{apiResponse.Data.Number}.xml", xml);

                MessageBox.Show($@"Factura {apiResponse.Data.Number} creada");
            }
            else
            {
                MessageBox.Show(apiResponse.Message);
                MessageBox.Show(apiResponse.Details);
            }
        }

        private async void button8_Click(object sender, EventArgs e)
        {
            var fiscalApi = FiscalApiClient.Create(_settings);

            // Emisor KARLA FUENTE NOLASCO
            var issuer = new InvoiceIssuer
            {
                Id = "0e82a655-5f0c-4e07-abab-8f322e4123ef"
            };

            // Receptor ESCUELA KEMPER URGATE
            var recipient = new InvoiceRecipient
            {
                Id = "bd199ed8-02ef-47c0-919c-9479dd8ecae7"
            };

            var complement = new Complement
            {
                Payment = new InvoicePayment
                {
                    PaymentDate = DateTime.Parse("2022-01-31T17:49:04"),
                    PaymentFormCode = "03",
                    CurrencyCode = "USD",
                    ExchangeRate = 18.012300m,
                    Amount = 1160.00m,
                    PaidInvoices = new List<PaidInvoice>()
                    {
                        new PaidInvoice
                        {
                            Uuid = "4a5d025b-813a-4acf-9f32-8fb61f4918ac",
                            CurrencyCode = "USD",
                            PartialityNumber = 1,
                            PreviousBalance = 1160.00m,
                            PaymentAmount = 1160.00m,
                            RemainingBalance = 0.00m,
                            TaxObjectCode = "02",
                            Equivalence = 1.00m,
                            Subtotal = 10.00m,
                            PaidInvoiceTaxes = new List<PaidInvoiceTax>
                            {
                                new PaidInvoiceTax
                                {
                                    TaxCode = "002",
                                    TaxTypeCode = "Tasa",
                                    TaxRate = 0.160000m,
                                    TaxFlagCode = "T"
                                }
                            }
                        }
                    }
                }
            };



            // Crear la factura 
            var invoice = new Invoice
            {
                VersionCode = "4.0",
                Series = "SDK-F",
                Date = DateTime.Now,
                CurrencyCode = "XXX",
                TypeCode = "P",
                ExpeditionZipCode = "20000",
                Issuer = issuer,
                Recipient = recipient,
                Complement = complement,
                ExportCode = "01",
                PaymentMethodCode = ""
            };


            // Timbrar la factura
            var apiResponse = await fiscalApi.Invoices.CreateAsync(invoice);


            if (apiResponse.Succeeded)
            {
                // Guardar el XML de la factura
                var xml = apiResponse.Data.Responses.FirstOrDefault()?.InvoiceBase64.DecodeFromBase64();
                File.WriteAllText($@"C:\facturas\{apiResponse.Data.Number}.xml", xml);

                MessageBox.Show($@"Factura {apiResponse.Data.Number} creada");
            }
            else
            {
                MessageBox.Show(apiResponse.Message);
                MessageBox.Show(apiResponse.Details);
            }
        }

        private async void button9_Click(object sender, EventArgs e)
        {
            var fiscalApi = FiscalApiClient.Create(_settings);

            // Emisor KARLA FUENTE NOLASCO
            var issuer = new InvoiceIssuer
            {
                Id = "0e82a655-5f0c-4e07-abab-8f322e4123ef"
            };

            // Receptor ESCUELA KEMPER URGATE
            var recipient = new InvoiceRecipient
            {
                Id = "bd199ed8-02ef-47c0-919c-9479dd8ecae7"
            };

            var complement = new Complement
            {
                Payment = new InvoicePayment
                {
                    PaymentDate = DateTime.Parse("2023-11-29T12:00:00"),
                    PaymentFormCode = "03",
                    CurrencyCode = "USD",
                    ExchangeRate = 1.00m,
                    Amount = 100.00m,
                    PaidInvoices = new List<PaidInvoice>()
                    {
                        new PaidInvoice
                        {
                            Uuid = "a0476c1b-8829-448d-82ab-92d8b26be878",
                            CurrencyCode = "MXN",
                            PartialityNumber = 1,
                            PreviousBalance = 98.75m,
                            PaymentAmount = 98.75m,
                            RemainingBalance = 0.00m,
                            TaxObjectCode = "02",
                            Equivalence = 1.00m,
                            Subtotal = 100.00m,
                            PaidInvoiceTaxes = new List<PaidInvoiceTax>
                            {
                                new PaidInvoiceTax
                                {
                                    TaxCode = "002",
                                    TaxTypeCode = "Tasa",
                                    TaxRate = 0.160000m,
                                    TaxFlagCode = "R"
                                },
                                new PaidInvoiceTax
                                {
                                    TaxCode = "002",
                                    TaxTypeCode = "Tasa",
                                    TaxRate = 0.160000m,
                                    TaxFlagCode = "T"
                                }
                            }
                        }
                    }
                }
            };



            // Crear la factura 
            var invoice = new Invoice
            {
                VersionCode = "4.0",
                Series = "SDK-F",
                Date = DateTime.Now,
                CurrencyCode = "XXX",
                TypeCode = "P",
                ExpeditionZipCode = "06370",
                Issuer = issuer,
                Recipient = recipient,
                Complement = complement,
                ExportCode = "01",
                PaymentMethodCode = ""
            };


            // Timbrar la factura
            var apiResponse = await fiscalApi.Invoices.CreateAsync(invoice);


            if (apiResponse.Succeeded)
            {
                // Guardar el XML de la factura
                var xml = apiResponse.Data.Responses.FirstOrDefault()?.InvoiceBase64.DecodeFromBase64();
                File.WriteAllText($@"C:\facturas\{apiResponse.Data.Number}.xml", xml);

                MessageBox.Show($@"Factura {apiResponse.Data.Number} creada");
            }
            else
            {
                MessageBox.Show(apiResponse.Message);
                MessageBox.Show(apiResponse.Details);
            }
        }

        private async void button10_Click(object sender, EventArgs e)
        {
            var fiscalApi = FiscalApiClient.Create(_settings);

            // Emisor KARLA FUENTE NOLASCO
            var issuer = new InvoiceIssuer
            {
                Id = "0e82a655-5f0c-4e07-abab-8f322e4123ef"
            };

            // Receptor ESCUELA KEMPER URGATE
            var recipient = new InvoiceRecipient
            {
                Id = "bd199ed8-02ef-47c0-919c-9479dd8ecae7"
            };

            var complement = new Complement
            {
                Payment = new InvoicePayment
                {
                    PaymentDate = DateTime.Parse("2022-09-09T17:33:38"),
                    PaymentFormCode = "01",
                    CurrencyCode = "MXN",
                    ExchangeRate = 1.00m,
                    Amount = 100.00m,
                    PaidInvoices = new List<PaidInvoice>()
                    {
                        new PaidInvoice
                        {
                            Uuid = "b7c8d2bf-cb4e-4f84-af89-c68b6731206a",
                            Series = "FA",
                            Number = "N0000216349",
                            CurrencyCode = "MXN",
                            PartialityNumber = 2,
                            PreviousBalance = 100.00m,
                            PaymentAmount = 100.00m,
                            RemainingBalance = 0.00m,
                            TaxObjectCode = "02",
                            Equivalence = 1.00m,
                            Subtotal = 1.00m,
                            PaidInvoiceTaxes = new List<PaidInvoiceTax>
                            {
                                new PaidInvoiceTax
                                {
                                    TaxCode = "002",
                                    TaxTypeCode = "Exento",
                                    TaxFlagCode = "T"
                                },
                                new PaidInvoiceTax
                                {
                                    TaxCode = "003",
                                    TaxTypeCode = "Exento",
                                    TaxFlagCode = "T"
                                }
                            }
                        }
                    }
                }
            };



            // Crear la factura 
            var invoice = new Invoice
            {
                VersionCode = "4.0",
                Series = "SDK-F",
                Date = DateTime.Now,
                CurrencyCode = "XXX",
                TypeCode = "P",
                ExpeditionZipCode = "75700",
                Issuer = issuer,
                Recipient = recipient,
                Complement = complement,
                ExportCode = "01",
                PaymentMethodCode = ""
            };


            // Timbrar la factura
            var apiResponse = await fiscalApi.Invoices.CreateAsync(invoice);


            if (apiResponse.Succeeded)
            {
                // Guardar el XML de la factura
                var xml = apiResponse.Data.Responses.FirstOrDefault()?.InvoiceBase64.DecodeFromBase64();
                File.WriteAllText($@"C:\facturas\{apiResponse.Data.Number}.xml", xml);

                MessageBox.Show($@"Factura {apiResponse.Data.Number} creada");
            }
            else
            {
                MessageBox.Show(apiResponse.Message);
                MessageBox.Show(apiResponse.Details);
            }
        }

        private async void button11_Click(object sender, EventArgs e)
        {
            var fiscalApi = FiscalApiClient.Create(_settings);

            // Emisor KARLA FUENTE NOLASCO
            var issuer = new InvoiceIssuer
            {
                Id = "0e82a655-5f0c-4e07-abab-8f322e4123ef"
            };

            // Receptor ESCUELA KEMPER URGATE
            var recipient = new InvoiceRecipient
            {
                Id = "bd199ed8-02ef-47c0-919c-9479dd8ecae7"
            };

            var complement = new Complement
            {
                Payment = new InvoicePayment
                {
                    PaymentDate = DateTime.Parse("2022-05-26T12:00:00"),
                    PaymentFormCode = "03",
                    CurrencyCode = "MXN",
                    ExchangeRate = 1.00m,
                    Amount = 100.00m,
                    PaidInvoices = new List<PaidInvoice>()
                    {
                        new PaidInvoice
                        {
                            Uuid = "a0476c1b-8829-448d-82ab-92d8b26be878",
                            CurrencyCode = "MXN",
                            PartialityNumber = 1,
                            PreviousBalance = 98.75m,
                            PaymentAmount = 98.75m,
                            RemainingBalance = 0.00m,
                            TaxObjectCode = "02",
                            Equivalence = 1.00m,
                            Subtotal = 100.00m,
                            PaidInvoiceTaxes = new List<PaidInvoiceTax>
                            {
                                new PaidInvoiceTax
                                {
                                    TaxCode = "001",
                                    TaxTypeCode = "Tasa",
                                    TaxRate = 0.000000m,
                                    TaxFlagCode = "R"
                                },
                                new PaidInvoiceTax
                                {
                                    TaxCode = "002",
                                    TaxTypeCode = "Tasa",
                                    TaxRate = 0.160000m,
                                    TaxFlagCode = "R"
                                },
                                new PaidInvoiceTax
                                {
                                    TaxCode = "003",
                                    TaxTypeCode = "Cuota",
                                    TaxRate = 0.040000m,
                                    TaxFlagCode = "R"
                                },
                                new PaidInvoiceTax
                                {
                                    TaxCode = "002",
                                    TaxTypeCode = "Exento",
                                    TaxFlagCode = "T"
                                }
                            }
                        }
                    }
                }
            };



            // Crear la factura 
            var invoice = new Invoice
            {
                VersionCode = "4.0",
                Series = "SDK-F",
                Date = DateTime.Now,
                CurrencyCode = "XXX",
                TypeCode = "P",
                ExpeditionZipCode = "75700",
                Issuer = issuer,
                Recipient = recipient,
                Complement = complement,
                ExportCode = "01",
                PaymentMethodCode = ""
            };


            // Timbrar la factura
            var apiResponse = await fiscalApi.Invoices.CreateAsync(invoice);


            if (apiResponse.Succeeded)
            {
                // Guardar el XML de la factura
                var xml = apiResponse.Data.Responses.FirstOrDefault()?.InvoiceBase64.DecodeFromBase64();
                File.WriteAllText($@"C:\facturas\{apiResponse.Data.Number}.xml", xml);

                MessageBox.Show($@"Factura {apiResponse.Data.Number} creada");
            }
            else
            {
                MessageBox.Show(apiResponse.Message);
                MessageBox.Show(apiResponse.Details);
            }
        }

        private async void button12_Click(object sender, EventArgs e)
        {
            var fiscalApi = FiscalApiClient.Create(_settings);

            // Emisor KARLA FUENTE NOLASCO
            var issuer = new InvoiceIssuer
            {
                Id = "0e82a655-5f0c-4e07-abab-8f322e4123ef"
            };

            // Receptor ESCUELA KEMPER URGATE
            var recipient = new InvoiceRecipient
            {
                Id = "bd199ed8-02ef-47c0-919c-9479dd8ecae7"
            };

            var complement = new Complement
            {
                Payment = new InvoicePayment
                {
                    PaymentDate = DateTime.Parse("2022-01-31T17:49:04"),
                    PaymentFormCode = "03",
                    CurrencyCode = "MXN",
                    ExchangeRate = 1.00m,
                    Amount = 921.23m,
                    PaidInvoices = new List<PaidInvoice>()
                    {
                        new PaidInvoice
                        {
                            Uuid = "4a5d025b-813a-4acf-9f32-8fb61f4918ac",
                            CurrencyCode = "USD",
                            PartialityNumber = 1,
                            PreviousBalance = 41.76m,
                            PaymentAmount = 41.76m,
                            RemainingBalance = 0.00m,
                            TaxObjectCode = "02",
                            Equivalence = 0.045331m,
                            Subtotal = 36.00m,
                            PaidInvoiceTaxes = new List<PaidInvoiceTax>
                            {
                                new PaidInvoiceTax
                                {
                                    TaxCode = "002",
                                    TaxTypeCode = "Tasa",
                                    TaxRate = 0.160000m,
                                    TaxFlagCode = "T"
                                }
                            }
                        }
                    }
                }
            };

            // Crear la factura 
            var invoice = new Invoice
            {
                VersionCode = "4.0",
                Series = "SDK-F",
                Date = DateTime.Now,
                CurrencyCode = "XXX",
                TypeCode = "P",
                ExpeditionZipCode = "42060",
                Issuer = issuer,
                Recipient = recipient,
                Complement = complement,
                ExportCode = "01",
                PaymentMethodCode = ""
            };


            // Timbrar la factura
            var apiResponse = await fiscalApi.Invoices.CreateAsync(invoice);


            if (apiResponse.Succeeded)
            {
                // Guardar el XML de la factura
                var xml = apiResponse.Data.Responses.FirstOrDefault()?.InvoiceBase64.DecodeFromBase64();
                File.WriteAllText($@"C:\facturas\{apiResponse.Data.Number}.xml", xml);

                MessageBox.Show($@"Factura {apiResponse.Data.Number} creada");
            }
            else
            {
                MessageBox.Show(apiResponse.Message);
                MessageBox.Show(apiResponse.Details);
            }
        }

        private async void button13_Click(object sender, EventArgs e)
        {
            var fiscalApi = FiscalApiClient.Create(_settings);

            // Emisor KARLA FUENTE NOLASCO
            var issuer = new InvoiceIssuer
            {
                Id = "0e82a655-5f0c-4e07-abab-8f322e4123ef"
            };

            // Receptor ESCUELA KEMPER URGATE
            var recipient = new InvoiceRecipient
            {
                Id = "bd199ed8-02ef-47c0-919c-9479dd8ecae7"
            };

            var items = new List<InvoiceItem>()
            {
                new InvoiceItem
                {
                    ItemCode = "23151602",
                    ItemSku = "23151602",
                    Quantity = 1.00m,
                    UnitOfMeasurementCode = "H87",
                    Description = "Trituradora",
                    UnitPrice = 5000.00m,
                    TaxObjectCode = "02",
                    ItemTaxes = new List<InvoiceItemTax>
                    {
                        new InvoiceItemTax
                        {
                            TaxCode = "002",
                            TaxTypeCode = "Tasa",
                            TaxRate = 0.160000m,
                            TaxFlagCode = "T"
                        }
                    }
                },
                new InvoiceItem
                {
                    ItemCode = "23101510",
                    ItemSku = "23101510",
                    Quantity = 1.00m,
                    UnitOfMeasurementCode = "H87",
                    Description = "Pulidora",
                    UnitPrice = 10000.00m,
                    TaxObjectCode = "02",
                    ItemTaxes = new List<InvoiceItemTax>
                    {
                        new InvoiceItemTax
                        {
                            TaxCode = "002",
                            TaxTypeCode = "Tasa",
                            TaxRate = 0.160000m,
                            TaxFlagCode = "T"
                        }
                    },
                    OnBehalfOf = new OnBehalfOf
                    {
                        Tin = "XIQB891116QE4",
                        LegalName = "BERENICE XIMO QUEZADA",
                        TaxRegimeCode = "612",
                        ZipCode = "40968"
                    }
                },
                new InvoiceItem
                {
                    ItemCode = "23281703",
                    ItemSku = "23281703",
                    Quantity = 1.00m,
                    UnitOfMeasurementCode = "H87",
                    Description = "Maquina de arena",
                    UnitPrice = 30000.00m,
                    TaxObjectCode = "02",
                    ItemTaxes = new List<InvoiceItemTax>
                    {
                        new InvoiceItemTax
                        {
                            TaxCode = "002",
                            TaxTypeCode = "Tasa",
                            TaxRate = 0.160000m,
                            TaxFlagCode = "T"
                        }
                    },
                    OnBehalfOf = new OnBehalfOf
                    {
                        Tin = "IVD920810GU2",
                        LegalName = "INNOVACION VALOR Y DESARROLLO",
                        TaxRegimeCode = "601",
                        ZipCode = "63901"
                    }
                }
            };

            // Crear la factura 
            var invoice = new Invoice
            {
                VersionCode = "4.0",
                Series = "SDK-F",
                Date = DateTime.Now,
                CurrencyCode = "MXN",
                TypeCode = "I",
                ExpeditionZipCode = "26015",
                Issuer = issuer,
                Recipient = recipient,
                Items = items,
                ExportCode = "01",
                PaymentMethodCode = "PPD",
                PaymentFormCode = "99"
            };

            // Timbrar la factura
            var apiResponse = await fiscalApi.Invoices.CreateAsync(invoice);


            if (apiResponse.Succeeded)
            {
                // Guardar el XML de la factura
                var xml = apiResponse.Data.Responses.FirstOrDefault()?.InvoiceBase64.DecodeFromBase64();
                File.WriteAllText($@"C:\facturas\{apiResponse.Data.Number}.xml", xml);

                MessageBox.Show($@"Factura {apiResponse.Data.Number} creada");
            }
            else
            {
                MessageBox.Show(apiResponse.Message);
                MessageBox.Show(apiResponse.Details);
            }
        }

        private async void button14_Click(object sender, EventArgs e)
        {
            var fiscalApi = FiscalApiClient.Create(_settings);

            // Emisor KARLA FUENTE NOLASCO
            var issuer = new InvoiceIssuer
            {
                Id = "0e82a655-5f0c-4e07-abab-8f322e4123ef"
            };

            // Receptor ESCUELA KEMPER URGATE
            var recipient = new InvoiceRecipient
            {
                Id = "bd199ed8-02ef-47c0-919c-9479dd8ecae7"
            };

            var complement = new Complement
            {
                Payment = new InvoicePayment
                {
                    PaymentDate = DateTime.Parse("2022-09-09T17:33:38"),
                    PaymentFormCode = "01",
                    CurrencyCode = "MXN",
                    ExchangeRate = 1.00m,
                    Amount = 100.00m,
                    PaidInvoices = new List<PaidInvoice>()
                    {
                        new PaidInvoice
                        {
                            Uuid = "b7c8d2bf-cb4e-4f84-af89-c68b6731206a",
                            Series = "FA",
                            Number = "N0000216349",
                            CurrencyCode = "MXN",
                            PartialityNumber = 2,
                            PreviousBalance = 100.00m,
                            PaymentAmount = 100.00m,
                            RemainingBalance = 0.00m,
                            TaxObjectCode = "02",
                            Equivalence = 1.00m,
                            Subtotal = 76.80m,
                            PaidInvoiceTaxes = new List<PaidInvoiceTax>
                            {
                                new PaidInvoiceTax
                                {
                                    TaxCode = "002",
                                    TaxTypeCode = "Exento",
                                    TaxFlagCode = "T"
                                },
                                new PaidInvoiceTax
                                {
                                    TaxCode = "002",
                                    TaxTypeCode = "Tasa",
                                    TaxRate=  0.160000m,
                                    TaxFlagCode = "T"
                                },
                                new PaidInvoiceTax
                                {
                                    TaxCode = "003",
                                    TaxTypeCode = "Exento",
                                    TaxFlagCode = "T"
                                },
                                new PaidInvoiceTax
                                {
                                    TaxCode = "003",
                                    TaxTypeCode = "Tasa",
                                    TaxRate = 0.080000m,
                                    TaxFlagCode = "T"
                                }
                            }
                        }
                    }
                }
            };



            // Crear la factura 
            var invoice = new Invoice
            {
                VersionCode = "4.0",
                Series = "SDK-F",
                Date = DateTime.Now,
                CurrencyCode = "XXX",
                TypeCode = "P",
                ExpeditionZipCode = "75700",
                Issuer = issuer,
                Recipient = recipient,
                Complement = complement,
                ExportCode = "01",
                PaymentMethodCode = ""
            };


            // Timbrar la factura
            var apiResponse = await fiscalApi.Invoices.CreateAsync(invoice);


            if (apiResponse.Succeeded)
            {
                // Guardar el XML de la factura
                var xml = apiResponse.Data.Responses.FirstOrDefault()?.InvoiceBase64.DecodeFromBase64();
                File.WriteAllText($@"C:\facturas\{apiResponse.Data.Number}.xml", xml);

                MessageBox.Show($@"Factura {apiResponse.Data.Number} creada");
            }
            else
            {
                MessageBox.Show(apiResponse.Message);
                MessageBox.Show(apiResponse.Details);
            }
        }

        private async void button15_Click(object sender, EventArgs e)
        {
            var fiscalApi = FiscalApiClient.Create(_settings);

            // Emisor KARLA FUENTE NOLASCO
            var issuer = new InvoiceIssuer
            {
                Id = "0e82a655-5f0c-4e07-abab-8f322e4123ef"
            };

            // Receptor ESCUELA KEMPER URGATE
            var recipient = new InvoiceRecipient
            {
                Id = "bd199ed8-02ef-47c0-919c-9479dd8ecae7"
            };

            var complement = new Complement
            {
                Payment = new InvoicePayment
                {
                    PaymentDate = DateTime.Parse("2022-01-31T17:49:04"),
                    PaymentFormCode = "03",
                    CurrencyCode = "MXN",
                    ExchangeRate = 1.00m,
                    Amount = 921.23m,
                    PaidInvoices = new List<PaidInvoice>()
                    {
                        new PaidInvoice
                        {
                            Uuid = "4a5d025b-813a-4acf-9f32-8fb61f4918ac",
                            CurrencyCode = "MXN",
                            PartialityNumber = 1,
                            PreviousBalance = 921.23m,
                            PaymentAmount = 921.23m,
                            RemainingBalance = 0.00m,
                            TaxObjectCode = "02",
                            Equivalence = 1.00m,
                            Subtotal = 794.1638m,
                            PaidInvoiceTaxes = new List<PaidInvoiceTax>
                            {
                                new PaidInvoiceTax
                                {
                                    TaxCode = "002",
                                    TaxTypeCode = "Tasa",
                                    TaxRate = 0.160000m,
                                    TaxFlagCode = "T"
                                }
                            }
                        }
                    }
                }
            };



            // Crear la factura 
            var invoice = new Invoice
            {
                VersionCode = "4.0",
                Series = "SDK-F",
                Date = DateTime.Now,
                CurrencyCode = "XXX",
                TypeCode = "P",
                ExpeditionZipCode = "42060",
                Issuer = issuer,
                Recipient = recipient,
                Complement = complement,
                ExportCode = "01",
                PaymentMethodCode = ""
            };


            // Timbrar la factura
            var apiResponse = await fiscalApi.Invoices.CreateAsync(invoice);


            if (apiResponse.Succeeded)
            {
                // Guardar el XML de la factura
                var xml = apiResponse.Data.Responses.FirstOrDefault()?.InvoiceBase64.DecodeFromBase64();
                File.WriteAllText($@"C:\facturas\{apiResponse.Data.Number}.xml", xml);

                MessageBox.Show($@"Factura {apiResponse.Data.Number} creada");
            }
            else
            {
                MessageBox.Show(apiResponse.Message);
                MessageBox.Show(apiResponse.Details);
            }
        }

        private async void button16_Click(object sender, EventArgs e)
        {
            var fiscalApi = FiscalApiClient.Create(_settings);

            // Emisor KARLA FUENTE NOLASCO
            var issuer = new InvoiceIssuer
            {
                Id = "0e82a655-5f0c-4e07-abab-8f322e4123ef"
            };

            // Receptor ESCUELA KEMPER URGATE
            var recipient = new InvoiceRecipient
            {
                Id = "bd199ed8-02ef-47c0-919c-9479dd8ecae7"
            };

            var complement = new Complement
            {
                Payment = new InvoicePayment
                {
                    PaymentDate = DateTime.Parse("2022-06-06T00:00:00"),
                    PaymentFormCode = "01",
                    CurrencyCode = "MXN",
                    ExchangeRate = 1.00m,
                    Amount = 100.00m,
                    PaidInvoices = new List<PaidInvoice>()
                    {
                        new PaidInvoice
                        {
                            Uuid = "bfc36522-4b8e-45c4-8f14-d11b289f9eb7",
                            CurrencyCode = "MXN",
                            PartialityNumber = 1,
                            PreviousBalance = 100.00m,
                            PaymentAmount = 100.00m,
                            RemainingBalance = 0.00m,
                            TaxObjectCode = "08",
                            Equivalence = 1.00m,
                            Subtotal = 100.00m,
                            PaidInvoiceTaxes = new List<PaidInvoiceTax>
                            {
                                new PaidInvoiceTax
                                {
                                    TaxCode = "001",
                                    TaxTypeCode = "Tasa",
                                    TaxRate = 0.000000m,
                                    TaxFlagCode = "R"
                                },
                                new PaidInvoiceTax
                                {
                                    TaxCode = "001",
                                    TaxTypeCode = "Tasa",
                                    TaxRate = 0.350000m,
                                    TaxFlagCode = "R"
                                }
                            }
                        }
                    }
                }
            };



            // Crear la factura 
            var invoice = new Invoice
            {
                VersionCode = "4.0",
                Series = "SDK-F",
                Date = DateTime.Now,
                CurrencyCode = "XXX",
                TypeCode = "P",
                ExpeditionZipCode = "20000",
                Issuer = issuer,
                Recipient = recipient,
                Complement = complement,
                ExportCode = "01",
                PaymentMethodCode = ""
            };


            // Timbrar la factura
            var apiResponse = await fiscalApi.Invoices.CreateAsync(invoice);


            if (apiResponse.Succeeded)
            {
                // Guardar el XML de la factura
                var xml = apiResponse.Data.Responses.FirstOrDefault()?.InvoiceBase64.DecodeFromBase64();
                File.WriteAllText($@"C:\facturas\{apiResponse.Data.Number}.xml", xml);

                MessageBox.Show($@"Factura {apiResponse.Data.Number} creada");
            }
            else
            {
                MessageBox.Show(apiResponse.Message);
                MessageBox.Show(apiResponse.Details);
            }
        }

        private async void button17_Click(object sender, EventArgs e)
        {
            var fiscalApi = FiscalApiClient.Create(_settings);

            // Emisor KARLA FUENTE NOLASCO
            var issuer = new InvoiceIssuer
            {
                Id = "0e82a655-5f0c-4e07-abab-8f322e4123ef"
            };

            // Receptor ESCUELA KEMPER URGATE
            var recipient = new InvoiceRecipient
            {
                Id = "bd199ed8-02ef-47c0-919c-9479dd8ecae7"
            };

            var complement = new Complement
            {
                Payment = new InvoicePayment
                {
                    PaymentDate = DateTime.Parse("2022-06-06T00:00:00"),
                    PaymentFormCode = "01",
                    CurrencyCode = "MXN",
                    ExchangeRate = 1.00m,
                    Amount = 100.00m,
                    PaidInvoices = new List<PaidInvoice>()
                    {
                        new PaidInvoice
                        {
                            Uuid = "bfc36522-4b8e-45c4-8f14-d11b289f9eb7",
                            CurrencyCode = "MXN",
                            PartialityNumber = 1,
                            PreviousBalance = 100.00m,
                            PaymentAmount = 100.00m,
                            RemainingBalance = 0.00m,
                            TaxObjectCode = "07",
                            Equivalence = 1.00m,
                            Subtotal = 64.00m,
                            PaidInvoiceTaxes = new List<PaidInvoiceTax>
                            {
                                new PaidInvoiceTax
                                {
                                    TaxCode = "003",
                                    TaxTypeCode = "Cuota",
                                    TaxRate = 0.000000m,
                                    TaxFlagCode = "R"
                                },
                                new PaidInvoiceTax
                                {
                                    TaxCode = "003",
                                    TaxTypeCode = "Tasa",
                                    TaxRate = 0.304000m,
                                    TaxFlagCode = "R"
                                },
                                new PaidInvoiceTax
                                {
                                    TaxCode = "003",
                                    TaxTypeCode = "Cuota",
                                    TaxRate = 0.040000m,
                                    TaxFlagCode = "R"
                                },
                                new PaidInvoiceTax
                                {
                                    TaxCode = "003",
                                    TaxTypeCode = "Exento",
                                    TaxFlagCode = "T"
                                },
                                new PaidInvoiceTax
                                {
                                    TaxCode = "003",
                                    TaxTypeCode = "Tasa",
                                    TaxRate = 0.080000m,
                                    TaxFlagCode = "T"
                                }
                            }
                        }
                    }
                }
            };



            // Crear la factura 
            var invoice = new Invoice
            {
                VersionCode = "4.0",
                Series = "SDK-F",
                Date = DateTime.Now,
                CurrencyCode = "XXX",
                TypeCode = "P",
                ExpeditionZipCode = "42060",
                Issuer = issuer,
                Recipient = recipient,
                Complement = complement,
                ExportCode = "01",
                PaymentMethodCode = ""
            };


            // Timbrar la factura
            var apiResponse = await fiscalApi.Invoices.CreateAsync(invoice);


            if (apiResponse.Succeeded)
            {
                // Guardar el XML de la factura
                var xml = apiResponse.Data.Responses.FirstOrDefault()?.InvoiceBase64.DecodeFromBase64();
                File.WriteAllText($@"C:\facturas\{apiResponse.Data.Number}.xml", xml);

                MessageBox.Show($@"Factura {apiResponse.Data.Number} creada");
            }
            else
            {
                MessageBox.Show(apiResponse.Message);
                MessageBox.Show(apiResponse.Details);
            }
        }

        private async void button18_Click(object sender, EventArgs e)
        {
            var fiscalApi = FiscalApiClient.Create(_settings);

            // Emisor KARLA FUENTE NOLASCO
            var issuer = new InvoiceIssuer
            {
                Id = "0e82a655-5f0c-4e07-abab-8f322e4123ef"
            };

            // Receptor ESCUELA KEMPER URGATE
            var recipient = new InvoiceRecipient
            {
                Id = "bd199ed8-02ef-47c0-919c-9479dd8ecae7"
            };

            var complement = new Complement
            {
                Payment = new InvoicePayment
                {
                    PaymentDate = DateTime.Parse("2022-06-06T00:00:00"),
                    PaymentFormCode = "01",
                    CurrencyCode = "MXN",
                    ExchangeRate = 1.00m,
                    Amount = 100.00m,
                    PaidInvoices = new List<PaidInvoice>()
                    {
                        new PaidInvoice
                        {
                            Uuid = "bfc36522-4b8e-45c4-8f14-d11b289f9eb7",
                            CurrencyCode = "MXN",
                            PartialityNumber = 1,
                            PreviousBalance = 100.00m,
                            PaymentAmount = 100.00m,
                            RemainingBalance = 0.00m,
                            TaxObjectCode = "06",
                            Equivalence = 1.00m,
                            Subtotal = 100.00m,
                            PaidInvoiceTaxes = new List<PaidInvoiceTax>
                            {
                                new PaidInvoiceTax
                                {
                                    TaxCode = "001",
                                    TaxTypeCode = "Tasa",
                                    TaxRate = 0.000000m,
                                    TaxFlagCode = "R"
                                },
                                new PaidInvoiceTax
                                {
                                    TaxCode = "001",
                                    TaxTypeCode = "Tasa",
                                    TaxRate = 0.350000m,
                                    TaxFlagCode = "R"
                                }
                            }
                        }
                    }
                }
            };



            // Crear la factura 
            var invoice = new Invoice
            {
                VersionCode = "4.0",
                Series = "SDK-F",
                Date = DateTime.Now,
                CurrencyCode = "XXX",
                TypeCode = "P",
                ExpeditionZipCode = "42060",
                Issuer = issuer,
                Recipient = recipient,
                Complement = complement,
                ExportCode = "01",
                PaymentMethodCode = ""
            };


            // Timbrar la factura
            var apiResponse = await fiscalApi.Invoices.CreateAsync(invoice);


            if (apiResponse.Succeeded)
            {
                // Guardar el XML de la factura
                var xml = apiResponse.Data.Responses.FirstOrDefault()?.InvoiceBase64.DecodeFromBase64();
                File.WriteAllText($@"C:\facturas\{apiResponse.Data.Number}.xml", xml);

                MessageBox.Show($@"Factura {apiResponse.Data.Number} creada");
            }
            else
            {
                MessageBox.Show(apiResponse.Message);
                MessageBox.Show(apiResponse.Details);
            }
        }

        private async void button19_Click(object sender, EventArgs e)
        {
            var fiscalApi = FiscalApiClient.Create(_settings);

            // Emisor KARLA FUENTE NOLASCO
            var issuer = new InvoiceIssuer
            {
                Id = "0e82a655-5f0c-4e07-abab-8f322e4123ef"
            };

            // Receptor ESCUELA KEMPER URGATE
            var recipient = new InvoiceRecipient
            {
                Id = "bd199ed8-02ef-47c0-919c-9479dd8ecae7"
            };

            var complement = new Complement
            {
                Payment = new InvoicePayment
                {
                    PaymentDate = DateTime.Parse("2022-06-06T00:00:00"),
                    PaymentFormCode = "01",
                    CurrencyCode = "MXN",
                    ExchangeRate = 1.00m,
                    Amount = 100.00m,
                    PaidInvoices = new List<PaidInvoice>()
                    {
                        new PaidInvoice
                        {
                            Uuid = "bfc36522-4b8e-45c4-8f14-d11b289f9eb7",
                            CurrencyCode = "MXN",
                            PartialityNumber = 1,
                            PreviousBalance = 100.00m,
                            PaymentAmount = 100.00m,
                            RemainingBalance = 0.00m,
                            TaxObjectCode = "07",
                            Equivalence = 1.00m,
                            Subtotal = 63.40m,
                            PaidInvoiceTaxes = new List<PaidInvoiceTax>
                            {
                                new PaidInvoiceTax
                                {
                                    TaxCode = "001",
                                    TaxTypeCode = "Tasa",
                                    TaxRate = 0.000000m,
                                    TaxFlagCode = "R"
                                },
                                new PaidInvoiceTax
                                {
                                    TaxCode = "001",
                                    TaxTypeCode = "Tasa",
                                    TaxRate = 0.350000m,
                                    TaxFlagCode = "R"
                                },
                                new PaidInvoiceTax
                                {
                                    TaxCode = "003",
                                    TaxTypeCode = "Exento",
                                    TaxFlagCode = "T"
                                },
                                new PaidInvoiceTax
                                {
                                    TaxCode = "003",
                                    TaxTypeCode = "Tasa",
                                    TaxRate = 0.080000m,
                                    TaxFlagCode = "T"
                                },
                            }
                        }
                    }
                }
            };



            // Crear la factura 
            var invoice = new Invoice
            {
                VersionCode = "4.0",
                Series = "SDK-F",
                Date = DateTime.Now,
                CurrencyCode = "XXX",
                TypeCode = "P",
                ExpeditionZipCode = "20000",
                Issuer = issuer,
                Recipient = recipient,
                Complement = complement,
                ExportCode = "01",
                PaymentMethodCode = ""
            };


            // Timbrar la factura
            var apiResponse = await fiscalApi.Invoices.CreateAsync(invoice);


            if (apiResponse.Succeeded)
            {
                // Guardar el XML de la factura
                var xml = apiResponse.Data.Responses.FirstOrDefault()?.InvoiceBase64.DecodeFromBase64();
                File.WriteAllText($@"C:\facturas\{apiResponse.Data.Number}.xml", xml);

                MessageBox.Show($@"Factura {apiResponse.Data.Number} creada");
            }
            else
            {
                MessageBox.Show(apiResponse.Message);
                MessageBox.Show(apiResponse.Details);
            }
        }
    }
}
