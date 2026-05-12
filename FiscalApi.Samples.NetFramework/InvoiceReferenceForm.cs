using Fiscalapi.Common;
using Fiscalapi.Models;
using Fiscalapi.Services;
using System;
using System.IO;
using System.Windows.Forms;

namespace FiscalApi.Samples.NetFramework
{
    public partial class InvoiceReferenceForm : Form
    {
        private FiscalapiSettings _settings;
        public InvoiceReferenceForm(FiscalapiSettings settings)
        {
            InitializeComponent();
            _settings = settings;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            IncomeInvoiceReferenceForm incomeInvoiceReferenceForm = new IncomeInvoiceReferenceForm(_settings);
            incomeInvoiceReferenceForm.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            PaymentComplementInvoiceForm paymentComplementInvoiceForm = new PaymentComplementInvoiceForm(_settings);
            paymentComplementInvoiceForm.Show();
        }

        private async void button8_Click(object sender, EventArgs e)
        {
            /*Generar PDF de factura por referencias*/

            // Crear instancia de FiscalApiClient
            var fiscalApi = FiscalApiClient.Create(_settings);


            // request model (utiliza las reglas de reporte https://docs.fiscalapi.com/report-rules-info)
            var request = new CreatePdfRequest
            {
                InvoiceId = "51a3a6d3-b617-4a6b-8a67-cbfd654c7e90",
            };

            // Send request
            var apiResponse = await fiscalApi.Invoices.GetPdfAsync(request);

            // Check response
            if (apiResponse.Succeeded)
            {
                var pdfBytes = Convert.FromBase64String(apiResponse.Data.Base64File);

                File.WriteAllBytes(@"C:\facturas\MyFile.PDF", pdfBytes);
                MessageBox.Show(@"PDF generado.");
            }
            else
            {
                MessageBox.Show($@"HttpStatusCode: {apiResponse.HttpStatusCode}");
                MessageBox.Show(apiResponse.Message);
                MessageBox.Show(apiResponse.Details);
            }
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            // Consultar estado de una factura por referencias (por id de la factura)

            // Create instance of FiscalApiClient
            var fiscalApi = FiscalApiClient.Create(_settings);


            // model request
            var request = new InvoiceStatusRequest
            {
                Id = "bda0b31d-e1e0-4644-91ea-c6f0e90fb57c", // Id, No folio fiscal (UUID). 
            };

            // Send request
            var apiResponse = await fiscalApi.Invoices.GetStatusAsync(request);

            // Check response
            if (apiResponse.Succeeded)
            {
                MessageBox.Show("OK");
                MessageBox.Show($@"Estado: {apiResponse.Data.Status}");
            }
            else
            {
                MessageBox.Show($@"HttpStatusCode: {apiResponse.HttpStatusCode}");
                MessageBox.Show(apiResponse.Message);
                MessageBox.Show(apiResponse.Details);
            }
        }

        private async void button7_Click(object sender, EventArgs e)
        {
            /*Cancelar factura por referencias */


            // Crear instancia de FiscalApiClient
            var fiscalApi = FiscalApiClient.Create(_settings);

            // request model
            var request = new CancelInvoiceRequest()
            {
                Id = "630a41d1-00ce-4750-8f8c-7b36786134d0", // Id factura en fiscalapi
                CancellationReasonCode = "01",
                ReplacementUuid = "de841944-bd4f-4bb8-adfe-2a2282787c62",
            };

            // Cancelar la factura
            var apiResponse = await fiscalApi.Invoices.CancelAsync(request);

            if (apiResponse.Succeeded)
            {
                MessageBox.Show("Factura cancelada exitosamente");
            }
            else
            {
                MessageBox.Show($@"HttpStatusCode: {apiResponse.HttpStatusCode}");
                MessageBox.Show(apiResponse.Message);
                MessageBox.Show(apiResponse.Details);
            }
        }

        private async void button6_Click(object sender, EventArgs e)
        {
            /* Enviar factura por referencia*/

            // Crear instancia de FiscalApiClient
            var fiscalApi = FiscalApiClient.Create(_settings);

            // request model (personaliza el pdf de la factura)
            var request = new SendInvoiceRequest
            {
                InvoiceId = "51a3a6d3-b617-4a6b-8a67-cbfd654c7e90",
                ToEmail = "mendoza.git@gmail.com", // email1@dominio;email2@dominio
            };

            // Send request
            var apiResponse = await fiscalApi.Invoices.SendAsync(request);

            // Check response
            if (apiResponse.Succeeded)
            {
                MessageBox.Show(@"Factura enviada.");
            }
            else
            {
                MessageBox.Show($@"HttpStatusCode: {apiResponse.HttpStatusCode}");
                MessageBox.Show(apiResponse.Message);
                MessageBox.Show(apiResponse.Details);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            EgressInvoiceReferenceForm egressInvoiceReferenceForm = new EgressInvoiceReferenceForm(_settings);
            egressInvoiceReferenceForm.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            PayrollComplementReferenceForm payrollComplementReferenceForm = new PayrollComplementReferenceForm(_settings);
            payrollComplementReferenceForm.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            LocalTaxesComplementReferenceForm localTaxesComplementReference = new LocalTaxesComplementReferenceForm(_settings);
            localTaxesComplementReference.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            BillOfLadingReferenceForm billOfLadingReferenceForm = new BillOfLadingReferenceForm(_settings);
            billOfLadingReferenceForm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ComercioExteriorReferenceForm comercioExteriorReferenceForm = new ComercioExteriorReferenceForm(_settings);
            comercioExteriorReferenceForm.Show();
        }
    }
}
