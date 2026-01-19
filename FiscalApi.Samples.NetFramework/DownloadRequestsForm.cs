using Fiscalapi.Common;
using Fiscalapi.Models;
using Fiscalapi.Services;
using FiscalApi.Samples.NetFramework.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FiscalApi.Samples.NetFramework
{
    public partial class DownloadRequestsForm : Form
    {
        private FiscalapiSettings _settings;
        public DownloadRequestsForm(FiscalapiSettings settings)
        {
            InitializeComponent();
            _settings = settings;
        }

        private async void button9_Click(object sender, EventArgs e)
        {
            // Obtener lista paginada de solicitudes de descarga masiva

            // Create instance of FiscalApiClient
            var fiscalApi = FiscalApiClient.Create(_settings);

            // Send request (pageNumber=1, pageSize=2)
            var apiResponse = await fiscalApi.DownloadRequests.GetListAsync(1, 2);

            // Check response
            if (apiResponse.Succeeded)
            {
                foreach (var item in apiResponse.Data.Items)
                    MessageBox.Show($@"RFC solicitante: {item.RequesterTin}");
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
            // Buscar solicitud de descarga masiva por fecha de creación.
            // Create instance of FiscalApiClient
            var fiscalApi = FiscalApiClient.Create(_settings);
            // Send request
            var apiResponse = await fiscalApi.DownloadRequests.SearchAsync(DateTime.Now);

            // Check response
            if (apiResponse.Succeeded)
            {
                MessageBox.Show("OK");
                foreach (var item in apiResponse.Data)
                    MessageBox.Show($@"Solicitud: {item.Id} - {item.SatInvoiceStatus.Description}");
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
            var apiResponse = await fiscalApi.DownloadRequests.GetByIdAsync("4e376d60-8ab0-47d7-a82d-eb13583aaf22");

            // Check response
            if (apiResponse.Succeeded)
            {
                var product = apiResponse.Data;
                MessageBox.Show("OK");
                MessageBox.Show($@"RFC solicitante:  {product.RequesterTin}");
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
            // Obtener lista paginada de xmls descargados asociados a una solicitud de descarga.
            var fiscalApi = FiscalApiClient.Create(_settings);

            // request
            var apiResponse = await fiscalApi.DownloadRequests.GetXmlsAsync("4e376d60-8ab0-47d7-a82d-eb13583aaf22");

            // Check response
            if (apiResponse.Succeeded)
            {
                foreach (var xml in apiResponse.Data.Items)
                    MessageBox.Show($@"Factura: Serie:{xml.Series} Folio:{xml.Number}");
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
            // Obtener lista paginada de metadatos descargados asociados a una solicitud de descarga.
            var fiscalApi = FiscalApiClient.Create(_settings);

            // request
            var apiResponse =
                await fiscalApi.DownloadRequests.GetMetadataItemsAsync("4e376d60-8ab0-47d7-a82d-eb13583aaf22");

            // Check response
            if (apiResponse.Succeeded)
            {
                foreach (var metadataItem in apiResponse.Data.Items)
                    MessageBox.Show($@" Factura UUID:{metadataItem.InvoiceUuid} Receptor:{metadataItem.RecipientName}");
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
            // Descargar paquete (.zip file) de una solicitud de descarga masiva.

            var fiscalApi = FiscalApiClient.Create(_settings);
            // Send request
            var apiResponse =
                await fiscalApi.DownloadRequests.DownloadPackageAsync("4e376d60-8ab0-47d7-a82d-eb13583aaf22");
            // Check response
            if (apiResponse.Succeeded)
            {
                Form1.WriteFileToDisk(apiResponse.Data.FirstOrDefault());
                MessageBox.Show(@"Archivo descargado.");
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
            // Descargar SAT request (.xml file) de una solicitud de descarga masiva. (debug/testing)
            var fiscalApi = FiscalApiClient.Create(_settings);
            // Send request
            var apiResponse =
                await fiscalApi.DownloadRequests.DownloadSatRequestAsync("4e376d60-8ab0-47d7-a82d-eb13583aaf22");
            // Check response
            if (apiResponse.Succeeded)
            {
                Form1.WriteFileToDisk(apiResponse.Data);
                MessageBox.Show(@"Archivo descargado.");
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
            // Descargar SAT response (.xml file) de una solicitud de descarga masiva. (debug/testing)
            var fiscalApi = FiscalApiClient.Create(_settings);
            // Send request
            var apiResponse = await fiscalApi.DownloadRequests
                .DownloadSatResponseAsync("4e376d60-8ab0-47d7-a82d-eb13583aaf22");

            // Check response
            if (apiResponse.Succeeded)
            {
                Form1.WriteFileToDisk(apiResponse.Data);
                MessageBox.Show(@"Archivo descargado.");
            }
            else
            {
                MessageBox.Show($@"HttpStatusCode: {apiResponse.HttpStatusCode}");
                MessageBox.Show(apiResponse.Message);
                MessageBox.Show(apiResponse.Details);
            }
        }

        private async void button8_Click(object sender, EventArgs e)
        {
            // Crear solicitud de descarga masiva
            var fiscalApi = FiscalApiClient.Create(_settings);

            // Crear solicitud para descargar facturas de los últimos 5 días.
            var request = new DownloadRequest
            {
                DownloadRuleId = "89aba371-3f9a-431c-a92d-dcb1e606fcfd",
                DownloadRequestTypeId = "Manual",
                StartDate = DateTime.Now.AddDays(-5),
                EndDate = DateTime.Now,
            };

            // Send request
            var apiResponse = await fiscalApi.DownloadRequests.CreateAsync(request);

            // Check response
            if (apiResponse.Succeeded)
            {
                MessageBox.Show(@"Solicitud creada.");
                MessageBox.Show($@" {apiResponse.Data.Id}");
            }
            else
            {
                MessageBox.Show($@"HttpStatusCode: {apiResponse.HttpStatusCode}");
                MessageBox.Show(apiResponse.Message);
                MessageBox.Show(apiResponse.Details);
            }
        }

        private async void button10_Click(object sender, EventArgs e)
        {
            // Eliminar solicitud de descarga masiva.

            // Create instance of FiscalApiClient
            var fiscalApi = FiscalApiClient.Create(_settings);
            // Send request

            var apiResponse = await fiscalApi.DownloadRequests.DeleteAsync("4763983b-f587-4497-8b87-7f3645589ac9");
            // Check response
            if (apiResponse.Succeeded)
            {
                MessageBox.Show($@"Solicitud borrada {apiResponse.Data}");
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
