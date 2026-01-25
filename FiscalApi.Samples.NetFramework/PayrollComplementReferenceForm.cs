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
    public partial class PayrollComplementReferenceForm : Form
    {
        private FiscalapiSettings _settings;

        public PayrollComplementReferenceForm(FiscalapiSettings settings)
        {
            InitializeComponent();
            _settings = settings;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            // https://docs.fiscalapi.com/credentials-info

            var fiscalApi = FiscalApiClient.Create(_settings);

            // Emisor
            var issuer = new InvoiceIssuer
            {
                Id = "0e82a655-5f0c-4e07-abab-8f322e4123ef"
            };

            // Receptor
            var recipient = new InvoiceRecipient
            {
                Id = "da71df0c-f328-45ee-9bd9-3096ed02c164"
            };

            var payroll = new Payroll
            {
                Version = "1.2",
                PayrollTypeCode = "O",
                PaymentDate = DateTime.Parse("2025-08-30"),
                InitialPaymentDate = DateTime.Parse("2025-07-31"),
                FinalPaymentDate = DateTime.Parse("2025-08-30"),
                DaysPaid = 30,
                Earnings = new PayrollEarnings
                {
                    Earnings = new List<PayrollEarning>()
                    {
                        new PayrollEarning
                        {
                            EarningTypeCode = "001",
                            Code = "1003",
                            Concept = "Sueldo Nominal",
                            TaxedAmount = 95030.00m,
                            ExemptAmount = 0.00m
                        },
                        new PayrollEarning
                        {
                            EarningTypeCode = "005",
                            Code = "5913",
                            Concept = "Fondo de Ahorro Aportación Patrón",
                            TaxedAmount = 0.00m,
                            ExemptAmount = 4412.46m
                        },
                        new PayrollEarning
                        {
                            EarningTypeCode = "038",
                            Code = "1885",
                            Concept = "Bono Ingles",
                            TaxedAmount = 14254.50m,
                            ExemptAmount = 0.00m
                        },
                        new PayrollEarning
                        {
                            EarningTypeCode = "029",
                            Code = "1941",
                            Concept = "Vales Despensa",
                            TaxedAmount = 0.00m,
                            ExemptAmount = 3439.00m
                        },
                        new PayrollEarning
                        {
                            EarningTypeCode = "038",
                            Code = "1824",
                            Concept = "Herramientas Teletrabajo (telecom y prop. electri)",
                            TaxedAmount = 273.00m,
                            ExemptAmount = 0.00m
                        }
                    },
                    OtherPayments = new List<PayrollEarningOtherPayment>()
                    {
                        new PayrollEarningOtherPayment
                        {
                            OtherPaymentTypeCode = "002",
                            Code = "5050",
                            Concept = "Exceso de subsidio al empleo",
                            Amount = 0.0m,
                            SubsidyCaused = 0.0m
                        }
                    }
                },
                Deductions = new List<PayrollDeduction>()
                {
                    new PayrollDeduction
                    {
                        DeductionTypeCode = "002",
                        Code = "5003",
                        Concept = "ISR Causado",
                        Amount = 27645.52m
                    },
                    new PayrollDeduction
                    {
                        DeductionTypeCode = "004",
                        Code = "5910",
                        Concept = "Fondo de ahorro Empleado Inversión",
                        Amount = 4412.46m
                    },
                    new PayrollDeduction
                    {
                        DeductionTypeCode = "004",
                        Code = "5914",
                        Concept = "Fondo de Ahorro Patrón Inversión",
                        Amount = 4412.46m
                    },
                    new PayrollDeduction
                    {
                        DeductionTypeCode = "004",
                        Code = "1966",
                        Concept = "Contribución póliza exceso GMM",
                        Amount = 519.91m
                    },
                    new PayrollDeduction
                    {
                        DeductionTypeCode = "004",
                        Code = "1934",
                        Concept = "Descuento Vales Despensa",
                        Amount = 1.00m
                    },
                    new PayrollDeduction
                    {
                        DeductionTypeCode = "004",
                        Code = "1942",
                        Concept = "Vales Despensa Electrónico",
                        Amount = 3439.00m
                    },
                    new PayrollDeduction
                    {
                        DeductionTypeCode = "001",
                        Code = "1895",
                        Concept = "IMSS",
                        Amount = 2391.13m
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
                TypeCode = "N",
                ExpeditionZipCode = "20000",
                Issuer = issuer,
                Recipient = recipient,
                Complement = new Complement { Payroll = payroll },
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
            // https://docs.fiscalapi.com/credentials-info

            var fiscalApi = FiscalApiClient.Create(_settings);

            // Emisor
            var issuer = new InvoiceIssuer
            {
                Id = "0e82a655-5f0c-4e07-abab-8f322e4123ef"
            };

            // Receptor
            var recipient = new InvoiceRecipient
            {
                Id = "acf43966-4672-48b6-a01a-d04cac6c3d64"
            };

            var payroll = new Payroll
            {
                Version = "1.2",
                PayrollTypeCode = "E",
                PaymentDate = DateTime.Parse("2023-06-02T00:00:00"),
                InitialPaymentDate = DateTime.Parse("2023-06-01T00:00:00"),
                FinalPaymentDate = DateTime.Parse("2023-06-02T00:00:00"),
                DaysPaid = 1,
                Earnings = new PayrollEarnings
                {
                    Earnings = new List<PayrollEarning>()
                    {
                        new PayrollEarning
                        {
                            EarningTypeCode = "046",
                            Code = "010046",
                            Concept = "INGRESOS ASIMILADOS A SALARIOS",
                            TaxedAmount = 111197.73m,
                            ExemptAmount = 0.00m
                        }
                    },
                    OtherPayments = new List<PayrollEarningOtherPayment>() { }
                },
                Deductions = new List<PayrollDeduction>()
                {
                    new PayrollDeduction
                    {
                        DeductionTypeCode = "002",
                        Code = "020002",
                        Concept = "ISR",
                        Amount = 36197.73m
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
                TypeCode = "N",
                ExpeditionZipCode = "06880",
                Issuer = issuer,
                Recipient = recipient,
                Complement = new Complement { Payroll = payroll },
                PaymentMethodCode = "PUE",
                ExportCode = "01"
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
            // https://docs.fiscalapi.com/credentials-info

            var fiscalApi = FiscalApiClient.Create(_settings);

            // Emisor
            var issuer = new InvoiceIssuer
            {
                Id = "0e82a655-5f0c-4e07-abab-8f322e4123ef"
            };

            // Receptor
            var recipient = new InvoiceRecipient
            {
                Id = "da71df0c-f328-45ee-9bd9-3096ed02c164"
            };

            var payroll = new Payroll
            {
                Version = "1.2",
                PayrollTypeCode = "O",
                PaymentDate = DateTime.Parse("2023-06-11T00:00:00"),
                InitialPaymentDate = DateTime.Parse("2023-06-05T00:00:00"),
                FinalPaymentDate = DateTime.Parse("2023-06-11T00:00:00"),
                DaysPaid = 7,
                Earnings = new PayrollEarnings
                {
                    Earnings = new List<PayrollEarning>()
                    {
                        new PayrollEarning
                        {
                            EarningTypeCode = "001",
                            Code = "SP01",
                            Concept = "Sueldo Nominal",
                            TaxedAmount = 1210.30m,
                            ExemptAmount = 0.00m
                        },
                        new PayrollEarning
                        {
                            EarningTypeCode = "010",
                            Code = "SP02",
                            Concept = "Premio de puntualidad",
                            TaxedAmount = 121.03m,
                            ExemptAmount = 0.00m
                        },
                        new PayrollEarning
                        {
                            EarningTypeCode = "029",
                            Code = "SP03",
                            Concept = "Monedero electrónico",
                            TaxedAmount = 00.00m,
                            ExemptAmount = 269.43m
                        },
                        new PayrollEarning
                        {
                            EarningTypeCode = "010",
                            Code = "SP04",
                            Concept = "Premio de asistencia",
                            TaxedAmount = 121.03m,
                            ExemptAmount = 00.00m
                        },
                        new PayrollEarning
                        {
                            EarningTypeCode = "005",
                            Code = "SP54",
                            Concept = "Aportación fondo de ahorro",
                            TaxedAmount = 0.00m,
                            ExemptAmount = 121.03m
                        }
                    },
                    OtherPayments = new List<PayrollEarningOtherPayment>()
                    {
                        new PayrollEarningOtherPayment
                        {
                            OtherPaymentTypeCode = "002",
                            Code = "ISRSUB",
                            Concept = "Exceso de subsidio al empleo",
                            Amount = 0.0m,
                            SubsidyCaused = 0.0m,
                            BalanceCompensation = new BalanceCompensation
                            {
                                FavorableBalance = 0.00m,
                                Year = 2022,
                                RemainingFavorableBalance = 0.00m
                            }
                        }
                    }
                },
                Deductions = new List<PayrollDeduction>()
                {
                    new PayrollDeduction
                    {
                        DeductionTypeCode = "004",
                        Code = "ZA09",
                        Concept = "Aportación fondo de ahorro",
                        Amount = 121.03m
                    },
                    new PayrollDeduction
                    {
                        DeductionTypeCode = "002",
                        Code = "ISR",
                        Concept = "ISR",
                        Amount = 36.57m
                    },
                    new PayrollDeduction
                    {
                        DeductionTypeCode = "001",
                        Code = "IMSS",
                        Concept = "Cuota de seguridad social EE",
                        Amount = 30.08m
                    },
                    new PayrollDeduction
                    {
                        DeductionTypeCode = "004",
                        Code = "ZA68",
                        Concept = "Deducción fondo de ahorro patrón",
                        Amount = 121.03m
                    },
                    new PayrollDeduction
                    {
                        DeductionTypeCode = "018",
                        Code = "ZA11",
                        Concept = "Aportación caja de ahorro",
                        Amount = 300.00m
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
                TypeCode = "N",
                ExpeditionZipCode = "20000",
                ExportCode = "01",
                Issuer = issuer,
                Recipient = recipient,
                Complement = new Complement { Payroll = payroll },
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
            // https://docs.fiscalapi.com/credentials-info

            var fiscalApi = FiscalApiClient.Create(_settings);

            // Emisor
            var issuer = new InvoiceIssuer
            {
                Id = "0e82a655-5f0c-4e07-abab-8f322e4123ef"
            };

            // Receptor
            var recipient = new InvoiceRecipient
            {
                Id = "aa2ad8c3-6ec5-4601-91be-d827d9a865bc"
            };

            var payroll = new Payroll
            {
                Version = "1.2",
                PayrollTypeCode = "O",
                PaymentDate = DateTime.Parse("2023-05-24T00:00:00"),
                InitialPaymentDate = DateTime.Parse("2023-05-09T00:00:00"),
                FinalPaymentDate = DateTime.Parse("2023-05-24T00:00:00"),
                DaysPaid = 15,
                Earnings = new PayrollEarnings
                {
                    Earnings = new List<PayrollEarning>()
                    {
                        new PayrollEarning
                        {
                            EarningTypeCode = "001",
                            Code = "00500",
                            Concept = "Sueldos, Salarios Rayas y Jornales",
                            TaxedAmount = 2808.80m,
                            ExemptAmount = 2191.20m
                        },
                        new PayrollEarning
                        {
                            EarningTypeCode = "019",
                            Code = "00100",
                            Concept = "Horas extra",
                            TaxedAmount = 50.00m,
                            ExemptAmount = 50.00m,
                            Overtime = new List<PayrollEarningOvertime>
                            {
                                new PayrollEarningOvertime
                                {
                                    Days = 1,
                                    HoursTypeCode = "01",
                                    ExtraHours = 2,
                                    AmountPaid = 100.00m
                                }
                            }
                        }
                    },
                    OtherPayments = { }
                },
                Deductions = new List<PayrollDeduction>()
                {
                    new PayrollDeduction
                    {
                        DeductionTypeCode = "001",
                        Code = "00301",
                        Concept = "Seguridad social",
                        Amount = 200.00m
                    },
                    new PayrollDeduction
                    {
                        DeductionTypeCode = "002",
                        Code = "00302",
                        Concept = "ISR",
                        Amount = 100.00m
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
                TypeCode = "N",
                ExpeditionZipCode = "20000",
                ExportCode = "01",
                Issuer = issuer,
                Recipient = recipient,
                Complement = new Complement { Payroll = payroll },
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
            // https://docs.fiscalapi.com/credentials-info

            var fiscalApi = FiscalApiClient.Create(_settings);

            // Emisor
            var issuer = new InvoiceIssuer
            {
                Id = "0e82a655-5f0c-4e07-abab-8f322e4123ef"
            };

            // Receptor
            var recipient = new InvoiceRecipient
            {
                Id = "aa2ad8c3-6ec5-4601-91be-d827d9a865bc"
            };

            var payroll = new Payroll
            {
                Version = "1.2",
                PayrollTypeCode = "O",
                PaymentDate = DateTime.Parse("2023-05-24T00:00:00"),
                InitialPaymentDate = DateTime.Parse("2023-05-09T00:00:00"),
                FinalPaymentDate = DateTime.Parse("2023-05-24T00:00:00"),
                DaysPaid = 15,
                Earnings = new PayrollEarnings
                {
                    Earnings = new List<PayrollEarning>()
                    {
                        new PayrollEarning
                        {
                            EarningTypeCode = "001",
                            Code = "00500",
                            Concept = "Sueldos, Salarios Rayas y Jornales",
                            TaxedAmount = 2808.80m,
                            ExemptAmount = 2191.20m
                        }
                    },
                    OtherPayments = new List<PayrollEarningOtherPayment>() { }
                },
                Deductions = new List<PayrollDeduction>()
                {
                    new PayrollDeduction
                    {
                        DeductionTypeCode = "001",
                        Code = "00301",
                        Concept = "Seguridad social",
                        Amount = 200.00m
                    },
                    new PayrollDeduction
                    {
                        DeductionTypeCode = "002",
                        Code = "00302",
                        Concept = "ISR",
                        Amount = 100.00m
                    }
                },
                Disabilities = new List<PayrollDisability>()
                {
                    new PayrollDisability
                    {
                        DisabilityDays = 1,
                        DisabilityTypeCode = "01"
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
                TypeCode = "N",
                ExpeditionZipCode = "20000",
                ExportCode = "01",
                Issuer = issuer,
                Recipient = recipient,
                Complement = new Complement { Payroll = payroll },
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
            // https://docs.fiscalapi.com/credentials-info

            var fiscalApi = FiscalApiClient.Create(_settings);

            // Emisor
            var issuer = new InvoiceIssuer
            {
                Id = "ab7ec306-6f81-4f9f-b55f-bbbb1ab2f153"
            };

            // Receptor
            var recipient = new InvoiceRecipient
            {
                Id = "acf43966-4672-48b6-a01a-d04cac6c3d64"
            };

            var payroll = new Payroll
            {
                Version = "1.2",
                PayrollTypeCode = "O",
                PaymentDate = DateTime.Parse("2023-05-16T00:00:00"),
                InitialPaymentDate = DateTime.Parse("2023-05-01T00:00:00"),
                FinalPaymentDate = DateTime.Parse("2023-05-16T00:00:00"),
                DaysPaid = 15,
                Earnings = new PayrollEarnings
                {
                    Earnings = new List<PayrollEarning>()
                    {
                        new PayrollEarning
                        {
                            EarningTypeCode = "001",
                            Code = "P01",
                            Concept = "Sueldos, Salarios Rayas y Jornales",
                            TaxedAmount = 3322.00m,
                            ExemptAmount = 0.00m
                        },
                        new PayrollEarning
                        {
                            EarningTypeCode = "038",
                            Code = "P540",
                            Concept = "Compensación",
                            TaxedAmount = 100.00m,
                            ExemptAmount = 0.00m
                        },
                        new PayrollEarning
                        {
                            EarningTypeCode = "038",
                            Code = "P550",
                            Concept = "Compensación Garantizada Extraordinaria",
                            TaxedAmount = 2200.00m,
                            ExemptAmount = 0.00m
                        },
                        new PayrollEarning
                        {
                            EarningTypeCode = "038",
                            Code = "P530",
                            Concept = "Servicio extraordinario",
                            TaxedAmount = 200.00m,
                            ExemptAmount = 0.00m
                        },
                        new PayrollEarning
                        {
                            EarningTypeCode = "001",
                            Code = "P506",
                            Concept = "Otras prestaciones",
                            TaxedAmount = 1500.00m,
                            ExemptAmount = 0.00m
                        },
                        new PayrollEarning
                        {
                            EarningTypeCode = "001",
                            Code = "P505",
                            Concept = "Remuneración del desempeño legislativo",
                            TaxedAmount = 17500.00m,
                            ExemptAmount = 0.00m
                        }
                    },
                    OtherPayments = new List<PayrollEarningOtherPayment>()
                    {
                        new PayrollEarningOtherPayment
                        {
                            OtherPaymentTypeCode = "002",
                            Code = "002",
                            Concept = "Exceso de subsidio al empleo",
                            Amount = 0.0m,
                            SubsidyCaused = 0.0m
                        }
                    }
                },
                Deductions = new List<PayrollDeduction>()
                {
                    new PayrollDeduction
                    {
                        DeductionTypeCode = "002",
                        Code = "D002",
                        Concept = "ISR",
                        Amount = 4716.61m
                    },
                    new PayrollDeduction
                    {
                        DeductionTypeCode = "004",
                        Code = "D525",
                        Concept = "Redondeo",
                        Amount = 0.81m
                    },
                    new PayrollDeduction
                    {
                        DeductionTypeCode = "001",
                        Code = "D510",
                        Concept = "Cuota Trabajador ISSSTE",
                        Amount = 126.78m
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
                TypeCode = "N",
                ExpeditionZipCode = "39074",
                Issuer = issuer,
                Recipient = recipient,
                Complement = new Complement { Payroll = payroll },
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

        private async void button7_Click(object sender, EventArgs e)
        {
            // https://docs.fiscalapi.com/credentials-info

            var fiscalApi = FiscalApiClient.Create(_settings);

            // Emisor
            var issuer = new InvoiceIssuer
            {
                Id = "0e82a655-5f0c-4e07-abab-8f322e4123ef"
            };

            // Receptor
            var recipient = new InvoiceRecipient
            {
                Id = "aa2ad8c3-6ec5-4601-91be-d827d9a865bc"
            };

            var payroll = new Payroll
            {
                Version = "1.2",
                PayrollTypeCode = "E",
                PaymentDate = DateTime.Parse("2023-06-04T00:00:00"),
                InitialPaymentDate = DateTime.Parse("2023-06-04T00:00:00"),
                FinalPaymentDate = DateTime.Parse("2023-06-04T00:00:00"),
                DaysPaid = 30,
                Earnings = new PayrollEarnings
                {
                    Earnings = new List<PayrollEarning>()
                    {
                        new PayrollEarning
                        {
                            EarningTypeCode = "002",
                            Code = "00500",
                            Concept = "Gratificación Anual (Aguinaldo)",
                            TaxedAmount = 0.00m,
                            ExemptAmount = 10000.00m
                        }
                    },
                    OtherPayments = { }
                },
                Deductions = { }
            };

            // Crear la factura 
            var invoice = new Invoice
            {
                VersionCode = "4.0",
                Series = "SDK-F",
                Date = DateTime.Now,
                CurrencyCode = "MXN",
                TypeCode = "N",
                ExpeditionZipCode = "20000",
                ExportCode = "01",
                Issuer = issuer,
                Recipient = recipient,
                Complement = new Complement { Payroll = payroll },
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
            // https://docs.fiscalapi.com/credentials-info

            var fiscalApi = FiscalApiClient.Create(_settings);

            // Emisor
            var issuer = new InvoiceIssuer
            {
                Id = "0e82a655-5f0c-4e07-abab-8f322e4123ef"
            };

            // Receptor
            var recipient = new InvoiceRecipient
            {
                Id = "aa2ad8c3-6ec5-4601-91be-d827d9a865bc"
            };

            var payroll = new Payroll
            {
                Version = "1.2",
                PayrollTypeCode = "E",
                PaymentDate = DateTime.Parse("2023-06-04T00:00:00"),
                InitialPaymentDate = DateTime.Parse("2023-06-04T00:00:00"),
                FinalPaymentDate = DateTime.Parse("2023-06-04T00:00:00"),
                DaysPaid = 30,
                Earnings = new PayrollEarnings
                {
                    Earnings = new List<PayrollEarning>()
                    {
                        new PayrollEarning
                        {
                            EarningTypeCode = "023",
                            Code = "00500",
                            Concept = "Pagos por separación",
                            TaxedAmount = 0.00m,
                            ExemptAmount = 10000.00m
                        },
                        new PayrollEarning
                        {
                            EarningTypeCode = "025",
                            Code = "00900",
                            Concept = "Indemnizaciones",
                            TaxedAmount = 0.00m,
                            ExemptAmount = 500.00m
                        }
                    },
                    OtherPayments = { },
                    Severance = new PayrollSeverance()
                    {
                        TotalPaid = 10500.00m,
                        YearsOfService = 1,
                        LastMonthlySalary = 10000.00m,
                        AccumulableIncome = 10000.00m,
                        NonAccumulableIncome = 0.00m
                    }
                },
                Deductions = { }
            };

            // Crear la factura 
            var invoice = new Invoice
            {
                VersionCode = "4.0",
                Series = "SDK-F",
                Date = DateTime.Now,
                CurrencyCode = "MXN",
                TypeCode = "N",
                ExpeditionZipCode = "20000",
                ExportCode = "01",
                Issuer = issuer,
                Recipient = recipient,
                Complement = new Complement { Payroll = payroll },
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
            // https://docs.fiscalapi.com/credentials-info

            var fiscalApi = FiscalApiClient.Create(_settings);

            // Emisor
            var issuer = new InvoiceIssuer
            {
                Id = "0e82a655-5f0c-4e07-abab-8f322e4123ef"
            };

            // Receptor
            var recipient = new InvoiceRecipient
            {
                Id = "aa2ad8c3-6ec5-4601-91be-d827d9a865bc"
            };

            var payroll = new Payroll
            {
                Version = "1.2",
                PayrollTypeCode = "E",
                PaymentDate = DateTime.Parse("2023-06-04T00:00:00"),
                InitialPaymentDate = DateTime.Parse("2023-06-04T00:00:00"),
                FinalPaymentDate = DateTime.Parse("2023-06-04T00:00:00"),
                DaysPaid = 30,
                Earnings = new PayrollEarnings
                {
                    Earnings = new List<PayrollEarning>()
                    {
                        new PayrollEarning
                        {
                            EarningTypeCode = "039",
                            Code = "00500",
                            Concept = "Jubilaciones, pensiones o haberes de retiro",
                            TaxedAmount = 0.00m,
                            ExemptAmount = 10000.00m
                        }
                    },
                    OtherPayments = { },
                    Retirement = new PayrollRetirement
                    {
                        TotalOneTime = 10000.00m,
                        AccumulableIncome = 10000.00m,
                        NonAccumulableIncome = 0.00m
                    }
                },
                Deductions = { }
            };

            // Crear la factura 
            var invoice = new Invoice
            {
                VersionCode = "4.0",
                Series = "SDK-F",
                Date = DateTime.Now,
                CurrencyCode = "MXN",
                TypeCode = "N",
                ExpeditionZipCode = "20000",
                ExportCode = "01",
                Issuer = issuer,
                Recipient = recipient,
                Complement = new Complement { Payroll = payroll },
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

        private void PayrollComplementReferenceForm_Load(object sender, EventArgs e)
        {
            
        }

        private async void button10_Click(object sender, EventArgs e)
        {
            // https://docs.fiscalapi.com/credentials-info

            var fiscalApi = FiscalApiClient.Create(_settings);

            // Emisor
            var issuer = new InvoiceIssuer
            {
                Id = "0e82a655-5f0c-4e07-abab-8f322e4123ef"
            };

            // Receptor
            var recipient = new InvoiceRecipient
            {
                Id = "aa2ad8c3-6ec5-4601-91be-d827d9a865bc"
            };

            var payroll = new Payroll
            {
                Version = "1.2",
                PayrollTypeCode = "O",
                PaymentDate = DateTime.Parse("2023-06-04T00:00:00"),
                InitialPaymentDate = DateTime.Parse("2023-06-04T00:00:00"),
                FinalPaymentDate = DateTime.Parse("2023-06-04T00:00:00"),
                DaysPaid = 15,
                Earnings = new PayrollEarnings
                {
                    Earnings = new List<PayrollEarning>()
                    {
                        new PayrollEarning
                        {
                            EarningTypeCode = "001",
                            Code = "00500",
                            Concept = "Jubilaciones, pensiones o haberes de retiro",
                            TaxedAmount = 2808.80m,
                            ExemptAmount = 2191.20m
                        }
                    },
                    OtherPayments = { },
                },
                Deductions = { }
            };

            // Crear la factura 
            var invoice = new Invoice
            {
                VersionCode = "4.0",
                Series = "SDK-F",
                Date = DateTime.Now,
                CurrencyCode = "MXN",
                TypeCode = "N",
                ExpeditionZipCode = "20000",
                ExportCode = "01",
                Issuer = issuer,
                Recipient = recipient,
                Complement = new Complement { Payroll = payroll },
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
            // https://docs.fiscalapi.com/credentials-info

            var fiscalApi = FiscalApiClient.Create(_settings);

            // Emisor
            var issuer = new InvoiceIssuer
            {
                Id = "0e82a655-5f0c-4e07-abab-8f322e4123ef"
            };

            // Receptor
            var recipient = new InvoiceRecipient
            {
                Id = "aa2ad8c3-6ec5-4601-91be-d827d9a865bc"
            };

            var payroll = new Payroll
            {
                Version = "1.2",
                PayrollTypeCode = "O",
                PaymentDate = DateTime.Parse("2023-05-24T00:00:00"),
                InitialPaymentDate = DateTime.Parse("2023-05-09T00:00:00"),
                FinalPaymentDate = DateTime.Parse("2023-05-24T00:00:00"),
                DaysPaid = 15,
                Earnings = new PayrollEarnings
                {
                    Earnings = new List<PayrollEarning>()
                    {
                        new PayrollEarning
                        {
                            EarningTypeCode = "001",
                            Code = "00500",
                            Concept = "Sueldos, salarios rayas y jornales",
                            TaxedAmount = 2808.80m,
                            ExemptAmount = 2191.20m
                        }
                    },
                    OtherPayments = new List<PayrollEarningOtherPayment>()
                    {
                        new PayrollEarningOtherPayment
                        {
                            OtherPaymentTypeCode = "007",
                            Code = "002",
                            Concept = "ISR ajustado por subsidio",
                            Amount = 145.80m,
                            SubsidyCaused = 0.00m
                        }
                    },
                },
                Deductions = new List<PayrollDeduction>()
                {
                    new PayrollDeduction
                    {
                        DeductionTypeCode = "107",
                        Code = "D002",
                        Concept = "Ajuste al subsidio causado",
                        Amount = 160.35m,
                    },
                    new PayrollDeduction
                    {
                        DeductionTypeCode = "002",
                        Code = "D002",
                        Concept = "ISR",
                        Amount = 145.80m
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
                TypeCode = "N",
                ExpeditionZipCode = "20000",
                ExportCode = "01",
                Issuer = issuer,
                Recipient = recipient,
                Complement = new Complement { Payroll = payroll },
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
            // https://docs.fiscalapi.com/credentials-info

            var fiscalApi = FiscalApiClient.Create(_settings);

            // Emisor
            var issuer = new InvoiceIssuer
            {
                Id = "0e82a655-5f0c-4e07-abab-8f322e4123ef"
            };

            // Receptor
            var recipient = new InvoiceRecipient
            {
                Id = "aa2ad8c3-6ec5-4601-91be-d827d9a865bc"
            };

            var payroll = new Payroll
            {
                Version = "1.2",
                PayrollTypeCode = "O",
                PaymentDate = DateTime.Parse("2023-09-26T00:00:00"),
                InitialPaymentDate = DateTime.Parse("2023-09-11T00:00:00"),
                FinalPaymentDate = DateTime.Parse("2023-09-26T00:00:00"),
                DaysPaid = 15,
                Earnings = new PayrollEarnings
                {
                    Earnings = new List<PayrollEarning>()
                    {
                        new PayrollEarning
                        {
                            EarningTypeCode = "050",
                            Code = "050",
                            Concept = "Viáticos",
                            TaxedAmount = 0.00m,
                            ExemptAmount = 3000.00m
                        }
                    },
                    OtherPayments = { },
                },
                Deductions = new List<PayrollDeduction>()
                {
                    new PayrollDeduction
                    {
                        DeductionTypeCode = "081",
                        Code = "081",
                        Concept = "Ajuste en viaticos entregados al trabajador",
                        Amount = 3000.00m,
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
                TypeCode = "N",
                ExpeditionZipCode = "20000",
                ExportCode = "01",
                Issuer = issuer,
                Recipient = recipient,
                Complement = new Complement { Payroll = payroll },
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

        private async void button13_Click(object sender, EventArgs e)
        {
            // https://docs.fiscalapi.com/credentials-info

            var fiscalApi = FiscalApiClient.Create(_settings);

            // Emisor
            var issuer = new InvoiceIssuer
            {
                Id = "0e82a655-5f0c-4e07-abab-8f322e4123ef"
            };

            // Receptor
            var recipient = new InvoiceRecipient
            {
                Id = "aa2ad8c3-6ec5-4601-91be-d827d9a865bc"
            };

            var payroll = new Payroll
            {
                Version = "1.2",
                PayrollTypeCode = "O",
                PaymentDate = DateTime.Parse("2023-05-24T00:00:00"),
                InitialPaymentDate = DateTime.Parse("2023-05-09T00:00:00"),
                FinalPaymentDate = DateTime.Parse("2023-05-24T00:00:00"),
                DaysPaid = 15,
                Earnings = new PayrollEarnings
                {
                    Earnings = new List<PayrollEarning>()
                    {
                        new PayrollEarning
                        {
                            EarningTypeCode = "001",
                            Code = "00500",
                            Concept = "Sueldos, salarios rayas y jornales",
                            TaxedAmount = 2808.80m,
                            ExemptAmount = 2191.20m
                        }
                    },
                    OtherPayments = { },
                },
                Deductions = new List<PayrollDeduction>()
                {
                    new PayrollDeduction
                    {
                        DeductionTypeCode = "001",
                        Code = "00301",
                        Concept = "Seguridad social",
                        Amount = 200.00m,
                    },
                    new PayrollDeduction
                    {
                        DeductionTypeCode = "002",
                        Code = "00302",
                        Concept = "ISR",
                        Amount = 100.00m
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
                TypeCode = "N",
                ExpeditionZipCode = "20000",
                ExportCode = "01",
                Issuer = issuer,
                Recipient = recipient,
                Complement = new Complement { Payroll = payroll },
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
