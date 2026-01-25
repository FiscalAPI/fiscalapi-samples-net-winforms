using Fiscalapi.Common;
using Fiscalapi.Models;
using Fiscalapi.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FiscalApi.Samples.NetFramework
{
    public partial class IncomeInvoiceReferenceForm : Form
    {
        private FiscalapiSettings _settings;

        public IncomeInvoiceReferenceForm(FiscalapiSettings settings)
        {
            _settings = settings;
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            // Crear instancia de FiscalApiClient
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

            // Crear una lista de productos o servicios de la factura
            var items = new List<InvoiceItem>()
            {
                new InvoiceItem
                {
                    Id = "2f3c65f3-ed02-452f-944c-97a47010df5c",
                    Quantity = 1
                },
            };

            // Crear la factura 
            var invoice = new Invoice
            {
                VersionCode = "4.0",
                Series = "SDK-F",
                Date = DateTime.Now,
                PaymentFormCode = "01",
                CurrencyCode = "MXN",
                TypeCode = "I",
                ExpeditionZipCode = "20000",
                Issuer = issuer,
                Recipient = recipient,
                Items = items,
                PaymentMethodCode = "PUE",
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
            // Crear instancia de FiscalApiClient
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

            // Crear una lista de productos o servicios de la factura
            var items = new List<InvoiceItem>()
            {
                new InvoiceItem
                {
                    Id = "2f3c65f3-ed02-452f-944c-97a47010df5c",
                    Quantity = 1,
                    OnBehalfOf = new OnBehalfOf
                    {
                        Tin = "CACX7605101P8",
                        LegalName = "XOCHILT CASAS CHAVEZ",
                        TaxRegimeCode = "601",
                        ZipCode = "36257"

                    }
                },
            };

            // Crear la factura 
            var invoice = new Invoice
            {
                VersionCode = "4.0",
                Series = "SDK-F",
                Date = DateTime.Now,
                PaymentFormCode = "01",
                CurrencyCode = "MXN",
                TypeCode = "I",
                ExpeditionZipCode = "20000",
                Issuer = issuer,
                Recipient = recipient,
                Items = items,
                PaymentMethodCode = "PUE",
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

        private async void button22_Click(object sender, EventArgs e)
        {
            // Crear instancia de FiscalApiClient
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

            // Crear una lista de productos o servicios de la factura
            var items = new List<InvoiceItem>()
            {
                new InvoiceItem
                {
                    Id = "2f3c65f3-ed02-452f-944c-97a47010df5c",
                    Quantity = 1,
                    UnitPrice = 288.00m
                },
            };

            // Crear la factura 
            var invoice = new Invoice
            {
                VersionCode = "4.0",
                Series = "SDK-F",
                Date = DateTime.Now,
                PaymentFormCode = "01",
                CurrencyCode = "MXN",
                TypeCode = "I",
                ExpeditionZipCode = "20000",
                Issuer = issuer,
                Recipient = recipient,
                Items = items,
                PaymentMethodCode = "PUE",
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
            // Crear instancia de FiscalApiClient
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

            // Crear una lista de productos o servicios de la factura
            var items = new List<InvoiceItem>()
            {
                new InvoiceItem
                {
                    Id = "037b5705-a9a2-4422-b842-97c0f9347498",
                    Quantity = 1
                },
            };

            // Crear la factura 
            var invoice = new Invoice
            {
                VersionCode = "4.0",
                Series = "SDK-F",
                Date = DateTime.Now,
                PaymentFormCode = "01",
                CurrencyCode = "MXN",
                TypeCode = "I",
                ExpeditionZipCode = "20000",
                Issuer = issuer,
                Recipient = recipient,
                Items = items,
                PaymentMethodCode = "PUE",
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
            // Crear instancia de FiscalApiClient
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

            // Crear una lista de productos o servicios de la factura
            var items = new List<InvoiceItem>()
            {
                new InvoiceItem
                {
                    Id = "037b5705-a9a2-4422-b842-97c0f9347498",
                    Quantity = 1
                },
            };

            var relatedInvoices = new List<RelatedInvoice>()
            {
                new RelatedInvoice
                {
                    RelationshipTypeCode = "02",
                    Uuid = "3f88783d-28cb-4695-bbe3-49e86877cc19",
                }
            };

            // Crear la factura 
            var invoice = new Invoice
            {
                VersionCode = "4.0",
                Series = "SDK-F",
                Date = DateTime.Now,
                PaymentFormCode = "01",
                CurrencyCode = "MXN",
                TypeCode = "I",
                ExpeditionZipCode = "20000",
                Issuer = issuer,
                Recipient = recipient,
                Items = items,
                PaymentMethodCode = "PUE",
                RelatedInvoices = relatedInvoices,
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
            // Crear instancia de FiscalApiClient
            var fiscalApi = FiscalApiClient.Create(_settings);

            var issuer = new InvoiceIssuer
            {
                Id = "0e82a655-5f0c-4e07-abab-8f322e4123ef"
            };

            var recipient = new InvoiceRecipient
            {
                Id = "bd199ed8-02ef-47c0-919c-9479dd8ecae7"
            };

            // Crear una lista de productos o servicios de la factura
            var items = new List<InvoiceItem>()
            {
                new InvoiceItem
                {
                    Id = "2f3c65f3-ed02-452f-944c-97a47010df5c",
                    Quantity = 1,
                    PropertyInfo = new List<PropertyInfo>()
                    {
                        new PropertyInfo
                        {
                        Number = "aB3cD4eF5gH6iJ7kL8mN9oP0"
                        }
                    }
                },
            };

            // Crear la factura 
            var invoice = new Invoice
            {
                VersionCode = "4.0",
                Series = "SDK-F",
                Date = DateTime.Now,
                PaymentFormCode = "01",
                CurrencyCode = "MXN",
                TypeCode = "I",
                ExpeditionZipCode = "20000",
                Issuer = issuer,
                Recipient = recipient,
                Items = items,
                PaymentMethodCode = "PUE",
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
            // Crear instancia de FiscalApiClient
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

            // Crear una lista de productos o servicios de la factura
            var items = new List<InvoiceItem>()
            {
                new InvoiceItem
                {
                    Id = "037b5705-a9a2-4422-b842-97c0f9347498",
                    Quantity = 1
                },
                new InvoiceItem
                {
                    Id = "2f3c65f3-ed02-452f-944c-97a47010df5c",
                    Quantity = 1
                },
                new InvoiceItem
                {
                    Id = "40389443-2aa1-4121-b86a-e8c45fac6b17",
                    Quantity = 1
                },
                new InvoiceItem
                {
                    Id = "783f1e2a-9c55-429d-9e82-c94b620c419c",
                    Quantity = 1
                },
            };

            // Crear la factura 
            var invoice = new Invoice
            {
                VersionCode = "4.0",
                Series = "SDK-F",
                Date = DateTime.Now,
                PaymentFormCode = "99",
                CurrencyCode = "MXN",
                TypeCode = "I",
                ExpeditionZipCode = "20000",
                Issuer = issuer,
                Recipient = recipient,
                Items = items,
                PaymentMethodCode = "PUE",
                GlobalInformation = new GlobalInformation
                {
                    PeriodicityCode = "01",
                    MonthCode = "01",
                    Year = 2026
                }
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
            // Crear instancia de FiscalApiClient
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

            // Crear una lista de productos o servicios de la factura
            var items = new List<InvoiceItem>()
            {
                new InvoiceItem
                {
                    Id = "87d20bd0-da21-4bce-aff4-f113fecfe6df",
                    Quantity = 1,
                    Discount = 20,
                },
            };

            // Crear la factura 
            var invoice = new Invoice
            {
                VersionCode = "4.0",
                Series = "SDK-F",
                Date = DateTime.Now,
                PaymentFormCode = "01",
                CurrencyCode = "MXN",
                TypeCode = "I",
                ExpeditionZipCode = "20000",
                Issuer = issuer,
                Recipient = recipient,
                Items = items,
                PaymentMethodCode = "PUE",
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

        private async void button21_Click(object sender, EventArgs e)
        {
            // Crear instancia de FiscalApiClient
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

            // Crear una lista de productos o servicios de la factura
            var items = new List<InvoiceItem>()
            {
                new InvoiceItem
                {
                    Id = "ec5c5b39-f52d-490e-83d6-437bc1101582",
                    Quantity = 10.236m,
                },
            };

            // Crear la factura 
            var invoice = new Invoice
            {
                VersionCode = "4.0",
                Series = "SDK-F",
                Date = DateTime.Now,
                PaymentFormCode = "01",
                CurrencyCode = "MXN",
                TypeCode = "I",
                ExpeditionZipCode = "20000",
                Issuer = issuer,
                Recipient = recipient,
                Items = items,
                PaymentMethodCode = "PUE",
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
            // Crear instancia de FiscalApiClient
            var fiscalApi = FiscalApiClient.Create(_settings);

            var issuer = new InvoiceIssuer
            {
                Id = "0e82a655-5f0c-4e07-abab-8f322e4123ef"
            };

            var recipient = new InvoiceRecipient
            {
                Id = "bd199ed8-02ef-47c0-919c-9479dd8ecae7"
            };

            // Crear una lista de productos o servicios de la factura
            var items = new List<InvoiceItem>()
            {
                new InvoiceItem
                {
                    Id = "652cc6ec-690f-40bd-97b1-29de4fedd9ee",
                    Quantity = 10.236m,
                },
            };

            // Crear la factura 
            var invoice = new Invoice
            {
                VersionCode = "4.0",
                Series = "SDK-F",
                Date = DateTime.Now,
                PaymentFormCode = "01",
                CurrencyCode = "MXN",
                TypeCode = "I",
                ExpeditionZipCode = "20000",
                Issuer = issuer,
                Recipient = recipient,
                Items = items,
                PaymentMethodCode = "PUE",
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
            // Crear instancia de FiscalApiClient
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

            // Crear una lista de productos o servicios de la factura
            var items = new List<InvoiceItem>()
            {
                new InvoiceItem
                {
                    Id = "10e2e439-3deb-4e63-9e71-fb35177b8d76",
                    Quantity = 1
                },
            };

            // Crear la factura 
            var invoice = new Invoice
            {
                VersionCode = "4.0",
                Series = "SDK-F",
                Date = DateTime.Now,
                PaymentFormCode = "01",
                CurrencyCode = "MXN",
                TypeCode = "I",
                ExpeditionZipCode = "20000",
                Issuer = issuer,
                Recipient = recipient,
                Items = items,
                PaymentMethodCode = "PUE",
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
            // Crear instancia de FiscalApiClient
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

            // Crear una lista de productos o servicios de la factura
            var items = new List<InvoiceItem>()
            {
                new InvoiceItem
                {
                    Id = "037b5705-a9a2-4422-b842-97c0f9347498",
                    Quantity = 1,
                    Parts = new List<InvoiceItemPart>()
                    {
                        new InvoiceItemPart
                        {
                            ItemCode  = "51241200",
                            ItemSku = "IM0071",
                            Quantity = 1,
                            Description = "25311FM00239 (LUARIL ETER SULFATO DE SODIO VEHICULO CBP 300ML), ACEITE AJONJOLI 150CC, ACEITE DE ALMENDRAS DULCES 150CC, TALCO 10GR, OXIDO DE ZINC 10GR.",
                            UnitPrice = 1000.00m
                        }
                    }
                },
            };

            var relatedInvoices = new List<RelatedInvoice>()
            {
                new RelatedInvoice
                {
                    RelationshipTypeCode = "01",
                    Uuid = "3f88783d-28cb-4695-bbe3-49e86877cc19",
                }
            };

            // Crear la factura 
            var invoice = new Invoice
            {
                VersionCode = "4.0",
                Series = "SDK-F",
                Date = DateTime.Now,
                PaymentFormCode = "01",
                CurrencyCode = "MXN",
                TypeCode = "I",
                ExpeditionZipCode = "20000",
                Issuer = issuer,
                Recipient = recipient,
                Items = items,
                PaymentMethodCode = "PUE",
                RelatedInvoices = relatedInvoices,
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
            // Crear instancia de FiscalApiClient
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

            // Crear una lista de productos o servicios de la factura
            var items = new List<InvoiceItem>()
            {
                new InvoiceItem
                {
                    Id = "5d3563d3-7882-4125-8cad-da7b24ffa85c",
                    Quantity = 1
                },
            };

            // Crear la factura 
            var invoice = new Invoice
            {
                VersionCode = "4.0",
                Series = "SDK-F",
                Date = DateTime.Now,
                PaymentFormCode = "01",
                CurrencyCode = "MXN",
                TypeCode = "I",
                ExpeditionZipCode = "20000",
                Issuer = issuer,
                Recipient = recipient,
                Items = items,
                PaymentMethodCode = "PUE",
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
            // Crear instancia de FiscalApiClient
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

            // Crear una lista de productos o servicios de la factura
            var items = new List<InvoiceItem>()
            {
                new InvoiceItem
                {
                    Id = "19d7810c-4284-4dd3-a886-bfaba96449bd",
                    Quantity = 1
                },
            };

            // Crear la factura 
            var invoice = new Invoice
            {
                VersionCode = "4.0",
                Series = "SDK-F",
                Date = DateTime.Now,
                PaymentFormCode = "01",
                CurrencyCode = "MXN",
                TypeCode = "I",
                ExpeditionZipCode = "20000",
                Issuer = issuer,
                Recipient = recipient,
                Items = items,
                PaymentMethodCode = "PUE",
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
            // Crear instancia de FiscalApiClient
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

            // Crear una lista de productos o servicios de la factura
            var items = new List<InvoiceItem>()
            {
                new InvoiceItem
                {
                    Id = "24671e0b-1a5e-4d1c-b05a-81ec682901fc",
                    Quantity = 1
                },
            };

            // Crear la factura 
            var invoice = new Invoice
            {
                VersionCode = "4.0",
                Series = "SDK-F",
                Date = DateTime.Now,
                PaymentFormCode = "01",
                CurrencyCode = "MXN",
                TypeCode = "I",
                ExpeditionZipCode = "20000",
                Issuer = issuer,
                Recipient = recipient,
                Items = items,
                PaymentMethodCode = "PUE",
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
            // Crear instancia de FiscalApiClient
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

            // Crear una lista de productos o servicios de la factura
            var items = new List<InvoiceItem>()
            {
                new InvoiceItem
                {
                    Id = "b8005c9a-6933-4411-b01a-8b17651bfd26",
                    Quantity = 1
                },
            };

            // Crear la factura 
            var invoice = new Invoice
            {
                VersionCode = "4.0",
                Series = "SDK-F",
                Date = DateTime.Now,
                PaymentFormCode = "01",
                CurrencyCode = "MXN",
                TypeCode = "I",
                ExpeditionZipCode = "20000",
                Issuer = issuer,
                Recipient = recipient,
                Items = items,
                PaymentMethodCode = "PUE",
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
            // Crear instancia de FiscalApiClient
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

            // Crear una lista de productos o servicios de la factura
            var items = new List<InvoiceItem>()
            {
                new InvoiceItem
                {
                    Id = "86f713f8-c67e-4b74-ba31-642d689a9980",
                    Quantity = 1
                },
            };

            var globalInfo = new GlobalInformation
            {
                Year = 2026,
                MonthCode = "01",
                PeriodicityCode = "01"
            };

            // Crear la factura 
            var invoice = new Invoice
            {
                VersionCode = "4.0",
                Series = "SDK-F",
                Date = DateTime.Now,
                PaymentFormCode = "01",
                CurrencyCode = "MXN",
                TypeCode = "I",
                ExpeditionZipCode = "20000",
                Issuer = issuer,
                Recipient = recipient,
                Items = items,
                PaymentMethodCode = "PUE",
                GlobalInformation = globalInfo
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
            // Crear instancia de FiscalApiClient
            var fiscalApi = FiscalApiClient.Create(_settings);

            var issuer = new InvoiceIssuer
            {
                Id = "0e82a655-5f0c-4e07-abab-8f322e4123ef"
            };

            var recipient = new InvoiceRecipient
            {
                Id = "a8903553-7220-4b15-bdb1-e64cd19f5203"
            };

            // Crear una lista de productos o servicios de la factura
            var items = new List<InvoiceItem>()
            {
                new InvoiceItem
                {
                    Id = "86f713f8-c67e-4b74-ba31-642d689a9980",
                    Quantity = 1
                },
            };

            var globalInformation = new GlobalInformation
            {
                MonthCode = "01",
                Year = 2026,
                PeriodicityCode = "01"
            };

            // Crear la factura 
            var invoice = new Invoice
            {
                VersionCode = "4.0",
                Series = "SDK-F",
                Date = DateTime.Now,
                PaymentFormCode = "01",
                CurrencyCode = "MXN",
                TypeCode = "I",
                ExpeditionZipCode = "45610",
                Issuer = issuer,
                Recipient = recipient,
                Items = items,
                GlobalInformation = globalInformation,
                PaymentMethodCode = "PUE",
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
            // Crear instancia de FiscalApiClient
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

            // Crear una lista de productos o servicios de la factura
            var items = new List<InvoiceItem>()
            {
                new InvoiceItem
                {
                    Id = "2b1d05d3-0ca8-4d48-a675-53313be8d217",
                    Quantity = 1
                },
            };

            // Crear la factura 
            var invoice = new Invoice
            {
                VersionCode = "4.0",
                Series = "SDK-F",
                Date = DateTime.Now,
                PaymentFormCode = "01",
                CurrencyCode = "MXN",
                TypeCode = "I",
                ExpeditionZipCode = "20000",
                Issuer = issuer,
                Recipient = recipient,
                Items = items,
                PaymentMethodCode = "PUE",
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

        private async void button20_Click(object sender, EventArgs e)
        {
            // Crear instancia de FiscalApiClient
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

            // Crear una lista de productos o servicios de la factura
            var items = new List<InvoiceItem>()
            {
                new InvoiceItem
                {
                    Id = "4d94412e-4ed9-4ac6-8ae7-67004c470518",
                    Quantity = 1
                },
            };

            // Crear la factura 
            var invoice = new Invoice
            {
                VersionCode = "4.0",
                Series = "SDK-F",
                Date = DateTime.Now,
                PaymentFormCode = "01",
                CurrencyCode = "MXN",
                TypeCode = "I",
                ExpeditionZipCode = "20000",
                Issuer = issuer,
                Recipient = recipient,
                Items = items,
                PaymentMethodCode = "PUE",
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
            // Crear instancia de FiscalApiClient
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

            // Crear una lista de productos o servicios de la factura
            var items = new List<InvoiceItem>()
            {
                new InvoiceItem
                {
                    Id = "86b63573-5ac2-42ef-b506-c8732f85cfd0",
                    Quantity = 1
                },
            };

            // Crear la factura 
            var invoice = new Invoice
            {
                VersionCode = "4.0",
                Series = "SDK-F",
                Date = DateTime.Now,
                PaymentFormCode = "01",
                CurrencyCode = "MXN",
                TypeCode = "I",
                ExpeditionZipCode = "20000",
                Issuer = issuer,
                Recipient = recipient,
                Items = items,
                PaymentMethodCode = "PUE",
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
            // Crear instancia de FiscalApiClient
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

            // Crear una lista de productos o servicios de la factura
            var items = new List<InvoiceItem>()
            {
                new InvoiceItem
                {
                    Id = "037b5705-a9a2-4422-b842-97c0f9347498",
                    Quantity = 1
                },
            };

            // Crear la factura 
            var invoice = new Invoice
            {
                VersionCode = "4.0",
                Series = "SDK-F",
                Date = DateTime.Now,
                PaymentFormCode = "01",
                CurrencyCode = "MXN",
                TypeCode = "I",
                ExpeditionZipCode = "20000",
                Issuer = issuer,
                Recipient = recipient,
                Items = items,
                PaymentMethodCode = "PUE",
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
