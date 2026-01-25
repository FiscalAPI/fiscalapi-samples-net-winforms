using Fiscalapi.Common;
using Fiscalapi.Models;
using Fiscalapi.Services;
using System;
using System.Windows.Forms;

namespace FiscalApi.Samples.NetFramework
{
    public partial class DownloadRulesForm : Form
    {
        private FiscalapiSettings _settings;
        public DownloadRulesForm(FiscalapiSettings settings)
        {
            InitializeComponent();
            _settings = settings;
        }

        private async void button11_Click(object sender, EventArgs e)
        {
            // Obtener lista paginada de reglas de descarga masiva

            // Create instance of FiscalApiClient
            var fiscalApi = FiscalApiClient.Create(_settings);

            // Send request (pageNumber=1, pageSize=2)
            var apiResponse = await fiscalApi.DownloadRules.GetListAsync(1, 2);

            // Check response
            if (apiResponse.Succeeded)
            {
                foreach (var item in apiResponse.Data.Items)
                    MessageBox.Show($@"Producto: {item.Description}");
            }
            else
            {
                MessageBox.Show($@"HttpStatusCode: {apiResponse.HttpStatusCode}");
                MessageBox.Show(apiResponse.Message);
                MessageBox.Show(apiResponse.Details);
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            // Create instance of FiscalApiClient
            var fiscalApi = FiscalApiClient.Create(_settings);

            // Send request
            var apiResponse = await fiscalApi.DownloadRules.GetByIdAsync("59ccad08-5d3a-48ab-95fa-b7f80f9b00c7");

            // Check response
            if (apiResponse.Succeeded)
            {
                var product = apiResponse.Data;
                MessageBox.Show("OK");
                MessageBox.Show($@"Regla: {product.Description}");
            }
            else
            {
                MessageBox.Show($@"HttpStatusCode: {apiResponse.HttpStatusCode}");
                MessageBox.Show(apiResponse.Message);
                MessageBox.Show(apiResponse.Details);
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            // Create instance of FiscalApiClient
            var fiscalApi = FiscalApiClient.Create(_settings);

            // Regla para descargar CFDI recibidos y vigentes.
            var request = new DownloadRule
            {
                PersonId = "b0c1cf6c-153a-464e-99df-5741f45d6695", //Persona que recibió los CFDI
                Description = "Regla descarga demo ...",
                SatQueryTypeId = "CFDI",
                DownloadTypeId = "Recibidos",
                SatInvoiceStatusId = "Vigente",
            };

            // Send request
            var apiResponse = await fiscalApi.DownloadRules.CreateAsync(request);

            // Check response

            if (apiResponse.Succeeded)
            {
                MessageBox.Show(@"Regla creada.");
                MessageBox.Show($@" {apiResponse.Data.Description}");
            }
            else
            {
                MessageBox.Show($@"HttpStatusCode: {apiResponse.HttpStatusCode}");
                MessageBox.Show(apiResponse.Message);
                MessageBox.Show(apiResponse.Details);
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            // Create instance of FiscalApiClient
            var fiscalApi = FiscalApiClient.Create(_settings);

            // Send request
            var apiResponse = await fiscalApi.DownloadRules.CreateTestRuleAsync();

            // Check response
            if (apiResponse.Succeeded)
            {
                MessageBox.Show(@"Regla creada.");
                MessageBox.Show($@" {apiResponse.Data.Id}");
            }
            else
            {
                MessageBox.Show($@"HttpStatusCode: {apiResponse.HttpStatusCode}");
                MessageBox.Show(apiResponse.Message);
                MessageBox.Show(apiResponse.Details);
            }
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            // Actualizar regla de descarga masiva

            // Create instance of FiscalApiClient
            var fiscalApi = FiscalApiClient.Create(_settings);

            var id = "8d5905f3-d7e1-46b7-b0f4-9f3a2528bb56";

            // Actualizar descripción.
            var request = new DownloadRule
            {
                Id = id,
                Description = "Regla descarga actualizada",
            };

            // Send request
            var apiResponse = await fiscalApi.DownloadRules.UpdateAsync(id, request);

            // Check response

            if (apiResponse.Succeeded)
            {
                MessageBox.Show(@"Regla actualizada.");
                MessageBox.Show($@" {apiResponse.Data.Description}");
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
            // Create instance of FiscalApiClient
            var fiscalApi = FiscalApiClient.Create(_settings);

            // Send request
            var apiResponse = await fiscalApi.DownloadRules.DeleteAsync("2029b977-31d5-4911-a7ba-23bda12e97f2");

            // Check response
            if (apiResponse.Succeeded)
            {
                MessageBox.Show($@"Regla borrada {apiResponse.Data}");
            }
            else
            {
                MessageBox.Show($@"HttpStatusCode: {apiResponse.HttpStatusCode}");
                MessageBox.Show(apiResponse.Message);
                MessageBox.Show(apiResponse.Details);
            }
        }
    }
}
