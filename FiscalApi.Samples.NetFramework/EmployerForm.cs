using Fiscalapi.Common;
using Fiscalapi.Services;
using FiscalApi.Samples.NetFramework.Properties;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FiscalApi.Samples.NetFramework
{
    public partial class EmployerForm : Form
    {
        private FiscalapiSettings _settings;
        public EmployerForm(FiscalapiSettings settings)
        {
            InitializeComponent();
            _settings = settings;
        }

        private async void button9_Click(object sender, EventArgs e)
        {
            var fiscalApi = FiscalApiClient.Create(_settings);

            var apiResponse = await fiscalApi.Persons.Employer.GetByIdAsync("0e82a655-5f0c-4e07-abab-8f322e4123ef");

            if (apiResponse.Succeeded)
            {
                MessageBox.Show(JsonConvert.SerializeObject(apiResponse.Data, Formatting.Indented));
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var fiscalApi = FiscalApiClient.Create(_settings);

            string personId = "bd199ed8-02ef-47c0-919c-9479dd8ecae7";
            EmployerData requestModel = new EmployerData()
            {
                PersonId = personId,
                EmployerRegistration = "abc1234567890",
                OriginEmployerTin = "MEQA951024HC9",
                OwnResourceAmount = 10000.0M
            };
            var apiResponse = await fiscalApi.Persons.Employer.CreateAsync(requestModel);

            if (apiResponse.Succeeded)
            {
                MessageBox.Show(JsonConvert.SerializeObject(apiResponse.Data, Formatting.Indented));
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            var fiscalapi = FiscalApiClient.Create(_settings);
            string personId = "bd199ed8-02ef-47c0-919c-9479dd8ecae7";
            EmployerData requestModel = new EmployerData()
            {
                PersonId = personId,
                EmployerRegistration = "xyz0987654321",
                OriginEmployerTin = "URE180429TM6",
                OwnResourceAmount = 98.5M,
                SatFundSourceId = "IF"
            };

            var apiResponse = await fiscalapi.Persons.Employer.UpdateAsync(requestModel);

            if (apiResponse.Succeeded)
            {
                MessageBox.Show(JsonConvert.SerializeObject(apiResponse.Data, Formatting.Indented));
            }
            else
            {
                MessageBox.Show(apiResponse.Details);
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            var fiscalapi = FiscalApiClient.Create(_settings);
            string personId = "bd199ed8-02ef-47c0-919c-9479dd8ecae7";

            var apiResponse = await fiscalapi.Persons.Employer.DeleteAsync(personId);

            if (apiResponse.Succeeded)
            {
                MessageBox.Show(apiResponse.Data.ToString());
            }
            else
            {
                MessageBox.Show(apiResponse.Details);
            }
        }
    }
}
