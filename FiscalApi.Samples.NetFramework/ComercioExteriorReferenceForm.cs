using Fiscalapi.Common;
using Fiscalapi.Models;
using Fiscalapi.Models.BillOfLading;
using Fiscalapi.Models.ForeignTrade;
using Fiscalapi.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FiscalApi.Samples.NetFramework
{
    public partial class ComercioExteriorReferenceForm : Form
    {
        private FiscalapiSettings _settings;

        public ComercioExteriorReferenceForm(FiscalapiSettings settings)
        {
            InitializeComponent();
            _settings = settings;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }

        private Emisor CreateCommonEmisor()
        {
            return new Emisor
            {
                Domicilio = new EmisorDomicilio
                {
                    Calle = "CALLE DEL PAPEL",
                    ColoniaId = "0214",
                    LocalidadId = "01",
                    MunicipioId = "014",
                    EstadoId = "QUE",
                    PaisId = "MEX",
                    CodigoPostalId = "76199"
                }
            };
        }

        private Receptor CreateCommonReceptorTX(bool includeNumRegIdTrib)
        {
            var receptor = new Receptor
            {
                Domicilio = new ReceptorDomicilio
                {
                    Calle = "ST. A",
                    Estado = "TX",
                    PaisId = "USA",
                    CodigoPostal = "00000"
                }
            };
            if (includeNumRegIdTrib) receptor.NumRegIdTrib = "123456789";
            return receptor;
        }

        private void ShowResult<T>(ApiResponse<T> apiResponse)
        {
            if (apiResponse.Succeeded)
                MessageBox.Show("Timbrada: " + apiResponse.Succeeded);
            else
            {
                MessageBox.Show(apiResponse.Message);
                MessageBox.Show(apiResponse.Details);
            }
        }

        // Factura CE Ingreso Con Carta Porte 31 (USD, PUE)
        private async void FacturaCEIngresoConCartaPorte31Button_Click(object sender, EventArgs e)
        {
            var fiscalApi = FiscalApiClient.Create(_settings);

            var invoice = new Invoice
            {
                VersionCode = "4.0",
                PaymentFormCode = "99",
                PaymentMethodCode = "PUE",
                CurrencyCode = "USD",
                TypeCode = "I",
                ExpeditionZipCode = "42501",
                Series = "CCE",
                Date = DateTime.Parse("2026-05-08T08:56:40"),
                PaymentConditions = "CondicionesDePago",
                ExportCode = "02",
                Issuer = new InvoiceIssuer { Id = "2e7b988f-3a2a-4f67-86e9-3f931dd48581" },
                Recipient = new InvoiceRecipient { Id = "109f4d94-63ea-4a21-ab15-20c8b87d8ee9" },
                Items = new List<InvoiceItem>
                {
                    new InvoiceItem
                    {
                        ItemCode = "78101800", ItemSku = "SERV02", Quantity = 1.000000m,
                        UnitOfMeasurementCode = "HUR", Description = "FLETE", UnitPrice = 2300.000000m,
                        Discount = 0, TaxObjectCode = "02",
                        ItemTaxes = new List<InvoiceItemTax>
                        {
                            new InvoiceItemTax { TaxCode = "002", TaxTypeCode = "Tasa", TaxRate = 0.160000m, TaxFlagCode = "T" },
                            new InvoiceItemTax { TaxCode = "003", TaxTypeCode = "Tasa", TaxRate = 0.300000m, TaxFlagCode = "R" }
                        }
                    },
                    new InvoiceItem
                    {
                        ItemCode = "50161509", ItemSku = "A0001", Quantity = 1.000000m,
                        UnitOfMeasurementCode = "H87", Description = "Gomitas", UnitPrice = 120.000000m,
                        Discount = 0, TaxObjectCode = "02",
                        ItemTaxes = new List<InvoiceItemTax>
                        {
                            new InvoiceItemTax { TaxCode = "002", TaxTypeCode = "Tasa", TaxRate = 0.160000m, TaxFlagCode = "T" }
                        }
                    },
                    new InvoiceItem
                    {
                        ItemCode = "50307037", ItemSku = "A0002", Quantity = 1.000000m,
                        UnitOfMeasurementCode = "H87", Description = "Pulparindo", UnitPrice = 100.000000m,
                        Discount = 0, TaxObjectCode = "02",
                        ItemTaxes = new List<InvoiceItemTax>
                        {
                            new InvoiceItemTax { TaxCode = "002", TaxTypeCode = "Tasa", TaxRate = 0.160000m, TaxFlagCode = "T" }
                        }
                    }
                },
                Complement = new Complement
                {
                    CartaPorte = new CartaPorte
                    {
                        TranspInternacId = "Sí",
                        EntradaSalidaMercId = "Salida",
                        PaisOrigenDestinoId = "ALB",
                        ViaEntradaSalidaId = "01",
                        TotalDistRec = 120.00m,
                        UnidadPesoId = "KGM",
                        RegimenAduaneros = new List<RegimenAduanero>
                        {
                            new RegimenAduanero { RegimenAduaneroId = "EXD" }
                        },
                        Ubicaciones = new List<Ubicacion>
                        {
                            new Ubicacion
                            {
                                TipoUbicacion = "Origen", IDUbicacion = "OR000001",
                                RFCRemitenteDestinatario = "XAXX010101000", NombreRemitenteDestinatario = "Origen Nacional",
                                FechaHoraSalidaLlegada = DateTime.Parse("2026-04-27T08:00:00"),
                                Domicilio = new UbicacionDomicilio
                                {
                                    Calle = "xola", NumeroExterior = "531", ColoniaId = "0496",
                                    LocalidadId = "03", MunicipioId = "014", EstadoId = "CMX",
                                    PaisId = "MEX", CodigoPostalId = "03100"
                                }
                            },
                            new Ubicacion
                            {
                                TipoUbicacion = "Destino", IDUbicacion = "DE000001",
                                RFCRemitenteDestinatario = "XAXX010101000", NombreRemitenteDestinatario = "Destino Nacional",
                                FechaHoraSalidaLlegada = DateTime.Parse("2026-04-27T20:00:00"),
                                DistanciaRecorrida = 120.00m,
                                Domicilio = new UbicacionDomicilio
                                {
                                    Calle = "Av Coyoacan", NumeroExterior = "120", ColoniaId = "2624",
                                    LocalidadId = "03", MunicipioId = "014", EstadoId = "CMX",
                                    PaisId = "MEX", CodigoPostalId = "03100"
                                }
                            }
                        },
                        Mercancias = new List<Fiscalapi.Models.BillOfLading.Mercancia>
                        {
                            new Fiscalapi.Models.BillOfLading.Mercancia
                            {
                                BienesTranspId = "50433238", Descripcion = "Gomitas", Cantidad = 1,
                                ClaveUnidadId = "XPK", PesoEnKg = 10.000m, ValorMercancia = 1200.00m,
                                MonedaId = "USD", FraccionArancelariaId = "2005800100", TipoMateriaId = "04"
                            },
                            new Fiscalapi.Models.BillOfLading.Mercancia
                            {
                                BienesTranspId = "50433238", Descripcion = "Pulparindo", Cantidad = 1,
                                ClaveUnidadId = "XPK", PesoEnKg = 10.000m, ValorMercancia = 1000.00m,
                                MonedaId = "USD", FraccionArancelariaId = "2005800100", TipoMateriaId = "04"
                            }
                        },
                        Autotransporte = new Autotransporte
                        {
                            PermSCTId = "TPAF02",
                            NumPermisoSCT = "123456",
                            ConfigVehicularId = "C2",
                            PesoBrutoVehicular = 1,
                            PlacaVM = "555TTT",
                            AnioModeloVM = 2023,
                            AseguraRespCivil = "ODISEA",
                            PolizaRespCivil = "3456YUHNB234RT"
                        },
                        TiposFigura = new List<TipoFigura>
                        {
                            new TipoFigura
                            {
                                TipoFiguraId = "01", RFCFigura = "KAHO641101B39",
                                NumLicencia = "D0908240", NombreFigura = "OSCAR KALA HAAK"
                            }
                        }
                    },
                    ComercioExterior = new ComercioExterior
                    {
                        ClaveDePedimentoId = "A1",
                        CertificadoOrigen = 0,
                        IncotermId = "CIF",
                        TipoCambioUSD = 17.2530m,
                        Emisor = new Emisor
                        {
                            Domicilio = new EmisorDomicilio
                            {
                                Calle = "Av Siempre viva",
                                NumeroExterior = "123",
                                ColoniaId = "0001",
                                LocalidadId = "06",
                                MunicipioId = "025",
                                EstadoId = "COA",
                                PaisId = "MEX",
                                CodigoPostalId = "26015"
                            }
                        },
                        Receptor = new Receptor
                        {
                            Domicilio = new ReceptorDomicilio
                            {
                                Calle = "Clinton ST",
                                NumeroExterior = "10002",
                                Estado = "NY",
                                PaisId = "USA",
                                CodigoPostal = "10002-0000"
                            }
                        },
                        Mercancias = new List<Fiscalapi.Models.ForeignTrade.Mercancia>
                        {
                            new Fiscalapi.Models.ForeignTrade.Mercancia
                            {
                                NoIdentificacion = "A0001", FraccionArancelariaId = "4011101099",
                                CantidadAduana = 1.000m, UnidadAduanaId = "06",
                                ValorUnitarioAduana = 120.00m, ValorDolares = 120.00m
                            },
                            new Fiscalapi.Models.ForeignTrade.Mercancia
                            {
                                NoIdentificacion = "A0002", FraccionArancelariaId = "8407210299",
                                CantidadAduana = 1.000m, UnidadAduanaId = "06",
                                ValorUnitarioAduana = 100.00m, ValorDolares = 100.00m
                            }
                        }
                    }
                }
            };

            var apiResponse = await fiscalApi.Invoices.CreateAsync(invoice);
            ShowResult(apiResponse);
        }

        // Factura CE Ingreso Diferentes Monedas (MXN, PPD)
        private async void FacturaCEIngresoDiferentesMonedasButton_Click(object sender, EventArgs e)
        {
            var fiscalApi = FiscalApiClient.Create(_settings);

            var invoice = new Invoice
            {
                VersionCode = "4.0",
                PaymentFormCode = "99",
                PaymentMethodCode = "PPD",
                CurrencyCode = "MXN",
                TypeCode = "I",
                ExpeditionZipCode = "42501",
                Series = "CCE",
                Date = DateTime.Parse("2026-05-08T08:56:40"),
                PaymentConditions = "CondicionesDePago",
                ExportCode = "02",
                Issuer = new InvoiceIssuer { Id = "2e7b988f-3a2a-4f67-86e9-3f931dd48581" },
                Recipient = new InvoiceRecipient { Id = "109f4d94-63ea-4a21-ab15-20c8b87d8ee9" },
                Items = new List<InvoiceItem>
                {
                    new InvoiceItem
                    {
                        ItemCode = "50211503", ItemSku = "131494-1055", Quantity = 2,
                        UnitOfMeasurementCode = "H87", Description = "Cigarros", UnitPrice = 200.00m,
                        Discount = 0, TaxObjectCode = "02",
                        ItemTaxes = new List<InvoiceItemTax>
                        {
                            new InvoiceItemTax { TaxCode = "002", TaxTypeCode = "Tasa", TaxRate = 0.160000m, TaxFlagCode = "T" },
                            new InvoiceItemTax { TaxCode = "001", TaxTypeCode = "Tasa", TaxRate = 0.100000m, TaxFlagCode = "R" },
                            new InvoiceItemTax { TaxCode = "002", TaxTypeCode = "Tasa", TaxRate = 0.106666m, TaxFlagCode = "R" }
                        }
                    }
                },
                Complement = new Complement
                {
                    ComercioExterior = new ComercioExterior
                    {
                        ClaveDePedimentoId = "A1",
                        CertificadoOrigen = 0,
                        IncotermId = "FOB",
                        TipoCambioUSD = 17.2530m,
                        Emisor = CreateCommonEmisor(),
                        Receptor = CreateCommonReceptorTX(includeNumRegIdTrib: true),
                        Mercancias = new List<Fiscalapi.Models.ForeignTrade.Mercancia>
                        {
                            new Fiscalapi.Models.ForeignTrade.Mercancia
                            {
                                NoIdentificacion = "131494-1055", FraccionArancelariaId = "2402200100",
                                CantidadAduana = 2.00m, UnidadAduanaId = "01",
                                ValorUnitarioAduana = 11.74m, ValorDolares = 23.47m
                            }
                        }
                    }
                }
            };

            var apiResponse = await fiscalApi.Invoices.CreateAsync(invoice);
            ShowResult(apiResponse);
        }

        // Factura CE Kit Parte (MXN, PUE)
        private async void FacturaCEKitParteButton_Click(object sender, EventArgs e)
        {
            var fiscalApi = FiscalApiClient.Create(_settings);

            var invoice = new Invoice
            {
                VersionCode = "4.0",
                PaymentFormCode = "01",
                PaymentMethodCode = "PUE",
                CurrencyCode = "MXN",
                TypeCode = "I",
                ExpeditionZipCode = "42501",
                Series = "CCE",
                Date = DateTime.Parse("2026-05-08T08:56:40"),
                PaymentConditions = "CondicionesDePago",
                ExportCode = "02",
                Issuer = new InvoiceIssuer { Id = "2e7b988f-3a2a-4f67-86e9-3f931dd48581" },
                Recipient = new InvoiceRecipient { Id = "109f4d94-63ea-4a21-ab15-20c8b87d8ee9" },
                Items = new List<InvoiceItem>
                {
                    new InvoiceItem
                    {
                        ItemCode = "51241200", ItemSku = "131494-1055", Quantity = 1.0m,
                        UnitOfMeasurementCode = "H87", Description = "FORMULA MAGISTRAL", UnitPrice = 200.00m,
                        Discount = 0, TaxObjectCode = "01", ItemTaxes = new List<InvoiceItemTax>()
                    },
                    new InvoiceItem
                    {
                        ItemCode = "51241200", ItemSku = "131494-1055", Quantity = 1.0m,
                        UnitOfMeasurementCode = "H87", Description = "FORMULA MAGISTRAL", UnitPrice = 200.00m,
                        Discount = 0, TaxObjectCode = "01", ItemTaxes = new List<InvoiceItemTax>()
                    }
                },
                Complement = new Complement
                {
                    ComercioExterior = new ComercioExterior
                    {
                        ClaveDePedimentoId = "A1",
                        CertificadoOrigen = 0,
                        IncotermId = "FOB",
                        TipoCambioUSD = 17.2530m,
                        Emisor = CreateCommonEmisor(),
                        Receptor = CreateCommonReceptorTX(includeNumRegIdTrib: true),
                        Mercancias = new List<Fiscalapi.Models.ForeignTrade.Mercancia>
                        {
                            new Fiscalapi.Models.ForeignTrade.Mercancia
                            {
                                NoIdentificacion = "131494-1055", FraccionArancelariaId = "2402200100",
                                CantidadAduana = 2, UnidadAduanaId = "01",
                                ValorUnitarioAduana = 10.00m, ValorDolares = 20.00m
                            }
                        }
                    }
                }
            };

            var apiResponse = await fiscalApi.Invoices.CreateAsync(invoice);
            ShowResult(apiResponse);
        }

        // Factura CE Receptor Extranjero (USD, PPD)
        private async void FacturaCEReceptorExtranjeroButton_Click(object sender, EventArgs e)
        {
            var fiscalApi = FiscalApiClient.Create(_settings);

            var invoice = new Invoice
            {
                VersionCode = "4.0",
                PaymentFormCode = "99",
                PaymentMethodCode = "PPD",
                CurrencyCode = "USD",
                TypeCode = "I",
                ExpeditionZipCode = "42501",
                Series = "CCE",
                Date = DateTime.Parse("2026-05-08T08:56:40"),
                PaymentConditions = "CondicionesDePago",
                ExportCode = "02",
                Issuer = new InvoiceIssuer { Id = "2e7b988f-3a2a-4f67-86e9-3f931dd48581" },
                Recipient = new InvoiceRecipient { Id = "109f4d94-63ea-4a21-ab15-20c8b87d8ee9" },
                Items = new List<InvoiceItem>
                {
                    new InvoiceItem
                    {
                        ItemCode = "50211503", ItemSku = "131494-1055", Quantity = 2,
                        UnitOfMeasurementCode = "H87", Description = "Cigarros", UnitPrice = 200.00m,
                        Discount = 0, TaxObjectCode = "02",
                        ItemTaxes = new List<InvoiceItemTax>
                        {
                            new InvoiceItemTax { TaxCode = "002", TaxTypeCode = "Tasa", TaxRate = 0.160000m, TaxFlagCode = "T" },
                            new InvoiceItemTax { TaxCode = "001", TaxTypeCode = "Tasa", TaxRate = 0.100000m, TaxFlagCode = "R" }
                        }
                    }
                },
                Complement = new Complement
                {
                    ComercioExterior = new ComercioExterior
                    {
                        ClaveDePedimentoId = "A1",
                        CertificadoOrigen = 0,
                        IncotermId = "FOB",
                        TipoCambioUSD = 17.2530m,
                        Emisor = CreateCommonEmisor(),
                        Receptor = CreateCommonReceptorTX(includeNumRegIdTrib: true),
                        Mercancias = new List<Fiscalapi.Models.ForeignTrade.Mercancia>
                        {
                            new Fiscalapi.Models.ForeignTrade.Mercancia
                            {
                                NoIdentificacion = "131494-1055", FraccionArancelariaId = "2402200100",
                                CantidadAduana = 117.64m, UnidadAduanaId = "01",
                                ValorUnitarioAduana = 3.40m, ValorDolares = 400.00m
                            }
                        }
                    }
                }
            };

            var apiResponse = await fiscalApi.Invoices.CreateAsync(invoice);
            ShowResult(apiResponse);
        }

        // Factura CE Receptor Nacional (USD, PPD)
        private async void FacturaCEReceptorNacionalButton_Click(object sender, EventArgs e)
        {
            var fiscalApi = FiscalApiClient.Create(_settings);

            var invoice = new Invoice
            {
                VersionCode = "4.0",
                PaymentFormCode = "99",
                PaymentMethodCode = "PPD",
                CurrencyCode = "USD",
                TypeCode = "I",
                ExpeditionZipCode = "42501",
                Series = "CCE",
                Date = DateTime.Parse("2026-05-08T08:56:40"),
                PaymentConditions = "CondicionesDePago",
                ExportCode = "02",
                Issuer = new InvoiceIssuer { Id = "2e7b988f-3a2a-4f67-86e9-3f931dd48581" },
                Recipient = new InvoiceRecipient { Id = "109f4d94-63ea-4a21-ab15-20c8b87d8ee9" },
                Items = new List<InvoiceItem>
                {
                    new InvoiceItem
                    {
                        ItemCode = "50211503", ItemSku = "131494-1055", Quantity = 2,
                        UnitOfMeasurementCode = "H87", Description = "Cigarros", UnitPrice = 200.00m,
                        Discount = 0, TaxObjectCode = "02",
                        ItemTaxes = new List<InvoiceItemTax>
                        {
                            new InvoiceItemTax { TaxCode = "002", TaxTypeCode = "Tasa", TaxRate = 0.160000m, TaxFlagCode = "T" },
                            new InvoiceItemTax { TaxCode = "001", TaxTypeCode = "Tasa", TaxRate = 0.100000m, TaxFlagCode = "R" },
                            new InvoiceItemTax { TaxCode = "002", TaxTypeCode = "Tasa", TaxRate = 0.106666m, TaxFlagCode = "R" }
                        }
                    }
                },
                Complement = new Complement
                {
                    ComercioExterior = new ComercioExterior
                    {
                        ClaveDePedimentoId = "A1",
                        CertificadoOrigen = 0,
                        IncotermId = "FOB",
                        TipoCambioUSD = 17.2530m,
                        Emisor = CreateCommonEmisor(),
                        Receptor = new Receptor
                        {
                            Domicilio = new ReceptorDomicilio
                            {
                                Calle = "CALLE DEL PAPEL",
                                Colonia = "0214",
                                Localidad = "01",
                                Municipio = "014",
                                Estado = "QUE",
                                PaisId = "MEX",
                                CodigoPostal = "76199"
                            }
                        },
                        Mercancias = new List<Fiscalapi.Models.ForeignTrade.Mercancia>
                        {
                            new Fiscalapi.Models.ForeignTrade.Mercancia
                            {
                                NoIdentificacion = "131494-1055", FraccionArancelariaId = "2402200100",
                                CantidadAduana = 117.64m, UnidadAduanaId = "01",
                                ValorUnitarioAduana = 3.40m, ValorDolares = 400.00m
                            }
                        }
                    }
                }
            };

            var apiResponse = await fiscalApi.Invoices.CreateAsync(invoice);
            ShowResult(apiResponse);
        }

        // Factura CE Traslado Traslado Mercancia Propia (USD, T)
        private async void FacturaCETrasladoTrasladoMercanciaPropiaButton_Click(object sender, EventArgs e)
        {
            var fiscalApi = FiscalApiClient.Create(_settings);

            var invoice = new Invoice
            {
                VersionCode = "4.0",
                PaymentMethodCode = null,
                CurrencyCode = "USD",
                TypeCode = "T",
                ExpeditionZipCode = "42501",
                Series = "CCE",
                Date = DateTime.Parse("2026-05-08T08:56:40"),
                ExportCode = "02",
                Issuer = new InvoiceIssuer { Id = "2e7b988f-3a2a-4f67-86e9-3f931dd48581" },
                Recipient = new InvoiceRecipient { Id = "109f4d94-63ea-4a21-ab15-20c8b87d8ee9" },
                Items = new List<InvoiceItem>
                {
                    new InvoiceItem
                    {
                        ItemCode = "50211503", ItemSku = "131494-1055", Quantity = 1.0m,
                        UnitOfMeasurementCode = "H87", Description = "My description...", UnitPrice = 0.00m,
                        Discount = 0, TaxObjectCode = "01", ItemTaxes = new List<InvoiceItemTax>()
                    }
                },
                Complement = new Complement
                {
                    ComercioExterior = new ComercioExterior
                    {
                        MotivoTrasladoId = "02",
                        ClaveDePedimentoId = "A1",
                        CertificadoOrigen = 0,
                        IncotermId = "FCA",
                        TipoCambioUSD = 17.2530m,
                        Emisor = CreateCommonEmisor(),
                        Receptor = new Receptor
                        {
                            Domicilio = new ReceptorDomicilio
                            {
                                Calle = "SW Street.", NumeroExterior = "12345", Localidad = "Oregon",
                                Estado = "OR", PaisId = "USA", CodigoPostal = "12345"
                            }
                        },
                        Destinatarios = new List<Destinatario>
                        {
                            new Destinatario
                            {
                                NumRegIdTrib = "123456789",
                                Nombre = "EKU9003173C9",
                                Domicilios = new List<DestinatarioDomicilio>
                                {
                                    new DestinatarioDomicilio
                                    {
                                        Calle = "SW Street.", NumeroExterior = "12345", Localidad = "Oregon",
                                        Estado = "OR", PaisId = "USA", CodigoPostal = "12345"
                                    }
                                }
                            }
                        },
                        Mercancias = new List<Fiscalapi.Models.ForeignTrade.Mercancia>
                        {
                            new Fiscalapi.Models.ForeignTrade.Mercancia
                            {
                                NoIdentificacion = "131494-1055", FraccionArancelariaId = "0101210100",
                                CantidadAduana = 1, UnidadAduanaId = "07",
                                ValorUnitarioAduana = 22.64m, ValorDolares = 22.64m
                            }
                        }
                    }
                }
            };

            var apiResponse = await fiscalApi.Invoices.CreateAsync(invoice);
            ShowResult(apiResponse);
        }

        // Factura CE Traslado Traslado (USD, T)
        private async void FacturaCETrasladoTrasladoButton_Click(object sender, EventArgs e)
        {
            var fiscalApi = FiscalApiClient.Create(_settings);

            var invoice = new Invoice
            {
                VersionCode = "4.0",
                PaymentMethodCode = null,
                CurrencyCode = "USD",
                TypeCode = "T",
                ExpeditionZipCode = "42501",
                Series = "CCE",
                Date = DateTime.Parse("2026-05-08T08:56:40"),
                ExportCode = "02",
                Issuer = new InvoiceIssuer { Id = "2e7b988f-3a2a-4f67-86e9-3f931dd48581" },
                Recipient = new InvoiceRecipient { Id = "109f4d94-63ea-4a21-ab15-20c8b87d8ee9" },
                Items = new List<InvoiceItem>
                {
                    new InvoiceItem
                    {
                        ItemCode = "50211503", ItemSku = "131494-1055", Quantity = 2,
                        UnitOfMeasurementCode = "H87", Description = "Cigarros", UnitPrice = 200.00m,
                        Discount = 0, TaxObjectCode = "01", ItemTaxes = new List<InvoiceItemTax>()
                    }
                },
                Complement = new Complement
                {
                    ComercioExterior = new ComercioExterior
                    {
                        ClaveDePedimentoId = "A1",
                        CertificadoOrigen = 0,
                        IncotermId = "FOB",
                        TipoCambioUSD = 17.2530m,
                        Emisor = CreateCommonEmisor(),
                        Receptor = CreateCommonReceptorTX(includeNumRegIdTrib: false),
                        Mercancias = new List<Fiscalapi.Models.ForeignTrade.Mercancia>
                        {
                            new Fiscalapi.Models.ForeignTrade.Mercancia
                            {
                                NoIdentificacion = "131494-1055", FraccionArancelariaId = "2402200100",
                                CantidadAduana = 117.64m, UnidadAduanaId = "01",
                                ValorUnitarioAduana = 3.40m, ValorDolares = 400.00m
                            }
                        }
                    }
                }
            };

            var apiResponse = await fiscalApi.Invoices.CreateAsync(invoice);
            ShowResult(apiResponse);
        }

        // Factura CE Unidades De Medida No Equivalentes (USD, PPD)
        private async void FacturaCEUnidadesDeMedidaNoEquivalentesButton_Click(object sender, EventArgs e)
        {
            var fiscalApi = FiscalApiClient.Create(_settings);

            var invoice = new Invoice
            {
                VersionCode = "4.0",
                PaymentFormCode = "99",
                PaymentMethodCode = "PPD",
                CurrencyCode = "USD",
                TypeCode = "I",
                ExpeditionZipCode = "42501",
                Series = "CCE",
                Date = DateTime.Parse("2026-05-08T08:56:40"),
                PaymentConditions = "CondicionesDePago",
                ExportCode = "02",
                Issuer = new InvoiceIssuer { Id = "2e7b988f-3a2a-4f67-86e9-3f931dd48581" },
                Recipient = new InvoiceRecipient { Id = "109f4d94-63ea-4a21-ab15-20c8b87d8ee9" },
                Items = new List<InvoiceItem>
                {
                    new InvoiceItem
                    {
                        ItemCode = "50201708", ItemSku = "131494-1055", Quantity = 1.000m,
                        UnitOfMeasurementCode = "H87", Description = "Bebida", UnitPrice = 100.00m,
                        Discount = 0, TaxObjectCode = "02",
                        ItemTaxes = new List<InvoiceItemTax>
                        {
                            new InvoiceItemTax { TaxCode = "002", TaxTypeCode = "Tasa", TaxRate = 0.160000m, TaxFlagCode = "T" },
                            new InvoiceItemTax { TaxCode = "001", TaxTypeCode = "Tasa", TaxRate = 0.100000m, TaxFlagCode = "R" },
                            new InvoiceItemTax { TaxCode = "002", TaxTypeCode = "Tasa", TaxRate = 0.106666m, TaxFlagCode = "R" }
                        }
                    }
                },
                Complement = new Complement
                {
                    ComercioExterior = new ComercioExterior
                    {
                        ClaveDePedimentoId = "A1",
                        CertificadoOrigen = 0,
                        IncotermId = "FOB",
                        TipoCambioUSD = 17.2530m,
                        Emisor = CreateCommonEmisor(),
                        Receptor = CreateCommonReceptorTX(includeNumRegIdTrib: true),
                        Mercancias = new List<Fiscalapi.Models.ForeignTrade.Mercancia>
                        {
                            new Fiscalapi.Models.ForeignTrade.Mercancia
                            {
                                NoIdentificacion = "131494-1055", FraccionArancelariaId = "2009310201",
                                CantidadAduana = 0.500m, UnidadAduanaId = "08",
                                ValorUnitarioAduana = 200.00m, ValorDolares = 100.00m
                            }
                        }
                    }
                }
            };

            var apiResponse = await fiscalApi.Invoices.CreateAsync(invoice);
            ShowResult(apiResponse);
        }

        // Factura CE Traslado Con Carta Porte 31 (XXX, T)
        private async void FacturaCETrasladoConCartaPorte31Button_Click(object sender, EventArgs e)
        {
            var fiscalApi = FiscalApiClient.Create(_settings);

            var invoice = new Invoice
            {
                VersionCode = "4.0",
                PaymentMethodCode = null,
                CurrencyCode = "XXX",
                TypeCode = "T",
                ExpeditionZipCode = "42501",
                Series = "CCE",
                Date = DateTime.Parse("2026-05-08T08:56:40"),
                ExportCode = "02",
                Issuer = new InvoiceIssuer { Id = "2e7b988f-3a2a-4f67-86e9-3f931dd48581" },
                Recipient = new InvoiceRecipient { Id = "109f4d94-63ea-4a21-ab15-20c8b87d8ee9" },
                Items = new List<InvoiceItem>
                {
                    new InvoiceItem
                    {
                        ItemCode = "78101800", ItemSku = "TR01", Quantity = 1.0m,
                        UnitOfMeasurementCode = "H87", Description = "TRANSPORTE DE CARGA", UnitPrice = 0.00m,
                        Discount = 0, TaxObjectCode = "01", ItemTaxes = new List<InvoiceItemTax>()
                    },
                    new InvoiceItem
                    {
                        ItemCode = "32101622", ItemSku = "UT421511", Quantity = 100.00m,
                        UnitOfMeasurementCode = "XBX", Description = "MEMORIA FLASH", UnitPrice = 0.00m,
                        Discount = 0, TaxObjectCode = "01", ItemTaxes = new List<InvoiceItemTax>()
                    }
                },
                Complement = new Complement
                {
                    CartaPorte = new CartaPorte
                    {
                        TranspInternacId = "Sí",
                        EntradaSalidaMercId = "Salida",
                        PaisOrigenDestinoId = "ALB",
                        ViaEntradaSalidaId = "01",
                        TotalDistRec = 120.00m,
                        UnidadPesoId = "KGM",
                        RegimenAduaneros = new List<RegimenAduanero>
                        {
                            new RegimenAduanero { RegimenAduaneroId = "EXD" }
                        },
                        Ubicaciones = new List<Ubicacion>
                        {
                            new Ubicacion
                            {
                                TipoUbicacion = "Origen", IDUbicacion = "OR000001",
                                RFCRemitenteDestinatario = "XAXX010101000", NombreRemitenteDestinatario = "Origen Nacional",
                                FechaHoraSalidaLlegada = DateTime.Parse("2026-04-27T08:00:00"),
                                Domicilio = new UbicacionDomicilio
                                {
                                    Calle = "xola", NumeroExterior = "531", ColoniaId = "0496",
                                    LocalidadId = "03", MunicipioId = "014", EstadoId = "CMX",
                                    PaisId = "MEX", CodigoPostalId = "03100"
                                }
                            },
                            new Ubicacion
                            {
                                TipoUbicacion = "Destino", IDUbicacion = "DE000001",
                                RFCRemitenteDestinatario = "XAXX010101000", NombreRemitenteDestinatario = "Destino Nacional",
                                FechaHoraSalidaLlegada = DateTime.Parse("2026-04-27T20:00:00"),
                                DistanciaRecorrida = 120.00m,
                                Domicilio = new UbicacionDomicilio
                                {
                                    Calle = "Av Coyoacan", NumeroExterior = "120", ColoniaId = "2624",
                                    LocalidadId = "03", MunicipioId = "014", EstadoId = "CMX",
                                    PaisId = "MEX", CodigoPostalId = "03100"
                                }
                            }
                        },
                        Mercancias = new List<Fiscalapi.Models.BillOfLading.Mercancia>
                        {
                            new Fiscalapi.Models.BillOfLading.Mercancia
                            {
                                BienesTranspId = "50433238", Descripcion = "Gomitas", Cantidad = 1,
                                ClaveUnidadId = "XPK", PesoEnKg = 10.000m, ValorMercancia = 1200.00m,
                                MonedaId = "USD", FraccionArancelariaId = "2005800100", TipoMateriaId = "04"
                            },
                            new Fiscalapi.Models.BillOfLading.Mercancia
                            {
                                BienesTranspId = "50433238", Descripcion = "Pulparindo", Cantidad = 1,
                                ClaveUnidadId = "XPK", PesoEnKg = 10.000m, ValorMercancia = 1000.00m,
                                MonedaId = "USD", FraccionArancelariaId = "2005800100", TipoMateriaId = "04"
                            }
                        },
                        Autotransporte = new Autotransporte
                        {
                            PermSCTId = "TPAF02", NumPermisoSCT = "123456", ConfigVehicularId = "C2",
                            PesoBrutoVehicular = 1, PlacaVM = "555TTT", AnioModeloVM = 2023,
                            AseguraRespCivil = "ODISEA", PolizaRespCivil = "3456YUHNB234RT"
                        },
                        TiposFigura = new List<TipoFigura>
                        {
                            new TipoFigura
                            {
                                TipoFiguraId = "01", RFCFigura = "KAHO641101B39",
                                NumLicencia = "D0908240", NombreFigura = "OSCAR KALA HAAK"
                            }
                        }
                    },
                    ComercioExterior = new ComercioExterior
                    {
                        ClaveDePedimentoId = "A1",
                        CertificadoOrigen = 0,
                        IncotermId = "FOB",
                        TipoCambioUSD = 17.2530m,
                        Emisor = CreateCommonEmisor(),
                        Receptor = CreateCommonReceptorTX(includeNumRegIdTrib: false),
                        Mercancias = new List<Fiscalapi.Models.ForeignTrade.Mercancia>
                        {
                            new Fiscalapi.Models.ForeignTrade.Mercancia
                            {
                                NoIdentificacion = "UT421511", FraccionArancelariaId = "2402200100",
                                CantidadAduana = 100.00m, UnidadAduanaId = "01",
                                ValorUnitarioAduana = 1.00m, ValorDolares = 0.00m
                            }
                        }
                    }
                }
            };

            var apiResponse = await fiscalApi.Invoices.CreateAsync(invoice);
            ShowResult(apiResponse);
        }
    }
}
