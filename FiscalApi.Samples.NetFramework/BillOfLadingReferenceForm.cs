using Fiscalapi.Common;
using Fiscalapi.Models;
using Fiscalapi.Models.BillOfLading;
using Fiscalapi.Services;
using Newtonsoft.Json;
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
    public partial class BillOfLadingReferenceForm : Form
    {
        private FiscalapiSettings _settings;
        public BillOfLadingReferenceForm(FiscalapiSettings settings)
        {
            InitializeComponent();
            _settings = settings;
        }

        private string _certEscuelaKemper = "MIIFsDCCA5igAwIBAgIUMzAwMDEwMDAwMDA1MDAwMDM0MTYwDQYJKoZIhvcNAQELBQAwggErMQ8wDQYDVQQDDAZBQyBVQVQxLjAsBgNVBAoMJVNFUlZJQ0lPIERFIEFETUlOSVNUUkFDSU9OIFRSSUJVVEFSSUExGjAYBgNVBAsMEVNBVC1JRVMgQXV0aG9yaXR5MSgwJgYJKoZIhvcNAQkBFhlvc2Nhci5tYXJ0aW5lekBzYXQuZ29iLm14MR0wGwYDVQQJDBQzcmEgY2VycmFkYSBkZSBjYWxpejEOMAwGA1UEEQwFMDYzNzAxCzAJBgNVBAYTAk1YMRkwFwYDVQQIDBBDSVVEQUQgREUgTUVYSUNPMREwDwYDVQQHDAhDT1lPQUNBTjERMA8GA1UELRMIMi41LjQuNDUxJTAjBgkqhkiG9w0BCQITFnJlc3BvbnNhYmxlOiBBQ0RNQS1TQVQwHhcNMjMwNTE4MTE0MzUxWhcNMjcwNTE4MTE0MzUxWjCB1zEnMCUGA1UEAxMeRVNDVUVMQSBLRU1QRVIgVVJHQVRFIFNBIERFIENWMScwJQYDVQQpEx5FU0NVRUxBIEtFTVBFUiBVUkdBVEUgU0EgREUgQ1YxJzAlBgNVBAoTHkVTQ1VFTEEgS0VNUEVSIFVSR0FURSBTQSBERSBDVjElMCMGA1UELRMcRUtVOTAwMzE3M0M5IC8gVkFEQTgwMDkyN0RKMzEeMBwGA1UEBRMVIC8gVkFEQTgwMDkyN0hTUlNSTDA1MRMwEQYDVQQLEwpTdWN1cnNhbCAxMIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAtmecO6n2GS0zL025gbHGQVxznPDICoXzR2uUngz4DqxVUC/w9cE6FxSiXm2ap8Gcjg7wmcZfm85EBaxCx/0J2u5CqnhzIoGCdhBPuhWQnIh5TLgj/X6uNquwZkKChbNe9aeFirU/JbyN7Egia9oKH9KZUsodiM/pWAH00PCtoKJ9OBcSHMq8Rqa3KKoBcfkg1ZrgueffwRLws9yOcRWLb02sDOPzGIm/jEFicVYt2Hw1qdRE5xmTZ7AGG0UHs+unkGjpCVeJ+BEBn0JPLWVvDKHZAQMj6s5Bku35+d/MyATkpOPsGT/VTnsouxekDfikJD1f7A1ZpJbqDpkJnss3vQIDAQABox0wGzAMBgNVHRMBAf8EAjAAMAsGA1UdDwQEAwIGwDANBgkqhkiG9w0BAQsFAAOCAgEAFaUgj5PqgvJigNMgtrdXZnbPfVBbukAbW4OGnUhNrA7SRAAfv2BSGk16PI0nBOr7qF2mItmBnjgEwk+DTv8Zr7w5qp7vleC6dIsZFNJoa6ZndrE/f7KO1CYruLXr5gwEkIyGfJ9NwyIagvHHMszzyHiSZIA850fWtbqtythpAliJ2jF35M5pNS+YTkRB+T6L/c6m00ymN3q9lT1rB03YywxrLreRSFZOSrbwWfg34EJbHfbFXpCSVYdJRfiVdvHnewN0r5fUlPtR9stQHyuqewzdkyb5jTTw02D2cUfL57vlPStBj7SEi3uOWvLrsiDnnCIxRMYJ2UA2ktDKHk+zWnsDmaeleSzonv2CHW42yXYPCvWi88oE1DJNYLNkIjua7MxAnkNZbScNw01A6zbLsZ3y8G6eEYnxSTRfwjd8EP4kdiHNJftm7Z4iRU7HOVh79/lRWB+gd171s3d/mI9kte3MRy6V8MMEMCAnMboGpaooYwgAmwclI2XZCczNWXfhaWe0ZS5PmytD/GDpXzkX0oEgY9K/uYo5V77NdZbGAjmyi8cE2B2ogvyaN2XfIInrZPgEffJ4AB7kFA2mwesdLOCh0BLD9itmCve3A1FGR4+stO2ANUoiI3w3Tv2yQSg4bjeDlJ08lXaaFCLW2peEXMXjQUk7fmpb5MNuOUTW6BE=";
        private string _keyEscuelaKemper = "MIIFDjBABgkqhkiG9w0BBQ0wMzAbBgkqhkiG9w0BBQwwDgQIAgEAAoIBAQACAggAMBQGCCqGSIb3DQMHBAgwggS/AgEAMASCBMh4EHl7aNSCaMDA1VlRoXCZ5UUmqErAbucoZQObOaLUEm+I+QZ7Y8Giupo+F1XWkLvAsdk/uZlJcTfKLJyJbJwsQYbSpLOCLataZ4O5MVnnmMbfG//NKJn9kSMvJQZhSwAwoGLYDm1ESGezrvZabgFJnoQv8Si1nAhVGTk9FkFBesxRzq07dmZYwFCnFSX4xt2fDHs1PMpQbeq83aL/PzLCce3kxbYSB5kQlzGtUYayiYXcu0cVRu228VwBLCD+2wTDDoCmRXtPesgrLKUR4WWWb5N2AqAU1mNDC+UEYsENAerOFXWnmwrcTAu5qyZ7GsBMTpipW4Dbou2yqQ0lpA/aB06n1kz1aL6mNqGPaJ+OqoFuc8Ugdhadd+MmjHfFzoI20SZ3b2geCsUMNCsAd6oXMsZdWm8lzjqCGWHFeol0ik/xHMQvuQkkeCsQ28PBxdnUgf7ZGer+TN+2ZLd2kvTBOk6pIVgy5yC6cZ+o1Tloql9hYGa6rT3xcMbXlW+9e5jM2MWXZliVW3ZhaPjptJFDbIfWxJPjz4QvKyJk0zok4muv13Iiwj2bCyefUTRz6psqI4cGaYm9JpscKO2RCJN8UluYGbbWmYQU+Int6LtZj/lv8p6xnVjWxYI+rBPdtkpfFYRp+MJiXjgPw5B6UGuoruv7+vHjOLHOotRo+RdjZt7NqL9dAJnl1Qb2jfW6+d7NYQSI/bAwxO0sk4taQIT6Gsu/8kfZOPC2xk9rphGqCSS/4q3Os0MMjA1bcJLyoWLp13pqhK6bmiiHw0BBXH4fbEp4xjSbpPx4tHXzbdn8oDsHKZkWh3pPC2J/nVl0k/yF1KDVowVtMDXE47k6TGVcBoqe8PDXCG9+vjRpzIidqNo5qebaUZu6riWMWzldz8x3Z/jLWXuDiM7/Yscn0Z2GIlfoeyz+GwP2eTdOw9EUedHjEQuJY32bq8LICimJ4Ht+zMJKUyhwVQyAER8byzQBwTYmYP5U0wdsyIFitphw+/IH8+v08Ia1iBLPQAeAvRfTTIFLCs8foyUrj5Zv2B/wTYIZy6ioUM+qADeXyo45uBLLqkN90Rf6kiTqDld78NxwsfyR5MxtJLVDFkmf2IMMJHTqSfhbi+7QJaC11OOUJTD0v9wo0X/oO5GvZhe0ZaGHnm9zqTopALuFEAxcaQlc4R81wjC4wrIrqWnbcl2dxiBtD73KW+wcC9ymsLf4I8BEmiN25lx/OUc1IHNyXZJYSFkEfaxCEZWKcnbiyf5sqFSSlEqZLc4lUPJFAoP6s1FHVcyO0odWqdadhRZLZC9RCzQgPlMRtji/OXy5phh7diOBZv5UYp5nb+MZ2NAB/eFXm2JLguxjvEstuvTDmZDUb6Uqv++RdhO5gvKf/AcwU38ifaHQ9uvRuDocYwVxZS2nr9rOwZ8nAh+P2o4e0tEXjxFKQGhxXYkn75H3hhfnFYjik/2qunHBBZfcdG148MaNP6DjX33M238T9Zw/GyGx00JMogr2pdP4JAErv9a5yt4YR41KGf8guSOUbOXVARw6+ybh7+meb7w4BeTlj3aZkv8tVGdfIt3lrwVnlbzhLjeQY6PplKp3/a5Kr5yM0T4wJoKQQ6v3vSNmrhpbuAtKxpMILe8CQoo=";

        private List<TaxCredential> CreateTaxCredentials()
        {
            return new List<TaxCredential>
            {
                new TaxCredential
                {
                    Base64File = _certEscuelaKemper,
                    FileType = FileType.CertificateCsd,
                    Password = "12345678a"
                },
                new TaxCredential
                {
                    Base64File = _keyEscuelaKemper,
                    FileType = FileType.PrivateKeyCsd,
                    Password = "12345678a"
                }
            };
        }

        private InvoiceIssuer CreateIssuer()
        {
            return new InvoiceIssuer { Id = "0e82a655-5f0c-4e07-abab-8f322e4123ef" };
        }

        private Autotransporte CreateAutotransporte()
        {
            return new Autotransporte
            {
                PermSCTId = "TPAF01",
                NumPermisoSCT = "NumPermisoSCT1",
                ConfigVehicularId = "VL",
                PesoBrutoVehicular = 1,
                PlacaVM = "plac892",
                AnioModeloVM = 2020,
                AseguraRespCivil = "AseguraRespCivil",
                PolizaRespCivil = "123456789",
                Remolques = new List<Remolque>
                {
                    new Remolque { SubTipoRemId = "CTR004", Placa = "VL45K98" }
                }
            };
        }

        private Mercancia CreateMercancia(bool includeDocumentacionAduanera = false)
        {
            var mercancia = new Mercancia
            {
                BienesTranspId = "11121900",
                Descripcion = "Accesorios de equipo de telefonía",
                Cantidad = 1.0m,
                ClaveUnidadId = "XBX",
                MaterialPeligrosoId = "No",
                DenominacionGenericaProd = "DenominacionGenericaProd1",
                DenominacionDistintivaProd = "DenominacionDistintivaProd1",
                Fabricante = "Fabricante1",
                FechaCaducidad = DateTime.Parse("2003-04-02T00:00:00"),
                LoteMedicamento = "LoteMedic1",
                FormaFarmaceuticaId = "01",
                CondicionesEspTranspId = "01",
                RegistroSanitarioFolioAutorizacion = "RegistroSanita1",
                PesoEnKg = 1,
                FraccionArancelariaId = "6309000100",
                CantidadTransporta = new List<CantidadTransporta>
                {
                    new CantidadTransporta { Cantidad = 1, IDOrigen = "OR101010", IDDestino = "DE202020" }
                }
            };

            if (includeDocumentacionAduanera)
            {
                mercancia.TipoMateriaId = "05";
                mercancia.DescripcionMateria = "otramateria";
                mercancia.DocumentacionAduanera = new List<DocumentoAduanero>
                {
                    new DocumentoAduanero
                    {
                        TipoDocumentoId = "01",
                        NumPedimento = "23  43  0472  8000448",
                        RFCImpo = "EKU9003173C9"
                    }
                };
            }

            return mercancia;
        }

        private Invoice CreateBaseInvoice(string taxObjectCode = "01", List<InvoiceItemTax> itemTaxes = null)
        {
            return new Invoice
            {
                VersionCode = "4.0",
                PaymentFormCode = "01",
                PaymentMethodCode = "PUE",
                CurrencyCode = "MXN",
                TypeCode = "I",
                ExpeditionZipCode = "42501",
                Series = "SerieCCP31",
                Date = DateTime.Now,
                ExchangeRate = 1,
                ExportCode = "01",
                Issuer = CreateIssuer(),
                Items = new List<InvoiceItem>
                {
                    new InvoiceItem
                    {
                        ItemCode = "78101800",
                        ItemSku = "UT421511",
                        Quantity = 1,
                        UnitOfMeasurementCode = "H87",
                        Description = "Transporte de carga por carretera",
                        UnitPrice = 100.00m,
                        Discount = 0,
                        TaxObjectCode = taxObjectCode,
                        ItemTaxes = itemTaxes ?? new List<InvoiceItemTax>()
                    }
                }
            };
        }

        // button1: Factura ingreso autotransporte nacional
        private async void button1_Click(object sender, EventArgs e)
        {
            var fiscalApi = FiscalApiClient.Create(_settings);

            var invoice = CreateBaseInvoice();
            invoice.Recipient = new InvoiceRecipient { Id = "37f7c342-d9a6-4881-9620-0da769b50ce5" };
            invoice.Complement = new Complement
            {
                CartaPorte = new CartaPorte
                {
                    TranspInternacId = "No",
                    TotalDistRec = 1.0m,
                    RegistroISTMOId = "Sí",
                    UbicacionPoloOrigenId = "01",
                    UbicacionPoloDestinoId = "01",
                    UnidadPesoId = "XBX",
                    LogisticaInversaRecoleccionDevolucionId = "Sí",
                    Ubicaciones = new List<Ubicacion>
                    {
                        new Ubicacion
                        {
                            TipoUbicacion = "Origen",
                            IDUbicacion = "OR101010",
                            RFCRemitenteDestinatario = "URE180429TM6",
                            NombreRemitenteDestinatario = "NombreRemitenteDestinatario1",
                            FechaHoraSalidaLlegada = DateTime.Parse("2023-08-01T00:00:00"),
                            Domicilio = new Domicilio
                            {
                                Calle = "Calle1", NumeroExterior = "211", NumeroInterior = "212",
                                ColoniaId = "1957", LocalidadId = "13", Referencia = "casa blanca",
                                MunicipioId = "011", EstadoId = "CMX", PaisId = "MEX", CodigoPostalId = "13250"
                            }
                        },
                        new Ubicacion
                        {
                            TipoUbicacion = "Destino",
                            IDUbicacion = "DE202020",
                            RFCRemitenteDestinatario = "URE180429TM6",
                            NombreRemitenteDestinatario = "NombreRemitenteDestinatario2",
                            FechaHoraSalidaLlegada = DateTime.Parse("2023-08-01T00:00:01"),
                            DistanciaRecorrida = 1,
                            Domicilio = new Domicilio
                            {
                                Calle = "Calle2", NumeroExterior = "214", NumeroInterior = "215",
                                ColoniaId = "0347", LocalidadId = "23", Referencia = "casa negra",
                                MunicipioId = "004", EstadoId = "COA", PaisId = "MEX", CodigoPostalId = "25350"
                            }
                        }
                    },
                    Mercancias = new List<Mercancia> { CreateMercancia() },
                    Autotransporte = CreateAutotransporte(),
                    TiposFigura = new List<TipoFigura>
                    {
                        new TipoFigura
                        {
                            TipoFiguraId = "01",
                            RFCFigura = "URE180429TM6",
                            NumLicencia = "NumLicencia1",
                            NombreFigura = "NombreFigura1",
                            Domicilio = new Domicilio
                            {
                                Calle = "Calle1", NumeroExterior = "NumeroExterior1", NumeroInterior = "NumeroInterior1",
                                ColoniaId = "Colonia1", LocalidadId = "Localidad1", Referencia = "Referencia1",
                                MunicipioId = "Municipio1", EstadoId = "Estado1", PaisId = "AFG", CodigoPostalId = "CodigoPosta1"
                            }
                        }
                    }
                }
            };

            var apiResponse = await fiscalApi.Invoices.CreateAsync(invoice);

            if (apiResponse.Succeeded)
                MessageBox.Show(JsonConvert.SerializeObject(apiResponse.Data, Formatting.Indented));
            else
            {
                MessageBox.Show(apiResponse.Message);
                MessageBox.Show(apiResponse.Details);
            }
        }

        // button2: Factura ingreso autotransporte nacional con impuestos
        private async void button2_Click(object sender, EventArgs e)
        {
            var fiscalApi = FiscalApiClient.Create(_settings);

            var itemTaxes = new List<InvoiceItemTax>
            {
                new InvoiceItemTax { TaxCode = "002", TaxTypeCode = "Tasa", TaxRate = 0.160000m, TaxFlagCode = "T" },
                new InvoiceItemTax { TaxCode = "002", TaxTypeCode = "Tasa", TaxRate = 0.040000m, TaxFlagCode = "R" }
            };

            var invoice = CreateBaseInvoice("02", itemTaxes);
            invoice.Items[0].UnitPrice = 26232.75m;
            invoice.Recipient = new InvoiceRecipient { Id = "37f7c342-d9a6-4881-9620-0da769b50ce5" };
            invoice.Complement = new Complement
            {
                CartaPorte = new CartaPorte
                {
                    TranspInternacId = "No",
                    TotalDistRec = 1,
                    RegistroISTMOId = "Sí",
                    UbicacionPoloOrigenId = "01",
                    UbicacionPoloDestinoId = "01",
                    UnidadPesoId = "XBX",
                    LogisticaInversaRecoleccionDevolucionId = "Sí",
                    Ubicaciones = new List<Ubicacion>
                    {
                        new Ubicacion
                        {
                            TipoUbicacion = "Origen",
                            IDUbicacion = "OR101010",
                            RFCRemitenteDestinatario = "URE180429TM6",
                            NombreRemitenteDestinatario = "NombreRemitenteDestinatario1",
                            FechaHoraSalidaLlegada = DateTime.Parse("2023-08-01T00:00:00"),
                            Domicilio = new Domicilio
                            {
                                Calle = "Calle1", NumeroExterior = "211", NumeroInterior = "212",
                                ColoniaId = "1957", LocalidadId = "13", Referencia = "casa blanca",
                                MunicipioId = "011", EstadoId = "CMX", PaisId = "MEX", CodigoPostalId = "13250"
                            }
                        },
                        new Ubicacion
                        {
                            TipoUbicacion = "Destino",
                            IDUbicacion = "DE202020",
                            RFCRemitenteDestinatario = "URE180429TM6",
                            NombreRemitenteDestinatario = "NombreRemitenteDestinatario2",
                            FechaHoraSalidaLlegada = DateTime.Parse("2023-08-01T00:00:01"),
                            DistanciaRecorrida = 1,
                            Domicilio = new Domicilio
                            {
                                Calle = "Calle2", NumeroExterior = "214", NumeroInterior = "215",
                                ColoniaId = "0347", LocalidadId = "23", Referencia = "casa negra",
                                MunicipioId = "004", EstadoId = "COA", PaisId = "MEX", CodigoPostalId = "25350"
                            }
                        }
                    },
                    Mercancias = new List<Mercancia> { CreateMercancia() },
                    Autotransporte = CreateAutotransporte(),
                    TiposFigura = new List<TipoFigura>
                    {
                        new TipoFigura
                        {
                            TipoFiguraId = "01",
                            RFCFigura = "URE180429TM6",
                            NumLicencia = "NumLicencia1",
                            NombreFigura = "NombreFigura1",
                            Domicilio = new Domicilio
                            {
                                Calle = "Calle1", NumeroExterior = "NumeroExterior1", NumeroInterior = "NumeroInterior1",
                                ColoniaId = "Colonia1", LocalidadId = "Localidad1", Referencia = "Referencia1",
                                MunicipioId = "Municipio1", EstadoId = "Estado1", PaisId = "AFG", CodigoPostalId = "CodigoPosta1"
                            }
                        }
                    }
                }
            };

            var apiResponse = await fiscalApi.Invoices.CreateAsync(invoice);

            if (apiResponse.Succeeded)
                MessageBox.Show(JsonConvert.SerializeObject(apiResponse.Data, Formatting.Indented));
            else
            {
                MessageBox.Show(apiResponse.Message);
                MessageBox.Show(apiResponse.Details);
            }
        }

        // button3: Factura ingreso autotransporte extranjero
        private async void button3_Click(object sender, EventArgs e)
        {
            var fiscalApi = FiscalApiClient.Create(_settings);

            var invoice = CreateBaseInvoice();
            invoice.Recipient = new InvoiceRecipient { Id = "37f7c342-d9a6-4881-9620-0da769b50ce5" };

            var domicilioUSA = new Domicilio
            {
                Calle = "ST", NumeroExterior = "214", ColoniaId = "N/A",
                Referencia = "WHITE HOUSE", MunicipioId = "N/A", EstadoId = "TX",
                PaisId = "USA", CodigoPostalId = "N/A"
            };

            invoice.Complement = new Complement
            {
                CartaPorte = new CartaPorte
                {
                    TranspInternacId = "Sí",
                    EntradaSalidaMercId = "Salida",
                    PaisOrigenDestinoId = "USA",
                    ViaEntradaSalidaId = "01",
                    TotalDistRec = 1,
                    RegistroISTMOId = "Sí",
                    UbicacionPoloOrigenId = "01",
                    UbicacionPoloDestinoId = "01",
                    UnidadPesoId = "XBX",
                    LogisticaInversaRecoleccionDevolucionId = "Sí",
                    RegimenAduaneros = new List<RegimenAduanero>
                    {
                        new RegimenAduanero { RegimenAduaneroId = "EXD" }
                    },
                    Ubicaciones = new List<Ubicacion>
                    {
                        new Ubicacion
                        {
                            TipoUbicacion = "Origen",
                            IDUbicacion = "OR101010",
                            RFCRemitenteDestinatario = "XEXX010101000",
                            NumRegIdTrib = "01010101",
                            ResidenciaFiscalId = "USA",
                            FechaHoraSalidaLlegada = DateTime.Parse("2023-08-01T00:00:01"),
                            Domicilio = domicilioUSA
                        },
                        new Ubicacion
                        {
                            TipoUbicacion = "Destino",
                            IDUbicacion = "DE202020",
                            RFCRemitenteDestinatario = "XEXX010101000",
                            NumRegIdTrib = "01010101",
                            ResidenciaFiscalId = "USA",
                            FechaHoraSalidaLlegada = DateTime.Parse("2023-08-01T00:00:01"),
                            DistanciaRecorrida = 1,
                            Domicilio = domicilioUSA
                        }
                    },
                    Mercancias = new List<Mercancia>
                    {
                        new Mercancia
                        {
                            BienesTranspId = "11121900",
                            Descripcion = "Accesorios de equipo de telefonía",
                            Cantidad = 1.0m,
                            ClaveUnidadId = "XBX",
                            MaterialPeligrosoId = "No",
                            DenominacionGenericaProd = "DenominacionGenericaProd1",
                            DenominacionDistintivaProd = "DenominacionDistintivaProd1",
                            Fabricante = "Fabricante1",
                            FechaCaducidad = DateTime.Parse("2003-04-02T00:00:00"),
                            LoteMedicamento = "LoteMedic1",
                            FormaFarmaceuticaId = "01",
                            CondicionesEspTranspId = "01",
                            RegistroSanitarioFolioAutorizacion = "RegistroSanita1",
                            PesoEnKg = 1,
                            FraccionArancelariaId = "6309000100",
                            TipoMateriaId = "05",
                            DescripcionMateria = "otramateria",
                            CantidadTransporta = new List<CantidadTransporta>
                            {
                                new CantidadTransporta { Cantidad = 1, IDOrigen = "OR101010", IDDestino = "DE202020" }
                            }
                        }
                    },
                    Autotransporte = CreateAutotransporte(),
                    TiposFigura = new List<TipoFigura>
                    {
                        new TipoFigura
                        {
                            TipoFiguraId = "01",
                            RFCFigura = "EKU9003173C9",
                            NumLicencia = "NumLicencia1",
                            NombreFigura = "NombreFigura1",
                            Domicilio = domicilioUSA
                        }
                    }
                }
            };

            var apiResponse = await fiscalApi.Invoices.CreateAsync(invoice);

            if (apiResponse.Succeeded)
                MessageBox.Show(JsonConvert.SerializeObject(apiResponse.Data, Formatting.Indented));
            else
            {
                MessageBox.Show(apiResponse.Message);
                MessageBox.Show(apiResponse.Details);
            }
        }

        // button4: Factura ingreso autotransporte internacional aduanero
        private async void button4_Click(object sender, EventArgs e)
        {
            var fiscalApi = FiscalApiClient.Create(_settings);

            var invoice = CreateBaseInvoice();
            invoice.Recipient = new InvoiceRecipient { Id = "37f7c342-d9a6-4881-9620-0da769b50ce5" };

            var domicilioUSA = new Domicilio
            {
                Calle = "ST", NumeroExterior = "214", ColoniaId = "N/A",
                Referencia = "WHITE HOUSE", MunicipioId = "N/A", EstadoId = "TX",
                PaisId = "USA", CodigoPostalId = "N/A"
            };

            invoice.Complement = new Complement
            {
                CartaPorte = new CartaPorte
                {
                    TranspInternacId = "Sí",
                    EntradaSalidaMercId = "Entrada",
                    PaisOrigenDestinoId = "USA",
                    ViaEntradaSalidaId = "01",
                    TotalDistRec = 1,
                    RegistroISTMOId = "Sí",
                    UbicacionPoloOrigenId = "01",
                    UbicacionPoloDestinoId = "01",
                    UnidadPesoId = "XBX",
                    LogisticaInversaRecoleccionDevolucionId = "Sí",
                    RegimenAduaneros = new List<RegimenAduanero>
                    {
                        new RegimenAduanero { RegimenAduaneroId = "IMD" }
                    },
                    Ubicaciones = new List<Ubicacion>
                    {
                        new Ubicacion
                        {
                            TipoUbicacion = "Origen",
                            IDUbicacion = "OR101010",
                            RFCRemitenteDestinatario = "XEXX010101000",
                            NumRegIdTrib = "01010101",
                            ResidenciaFiscalId = "USA",
                            FechaHoraSalidaLlegada = DateTime.Parse("2023-08-01T00:00:01"),
                            Domicilio = domicilioUSA
                        },
                        new Ubicacion
                        {
                            TipoUbicacion = "Destino",
                            IDUbicacion = "DE202020",
                            RFCRemitenteDestinatario = "XEXX010101000",
                            NumRegIdTrib = "01010101",
                            ResidenciaFiscalId = "USA",
                            FechaHoraSalidaLlegada = DateTime.Parse("2023-08-01T00:00:01"),
                            DistanciaRecorrida = 1,
                            Domicilio = domicilioUSA
                        }
                    },
                    Mercancias = new List<Mercancia> { CreateMercancia(includeDocumentacionAduanera: true) },
                    Autotransporte = CreateAutotransporte(),
                    TiposFigura = new List<TipoFigura>
                    {
                        new TipoFigura
                        {
                            TipoFiguraId = "01",
                            RFCFigura = "EKU9003173C9",
                            NumLicencia = "NumLicencia1",
                            NombreFigura = "NombreFigura1",
                            Domicilio = domicilioUSA
                        }
                    }
                }
            };

            var apiResponse = await fiscalApi.Invoices.CreateAsync(invoice);

            if (apiResponse.Succeeded)
                MessageBox.Show(JsonConvert.SerializeObject(apiResponse.Data, Formatting.Indented));
            else
            {
                MessageBox.Show(apiResponse.Message);
                MessageBox.Show(apiResponse.Details);
            }
        }

        // button5: Factura ingreso transporte ferroviario nacional
        private async void button5_Click(object sender, EventArgs e)
        {
            var fiscalApi = FiscalApiClient.Create(_settings);

            var invoice = CreateBaseInvoiceFerroviario();
            invoice.Complement = new Complement
            {
                CartaPorte = new CartaPorte
                {
                    TranspInternacId = "No",
                    TotalDistRec = 500,
                    PesoNetoTotal = 10,
                    RegistroISTMOId = "Sí",
                    UbicacionPoloOrigenId = "01",
                    UbicacionPoloDestinoId = "01",
                    UnidadPesoId = "XBX",
                    Ubicaciones = CreateUbicacionesFerroviarioNacional(),
                    Mercancias = new List<Mercancia> { CreateMercanciaFerroviario() },
                    TransporteFerroviario = CreateTransporteFerroviario(),
                    TiposFigura = new List<TipoFigura> { CreateTipoFiguraFerroviario() }
                }
            };

            var apiResponse = await fiscalApi.Invoices.CreateAsync(invoice);

            if (apiResponse.Succeeded)
                MessageBox.Show(JsonConvert.SerializeObject(apiResponse.Data, Formatting.Indented));
            else
            {
                MessageBox.Show(apiResponse.Message);
                MessageBox.Show(apiResponse.Details);
            }
        }

        // button6: Factura ingreso transporte ferroviario extranjero
        private async void button6_Click(object sender, EventArgs e)
        {
            var fiscalApi = FiscalApiClient.Create(_settings);

            var invoice = CreateBaseInvoiceFerroviario();

            var ubicaciones = CreateUbicacionesFerroviarioNacional();
            // Replace last destination with a foreign one
            ubicaciones[ubicaciones.Count - 1] = new Ubicacion
            {
                TipoUbicacion = "Destino", IDUbicacion = "DE202025",
                RFCRemitenteDestinatario = "XEXX010101000",
                NombreRemitenteDestinatario = "NombreRemitenteDestinatario2",
                NumRegIdTrib = "01010101", ResidenciaFiscalId = "USA",
                NumEstacionId = "EF0001", NombreEstacion = "NombreEstacion",
                FechaHoraSalidaLlegada = DateTime.Parse("2023-08-01T05:00:01"),
                DistanciaRecorrida = 100.00m,
                Domicilio = new Domicilio
                {
                    Calle = "ST", NumeroExterior = "1234", ColoniaId = "1234",
                    Referencia = "WHITE HOUSE", MunicipioId = "1234",
                    EstadoId = "TX", PaisId = "USA", CodigoPostalId = "12345"
                }
            };

            invoice.Complement = new Complement
            {
                CartaPorte = new CartaPorte
                {
                    TranspInternacId = "Sí",
                    EntradaSalidaMercId = "Salida",
                    PaisOrigenDestinoId = "USA",
                    ViaEntradaSalidaId = "04",
                    TotalDistRec = 500,
                    PesoNetoTotal = 10,
                    RegistroISTMOId = "Sí",
                    UbicacionPoloOrigenId = "01",
                    UbicacionPoloDestinoId = "01",
                    UnidadPesoId = "XBX",
                    RegimenAduaneros = new List<RegimenAduanero>
                    {
                        new RegimenAduanero { RegimenAduaneroId = "EXD" }
                    },
                    Ubicaciones = ubicaciones,
                    Mercancias = new List<Mercancia> { CreateMercanciaFerroviario(includeTipoMateria: true) },
                    TransporteFerroviario = CreateTransporteFerroviario(),
                    TiposFigura = new List<TipoFigura> { CreateTipoFiguraFerroviario() }
                }
            };

            var apiResponse = await fiscalApi.Invoices.CreateAsync(invoice);

            if (apiResponse.Succeeded)
                MessageBox.Show(JsonConvert.SerializeObject(apiResponse.Data, Formatting.Indented));
            else
            {
                MessageBox.Show(apiResponse.Message);
                MessageBox.Show(apiResponse.Details);
            }
        }

        // button7: Factura ingresdo transporte ferrovirario internacional aduanero
        private async void button7_Click(object sender, EventArgs e)
        {
            var fiscalApi = FiscalApiClient.Create(_settings);

            var invoice = CreateBaseInvoiceFerroviario();
            invoice.Complement = new Complement
            {
                CartaPorte = new CartaPorte
                {
                    TranspInternacId = "Sí",
                    EntradaSalidaMercId = "Entrada",
                    PaisOrigenDestinoId = "AFG",
                    ViaEntradaSalidaId = "04",
                    TotalDistRec = 500,
                    PesoNetoTotal = 10,
                    RegistroISTMOId = "Sí",
                    UbicacionPoloOrigenId = "01",
                    UbicacionPoloDestinoId = "01",
                    UnidadPesoId = "XBX",
                    RegimenAduaneros = new List<RegimenAduanero>
                    {
                        new RegimenAduanero { RegimenAduaneroId = "IMD" }
                    },
                    Ubicaciones = CreateUbicacionesFerroviarioNacional(),
                    Mercancias = new List<Mercancia> { CreateMercanciaFerroviario(includeDocumentacionAduanera: true) },
                    TransporteFerroviario = CreateTransporteFerroviario(),
                    TiposFigura = new List<TipoFigura> { CreateTipoFiguraFerroviario() }
                }
            };

            var apiResponse = await fiscalApi.Invoices.CreateAsync(invoice);

            if (apiResponse.Succeeded)
                MessageBox.Show(JsonConvert.SerializeObject(apiResponse.Data, Formatting.Indented));
            else
            {
                MessageBox.Show(apiResponse.Message);
                MessageBox.Show(apiResponse.Details);
            }
        }

        // button8: Factura ingreso transporte aereo nacional
        private async void button8_Click(object sender, EventArgs e)
        {
            var fiscalApi = FiscalApiClient.Create(_settings);

            var invoice = CreateBaseInvoice();
            invoice.Series = "Serie";
            invoice.Recipient = new InvoiceRecipient { Id = "37f7c342-d9a6-4881-9620-0da769b50ce5" };

            invoice.Complement = new Complement
            {
                CartaPorte = new CartaPorte
                {
                    TranspInternacId = "No",
                    UnidadPesoId = "XBX",
                    PesoNetoTotal = 10,
                    Ubicaciones = new List<Ubicacion>
                    {
                        new Ubicacion
                        {
                            TipoUbicacion = "Origen", IDUbicacion = "OR101010",
                            RFCRemitenteDestinatario = "EKU9003173C9",
                            NombreRemitenteDestinatario = "NombreRemitenteDestinatario1",
                            NumEstacionId = "EA0417", NombreEstacion = "Loreto",
                            FechaHoraSalidaLlegada = DateTime.Parse("2023-08-01T00:00:00"),
                            TipoEstacionId = "01",
                            Domicilio = new Domicilio
                            {
                                Calle = "Calle1", NumeroExterior = "211", NumeroInterior = "212",
                                ColoniaId = "1957", LocalidadId = "13", Referencia = "casa blanca",
                                MunicipioId = "011", EstadoId = "CMX", PaisId = "MEX", CodigoPostalId = "13250"
                            }
                        },
                        new Ubicacion
                        {
                            TipoUbicacion = "Destino", IDUbicacion = "DE202020",
                            RFCRemitenteDestinatario = "EKU9003173C9",
                            NombreRemitenteDestinatario = "NombreRemitenteDestinatario2",
                            NumEstacionId = "EA0418", NombreEstacion = "Los Cabos",
                            FechaHoraSalidaLlegada = DateTime.Parse("2023-08-01T00:00:01"),
                            TipoEstacionId = "03",
                            Domicilio = new Domicilio
                            {
                                Calle = "Calle2", NumeroExterior = "214", NumeroInterior = "215",
                                ColoniaId = "0347", LocalidadId = "23", Referencia = "casa negra",
                                MunicipioId = "004", EstadoId = "COA", PaisId = "MEX", CodigoPostalId = "25350"
                            }
                        }
                    },
                    Mercancias = new List<Mercancia>
                    {
                        new Mercancia
                        {
                            BienesTranspId = "11121900",
                            Descripcion = "Accesorios de equipo de telefonía",
                            Cantidad = 1.0m,
                            ClaveUnidadId = "XBX",
                            MaterialPeligrosoId = "No",
                            DenominacionGenericaProd = "DenominacionGenericaProd1",
                            DenominacionDistintivaProd = "DenominacionDistintivaProd1",
                            Fabricante = "Fabricante1",
                            FechaCaducidad = DateTime.Parse("2028-01-01T00:00:00"),
                            LoteMedicamento = "LoteMedic1",
                            RegistroSanitarioFolioAutorizacion = "RegistroSanita1",
                            PesoEnKg = 1,
                            ValorMercancia = 100,
                            MonedaId = "MXN",
                            CantidadTransporta = new List<CantidadTransporta>
                            {
                                new CantidadTransporta { Cantidad = 1, IDOrigen = "OR101010", IDDestino = "DE202020" }
                            }
                        }
                    },
                    TransporteAereo = new TransporteAereo
                    {
                        PermSCTId = "TPAF01",
                        NumPermisoSCT = "Demo",
                        MatriculaAeronave = "61E5-WZ",
                        NombreAseg = "NombreAseg",
                        NumPolizaSeguro = "NumPolizaSeguro",
                        NumeroGuia = "acUbYlBVTmlzx",
                        LugarContrato = "LugarContrato",
                        CodigoTransportistaId = "CA001",
                        RFCEmbarcador = "EKU9003173C9",
                        NombreEmbarcador = "Embarcador"
                    },
                    TiposFigura = new List<TipoFigura>
                    {
                        new TipoFigura
                        {
                            TipoFiguraId = "01",
                            RFCFigura = "EKU9003173C9",
                            NumLicencia = "a234567890",
                            NombreFigura = "NombreFigura"
                        }
                    }
                }
            };

            var apiResponse = await fiscalApi.Invoices.CreateAsync(invoice);

            if (apiResponse.Succeeded)
                MessageBox.Show(JsonConvert.SerializeObject(apiResponse.Data, Formatting.Indented));
            else
            {
                MessageBox.Show(apiResponse.Message);
                MessageBox.Show(apiResponse.Details);
            }
        }

        // button9: Factura ingreso transporte aereo extranjero
        private async void button9_Click(object sender, EventArgs e)
        {
            var fiscalApi = FiscalApiClient.Create(_settings);

            var invoice = CreateBaseInvoice();
            invoice.Series = "Serie";
            invoice.Recipient = new InvoiceRecipient { Id = "37f7c342-d9a6-4881-9620-0da769b50ce5" };

            invoice.Complement = new Complement
            {
                CartaPorte = new CartaPorte
                {
                    TranspInternacId = "Sí",
                    EntradaSalidaMercId = "Salida",
                    PaisOrigenDestinoId = "USA",
                    ViaEntradaSalidaId = "03",
                    UnidadPesoId = "XBX",
                    PesoNetoTotal = 10,
                    RegimenAduaneros = new List<RegimenAduanero>
                    {
                        new RegimenAduanero { RegimenAduaneroId = "EXD" }
                    },
                    Ubicaciones = new List<Ubicacion>
                    {
                        new Ubicacion
                        {
                            TipoUbicacion = "Origen", IDUbicacion = "OR101010",
                            RFCRemitenteDestinatario = "EKU9003173C9",
                            NombreRemitenteDestinatario = "NombreRemitenteDestinatario1",
                            NumEstacionId = "EA0417", NombreEstacion = "Loreto",
                            FechaHoraSalidaLlegada = DateTime.Parse("2023-08-01T00:00:00"),
                            TipoEstacionId = "01",
                            Domicilio = new Domicilio
                            {
                                Calle = "Calle2", NumeroExterior = "214", NumeroInterior = "215",
                                ColoniaId = "0347", LocalidadId = "23", Referencia = "casa negra",
                                MunicipioId = "004", EstadoId = "COA", PaisId = "MEX", CodigoPostalId = "25350"
                            }
                        },
                        new Ubicacion
                        {
                            TipoUbicacion = "Destino", IDUbicacion = "DE202020",
                            RFCRemitenteDestinatario = "XEXX010101000",
                            NombreRemitenteDestinatario = "NombreRemitenteDestinatario",
                            NumRegIdTrib = "01010101", ResidenciaFiscalId = "USA",
                            NumEstacionId = "EA0143", NombreEstacion = "Phoenix-Mesa Gateway",
                            FechaHoraSalidaLlegada = DateTime.Parse("2023-08-01T00:00:01"),
                            Domicilio = new Domicilio
                            {
                                Calle = "ST", NumeroExterior = "12344", ColoniaId = "N/A",
                                Referencia = "WHITE HOUSE", MunicipioId = "N/A",
                                EstadoId = "TX", PaisId = "USA", CodigoPostalId = "12345"
                            }
                        }
                    },
                    Mercancias = new List<Mercancia>
                    {
                        new Mercancia
                        {
                            BienesTranspId = "11121900",
                            Descripcion = "Accesorios de equipo de telefonía",
                            Cantidad = 1.0m,
                            ClaveUnidadId = "XBX",
                            MaterialPeligrosoId = "No",
                            DenominacionGenericaProd = "DenominacionGenericaProd1",
                            DenominacionDistintivaProd = "DenominacionDistintivaProd1",
                            Fabricante = "Fabricante1",
                            FechaCaducidad = DateTime.Parse("2028-01-01T00:00:00"),
                            LoteMedicamento = "LoteMedic1",
                            RegistroSanitarioFolioAutorizacion = "RegistroSanita1",
                            PesoEnKg = 1,
                            ValorMercancia = 100,
                            MonedaId = "MXN",
                            TipoMateriaId = "05",
                            DescripcionMateria = "otramateria",
                            CantidadTransporta = new List<CantidadTransporta>
                            {
                                new CantidadTransporta { Cantidad = 1, IDOrigen = "OR101010", IDDestino = "DE202020" }
                            }
                        }
                    },
                    TransporteAereo = new TransporteAereo
                    {
                        PermSCTId = "TPAF01",
                        NumPermisoSCT = "Demo",
                        MatriculaAeronave = "61E5-WZ",
                        NombreAseg = "NombreAseg",
                        NumPolizaSeguro = "NumPolizaSeguro",
                        NumeroGuia = "acUbYlBVTmlzx",
                        LugarContrato = "LugarContrato",
                        CodigoTransportistaId = "CA001",
                        RFCEmbarcador = "EKU9003173C9",
                        NombreEmbarcador = "Embarcador"
                    },
                    TiposFigura = new List<TipoFigura>
                    {
                        new TipoFigura
                        {
                            TipoFiguraId = "01",
                            RFCFigura = "EKU9003173C9",
                            NumLicencia = "a234567890",
                            NombreFigura = "NombreFigura"
                        }
                    }
                }
            };

            var apiResponse = await fiscalApi.Invoices.CreateAsync(invoice);

            if (apiResponse.Succeeded)
                MessageBox.Show(JsonConvert.SerializeObject(apiResponse.Data, Formatting.Indented));
            else
            {
                MessageBox.Show(apiResponse.Message);
                MessageBox.Show(apiResponse.Details);
            }
        }

        // button10: Factura ingreso transporte aereo internacional aduanero
        private async void button10_Click(object sender, EventArgs e)
        {
            var fiscalApi = FiscalApiClient.Create(_settings);

            var invoice = CreateBaseInvoice();
            invoice.Series = "Serie";
            invoice.Recipient = new InvoiceRecipient { Id = "37f7c342-d9a6-4881-9620-0da769b50ce5" };

            invoice.Complement = new Complement
            {
                CartaPorte = new CartaPorte
                {
                    TranspInternacId = "Sí",
                    EntradaSalidaMercId = "Entrada",
                    PaisOrigenDestinoId = "AFG",
                    ViaEntradaSalidaId = "03",
                    UnidadPesoId = "XBX",
                    PesoNetoTotal = 10,
                    RegimenAduaneros = new List<RegimenAduanero>
                    {
                        new RegimenAduanero { RegimenAduaneroId = "IMD" }
                    },
                    Ubicaciones = new List<Ubicacion>
                    {
                        new Ubicacion
                        {
                            TipoUbicacion = "Origen",
                            IDUbicacion = "OR101010",
                            RFCRemitenteDestinatario = "EKU9003173C9",
                            NombreRemitenteDestinatario = "NombreRemitenteDestinatario1",
                            NumEstacionId = "EA0417", NombreEstacion = "Loreto",
                            FechaHoraSalidaLlegada = DateTime.Parse("2023-08-01T00:00:00"),
                            TipoEstacionId = "01",
                            Domicilio = new Domicilio
                            {
                                Calle = "Calle1", NumeroExterior = "211", NumeroInterior = "212",
                                ColoniaId = "1957", LocalidadId = "13", Referencia = "casa blanca",
                                MunicipioId = "011", EstadoId = "CMX", PaisId = "MEX", CodigoPostalId = "13250"
                            }
                        },
                        new Ubicacion
                        {
                            TipoUbicacion = "Destino",
                            IDUbicacion = "DE202020",
                            RFCRemitenteDestinatario = "EKU9003173C9",
                            NombreRemitenteDestinatario = "NombreRemitenteDestinatario2",
                            NumEstacionId = "EA0418", NombreEstacion = "Los Cabos",
                            FechaHoraSalidaLlegada = DateTime.Parse("2023-08-01T00:00:01"),
                            TipoEstacionId = "03",
                            Domicilio = new Domicilio
                            {
                                Calle = "Calle2", NumeroExterior = "214", NumeroInterior = "215",
                                ColoniaId = "0347", LocalidadId = "23", Referencia = "casa negra",
                                MunicipioId = "004", EstadoId = "COA", PaisId = "MEX", CodigoPostalId = "25350"
                            }
                        }
                    },
                    Mercancias = new List<Mercancia>
                    {
                        new Mercancia
                        {
                            BienesTranspId = "11121900",
                            Descripcion = "Accesorios de equipo de telefonía",
                            Cantidad = 1.0m,
                            ClaveUnidadId = "XBX",
                            MaterialPeligrosoId = "No",
                            DenominacionGenericaProd = "DenominacionGenericaProd1",
                            DenominacionDistintivaProd = "DenominacionDistintivaProd1",
                            Fabricante = "Fabricante1",
                            FechaCaducidad = DateTime.Parse("2028-01-01T00:00:00"),
                            LoteMedicamento = "LoteMedic1",
                            RegistroSanitarioFolioAutorizacion = "RegistroSanita1",
                            PesoEnKg = 1,
                            ValorMercancia = 100,
                            MonedaId = "MXN",
                            TipoMateriaId = "05",
                            DescripcionMateria = "otramateria",
                            DocumentacionAduanera = new List<DocumentoAduanero>
                            {
                                new DocumentoAduanero { TipoDocumentoId = "01", NumPedimento = "23  43  0472  8000448", RFCImpo = "EKU9003173C9" }
                            },
                            CantidadTransporta = new List<CantidadTransporta>
                            {
                                new CantidadTransporta { Cantidad = 1, IDOrigen = "OR101010", IDDestino = "DE202020" }
                            }
                        }
                    },
                    TransporteAereo = new TransporteAereo
                    {
                        PermSCTId = "TPAF01",
                        NumPermisoSCT = "Demo",
                        MatriculaAeronave = "61E5-WZ",
                        NombreAseg = "NombreAseg",
                        NumPolizaSeguro = "NumPolizaSeguro",
                        NumeroGuia = "acUbYlBVTmlzx",
                        LugarContrato = "LugarContrato",
                        CodigoTransportistaId = "CA001",
                        RFCEmbarcador = "EKU9003173C9",
                        NombreEmbarcador = "Embarcador"
                    },
                    TiposFigura = new List<TipoFigura>
                    {
                        new TipoFigura
                        {
                            TipoFiguraId = "01",
                            RFCFigura = "EKU9003173C9",
                            NumLicencia = "a234567890",
                            NombreFigura = "NombreFigura"
                        }
                    }
                }
            };

            var apiResponse = await fiscalApi.Invoices.CreateAsync(invoice);

            if (apiResponse.Succeeded)
                MessageBox.Show(JsonConvert.SerializeObject(apiResponse.Data, Formatting.Indented));
            else
            {
                MessageBox.Show(apiResponse.Message);
                MessageBox.Show(apiResponse.Details);
            }
        }

        // button11: Factura ingreso transporte maritimo nacional
        private async void button11_Click(object sender, EventArgs e)
        {
            var fiscalApi = FiscalApiClient.Create(_settings);

            var invoice = CreateBaseInvoice();
            invoice.Series = "Serie";
            invoice.Recipient = new InvoiceRecipient { Id = "37f7c342-d9a6-4881-9620-0da769b50ce5" };

            invoice.Complement = new Complement
            {
                CartaPorte = new CartaPorte
                {
                    TranspInternacId = "No",
                    UnidadPesoId = "XBX",
                    PesoNetoTotal = 1,
                    Ubicaciones = new List<Ubicacion>
                    {
                        new Ubicacion
                        {
                            TipoUbicacion = "Origen", IDUbicacion = "OR101010",
                            RFCRemitenteDestinatario = "EKU9003173C9",
                            NombreRemitenteDestinatario = "NombreRemitenteDestinatario1",
                            NumEstacionId = "PM001", NombreEstacion = "Rosarito",
                            NavegacionTraficoId = "Altura",
                            FechaHoraSalidaLlegada = DateTime.Parse("2023-08-01T00:00:00"),
                            TipoEstacionId = "01",
                            Domicilio = new Domicilio
                            {
                                Calle = "Calle1", NumeroExterior = "211", NumeroInterior = "212",
                                ColoniaId = "1957", LocalidadId = "13", Referencia = "casa blanca",
                                MunicipioId = "011", EstadoId = "CMX", PaisId = "MEX", CodigoPostalId = "13250"
                            }
                        },
                        new Ubicacion
                        {
                            TipoUbicacion = "Destino", IDUbicacion = "DE202020",
                            RFCRemitenteDestinatario = "EKU9003173C9",
                            NombreRemitenteDestinatario = "NombreRemitenteDestinatario2",
                            NumEstacionId = "PM001", NombreEstacion = "Rosarito",
                            NavegacionTraficoId = "Altura",
                            FechaHoraSalidaLlegada = DateTime.Parse("2023-08-01T00:00:01"),
                            TipoEstacionId = "03",
                            Domicilio = new Domicilio
                            {
                                Calle = "Calle2", NumeroExterior = "214", NumeroInterior = "215",
                                ColoniaId = "0347", LocalidadId = "23", Referencia = "casa negra",
                                MunicipioId = "004", EstadoId = "COA", PaisId = "MEX", CodigoPostalId = "25350"
                            }
                        }
                    },
                    Mercancias = new List<Mercancia>
                    {
                        new Mercancia
                        {
                            BienesTranspId = "11121900",
                            Descripcion = "Accesorios de equipo de telefonía",
                            Cantidad = 1.0m,
                            ClaveUnidadId = "XBX",
                            MaterialPeligrosoId = "No",
                            DenominacionGenericaProd = "DenominacionGenericaProd1",
                            DenominacionDistintivaProd = "DenominacionDistintivaProd1",
                            Fabricante = "Fabricante1",
                            FechaCaducidad = DateTime.Parse("2028-01-01T00:00:00"),
                            LoteMedicamento = "LoteMedic1",
                            RegistroSanitarioFolioAutorizacion = "RegistroSanita1",
                            PesoEnKg = 1,
                            CantidadTransporta = new List<CantidadTransporta>
                            {
                                new CantidadTransporta { Cantidad = 1, IDOrigen = "OR101010", IDDestino = "DE202020" }
                            },
                            DetalleMercancia = new DetalleMercancia
                            {
                                UnidadPesoMercId = "Tu",
                                PesoBruto = 1,
                                PesoNeto = 1,
                                PesoTara = 0.001m,
                                NumPiezas = 1
                            }
                        }
                    },
                    TransporteMaritimo = new TransporteMaritimo
                    {
                        PermSCTId = "TPAF01",
                        NumPermisoSCT = "NumPermisoSCT1",
                        NombreAseg = "NombreAseg1",
                        NumPolizaSeguro = "NumPolizaSeguro1",
                        TipoEmbarcacionId = "B01",
                        Matricula = "Matricula1",
                        NumeroOMI = "IMO1234567",
                        AnioEmbarcacion = 2003,
                        NombreEmbarc = "NombreEmbarc1",
                        NacionalidadEmbarcId = "AFG",
                        UnidadesDeArqBruto = 0.001m,
                        TipoCargaId = "CGS",
                        Eslora = 0.01m,
                        Manga = 0.01m,
                        Calado = 0.01m,
                        Puntal = 0.01m,
                        LineaNaviera = "LineaNaviera1",
                        NombreAgenteNaviero = "NombreAgenteNaviero1",
                        NumAutorizacionNavieroId = "ANC001/2022",
                        NumViaje = "NumViaje1",
                        NumConocEmbarc = "NumConocEmbarc1",
                        PermisoTempNavegacion = "PermisoTempNavegac1",
                        Contenedores = new List<ContenedorMaritimo>
                        {
                            new ContenedorMaritimo
                            {
                                TipoContenedorId = "CM011",
                                IdCCPRelacionado = "CCCBCD94-870A-4332-A52A-A52AA52AA52A",
                                PlacaVMCCP = "JNG7683",
                                FechaCertificacionCCP = DateTime.Parse("2024-06-20T11:11:00"),
                                RemolquesCCP = new List<RemolqueCCP>
                                {
                                    new RemolqueCCP { SubTipoRemCCPId = "CTR001", PlacaCCP = "JNG7636" }
                                }
                            }
                        }
                    },
                    TiposFigura = new List<TipoFigura>
                    {
                        new TipoFigura
                        {
                            TipoFiguraId = "02",
                            RFCFigura = "EKU9003173C9",
                            NombreFigura = "NombreFigura",
                            PartesTransporte = new List<ParteTransporte>
                            {
                                new ParteTransporte { ParteTransporteId = "PT02" }
                            },
                            Domicilio = new Domicilio
                            {
                                Calle = "calle", NumeroExterior = "211", ColoniaId = "0814",
                                LocalidadId = "01", Referencia = "casa blanca",
                                MunicipioId = "010", EstadoId = "ZAC", PaisId = "MEX", CodigoPostalId = "99080"
                            }
                        }
                    }
                }
            };

            var apiResponse = await fiscalApi.Invoices.CreateAsync(invoice);

            if (apiResponse.Succeeded)
                MessageBox.Show(JsonConvert.SerializeObject(apiResponse.Data, Formatting.Indented));
            else
            {
                MessageBox.Show(apiResponse.Message);
                MessageBox.Show(apiResponse.Details);
            }
        }

        // button12: Factura ingreso transporte maritimo extranjero
        private async void button12_Click(object sender, EventArgs e)
        {
            var fiscalApi = FiscalApiClient.Create(_settings);

            var invoice = CreateBaseInvoice();
            invoice.Series = "Serie";
            invoice.Recipient = new InvoiceRecipient { Id = "37f7c342-d9a6-4881-9620-0da769b50ce5" };

            invoice.Complement = new Complement
            {
                CartaPorte = new CartaPorte
                {
                    TranspInternacId = "Sí",
                    EntradaSalidaMercId = "Salida",
                    PaisOrigenDestinoId = "USA",
                    ViaEntradaSalidaId = "02",
                    UnidadPesoId = "XBX",
                    PesoNetoTotal = 1,
                    RegimenAduaneros = new List<RegimenAduanero>
                    {
                        new RegimenAduanero { RegimenAduaneroId = "EXD" }
                    },
                    Ubicaciones = new List<Ubicacion>
                    {
                        new Ubicacion
                        {
                            TipoUbicacion = "Origen", IDUbicacion = "OR101010",
                            RFCRemitenteDestinatario = "EKU9003173C9",
                            NombreRemitenteDestinatario = "NombreRemitenteDestinatario1",
                            NumEstacionId = "PM001", NombreEstacion = "Rosarito",
                            NavegacionTraficoId = "Altura",
                            FechaHoraSalidaLlegada = DateTime.Parse("2023-08-01T00:00:00"),
                            TipoEstacionId = "01",
                            Domicilio = new Domicilio
                            {
                                Calle = "Calle1", NumeroExterior = "211", NumeroInterior = "212",
                                ColoniaId = "1957", LocalidadId = "13", Referencia = "casa blanca",
                                MunicipioId = "011", EstadoId = "CMX", PaisId = "MEX", CodigoPostalId = "13250"
                            }
                        },
                        new Ubicacion
                        {
                            TipoUbicacion = "Destino", IDUbicacion = "DE202020",
                            RFCRemitenteDestinatario = "XEXX010101000",
                            NombreRemitenteDestinatario = "NombreRemitenteDestinatario",
                            NumRegIdTrib = "01010101", ResidenciaFiscalId = "USA",
                            NumEstacionId = "PM120", NombreEstacion = "NombreEstacion",
                            NavegacionTraficoId = "Altura",
                            FechaHoraSalidaLlegada = DateTime.Parse("2023-08-01T00:00:01"),
                            Domicilio = new Domicilio
                            {
                                Calle = "ST", NumeroExterior = "12345", ColoniaId = "N/A",
                                Referencia = "N/A", MunicipioId = "N/A",
                                EstadoId = "TX", PaisId = "USA", CodigoPostalId = "12345"
                            }
                        }
                    },
                    Mercancias = new List<Mercancia>
                    {
                        new Mercancia
                        {
                            BienesTranspId = "11121900",
                            Descripcion = "Accesorios de equipo de telefonía",
                            Cantidad = 1.0m,
                            ClaveUnidadId = "XBX",
                            MaterialPeligrosoId = "No",
                            DenominacionGenericaProd = "DenominacionGenericaProd1",
                            DenominacionDistintivaProd = "DenominacionDistintivaProd1",
                            Fabricante = "Fabricante1",
                            FechaCaducidad = DateTime.Parse("2028-01-01T00:00:00"),
                            LoteMedicamento = "LoteMedic1",
                            RegistroSanitarioFolioAutorizacion = "RegistroSanita1",
                            PesoEnKg = 1,
                            ValorMercancia = 100,
                            MonedaId = "MXN",
                            TipoMateriaId = "05",
                            DescripcionMateria = "otramateria",
                            CantidadTransporta = new List<CantidadTransporta>
                            {
                                new CantidadTransporta { Cantidad = 1, IDOrigen = "OR101010", IDDestino = "DE202020" }
                            },
                            DetalleMercancia = new DetalleMercancia
                            {
                                UnidadPesoMercId = "Tu",
                                PesoBruto = 1,
                                PesoNeto = 1,
                                PesoTara = 0.001m,
                                NumPiezas = 1
                            }
                        }
                    },
                    TransporteMaritimo = new TransporteMaritimo
                    {
                        PermSCTId = "TPAF01",
                        NumPermisoSCT = "NumPermisoSCT1",
                        NombreAseg = "NombreAseg1",
                        NumPolizaSeguro = "NumPolizaSeguro1",
                        TipoEmbarcacionId = "B01",
                        Matricula = "Matricula1",
                        NumeroOMI = "IMO1234567",
                        AnioEmbarcacion = 2003,
                        NombreEmbarc = "NombreEmbarc1",
                        NacionalidadEmbarcId = "AFG",
                        UnidadesDeArqBruto = 0.001m,
                        TipoCargaId = "CGS",
                        Eslora = 0.01m,
                        Manga = 0.01m,
                        Calado = 0.01m,
                        Puntal = 0.01m,
                        LineaNaviera = "LineaNaviera1",
                        NombreAgenteNaviero = "NombreAgenteNaviero1",
                        NumAutorizacionNavieroId = "ANC001/2022",
                        NumViaje = "NumViaje1",
                        NumConocEmbarc = "NumConocEmbarc1",
                        PermisoTempNavegacion = "PermisoTempNavegac1",
                        Contenedores = new List<ContenedorMaritimo>
                        {
                            new ContenedorMaritimo
                            {
                                TipoContenedorId = "CM011",
                                IdCCPRelacionado = "CCCBCD94-870A-4332-A52A-A52AA52AA52A",
                                PlacaVMCCP = "JNG7683",
                                FechaCertificacionCCP = DateTime.Parse("2024-06-20T11:11:00"),
                                RemolquesCCP = new List<RemolqueCCP>
                                {
                                    new RemolqueCCP { SubTipoRemCCPId = "CTR001", PlacaCCP = "JNG7636" }
                                }
                            }
                        }
                    },
                    TiposFigura = new List<TipoFigura>
                    {
                        new TipoFigura
                        {
                            TipoFiguraId = "02",
                            RFCFigura = "EKU9003173C9",
                            NombreFigura = "NombreFigura",
                            PartesTransporte = new List<ParteTransporte>
                            {
                                new ParteTransporte { ParteTransporteId = "PT02" }
                            },
                            Domicilio = new Domicilio
                            {
                                Calle = "calle", NumeroExterior = "211", ColoniaId = "0814",
                                LocalidadId = "01", Referencia = "casa blanca",
                                MunicipioId = "010", EstadoId = "ZAC", PaisId = "MEX", CodigoPostalId = "99080"
                            }
                        }
                    }
                }
            };

            var apiResponse = await fiscalApi.Invoices.CreateAsync(invoice);

            if (apiResponse.Succeeded)
                MessageBox.Show(JsonConvert.SerializeObject(apiResponse.Data, Formatting.Indented));
            else
            {
                MessageBox.Show(apiResponse.Message);
                MessageBox.Show(apiResponse.Details);
            }
        }

        // button13: Factura ingreso transporte maritimo internacional aduanero
        private async void button13_Click(object sender, EventArgs e)
        {
            var fiscalApi = FiscalApiClient.Create(_settings);

            var invoice = CreateBaseInvoice();
            invoice.Series = "CP3.1";
            invoice.Recipient = new InvoiceRecipient { Id = "37f7c342-d9a6-4881-9620-0da769b50ce5" };

            invoice.Complement = new Complement
            {
                CartaPorte = new CartaPorte
                {
                    TranspInternacId = "Sí",
                    EntradaSalidaMercId = "Entrada",
                    PaisOrigenDestinoId = "AFG",
                    ViaEntradaSalidaId = "01",
                    RegistroISTMOId = "Sí",
                    UbicacionPoloOrigenId = "01",
                    UbicacionPoloDestinoId = "01",
                    UnidadPesoId = "XBX",
                    PesoNetoTotal = 1,
                    RegimenAduaneros = new List<RegimenAduanero>
                    {
                        new RegimenAduanero { RegimenAduaneroId = "IMD" },
                        new RegimenAduanero { RegimenAduaneroId = "IMD" }
                    },
                    Ubicaciones = new List<Ubicacion>
                    {
                        new Ubicacion
                        {
                            TipoUbicacion = "Origen",
                            IDUbicacion = "OR101010",
                            RFCRemitenteDestinatario = "EKU9003173C9",
                            NombreRemitenteDestinatario = "NombreRemitenteDestinatario1",
                            NumEstacionId = "EA0417",
                            NombreEstacion = "Loreto",
                            NavegacionTraficoId = "Altura",
                            FechaHoraSalidaLlegada = DateTime.Parse("2023-08-01T00:00:00"),
                            TipoEstacionId = "01",
                            Domicilio = new Domicilio
                            {
                                Calle = "Calle1", NumeroExterior = "211", NumeroInterior = "212",
                                ColoniaId = "1957", LocalidadId = "13", Referencia = "casa blanca",
                                MunicipioId = "011", EstadoId = "CMX", PaisId = "MEX", CodigoPostalId = "13250"
                            }
                        },
                        new Ubicacion
                        {
                            TipoUbicacion = "Destino",
                            IDUbicacion = "DE202020",
                            RFCRemitenteDestinatario = "EKU9003173C9",
                            NombreRemitenteDestinatario = "NombreRemitenteDestinatario2",
                            NumEstacionId = "PM001",
                            NombreEstacion = "Rosarito",
                            NavegacionTraficoId = "Altura",
                            FechaHoraSalidaLlegada = DateTime.Parse("2023-08-01T04:00:01"),
                            TipoEstacionId = "02",
                            Domicilio = new Domicilio
                            {
                                Calle = "Calle2", NumeroExterior = "214", NumeroInterior = "215",
                                ColoniaId = "0347", LocalidadId = "23", Referencia = "casa negra",
                                MunicipioId = "004", EstadoId = "COA", PaisId = "MEX", CodigoPostalId = "25350"
                            }
                        }
                    },
                    Mercancias = new List<Mercancia>
                    {
                        new Mercancia
                        {
                            BienesTranspId = "11121900",
                            Descripcion = "Accesorios de equipo de telefonía",
                            Cantidad = 1.0m,
                            ClaveUnidadId = "XBX",
                            MaterialPeligrosoId = "No",
                            DenominacionGenericaProd = "DenominacionGenericaProd1",
                            DenominacionDistintivaProd = "DenominacionDistintivaProd1",
                            Fabricante = "Fabricante1",
                            FechaCaducidad = DateTime.Parse("2003-04-02T00:00:00"),
                            LoteMedicamento = "LoteMedic1",
                            FormaFarmaceuticaId = "01",
                            CondicionesEspTranspId = "01",
                            RegistroSanitarioFolioAutorizacion = "RegistroSanita1",
                            PesoEnKg = 1.50m,
                            ValorMercancia = 100,
                            MonedaId = "MXN",
                            FraccionArancelariaId = "6309000100",
                            TipoMateriaId = "05",
                            DescripcionMateria = "otramateria",
                            DocumentacionAduanera = new List<DocumentoAduanero>
                            {
                                new DocumentoAduanero
                                {
                                    TipoDocumentoId = "01",
                                    NumPedimento = "23  43  0472  8000448",
                                    RFCImpo = "EKU9003173C9"
                                }
                            },
                            CantidadTransporta = new List<CantidadTransporta>
                            {
                                new CantidadTransporta { Cantidad = 1, IDOrigen = "OR101010", IDDestino = "DE202020", CvesTransporteId = "02" }
                            },
                            DetalleMercancia = new DetalleMercancia
                            {
                                UnidadPesoMercId = "X1A",
                                PesoBruto = 1.50m,
                                PesoNeto = 1.00m,
                                PesoTara = 0.50m
                            }
                        }
                    },
                    TransporteMaritimo = new TransporteMaritimo
                    {
                        PermSCTId = "TPAF01",
                        NumPermisoSCT = "NumPermisoSCT1",
                        NombreAseg = "NombreAseg1",
                        NumPolizaSeguro = "NumPolizaSeguro1",
                        TipoEmbarcacionId = "B01",
                        Matricula = "Matricula1",
                        NumeroOMI = "IMO1234567",
                        AnioEmbarcacion = 2003,
                        NombreEmbarc = "NombreEmbarc1",
                        NacionalidadEmbarcId = "AFG",
                        UnidadesDeArqBruto = 0.001m,
                        TipoCargaId = "CGS",
                        Eslora = 0.01m,
                        Manga = 0.01m,
                        Calado = 0.01m,
                        Puntal = 0.01m,
                        LineaNaviera = "LineaNaviera1",
                        NombreAgenteNaviero = "NombreAgenteNaviero1",
                        NumAutorizacionNavieroId = "ANC001/2022",
                        NumViaje = "NumViaje1",
                        NumConocEmbarc = "NumConocEmbarc1",
                        PermisoTempNavegacion = "PermisoTempNavegac1",
                        Contenedores = new List<ContenedorMaritimo>
                        {
                            new ContenedorMaritimo
                            {
                                TipoContenedorId = "CM011",
                                IdCCPRelacionado = "CCCBCD94-870A-4332-A52A-A52AA52AA52A",
                                PlacaVMCCP = "JNG7683",
                                FechaCertificacionCCP = DateTime.Parse("2024-06-20T11:11:00"),
                                RemolquesCCP = new List<RemolqueCCP>
                                {
                                    new RemolqueCCP { SubTipoRemCCPId = "CTR001", PlacaCCP = "JNG7636" }
                                }
                            }
                        }
                    },
                    TransporteAereo = new TransporteAereo
                    {
                        PermSCTId = "TPAF01",
                        NumPermisoSCT = "Demo",
                        MatriculaAeronave = "61E5-WZ",
                        NombreAseg = "NombreAseg",
                        NumPolizaSeguro = "NumPolizaSeguro",
                        NumeroGuia = "acUbYlBVTmlzx",
                        LugarContrato = "LugarContrato",
                        CodigoTransportistaId = "CA001",
                        RFCEmbarcador = "EKU9003173C9",
                        NombreEmbarcador = "Embarcador"
                    },
                    TiposFigura = new List<TipoFigura>
                    {
                        new TipoFigura
                        {
                            TipoFiguraId = "01",
                            RFCFigura = "EKU9003173C9",
                            NumLicencia = "NumLicencia1",
                            NombreFigura = "NombreFigura1",
                            Domicilio = new Domicilio
                            {
                                Calle = "Calle1", NumeroExterior = "NumeroExterior1", NumeroInterior = "NumeroInterior1",
                                ColoniaId = "Colonia1", LocalidadId = "Localidad1", Referencia = "Referencia1",
                                MunicipioId = "Municipio1", EstadoId = "Estado1", PaisId = "AFG", CodigoPostalId = "CodigoPosta1"
                            }
                        }
                    }
                }
            };

            var apiResponse = await fiscalApi.Invoices.CreateAsync(invoice);

            if (apiResponse.Succeeded)
                MessageBox.Show(JsonConvert.SerializeObject(apiResponse.Data, Formatting.Indented));
            else
            {
                MessageBox.Show(apiResponse.Message);
                MessageBox.Show(apiResponse.Details);
            }
        }

        // button14: Factura traslado autotransporte nacional
        private async void button14_Click(object sender, EventArgs e)
        {
            var fiscalApi = FiscalApiClient.Create(_settings);

            var invoice = CreateBaseTraslado();
            invoice.Series = "Serie";

            invoice.Complement = new Complement
            {
                CartaPorte = new CartaPorte
                {
                    TranspInternacId = "No",
                    TotalDistRec = 1,
                    RegistroISTMOId = "Sí",
                    UbicacionPoloOrigenId = "01",
                    UbicacionPoloDestinoId = "01",
                    UnidadPesoId = "XBX",
                    LogisticaInversaRecoleccionDevolucionId = "Sí",
                    Ubicaciones = new List<Ubicacion>
                    {
                        new Ubicacion
                        {
                            TipoUbicacion = "Origen",
                            IDUbicacion = "OR101010",
                            RFCRemitenteDestinatario = "EKU9003173C9",
                            NombreRemitenteDestinatario = "NombreRemitenteDestinatario1",
                            FechaHoraSalidaLlegada = DateTime.Parse("2023-08-01T00:00:00"),
                            Domicilio = new Domicilio
                            {
                                Calle = "Calle1", NumeroExterior = "211", NumeroInterior = "212",
                                ColoniaId = "1957", LocalidadId = "13", Referencia = "casa blanca",
                                MunicipioId = "011", EstadoId = "CMX", PaisId = "MEX", CodigoPostalId = "13250"
                            }
                        },
                        new Ubicacion
                        {
                            TipoUbicacion = "Destino",
                            IDUbicacion = "DE202020",
                            RFCRemitenteDestinatario = "EKU9003173C9",
                            NombreRemitenteDestinatario = "NombreRemitenteDestinatario2",
                            FechaHoraSalidaLlegada = DateTime.Parse("2023-08-01T00:00:01"),
                            DistanciaRecorrida = 1,
                            Domicilio = new Domicilio
                            {
                                Calle = "Calle2", NumeroExterior = "214", NumeroInterior = "215",
                                ColoniaId = "0347", LocalidadId = "23", Referencia = "casa negra",
                                MunicipioId = "004", EstadoId = "COA", PaisId = "MEX", CodigoPostalId = "25350"
                            }
                        }
                    },
                    Mercancias = new List<Mercancia>
                    {
                        new Mercancia
                        {
                            BienesTranspId = "11121900",
                            Descripcion = "Accesorios de equipo de telefonía",
                            Cantidad = 1.0m,
                            ClaveUnidadId = "XBX",
                            MaterialPeligrosoId = "No",
                            DenominacionGenericaProd = "DenominacionGenericaProd1",
                            DenominacionDistintivaProd = "DenominacionDistintivaProd1",
                            Fabricante = "Fabricante1",
                            FechaCaducidad = DateTime.Parse("2028-01-01T00:00:00"),
                            LoteMedicamento = "LoteMedic1",
                            RegistroSanitarioFolioAutorizacion = "RegistroSanita1",
                            PesoEnKg = 1,
                            CantidadTransporta = new List<CantidadTransporta>
                            {
                                new CantidadTransporta { Cantidad = 1, IDOrigen = "OR101010", IDDestino = "DE202020" }
                            }
                        }
                    },
                    Autotransporte = CreateAutotransporte(),
                    TiposFigura = new List<TipoFigura>
                    {
                        new TipoFigura
                        {
                            TipoFiguraId = "01",
                            RFCFigura = "EKU9003173C9",
                            NumLicencia = "a234567890",
                            NombreFigura = "NombreFigura"
                        }
                    }
                }
            };

            var apiResponse = await fiscalApi.Invoices.CreateAsync(invoice);

            if (apiResponse.Succeeded)
                MessageBox.Show(JsonConvert.SerializeObject(apiResponse.Data, Formatting.Indented));
            else
            {
                MessageBox.Show(apiResponse.Message);
                MessageBox.Show(apiResponse.Details);
            }
        }

        // button15: Factura traslado autotransporte extranjero
        private async void button15_Click(object sender, EventArgs e)
        {
            var fiscalApi = FiscalApiClient.Create(_settings);

            var invoice = CreateBaseTraslado();
            invoice.Series = "SerieCCP31";

            var domicilioUSA = new Domicilio
            {
                Calle = "ST", NumeroExterior = "214", ColoniaId = "N/A",
                Referencia = "WHITE HOUSE", MunicipioId = "N/A", EstadoId = "TX",
                PaisId = "USA", CodigoPostalId = "N/A"
            };

            invoice.Complement = new Complement
            {
                CartaPorte = new CartaPorte
                {
                    TranspInternacId = "Sí",
                    EntradaSalidaMercId = "Salida",
                    PaisOrigenDestinoId = "USA",
                    ViaEntradaSalidaId = "01",
                    TotalDistRec = 1,
                    RegistroISTMOId = "Sí",
                    UbicacionPoloOrigenId = "01",
                    UbicacionPoloDestinoId = "01",
                    UnidadPesoId = "XBX",
                    LogisticaInversaRecoleccionDevolucionId = "Sí",
                    RegimenAduaneros = new List<RegimenAduanero>
                    {
                        new RegimenAduanero { RegimenAduaneroId = "EXD" }
                    },
                    Ubicaciones = new List<Ubicacion>
                    {
                        new Ubicacion
                        {
                            TipoUbicacion = "Origen",
                            IDUbicacion = "OR101010",
                            RFCRemitenteDestinatario = "XEXX010101000",
                            NumRegIdTrib = "01010101",
                            ResidenciaFiscalId = "USA",
                            FechaHoraSalidaLlegada = DateTime.Parse("2023-08-01T00:00:01"),
                            Domicilio = domicilioUSA
                        },
                        new Ubicacion
                        {
                            TipoUbicacion = "Destino",
                            IDUbicacion = "DE202020",
                            RFCRemitenteDestinatario = "XEXX010101000",
                            NumRegIdTrib = "01010101",
                            ResidenciaFiscalId = "USA",
                            FechaHoraSalidaLlegada = DateTime.Parse("2023-08-01T00:00:01"),
                            DistanciaRecorrida = 1,
                            Domicilio = domicilioUSA
                        }
                    },
                    Mercancias = new List<Mercancia>
                    {
                        new Mercancia
                        {
                            BienesTranspId = "11121900",
                            Descripcion = "Accesorios de equipo de telefonía",
                            Cantidad = 1.0m,
                            ClaveUnidadId = "XBX",
                            MaterialPeligrosoId = "No",
                            DenominacionGenericaProd = "DenominacionGenericaProd1",
                            DenominacionDistintivaProd = "DenominacionDistintivaProd1",
                            Fabricante = "Fabricante1",
                            FechaCaducidad = DateTime.Parse("2003-04-02T00:00:00"),
                            LoteMedicamento = "LoteMedic1",
                            FormaFarmaceuticaId = "01",
                            CondicionesEspTranspId = "01",
                            RegistroSanitarioFolioAutorizacion = "RegistroSanita1",
                            PesoEnKg = 1,
                            FraccionArancelariaId = "6309000100",
                            TipoMateriaId = "05",
                            DescripcionMateria = "otramateria",
                            CantidadTransporta = new List<CantidadTransporta>
                            {
                                new CantidadTransporta { Cantidad = 1, IDOrigen = "OR101010", IDDestino = "DE202020" }
                            }
                        }
                    },
                    Autotransporte = CreateAutotransporte(),
                    TiposFigura = new List<TipoFigura>
                    {
                        new TipoFigura
                        {
                            TipoFiguraId = "01",
                            RFCFigura = "EKU9003173C9",
                            NumLicencia = "NumLicencia1",
                            NombreFigura = "NombreFigura1",
                            Domicilio = domicilioUSA
                        }
                    }
                }
            };

            var apiResponse = await fiscalApi.Invoices.CreateAsync(invoice);

            if (apiResponse.Succeeded)
                MessageBox.Show(JsonConvert.SerializeObject(apiResponse.Data, Formatting.Indented));
            else
            {
                MessageBox.Show(apiResponse.Message);
                MessageBox.Show(apiResponse.Details);
            }
        }

        // button16: Factura traslado autotransporte internacional aduanero
        private async void button16_Click(object sender, EventArgs e)
        {
            var fiscalApi = FiscalApiClient.Create(_settings);

            var invoice = CreateBaseTraslado();
            invoice.Series = "SerieCCP31";

            var domicilioUSA = new Domicilio
            {
                Calle = "ST", NumeroExterior = "214", ColoniaId = "N/A",
                Referencia = "WHITE HOUSE", MunicipioId = "N/A", EstadoId = "TX",
                PaisId = "USA", CodigoPostalId = "N/A"
            };

            invoice.Complement = new Complement
            {
                CartaPorte = new CartaPorte
                {
                    TranspInternacId = "Sí",
                    EntradaSalidaMercId = "Entrada",
                    PaisOrigenDestinoId = "USA",
                    ViaEntradaSalidaId = "01",
                    TotalDistRec = 1,
                    RegistroISTMOId = "Sí",
                    UbicacionPoloOrigenId = "01",
                    UbicacionPoloDestinoId = "01",
                    UnidadPesoId = "XBX",
                    LogisticaInversaRecoleccionDevolucionId = "Sí",
                    RegimenAduaneros = new List<RegimenAduanero>
                    {
                        new RegimenAduanero { RegimenAduaneroId = "IMD" }
                    },
                    Ubicaciones = new List<Ubicacion>
                    {
                        new Ubicacion
                        {
                            TipoUbicacion = "Origen",
                            IDUbicacion = "OR101010",
                            RFCRemitenteDestinatario = "XEXX010101000",
                            NumRegIdTrib = "01010101",
                            ResidenciaFiscalId = "USA",
                            FechaHoraSalidaLlegada = DateTime.Parse("2023-08-01T00:00:01"),
                            Domicilio = domicilioUSA
                        },
                        new Ubicacion
                        {
                            TipoUbicacion = "Destino",
                            IDUbicacion = "DE202020",
                            RFCRemitenteDestinatario = "XEXX010101000",
                            NumRegIdTrib = "01010101",
                            ResidenciaFiscalId = "USA",
                            FechaHoraSalidaLlegada = DateTime.Parse("2023-08-01T00:00:01"),
                            DistanciaRecorrida = 1,
                            Domicilio = domicilioUSA
                            }
                    },
                    Mercancias = new List<Mercancia>
                    {
                        new Mercancia
                        {
                            BienesTranspId = "11121900",
                            Descripcion = "Accesorios de equipo de telefonía",
                            Cantidad = 1.0m,
                            ClaveUnidadId = "XBX",
                            MaterialPeligrosoId = "No",
                            DenominacionGenericaProd = "DenominacionGenericaProd1",
                            DenominacionDistintivaProd = "DenominacionDistintivaProd1",
                            Fabricante = "Fabricante1",
                            FechaCaducidad = DateTime.Parse("2003-04-02T00:00:00"),
                            LoteMedicamento = "LoteMedic1",
                            FormaFarmaceuticaId = "01",
                            CondicionesEspTranspId = "01",
                            RegistroSanitarioFolioAutorizacion = "RegistroSanita1",
                            PesoEnKg = 1,
                            FraccionArancelariaId = "6309000100",
                            TipoMateriaId = "05",
                            DescripcionMateria = "otramateria",
                            DocumentacionAduanera = new List<DocumentoAduanero>
                            {
                                new DocumentoAduanero
                                {
                                    TipoDocumentoId = "01",
                                    NumPedimento = "23  43  0472  8000448",
                                    RFCImpo = "EKU9003173C9"
                                }
                            },
                            CantidadTransporta = new List<CantidadTransporta>
                            {
                                new CantidadTransporta { Cantidad = 1, IDOrigen = "OR101010", IDDestino = "DE202020" }
                            }
                        }
                    },
                    Autotransporte = CreateAutotransporte(),
                    TiposFigura = new List<TipoFigura>
                    {
                        new TipoFigura
                        {
                            TipoFiguraId = "01",
                            RFCFigura = "EKU9003173C9",
                            NumLicencia = "NumLicencia1",
                            NombreFigura = "NombreFigura1",
                            Domicilio = domicilioUSA
                        }
                    }
                }
            };

            var apiResponse = await fiscalApi.Invoices.CreateAsync(invoice);

            if (apiResponse.Succeeded)
                MessageBox.Show(JsonConvert.SerializeObject(apiResponse.Data, Formatting.Indented));
            else
            {
                MessageBox.Show(apiResponse.Message);
                MessageBox.Show(apiResponse.Details);
            }
        }

        // button17: Factura traslado transporte ferroviario nacional
        private async void button17_Click(object sender, EventArgs e)
        {
            var fiscalApi = FiscalApiClient.Create(_settings);

            var invoice = CreateBaseTraslado();
            invoice.Series = "Serie";
            invoice.Complement = new Complement
            {
                CartaPorte = new CartaPorte
                {
                    TranspInternacId = "No",
                    TotalDistRec = 500,
                    PesoNetoTotal = 10,
                    RegistroISTMOId = "Sí",
                    UbicacionPoloOrigenId = "01",
                    UbicacionPoloDestinoId = "01",
                    UnidadPesoId = "XBX",
                    Ubicaciones = CreateUbicacionesFerroviarioNacional(),
                    Mercancias = new List<Mercancia> { CreateMercanciaFerroviario() },
                    TransporteFerroviario = CreateTransporteFerroviario(),
                    TiposFigura = new List<TipoFigura> { CreateTipoFiguraFerroviario() }
                }
            };

            var apiResponse = await fiscalApi.Invoices.CreateAsync(invoice);

            if (apiResponse.Succeeded)
                MessageBox.Show(JsonConvert.SerializeObject(apiResponse.Data, Formatting.Indented));
            else
            {
                MessageBox.Show(apiResponse.Message);
                MessageBox.Show(apiResponse.Details);
            }
        }

        // button18: Factura traslado transporte ferroviario extranjero
        private async void button18_Click(object sender, EventArgs e)
        {
            var fiscalApi = FiscalApiClient.Create(_settings);

            var invoice = CreateBaseTraslado();
            invoice.Series = "Serie";

            var ubicaciones = CreateUbicacionesFerroviarioNacional();
            // Replace last destination with a foreign one
            ubicaciones[ubicaciones.Count - 1] = new Ubicacion
            {
                TipoUbicacion = "Destino", IDUbicacion = "DE202025",
                RFCRemitenteDestinatario = "XEXX010101000",
                NombreRemitenteDestinatario = "NombreRemitenteDestinatario2",
                NumRegIdTrib = "01010101", ResidenciaFiscalId = "USA",
                NumEstacionId = "EF0001", NombreEstacion = "NombreEstacion",
                FechaHoraSalidaLlegada = DateTime.Parse("2023-08-01T05:00:01"),
                DistanciaRecorrida = 100.00m,
                Domicilio = new Domicilio
                {
                    Calle = "ST", NumeroExterior = "1234", ColoniaId = "1234",
                    Referencia = "WHITE HOUSE", MunicipioId = "1234",
                    EstadoId = "TX", PaisId = "USA", CodigoPostalId = "12345"
                }
            };

            invoice.Complement = new Complement
            {
                CartaPorte = new CartaPorte
                {
                    TranspInternacId = "Sí",
                    EntradaSalidaMercId = "Salida",
                    PaisOrigenDestinoId = "USA",
                    ViaEntradaSalidaId = "04",
                    TotalDistRec = 500,
                    PesoNetoTotal = 10,
                    RegistroISTMOId = "Sí",
                    UbicacionPoloOrigenId = "01",
                    UbicacionPoloDestinoId = "01",
                    UnidadPesoId = "XBX",
                    RegimenAduaneros = new List<RegimenAduanero>
                    {
                        new RegimenAduanero { RegimenAduaneroId = "EXD" }
                    },
                    Ubicaciones = ubicaciones,
                    Mercancias = new List<Mercancia> { CreateMercanciaFerroviario(includeTipoMateria: true) },
                    TransporteFerroviario = CreateTransporteFerroviario(),
                    TiposFigura = new List<TipoFigura> { CreateTipoFiguraFerroviario() }
                }
            };

            var apiResponse = await fiscalApi.Invoices.CreateAsync(invoice);

            if (apiResponse.Succeeded)
                MessageBox.Show(JsonConvert.SerializeObject(apiResponse.Data, Formatting.Indented));
            else
            {
                MessageBox.Show(apiResponse.Message);
                MessageBox.Show(apiResponse.Details);
            }
        }

        // button19: Factura traslado transporte ferroviario inernacional aduanero
        private async void button19_Click(object sender, EventArgs e)
        {
            var fiscalApi = FiscalApiClient.Create(_settings);

            var invoice = CreateBaseTraslado();
            invoice.Series = "Serie";
            invoice.Complement = new Complement
            {
                CartaPorte = new CartaPorte
                {
                    TranspInternacId = "Sí",
                    EntradaSalidaMercId = "Entrada",
                    PaisOrigenDestinoId = "AFG",
                    ViaEntradaSalidaId = "04",
                    TotalDistRec = 500,
                    PesoNetoTotal = 10,
                    RegistroISTMOId = "Sí",
                    UbicacionPoloOrigenId = "01",
                    UbicacionPoloDestinoId = "01",
                    UnidadPesoId = "XBX",
                    RegimenAduaneros = new List<RegimenAduanero>
                    {
                        new RegimenAduanero { RegimenAduaneroId = "IMD" }
                    },
                    Ubicaciones = CreateUbicacionesFerroviarioNacional(),
                    Mercancias = new List<Mercancia> { CreateMercanciaFerroviario(includeDocumentacionAduanera: true) },
                    TransporteFerroviario = CreateTransporteFerroviario(),
                    TiposFigura = new List<TipoFigura> { CreateTipoFiguraFerroviario() }
                }
            };

            var apiResponse = await fiscalApi.Invoices.CreateAsync(invoice);

            if (apiResponse.Succeeded)
                MessageBox.Show(JsonConvert.SerializeObject(apiResponse.Data, Formatting.Indented));
            else
            {
                MessageBox.Show(apiResponse.Message);
                MessageBox.Show(apiResponse.Details);
            }
        }

        // button20: Factura traslado transporte aereo nacional
        private async void button20_Click(object sender, EventArgs e)
        {
            var fiscalApi = FiscalApiClient.Create(_settings);

            var invoice = CreateBaseTraslado();
            invoice.Series = "Serie";
            invoice.Complement = new Complement
            {
                CartaPorte = new CartaPorte
                {
                    TranspInternacId = "No",
                    UnidadPesoId = "XBX",
                    PesoNetoTotal = 10,
                    Ubicaciones = new List<Ubicacion>
                    {
                        new Ubicacion
                        {
                            TipoUbicacion = "Origen", IDUbicacion = "OR101010",
                            RFCRemitenteDestinatario = "EKU9003173C9",
                            NombreRemitenteDestinatario = "NombreRemitenteDestinatario1",
                            NumEstacionId = "EA0417", NombreEstacion = "Loreto",
                            FechaHoraSalidaLlegada = DateTime.Parse("2023-08-01T00:00:00"),
                            TipoEstacionId = "01",
                            Domicilio = new Domicilio
                            {
                                Calle = "Calle1", NumeroExterior = "211", NumeroInterior = "212",
                                ColoniaId = "1957", LocalidadId = "13", Referencia = "casa blanca",
                                MunicipioId = "011", EstadoId = "CMX", PaisId = "MEX", CodigoPostalId = "13250"
                            }
                        },
                        new Ubicacion
                        {
                            TipoUbicacion = "Destino", IDUbicacion = "DE202020",
                            RFCRemitenteDestinatario = "EKU9003173C9",
                            NombreRemitenteDestinatario = "NombreRemitenteDestinatario2",
                            NumEstacionId = "EA0418", NombreEstacion = "Los Cabos",
                            FechaHoraSalidaLlegada = DateTime.Parse("2023-08-01T00:00:01"),
                            TipoEstacionId = "03",
                            Domicilio = new Domicilio
                            {
                                Calle = "Calle2", NumeroExterior = "214", NumeroInterior = "215",
                                ColoniaId = "0347", LocalidadId = "23", Referencia = "casa negra",
                                MunicipioId = "004", EstadoId = "COA", PaisId = "MEX", CodigoPostalId = "25350"
                            }
                        }
                    },
                    Mercancias = new List<Mercancia>
                    {
                        new Mercancia
                        {
                            BienesTranspId = "11121900",
                            Descripcion = "Accesorios de equipo de telefonía",
                            Cantidad = 1.0m,
                            ClaveUnidadId = "XBX",
                            MaterialPeligrosoId = "No",
                            DenominacionGenericaProd = "DenominacionGenericaProd1",
                            DenominacionDistintivaProd = "DenominacionDistintivaProd1",
                            Fabricante = "Fabricante1",
                            FechaCaducidad = DateTime.Parse("2028-01-01T00:00:00"),
                            LoteMedicamento = "LoteMedic1",
                            RegistroSanitarioFolioAutorizacion = "RegistroSanita1",
                            PesoEnKg = 1,
                            ValorMercancia = 100,
                            MonedaId = "MXN",
                            CantidadTransporta = new List<CantidadTransporta>
                            {
                                new CantidadTransporta { Cantidad = 1, IDOrigen = "OR101010", IDDestino = "DE202020" }
                            }
                        }
                    },
                    TransporteAereo = new TransporteAereo
                    {
                        PermSCTId = "TPAF01",
                        NumPermisoSCT = "Demo",
                        MatriculaAeronave = "61E5-WZ",
                        NombreAseg = "NombreAseg",
                        NumPolizaSeguro = "NumPolizaSeguro",
                        NumeroGuia = "acUbYlBVTmlzx",
                        LugarContrato = "LugarContrato",
                        CodigoTransportistaId = "CA001",
                        RFCEmbarcador = "EKU9003173C9",
                        NombreEmbarcador = "Embarcador"
                    },
                    TiposFigura = new List<TipoFigura>
                    {
                        new TipoFigura
                        {
                            TipoFiguraId = "01",
                            RFCFigura = "EKU9003173C9",
                            NumLicencia = "a234567890",
                            NombreFigura = "NombreFigura"
                        }
                    }
                }
            };

            var apiResponse = await fiscalApi.Invoices.CreateAsync(invoice);

            if (apiResponse.Succeeded)
                MessageBox.Show(JsonConvert.SerializeObject(apiResponse.Data, Formatting.Indented));
            else
            {
                MessageBox.Show(apiResponse.Message);
                MessageBox.Show(apiResponse.Details);
            }
        }

        // button21: Factura traslado transporte aereo extranjero
        private async void button21_Click(object sender, EventArgs e)
        {
            var fiscalApi = FiscalApiClient.Create(_settings);

            var invoice = CreateBaseTraslado();
            invoice.Series = "Serie";

            invoice.Complement = new Complement
            {
                CartaPorte = new CartaPorte
                {
                    TranspInternacId = "Sí",
                    EntradaSalidaMercId = "Salida",
                    PaisOrigenDestinoId = "USA",
                    ViaEntradaSalidaId = "03",
                    UnidadPesoId = "XBX",
                    PesoNetoTotal = 10,
                    RegimenAduaneros = new List<RegimenAduanero>
                    {
                        new RegimenAduanero { RegimenAduaneroId = "EXD" }
                    },
                    Ubicaciones = new List<Ubicacion>
                    {
                        new Ubicacion
                        {
                            TipoUbicacion = "Origen", IDUbicacion = "OR101010",
                            RFCRemitenteDestinatario = "EKU9003173C9",
                            NombreRemitenteDestinatario = "NombreRemitenteDestinatario1",
                            NumEstacionId = "EA0417", NombreEstacion = "Loreto",
                            FechaHoraSalidaLlegada = DateTime.Parse("2023-08-01T00:00:00"),
                            TipoEstacionId = "01",
                            Domicilio = new Domicilio
                            {
                                Calle = "Calle2", NumeroExterior = "214", NumeroInterior = "215",
                                ColoniaId = "0347", LocalidadId = "23", Referencia = "casa negra",
                                MunicipioId = "004", EstadoId = "COA", PaisId = "MEX", CodigoPostalId = "25350"
                            }
                        },
                        new Ubicacion
                        {
                            TipoUbicacion = "Destino", IDUbicacion = "DE202020",
                            RFCRemitenteDestinatario = "XEXX010101000",
                            NombreRemitenteDestinatario = "NombreRemitenteDestinatario",
                            NumRegIdTrib = "01010101", ResidenciaFiscalId = "USA",
                            NumEstacionId = "EA0143", NombreEstacion = "Phoenix-Mesa Gateway",
                            FechaHoraSalidaLlegada = DateTime.Parse("2023-08-01T00:00:01"),
                            Domicilio = new Domicilio
                            {
                                Calle = "ST", NumeroExterior = "12344", ColoniaId = "N/A",
                                Referencia = "WHITE HOUSE", MunicipioId = "N/A",
                                EstadoId = "TX", PaisId = "USA", CodigoPostalId = "12345"
                            }
                        }
                    },
                    Mercancias = new List<Mercancia>
                    {
                        new Mercancia
                        {
                            BienesTranspId = "11121900",
                            Descripcion = "Accesorios de equipo de telefonía",
                            Cantidad = 1.0m,
                            ClaveUnidadId = "XBX",
                            MaterialPeligrosoId = "No",
                            DenominacionGenericaProd = "DenominacionGenericaProd1",
                            DenominacionDistintivaProd = "DenominacionDistintivaProd1",
                            Fabricante = "Fabricante1",
                            FechaCaducidad = DateTime.Parse("2028-01-01T00:00:00"),
                            LoteMedicamento = "LoteMedic1",
                            RegistroSanitarioFolioAutorizacion = "RegistroSanita1",
                            PesoEnKg = 1,
                            ValorMercancia = 100,
                            MonedaId = "MXN",
                            TipoMateriaId = "05",
                            DescripcionMateria = "otramateria",
                            CantidadTransporta = new List<CantidadTransporta>
                            {
                                new CantidadTransporta { Cantidad = 1, IDOrigen = "OR101010", IDDestino = "DE202020" }
                            }
                        }
                    },
                    TransporteAereo = new TransporteAereo
                    {
                        PermSCTId = "TPAF01",
                        NumPermisoSCT = "Demo",
                        MatriculaAeronave = "61E5-WZ",
                        NombreAseg = "NombreAseg",
                        NumPolizaSeguro = "NumPolizaSeguro",
                        NumeroGuia = "acUbYlBVTmlzx",
                        LugarContrato = "LugarContrato",
                        CodigoTransportistaId = "CA001",
                        RFCEmbarcador = "EKU9003173C9",
                        NombreEmbarcador = "Embarcador"
                    },
                    TiposFigura = new List<TipoFigura>
                    {
                        new TipoFigura
                        {
                            TipoFiguraId = "01",
                            RFCFigura = "EKU9003173C9",
                            NumLicencia = "a234567890",
                            NombreFigura = "NombreFigura"
                        }
                    }
                }
            };

            var apiResponse = await fiscalApi.Invoices.CreateAsync(invoice);

            if (apiResponse.Succeeded)
                MessageBox.Show(JsonConvert.SerializeObject(apiResponse.Data, Formatting.Indented));
            else
            {
                MessageBox.Show(apiResponse.Message);
                MessageBox.Show(apiResponse.Details);
            }
        }

        // button22: Factura traslado transporte aereo internacional aduanero
        private async void button22_Click(object sender, EventArgs e)
        {
            var fiscalApi = FiscalApiClient.Create(_settings);

            var invoice = CreateBaseTraslado();
            invoice.Series = "Serie";

            invoice.Complement = new Complement
            {
                CartaPorte = new CartaPorte
                {
                    TranspInternacId = "Sí",
                    EntradaSalidaMercId = "Entrada",
                    PaisOrigenDestinoId = "AFG",
                    ViaEntradaSalidaId = "03",
                    UnidadPesoId = "XBX",
                    PesoNetoTotal = 10,
                    RegimenAduaneros = new List<RegimenAduanero>
                    {
                        new RegimenAduanero { RegimenAduaneroId = "IMD" }
                    },
                    Ubicaciones = new List<Ubicacion>
                    {
                        new Ubicacion
                        {
                            TipoUbicacion = "Origen", IDUbicacion = "OR101010",
                            RFCRemitenteDestinatario = "EKU9003173C9",
                            NombreRemitenteDestinatario = "NombreRemitenteDestinatario1",
                            NumEstacionId = "EA0417", NombreEstacion = "Loreto",
                            FechaHoraSalidaLlegada = DateTime.Parse("2023-08-01T00:00:00"),
                            TipoEstacionId = "01",
                            Domicilio = new Domicilio
                            {
                                Calle = "Calle1", NumeroExterior = "211", NumeroInterior = "212",
                                ColoniaId = "1957", LocalidadId = "13", Referencia = "casa blanca",
                                MunicipioId = "011", EstadoId = "CMX", PaisId = "MEX", CodigoPostalId = "13250"
                            }
                        },
                        new Ubicacion
                        {
                            TipoUbicacion = "Destino", IDUbicacion = "DE202020",
                            RFCRemitenteDestinatario = "EKU9003173C9",
                            NombreRemitenteDestinatario = "NombreRemitenteDestinatario2",
                            NumEstacionId = "EA0418", NombreEstacion = "Los Cabos",
                            FechaHoraSalidaLlegada = DateTime.Parse("2023-08-01T00:00:01"),
                            TipoEstacionId = "03",
                            Domicilio = new Domicilio
                            {
                                Calle = "Calle2", NumeroExterior = "214", NumeroInterior = "215",
                                ColoniaId = "0347", LocalidadId = "23", Referencia = "casa negra",
                                MunicipioId = "004", EstadoId = "COA", PaisId = "MEX", CodigoPostalId = "25350"
                            }
                        }
                    },
                    Mercancias = new List<Mercancia>
                    {
                        new Mercancia
                        {
                            BienesTranspId = "11121900",
                            Descripcion = "Accesorios de equipo de telefonía",
                            Cantidad = 1.0m,
                            ClaveUnidadId = "XBX",
                            MaterialPeligrosoId = "No",
                            DenominacionGenericaProd = "DenominacionGenericaProd1",
                            DenominacionDistintivaProd = "DenominacionDistintivaProd1",
                            Fabricante = "Fabricante1",
                            FechaCaducidad = DateTime.Parse("2028-01-01T00:00:00"),
                            LoteMedicamento = "LoteMedic1",
                            RegistroSanitarioFolioAutorizacion = "RegistroSanita1",
                            PesoEnKg = 1,
                            ValorMercancia = 100,
                            MonedaId = "MXN",
                            TipoMateriaId = "05",
                            DescripcionMateria = "otramateria",
                            DocumentacionAduanera = new List<DocumentoAduanero>
                            {
                                new DocumentoAduanero
                                {
                                    TipoDocumentoId = "01",
                                    NumPedimento = "23  43  0472  8000448",
                                    RFCImpo = "EKU9003173C9"
                                }
                            },
                            CantidadTransporta = new List<CantidadTransporta>
                            {
                                new CantidadTransporta { Cantidad = 1, IDOrigen = "OR101010", IDDestino = "DE202020" }
                            }
                        }
                    },
                    TransporteAereo = new TransporteAereo
                    {
                        PermSCTId = "TPAF01",
                        NumPermisoSCT = "Demo",
                        MatriculaAeronave = "61E5-WZ",
                        NombreAseg = "NombreAseg",
                        NumPolizaSeguro = "NumPolizaSeguro",
                        NumeroGuia = "acUbYlBVTmlzx",
                        LugarContrato = "LugarContrato",
                        CodigoTransportistaId = "CA001",
                        RFCEmbarcador = "EKU9003173C9",
                        NombreEmbarcador = "Embarcador"
                    },
                    TiposFigura = new List<TipoFigura>
                    {
                        new TipoFigura
                        {
                            TipoFiguraId = "01",
                            RFCFigura = "EKU9003173C9",
                            NumLicencia = "a234567890",
                            NombreFigura = "NombreFigura"
                        }
                    }
                }
            };

            var apiResponse = await fiscalApi.Invoices.CreateAsync(invoice);

            if (apiResponse.Succeeded)
                MessageBox.Show(JsonConvert.SerializeObject(apiResponse.Data, Formatting.Indented));
            else
            {
                MessageBox.Show(apiResponse.Message);
                MessageBox.Show(apiResponse.Details);
            }
        }

        // button23: Factura traslado transporte maritimo nacional
        private async void button23_Click(object sender, EventArgs e)
        {
            var fiscalApi = FiscalApiClient.Create(_settings);

            var invoice = CreateBaseTraslado();
            invoice.Series = "Serie";

            invoice.Complement = new Complement
            {
                CartaPorte = new CartaPorte
                {
                    TranspInternacId = "No",
                    UnidadPesoId = "XBX",
                    PesoNetoTotal = 1,
                    Ubicaciones = new List<Ubicacion>
                    {
                        new Ubicacion
                        {
                            TipoUbicacion = "Origen", IDUbicacion = "OR101010",
                            RFCRemitenteDestinatario = "EKU9003173C9",
                            NombreRemitenteDestinatario = "NombreRemitenteDestinatario1",
                            NumEstacionId = "PM001", NombreEstacion = "Rosarito",
                            NavegacionTraficoId = "Altura",
                            FechaHoraSalidaLlegada = DateTime.Parse("2023-08-01T00:00:00"),
                            TipoEstacionId = "01",
                            Domicilio = new Domicilio
                            {
                                Calle = "Calle1", NumeroExterior = "211", NumeroInterior = "212",
                                ColoniaId = "1957", LocalidadId = "13", Referencia = "casa blanca",
                                MunicipioId = "011", EstadoId = "CMX", PaisId = "MEX", CodigoPostalId = "13250"
                            }
                        },
                        new Ubicacion
                        {
                            TipoUbicacion = "Destino", IDUbicacion = "DE202020",
                            RFCRemitenteDestinatario = "EKU9003173C9",
                            NombreRemitenteDestinatario = "NombreRemitenteDestinatario2",
                            NumEstacionId = "PM001", NombreEstacion = "Rosarito",
                            NavegacionTraficoId = "Altura",
                            FechaHoraSalidaLlegada = DateTime.Parse("2023-08-01T00:00:01"),
                            TipoEstacionId = "03",
                            Domicilio = new Domicilio
                            {
                                Calle = "Calle2", NumeroExterior = "214", NumeroInterior = "215",
                                ColoniaId = "0347", LocalidadId = "23", Referencia = "casa negra",
                                MunicipioId = "004", EstadoId = "COA", PaisId = "MEX", CodigoPostalId = "25350"
                            }
                        }
                    },
                    Mercancias = new List<Mercancia>
                    {
                        new Mercancia
                        {
                            BienesTranspId = "11121900",
                            Descripcion = "Accesorios de equipo de telefonía",
                            Cantidad = 1.0m,
                            ClaveUnidadId = "XBX",
                            MaterialPeligrosoId = "No",
                            DenominacionGenericaProd = "DenominacionGenericaProd1",
                            DenominacionDistintivaProd = "DenominacionDistintivaProd1",
                            Fabricante = "Fabricante1",
                            FechaCaducidad = DateTime.Parse("2028-01-01T00:00:00"),
                            LoteMedicamento = "LoteMedic1",
                            RegistroSanitarioFolioAutorizacion = "RegistroSanita1",
                            PesoEnKg = 1,
                            ValorMercancia = 100,
                            MonedaId = "MXN",
                            CantidadTransporta = new List<CantidadTransporta>
                            {
                                new CantidadTransporta { Cantidad = 1, IDOrigen = "OR101010", IDDestino = "DE202020" }
                            },
                            DetalleMercancia = new DetalleMercancia
                            {
                                UnidadPesoMercId = "Tu",
                                PesoBruto = 1,
                                PesoNeto = 1,
                                PesoTara = 0.001m,
                                NumPiezas = 1
                            }
                        }
                    },
                    TransporteMaritimo = new TransporteMaritimo
                    {
                        PermSCTId = "TPAF01",
                        NumPermisoSCT = "NumPermisoSCT1",
                        NombreAseg = "NombreAseg1",
                        NumPolizaSeguro = "NumPolizaSeguro1",
                        TipoEmbarcacionId = "B01",
                        Matricula = "Matricula1",
                        NumeroOMI = "IMO1234567",
                        AnioEmbarcacion = 2003,
                        NombreEmbarc = "NombreEmbarc1",
                        NacionalidadEmbarcId = "AFG",
                        UnidadesDeArqBruto = 0.001m,
                        TipoCargaId = "CGS",
                        Eslora = 0.01m,
                        Manga = 0.01m,
                        Calado = 0.01m,
                        Puntal = 0.01m,
                        LineaNaviera = "LineaNaviera1",
                        NombreAgenteNaviero = "NombreAgenteNaviero1",
                        NumAutorizacionNavieroId = "ANC001/2022",
                        NumViaje = "NumViaje1",
                        NumConocEmbarc = "NumConocEmbarc1",
                        PermisoTempNavegacion = "PermisoTempNavegac1",
                        Contenedores = new List<ContenedorMaritimo>
                        {
                            new ContenedorMaritimo
                            {
                                TipoContenedorId = "CM011",
                                IdCCPRelacionado = "CCCBCD94-870A-4332-A52A-A52AA52AA52A",
                                PlacaVMCCP = "JNG7683",
                                FechaCertificacionCCP = DateTime.Parse("2024-06-20T11:11:00"),
                                RemolquesCCP = new List<RemolqueCCP>
                                {
                                    new RemolqueCCP { SubTipoRemCCPId = "CTR001", PlacaCCP = "JNG7636" }
                                }
                            }
                        }
                    },
                    TiposFigura = new List<TipoFigura>
                    {
                        new TipoFigura
                        {
                            TipoFiguraId = "02",
                            RFCFigura = "EKU9003173C9",
                            NombreFigura = "NombreFigura",
                            PartesTransporte = new List<ParteTransporte>
                            {
                                new ParteTransporte { ParteTransporteId = "PT02" }
                            },
                            Domicilio = new Domicilio
                            {
                                Calle = "calle", NumeroExterior = "211", ColoniaId = "0814",
                                LocalidadId = "01", Referencia = "casa blanca",
                                MunicipioId = "010", EstadoId = "ZAC", PaisId = "MEX", CodigoPostalId = "99080"
                            }
                        }
                    }
                }
            };

            var apiResponse = await fiscalApi.Invoices.CreateAsync(invoice);

            if (apiResponse.Succeeded)
                MessageBox.Show(JsonConvert.SerializeObject(apiResponse.Data, Formatting.Indented));
            else
            {
                MessageBox.Show(apiResponse.Message);
                MessageBox.Show(apiResponse.Details);
            }
        }

        // button24: Factura traslado transporte maritimo extranjero
        private async void button24_Click(object sender, EventArgs e)
        {
            var fiscalApi = FiscalApiClient.Create(_settings);

            var invoice = CreateBaseTraslado();
            invoice.Series = "Serie";

            invoice.Complement = new Complement
            {
                CartaPorte = new CartaPorte
                {
                    TranspInternacId = "Sí",
                    EntradaSalidaMercId = "Salida",
                    PaisOrigenDestinoId = "USA",
                    ViaEntradaSalidaId = "02",
                    UnidadPesoId = "XBX",
                    PesoNetoTotal = 1,
                    RegimenAduaneros = new List<RegimenAduanero>
                    {
                        new RegimenAduanero { RegimenAduaneroId = "EXD" }
                    },
                    Ubicaciones = new List<Ubicacion>
                    {
                        new Ubicacion
                        {
                            TipoUbicacion = "Origen", IDUbicacion = "OR101010",
                            RFCRemitenteDestinatario = "EKU9003173C9",
                            NombreRemitenteDestinatario = "NombreRemitenteDestinatario1",
                            NumEstacionId = "PM001", NombreEstacion = "Rosarito",
                            NavegacionTraficoId = "Altura",
                            FechaHoraSalidaLlegada = DateTime.Parse("2023-08-01T00:00:00"),
                            TipoEstacionId = "01",
                            Domicilio = new Domicilio
                            {
                                Calle = "Calle1", NumeroExterior = "211", NumeroInterior = "212",
                                ColoniaId = "1957", LocalidadId = "13", Referencia = "casa blanca",
                                MunicipioId = "011", EstadoId = "CMX", PaisId = "MEX", CodigoPostalId = "13250"
                            }
                        },
                        new Ubicacion
                        {
                            TipoUbicacion = "Destino", IDUbicacion = "DE202020",
                            RFCRemitenteDestinatario = "XEXX010101000",
                            NombreRemitenteDestinatario = "NombreRemitenteDestinatario2",
                            NumRegIdTrib = "01010101", ResidenciaFiscalId = "USA",
                            NumEstacionId = "PM120", NombreEstacion = "NombreEstacion",
                            NavegacionTraficoId = "Altura",
                            FechaHoraSalidaLlegada = DateTime.Parse("2023-08-01T00:00:01"),
                            Domicilio = new Domicilio
                            {
                                Calle = "ST", NumeroExterior = "12345", ColoniaId = "N/A",
                                Referencia = "N/A", MunicipioId = "N/A",
                                EstadoId = "TX", PaisId = "USA", CodigoPostalId = "12345"
                            }
                        }
                    },
                    Mercancias = new List<Mercancia>
                    {
                        new Mercancia
                        {
                            BienesTranspId = "11121900",
                            Descripcion = "Accesorios de equipo de telefonía",
                            Cantidad = 1.0m,
                            ClaveUnidadId = "XBX",
                            MaterialPeligrosoId = "No",
                            DenominacionGenericaProd = "DenominacionGenericaProd1",
                            DenominacionDistintivaProd = "DenominacionDistintivaProd1",
                            Fabricante = "Fabricante1",
                            FechaCaducidad = DateTime.Parse("2028-01-01T00:00:00"),
                            LoteMedicamento = "LoteMedic1",
                            RegistroSanitarioFolioAutorizacion = "RegistroSanita1",
                            PesoEnKg = 1,
                            ValorMercancia = 100,
                            MonedaId = "MXN",
                            TipoMateriaId = "05",
                            DescripcionMateria = "otramateria",
                            CantidadTransporta = new List<CantidadTransporta>
                            {
                                new CantidadTransporta { Cantidad = 1, IDOrigen = "OR101010", IDDestino = "DE202020" }
                            },
                            DetalleMercancia = new DetalleMercancia
                            {
                                UnidadPesoMercId = "Tu",
                                PesoBruto = 1,
                                PesoNeto = 1,
                                PesoTara = 0.001m,
                                NumPiezas = 1
                            }
                        }
                    },
                    TransporteMaritimo = new TransporteMaritimo
                    {
                        PermSCTId = "TPAF01",
                        NumPermisoSCT = "NumPermisoSCT1",
                        NombreAseg = "NombreAseg1",
                        NumPolizaSeguro = "NumPolizaSeguro1",
                        TipoEmbarcacionId = "B01",
                        Matricula = "Matricula1",
                        NumeroOMI = "IMO1234567",
                        AnioEmbarcacion = 2003,
                        NombreEmbarc = "NombreEmbarc1",
                        NacionalidadEmbarcId = "AFG",
                        UnidadesDeArqBruto = 0.001m,
                        TipoCargaId = "CGS",
                        Eslora = 0.01m,
                        Manga = 0.01m,
                        Calado = 0.01m,
                        Puntal = 0.01m,
                        LineaNaviera = "LineaNaviera1",
                        NombreAgenteNaviero = "NombreAgenteNaviero1",
                        NumAutorizacionNavieroId = "ANC001/2022",
                        NumViaje = "NumViaje1",
                        NumConocEmbarc = "NumConocEmbarc1",
                        PermisoTempNavegacion = "PermisoTempNavegac1",
                        Contenedores = new List<ContenedorMaritimo>
                        {
                            new ContenedorMaritimo
                            {
                                TipoContenedorId = "CM011",
                                IdCCPRelacionado = "CCCBCD94-870A-4332-A52A-A52AA52AA52A",
                                PlacaVMCCP = "JNG7683",
                                FechaCertificacionCCP = DateTime.Parse("2024-06-20T11:11:00"),
                                RemolquesCCP = new List<RemolqueCCP>
                                {
                                    new RemolqueCCP { SubTipoRemCCPId = "CTR001", PlacaCCP = "JNG7636" }
                                }
                            }
                        }
                    },
                    TiposFigura = new List<TipoFigura>
                    {
                        new TipoFigura
                        {
                            TipoFiguraId = "02",
                            RFCFigura = "EKU9003173C9",
                            NombreFigura = "NombreFigura",
                            PartesTransporte = new List<ParteTransporte>
                            {
                                new ParteTransporte { ParteTransporteId = "PT02" }
                            },
                            Domicilio = new Domicilio
                            {
                                Calle = "calle", NumeroExterior = "211", ColoniaId = "0814",
                                LocalidadId = "01", Referencia = "casa blanca",
                                MunicipioId = "010", EstadoId = "ZAC", PaisId = "MEX", CodigoPostalId = "99080"
                            }
                        }
                    }
                }
            };

            var apiResponse = await fiscalApi.Invoices.CreateAsync(invoice);

            if (apiResponse.Succeeded)
                MessageBox.Show(JsonConvert.SerializeObject(apiResponse.Data, Formatting.Indented));
            else
            {
                MessageBox.Show(apiResponse.Message);
                MessageBox.Show(apiResponse.Details);
            }
        }

        // button25: Factura traslado transporte maritimo internacional aduanero
        private async void button25_Click(object sender, EventArgs e)
        {
            var fiscalApi = FiscalApiClient.Create(_settings);

            var invoice = CreateBaseTraslado();
            invoice.Series = "Serie";

            invoice.Complement = new Complement
            {
                CartaPorte = new CartaPorte
                {
                    TranspInternacId = "Sí",
                    EntradaSalidaMercId = "Entrada",
                    PaisOrigenDestinoId = "AFG",
                    ViaEntradaSalidaId = "02",
                    UnidadPesoId = "XBX",
                    PesoNetoTotal = 1,
                    RegimenAduaneros = new List<RegimenAduanero>
                    {
                        new RegimenAduanero { RegimenAduaneroId = "IMD" },
                        new RegimenAduanero { RegimenAduaneroId = "IMD" }
                    },
                    Ubicaciones = new List<Ubicacion>
                    {
                        new Ubicacion
                        {
                            TipoUbicacion = "Origen", IDUbicacion = "OR101010",
                            RFCRemitenteDestinatario = "EKU9003173C9",
                            NombreRemitenteDestinatario = "NombreRemitenteDestinatario1",
                            NumEstacionId = "PM001", NombreEstacion = "Rosarito",
                            NavegacionTraficoId = "Altura",
                            FechaHoraSalidaLlegada = DateTime.Parse("2023-08-01T00:00:00"),
                            TipoEstacionId = "01",
                            Domicilio = new Domicilio
                            {
                                Calle = "Calle1", NumeroExterior = "211", NumeroInterior = "212",
                                ColoniaId = "1957", LocalidadId = "13", Referencia = "casa blanca",
                                MunicipioId = "011", EstadoId = "CMX", PaisId = "MEX", CodigoPostalId = "13250"
                            }
                        },
                        new Ubicacion
                        {
                            TipoUbicacion = "Destino", IDUbicacion = "DE202020",
                            RFCRemitenteDestinatario = "EKU9003173C9",
                            NombreRemitenteDestinatario = "NombreRemitenteDestinatario2",
                            NumEstacionId = "PM001", NombreEstacion = "Rosarito",
                            NavegacionTraficoId = "Altura",
                            FechaHoraSalidaLlegada = DateTime.Parse("2023-08-01T00:00:01"),
                            TipoEstacionId = "03",
                            Domicilio = new Domicilio
                            {
                                Calle = "Calle2", NumeroExterior = "214", NumeroInterior = "215",
                                ColoniaId = "0347", LocalidadId = "23", Referencia = "casa negra",
                                MunicipioId = "004", EstadoId = "COA", PaisId = "MEX", CodigoPostalId = "25350"
                            }
                        }
                    },
                    Mercancias = new List<Mercancia>
                    {
                        new Mercancia
                        {
                            BienesTranspId = "11121900",
                            Descripcion = "Accesorios de equipo de telefonía",
                            Cantidad = 1.0m,
                            ClaveUnidadId = "XBX",
                            MaterialPeligrosoId = "No",
                            DenominacionGenericaProd = "DenominacionGenericaProd1",
                            DenominacionDistintivaProd = "DenominacionDistintivaProd1",
                            Fabricante = "Fabricante1",
                            FechaCaducidad = DateTime.Parse("2028-01-01T00:00:00"),
                            LoteMedicamento = "LoteMedic1",
                            RegistroSanitarioFolioAutorizacion = "RegistroSanita1",
                            PesoEnKg = 1,
                            ValorMercancia = 100,
                            MonedaId = "MXN",
                            TipoMateriaId = "05",
                            DescripcionMateria = "otramateria",
                            DocumentacionAduanera = new List<DocumentoAduanero>
                            {
                                new DocumentoAduanero
                                {
                                    TipoDocumentoId = "01",
                                    NumPedimento = "23  43  0472  8000448",
                                    RFCImpo = "EKU9003173C9"
                                }
                            },
                            CantidadTransporta = new List<CantidadTransporta>
                            {
                                new CantidadTransporta { Cantidad = 1, IDOrigen = "OR101010", IDDestino = "DE202020" }
                            },
                            DetalleMercancia = new DetalleMercancia
                            {
                                UnidadPesoMercId = "Tu",
                                PesoBruto = 1,
                                PesoNeto = 1,
                                PesoTara = 0.001m,
                                NumPiezas = 1
                            }
                        }
                    },
                    TransporteMaritimo = new TransporteMaritimo
                    {
                        PermSCTId = "TPAF01",
                        NumPermisoSCT = "NumPermisoSCT1",
                        NombreAseg = "NombreAseg1",
                        NumPolizaSeguro = "NumPolizaSeguro1",
                        TipoEmbarcacionId = "B01",
                        Matricula = "Matricula1",
                        NumeroOMI = "IMO1234567",
                        AnioEmbarcacion = 2003,
                        NombreEmbarc = "NombreEmbarc1",
                        NacionalidadEmbarcId = "AFG",
                        UnidadesDeArqBruto = 0.001m,
                        TipoCargaId = "CGS",
                        Eslora = 0.01m,
                        Manga = 0.01m,
                        Calado = 0.01m,
                        Puntal = 0.01m,
                        LineaNaviera = "LineaNaviera1",
                        NombreAgenteNaviero = "NombreAgenteNaviero1",
                        NumAutorizacionNavieroId = "ANC001/2022",
                        NumViaje = "NumViaje1",
                        NumConocEmbarc = "NumConocEmbarc1",
                        PermisoTempNavegacion = "PermisoTempNavegac1",
                        Contenedores = new List<ContenedorMaritimo>
                        {
                            new ContenedorMaritimo
                            {
                                TipoContenedorId = "CM011",
                                IdCCPRelacionado = "CCCBCD94-870A-4332-A52A-A52AA52AA52A",
                                PlacaVMCCP = "JNG7683",
                                FechaCertificacionCCP = DateTime.Parse("2024-06-20T11:11:00"),
                                RemolquesCCP = new List<RemolqueCCP>
                                {
                                    new RemolqueCCP { SubTipoRemCCPId = "CTR001", PlacaCCP = "JNG7636" }
                                }
                            }
                        }
                    },
                    TiposFigura = new List<TipoFigura>
                    {
                        new TipoFigura
                        {
                            TipoFiguraId = "02",
                            RFCFigura = "EKU9003173C9",
                            NombreFigura = "NombreFigura",
                            PartesTransporte = new List<ParteTransporte>
                            {
                                new ParteTransporte { ParteTransporteId = "PT02" }
                            },
                            Domicilio = new Domicilio
                            {
                                Calle = "calle", NumeroExterior = "211", ColoniaId = "0814",
                                LocalidadId = "01", Referencia = "casa blanca",
                                MunicipioId = "010", EstadoId = "ZAC", PaisId = "MEX", CodigoPostalId = "99080"
                            }
                        }
                    }
                }
            };

            var apiResponse = await fiscalApi.Invoices.CreateAsync(invoice);

            if (apiResponse.Succeeded)
                MessageBox.Show(JsonConvert.SerializeObject(apiResponse.Data, Formatting.Indented));
            else
            {
                MessageBox.Show(apiResponse.Message);
                MessageBox.Show(apiResponse.Details);
            }
        }

        private TransporteFerroviario CreateTransporteFerroviario()
        {
            return new TransporteFerroviario
            {
                TipoDeServicioId = "TS01",
                TipoDeTraficoId = "TT01",
                DerechosDePaso = new List<DerechoDePaso>
                {
                    new DerechoDePaso { TipoDerechoDePasoId = "CDP114", KilometrajePagado = 100 }
                },
                Carros = new List<Carro>
                {
                    new Carro
                    {
                        TipoCarroId = "TC08",
                        MatriculaCarro = "A00012",
                        GuiaCarro = "123ASD",
                        ToneladasNetasCarro = 10
                    }
                }
            };
        }

        private TipoFigura CreateTipoFiguraFerroviario()
        {
            return new TipoFigura
            {
                TipoFiguraId = "02",
                RFCFigura = "EKU9003173C9",
                NombreFigura = "NombreFigura",
                PartesTransporte = new List<ParteTransporte>
                {
                    new ParteTransporte { ParteTransporteId = "PT02" }
                },
                Domicilio = new Domicilio
                {
                    Calle = "calle", NumeroExterior = "211", ColoniaId = "0814",
                    LocalidadId = "01", Referencia = "casa blanca",
                    MunicipioId = "010", EstadoId = "ZAC", PaisId = "MEX", CodigoPostalId = "99080"
                }
            };
        }

        private List<Ubicacion> CreateUbicacionesFerroviarioNacional()
        {
            return new List<Ubicacion>
            {
                new Ubicacion
                {
                    TipoUbicacion = "Origen", IDUbicacion = "OR101010",
                    RFCRemitenteDestinatario = "EKU9003173C9",
                    NombreRemitenteDestinatario = "NombreRemitenteDestinatario1",
                    NumEstacionId = "Q0736", NombreEstacion = "SANTO NINO",
                    FechaHoraSalidaLlegada = DateTime.Parse("2023-08-01T00:00:00"),
                    TipoEstacionId = "01",
                    Domicilio = new Domicilio
                    {
                        Calle = "Calle1", NumeroExterior = "211", NumeroInterior = "212",
                        ColoniaId = "1957", LocalidadId = "13", Referencia = "casa blanca",
                        MunicipioId = "011", EstadoId = "CMX", PaisId = "MEX", CodigoPostalId = "13250"
                    }
                },
                new Ubicacion
                {
                    TipoUbicacion = "Destino", IDUbicacion = "DE202021",
                    RFCRemitenteDestinatario = "EKU9003173C9",
                    NombreRemitenteDestinatario = "NombreRemitenteDestinatario2",
                    NumEstacionId = "SC283", NombreEstacion = "HUAXTITLA",
                    FechaHoraSalidaLlegada = DateTime.Parse("2023-08-01T01:00:01"),
                    TipoEstacionId = "02", DistanciaRecorrida = 100.00m
                },
                new Ubicacion
                {
                    TipoUbicacion = "Destino", IDUbicacion = "DE202022",
                    RFCRemitenteDestinatario = "EKU9003173C9",
                    NombreRemitenteDestinatario = "NombreRemitenteDestinatario2",
                    NumEstacionId = "TG0", NombreEstacion = "NAVOJOA",
                    FechaHoraSalidaLlegada = DateTime.Parse("2023-08-01T02:00:01"),
                    TipoEstacionId = "02", DistanciaRecorrida = 100.00m
                },
                new Ubicacion
                {
                    TipoUbicacion = "Destino", IDUbicacion = "DE202023",
                    RFCRemitenteDestinatario = "EKU9003173C9",
                    NombreRemitenteDestinatario = "NombreRemitenteDestinatario2",
                    NumEstacionId = "E0029", NombreEstacion = "TRES JAGUEYES",
                    FechaHoraSalidaLlegada = DateTime.Parse("2023-08-01T03:00:01"),
                    TipoEstacionId = "02", DistanciaRecorrida = 100.00m
                },
                new Ubicacion
                {
                    TipoUbicacion = "Destino", IDUbicacion = "DE202024",
                    RFCRemitenteDestinatario = "EKU9003173C9",
                    NombreRemitenteDestinatario = "NombreRemitenteDestinatario2",
                    NumEstacionId = "TI032", NombreEstacion = "NAVOLATO",
                    FechaHoraSalidaLlegada = DateTime.Parse("2023-08-01T04:00:01"),
                    TipoEstacionId = "02", DistanciaRecorrida = 100.00m
                },
                new Ubicacion
                {
                    TipoUbicacion = "Destino", IDUbicacion = "DE202025",
                    RFCRemitenteDestinatario = "EKU9003173C9",
                    NombreRemitenteDestinatario = "NombreRemitenteDestinatario2",
                    NumEstacionId = "JM047", NombreEstacion = "HUEHUETOCA",
                    FechaHoraSalidaLlegada = DateTime.Parse("2023-08-01T05:00:01"),
                    TipoEstacionId = "03", DistanciaRecorrida = 100.00m,
                    Domicilio = new Domicilio
                    {
                        Calle = "Calle2", NumeroExterior = "214", NumeroInterior = "215",
                        ColoniaId = "0347", LocalidadId = "23", Referencia = "casa negra",
                        MunicipioId = "004", EstadoId = "COA", PaisId = "MEX", CodigoPostalId = "25350"
                    }
                }
            };
        }

        private Mercancia CreateMercanciaFerroviario(bool includeTipoMateria = false, bool includeDocumentacionAduanera = false)
        {
            var m = new Mercancia
            {
                BienesTranspId = "11121900",
                Descripcion = "Accesorios de equipo de telefonía",
                Cantidad = 1.0m,
                ClaveUnidadId = "XBX",
                MaterialPeligrosoId = "No",
                DenominacionGenericaProd = "DenominacionGenericaProd1",
                DenominacionDistintivaProd = "DenominacionDistintivaProd1",
                Fabricante = "Fabricante1",
                FechaCaducidad = DateTime.Parse("2028-01-01T00:00:00"),
                LoteMedicamento = "LoteMedic1",
                RegistroSanitarioFolioAutorizacion = "RegistroSanita1",
                PesoEnKg = 1,
                CantidadTransporta = new List<CantidadTransporta>
                {
                    new CantidadTransporta { Cantidad = 1, IDOrigen = "OR101010", IDDestino = "DE202025" }
                }
            };

            if (includeTipoMateria || includeDocumentacionAduanera)
            {
                m.TipoMateriaId = "05";
                m.DescripcionMateria = "otramateria";
            }

            if (includeDocumentacionAduanera)
            {
                m.DocumentacionAduanera = new List<DocumentoAduanero>
                {
                    new DocumentoAduanero
                    {
                        TipoDocumentoId = "01",
                        NumPedimento = "23  43  0472  8000448",
                        RFCImpo = "EKU9003173C9"
                    }
                };
            }

            return m;
        }

        private Invoice CreateBaseInvoiceFerroviario()
        {
            var invoice = CreateBaseInvoice();
            invoice.Series = "Serie";
            invoice.Recipient = new InvoiceRecipient { Id = "37f7c342-d9a6-4881-9620-0da769b50ce5" };
            return invoice;
        }

        private Invoice CreateBaseTraslado()
        {
            return new Invoice
            {
                VersionCode = "4.0",
                CurrencyCode = "XXX",
                TypeCode = "T",
                ExpeditionZipCode = "42501",
                PaymentMethodCode = "",
                Date = DateTime.Now,
                ExchangeRate = 1,
                ExportCode = "01",
                Issuer = CreateIssuer(),
                Recipient = new InvoiceRecipient { Id = "0e82a655-5f0c-4e07-abab-8f322e4123ef" },
                Items = new List<InvoiceItem>
                {
                    new InvoiceItem
                    {
                        ItemCode = "78101800",
                        ItemSku = "UT421511",
                        Quantity = 1,
                        UnitOfMeasurementCode = "H87",
                        Description = "Transporte de carga por carretera",
                        UnitPrice = 100.00m,
                        Discount = 0,
                        TaxObjectCode = "01",
                        ItemTaxes = new List<InvoiceItemTax>()
                    }
                }
            };
        }
    }
}
