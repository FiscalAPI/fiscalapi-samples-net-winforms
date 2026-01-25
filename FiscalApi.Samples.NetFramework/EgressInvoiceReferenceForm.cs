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
    public partial class EgressInvoiceReferenceForm : Form
    {
        private FiscalapiSettings _settings;

        public EgressInvoiceReferenceForm(FiscalapiSettings settings)
        {
            _settings = settings;
            InitializeComponent();
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

            var relatedInvoices = new List<RelatedInvoice>()
            {
                new RelatedInvoice { RelationshipTypeCode = "03", Uuid = "8335e91e-5c43-4cef-9ed0-b4985ddc2ca8" }
            };

            // Crear una lista de productos o servicios de la factura
            var items = new List<InvoiceItem>()
            {
                new InvoiceItem
                {
                    Id = "2f3c65f3-ed02-452f-944c-97a47010df5c",
                    Quantity = 1
                }
            };

            // Crear la factura 
            var invoice = new Invoice
            {
                VersionCode = "4.0",
                Series = "SDK-F",
                Date = DateTime.Now,
                PaymentFormCode = "99",
                CurrencyCode = "MXN",
                TypeCode = "E",
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

            var relatedInvoices = new List<RelatedInvoice>()
            {
                new RelatedInvoice { RelationshipTypeCode = "01", Uuid = "8335e91e-5c43-4cef-9ed0-b4985ddc2ca8" }
            };

            // Crear una lista de productos o servicios de la factura
            var items = new List<InvoiceItem>()
            {
                new InvoiceItem
                {
                    Id = "2f3c65f3-ed02-452f-944c-97a47010df5c",
                    Description = "10% del saldo de todos los CFDI relacionados",
                    Quantity = 1,
                    UnitPrice = 10
                }
            };

            // Crear la factura 
            var invoice = new Invoice
            {
                VersionCode = "4.0",
                Series = "SDK-F",
                Date = DateTime.Now,
                PaymentFormCode = "99",
                CurrencyCode = "MXN",
                TypeCode = "E",
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

            var relatedInvoices = new List<RelatedInvoice>()
            {
                new RelatedInvoice
                {
                    RelationshipTypeCode = "01",
                    Uuid = "8335e91e-5c43-4cef-9ed0-b4985ddc2ca8"
                }
            };

            // Crear una lista de productos o servicios de la factura
            var items = new List<InvoiceItem>()
            {
                new InvoiceItem
                {
                    Id = "2f3c65f3-ed02-452f-944c-97a47010df5c",
                    Description = "10% del saldo de todos los CFDI relacionados",
                    Quantity = 0.50m,
                }
            };

            // Crear la factura 
            var invoice = new Invoice
            {
                VersionCode = "4.0",
                Series = "SDK-F",
                Date = DateTime.Now,
                PaymentFormCode = "99",
                CurrencyCode = "MXN",
                TypeCode = "E",
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
