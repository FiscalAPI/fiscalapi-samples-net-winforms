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
    public partial class LocalTaxesComplementReferenceForm : Form
    {
        private FiscalapiSettings _settings;

        public LocalTaxesComplementReferenceForm(FiscalapiSettings settings)
        {
            InitializeComponent();
            _settings = settings;
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

            var items = new List<InvoiceItem>()
            {
                new InvoiceItem
                {
                    ItemCode = "01010101",
                    Quantity = 9.5m,
                    UnitOfMeasurementCode = "E48",
                    UnitOfMeasurement = "Unidad de servicio",
                    Description = "Invoicing software as a service",
                    UnitPrice = 3587.75m,
                    TaxObjectCode = "02",
                    ItemSku = "7506022301697",
                    Discount = 255.85m,
                    ItemTaxes = new List<InvoiceItemTax>()
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
                    ItemCode = "01010101",
                    Quantity = 8m,
                    UnitOfMeasurementCode = "E48",
                    UnitOfMeasurement = "Unidad de servicio2",
                    Description = "Software consultant",
                    UnitPrice = 250.85m,
                    TaxObjectCode = "02",
                    ItemSku = "7506022301698",
                    Discount = 255.85m,
                    ItemTaxes = new List<InvoiceItemTax>()
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
                    ItemCode = "01010101",
                    Quantity = 6m,
                    UnitOfMeasurementCode = "E48",
                    UnitOfMeasurement = "Unidad de servicio3",
                    Description = "Computer software",
                    UnitPrice = 1250.75m,
                    TaxObjectCode = "02",
                    ItemSku = "7506022301699",
                    Discount = 0.00m,
                    ItemTaxes = new List<InvoiceItemTax>()
                    {
                        new InvoiceItemTax
                        {
                            TaxCode = "002",
                            TaxTypeCode = "Tasa",
                            TaxRate = 0.160000m,
                            TaxFlagCode = "T"
                        },
                        new InvoiceItemTax
                        {
                            TaxCode = "002",
                            TaxTypeCode = "Tasa",
                            TaxRate = 0.106666m,
                            TaxFlagCode = "R"
                        }
                    }
                }
            };

            var complement = new Complement
            {
                LocalTaxes = new LocalTaxes
                {
                    Taxes = new List<LocalTax>
                    {
                        new LocalTax
                        {
                            TaxName = "CEDULAR",
                            TaxRate = 3.00m,
                            TaxAmount = 6.00m,
                            TaxFlagCode = "R"
                        },
                        new LocalTax
                        {
                            TaxName = "ISH",
                            TaxRate = 8.00m,
                            TaxAmount = 16.00m,
                            TaxFlagCode = "R"
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
                PaymentFormCode = "01",
                CurrencyCode = "MXN",
                TypeCode = "I",
                ExpeditionZipCode = "42501",
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
                    ItemCode = "01010101",
                    Quantity = 9.5m,
                    UnitOfMeasurementCode = "E48",
                    UnitOfMeasurement = "Unidad de servicio",
                    Description = "Invoicing software as a service",
                    UnitPrice = 3587.75m,
                    TaxObjectCode = "02",
                    ItemSku = "7506022301697",
                    Discount = 255.85m,
                    ItemTaxes = new List<InvoiceItemTax>()
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
                    ItemCode = "01010101",
                    Quantity = 8m,
                    UnitOfMeasurementCode = "E48",
                    UnitOfMeasurement = "Unidad de servicio2",
                    Description = "Software consultant",
                    UnitPrice = 250.85m,
                    TaxObjectCode = "02",
                    ItemSku = "7506022301698",
                    Discount = 255.85m,
                    ItemTaxes = new List<InvoiceItemTax>()
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
                    ItemCode = "01010101",
                    Quantity = 6m,
                    UnitOfMeasurementCode = "E48",
                    UnitOfMeasurement = "Unidad de servicio3",
                    Description = "Computer software",
                    UnitPrice = 1250.75m,
                    TaxObjectCode = "02",
                    ItemSku = "7506022301699",
                    Discount = 0.00m,
                    ItemTaxes = new List<InvoiceItemTax>()
                    {
                        new InvoiceItemTax
                        {
                            TaxCode = "002",
                            TaxTypeCode = "Tasa",
                            TaxRate = 0.160000m,
                            TaxFlagCode = "T"
                        },
                        new InvoiceItemTax
                        {
                            TaxCode = "002",
                            TaxTypeCode = "Tasa",
                            TaxRate = 0.106666m,
                            TaxFlagCode = "R"
                        }
                    }
                }
            };

            var complement = new Complement
            {
                LocalTaxes = new LocalTaxes
                {
                    Taxes = new List<LocalTax>
                    {
                        new LocalTax
                        {
                            TaxName = "CEDULAR",
                            TaxRate = 3.00m,
                            TaxAmount = 6.00m,
                            TaxFlagCode = "R"
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
                PaymentFormCode = "01",
                CurrencyCode = "MXN",
                TypeCode = "I",
                ExpeditionZipCode = "42501",
                Issuer = issuer,
                Recipient = recipient,
                Items = items,
                Complement = complement,
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
                    ItemCode = "01010101",
                    Quantity = 9.5m,
                    UnitOfMeasurementCode = "E48",
                    UnitOfMeasurement = "Unidad de servicio",
                    Description = "Invoicing software as a service",
                    UnitPrice = 3587.75m,
                    TaxObjectCode = "02",
                    ItemSku = "7506022301697",
                    Discount = 255.85m,
                    ItemTaxes = new List<InvoiceItemTax>()
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
                    ItemCode = "01010101",
                    Quantity = 8m,
                    UnitOfMeasurementCode = "E48",
                    UnitOfMeasurement = "Unidad de servicio2",
                    Description = "Software consultant",
                    UnitPrice = 250.85m,
                    TaxObjectCode = "02",
                    ItemSku = "7506022301698",
                    Discount = 255.85m,
                    ItemTaxes = new List<InvoiceItemTax>()
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
                    ItemCode = "01010101",
                    Quantity = 6m,
                    UnitOfMeasurementCode = "E48",
                    UnitOfMeasurement = "Unidad de servicio3",
                    Description = "Computer software",
                    UnitPrice = 1250.75m,
                    TaxObjectCode = "02",
                    ItemSku = "7506022301699",
                    Discount = 0.00m,
                    ItemTaxes = new List<InvoiceItemTax>()
                    {
                        new InvoiceItemTax
                        {
                            TaxCode = "002",
                            TaxTypeCode = "Tasa",
                            TaxRate = 0.160000m,
                            TaxFlagCode = "T"
                        },
                        new InvoiceItemTax
                        {
                            TaxCode = "002",
                            TaxTypeCode = "Tasa",
                            TaxRate = 0.106666m,
                            TaxFlagCode = "R"
                        }
                    }
                }
            };

            var complement = new Complement
            {
                LocalTaxes = new LocalTaxes
                {
                    Taxes = new List<LocalTax>
                    {
                        new LocalTax
                        {
                            TaxName = "ISH",
                            TaxRate = 8.00m,
                            TaxAmount = 16.00m,
                            TaxFlagCode = "R"
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
                PaymentFormCode = "01",
                CurrencyCode = "MXN",
                TypeCode = "I",
                ExpeditionZipCode = "42501",
                Issuer = issuer,
                Recipient = recipient,
                Items = items,
                Complement = complement,
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
