using Fiscalapi.Common;
using Fiscalapi.Models;
using Fiscalapi.Services;
using Newtonsoft.Json;
using System;
using System.Windows.Forms;

namespace FiscalApi.Samples.NetFramework
{
    public partial class EmployeeForm : Form
    {
        private FiscalapiSettings _settings;
        public EmployeeForm(FiscalapiSettings settings)
        {
            InitializeComponent();
            _settings = settings;
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            var fiscalApi = FiscalApiClient.Create(_settings);

            var apiResponse = await fiscalApi.Persons.Employee.GetByIdAsync("0e82a655-5f0c-4e07-abab-8f322e4123ef");

            if (apiResponse.Succeeded)
            {
                MessageBox.Show(JsonConvert.SerializeObject(apiResponse.Data));
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            var fiscalApi = FiscalApiClient.Create(_settings);

            string personId = "bd199ed8-02ef-47c0-919c-9479dd8ecae7";
            EmployeeData requestModel = new EmployeeData()
            {
                EmployerPersonId = "0e82a655-5f0c-4e07-abab-8f322e4123ef",
                EmployeePersonId = personId,
                EmployeeNumber = "12345",
                SatContractTypeId = "01",
                SatTaxRegimeTypeId = "02",
                SatPaymentPeriodicityId = "04",
                SatPayrollStateId = "JAL",
                SocialSecurityNumber = "1234567890",
                LaborRelationStartDate = DateTime.Parse("2023-01-15T00:00:00"),
                SatWorkdayTypeId = "01",
                SatJobRiskId = "1",
                SatBankId = "002",
                SatUnionizedStatusId = "No",
                Department = "Recursos humanos",
                Position = "Analista de nóminas",
                Seniority = "7Y3M1W",
                BankAccount = "12345678900987654321",
                BaseSalaryForContributions = 490.22m,
                IntegratedDailySalary = 146.47m,
                SubcontractorRfc = null,
                TimePercentage = 0
            };
            var apiResponse = await fiscalApi.Persons.Employee.CreateAsync(requestModel);

            if (apiResponse.Succeeded)
            {
                MessageBox.Show(JsonConvert.SerializeObject(apiResponse.Data, Formatting.Indented));
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var fiscalapi = FiscalApiClient.Create(_settings);
            string personId = "bd199ed8-02ef-47c0-919c-9479dd8ecae7";
            EmployeeData requestModel = new EmployeeData()
            {
                EmployerPersonId = "0e82a655-5f0c-4e07-abab-8f322e4123ef",
                EmployeePersonId = personId,
                EmployeeNumber = "09987675",
                SatContractTypeId = "01",
                SatTaxRegimeTypeId = "05",
                SatPaymentPeriodicityId = "01",
                SatPayrollStateId = "JAL",
                SocialSecurityNumber = "589685956948945",
                LaborRelationStartDate = DateTime.Parse("2023-01-15T00:00:00"),
                SatWorkdayTypeId = "01",
                SatJobRiskId = "1",
                SatBankId = "012",
                SatUnionizedStatusId = "No",
                Department = "RRHH",
                Position = "Analista de pagos",
                Seniority = "7Y3M1W",
                BankAccount = "585887494956848",
                BaseSalaryForContributions = 490.22m,
                IntegratedDailySalary = 146.47m,
                SubcontractorRfc = null,
                TimePercentage = 0
            };

            var apiResponse = await fiscalapi.Persons.Employee.UpdateAsync(requestModel);

            if (apiResponse.Succeeded)
            {
                MessageBox.Show(JsonConvert.SerializeObject(apiResponse.Data, Formatting.Indented));
            }
            else
            {
                MessageBox.Show(apiResponse.Details);
            }
        }

        private async void button9_Click(object sender, EventArgs e)
        {
            var fiscalapi = FiscalApiClient.Create(_settings);
            string personId = "bd199ed8-02ef-47c0-919c-9479dd8ecae7";

            var apiResponse = await fiscalapi.Persons.Employee.DeleteAsync(personId);

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
