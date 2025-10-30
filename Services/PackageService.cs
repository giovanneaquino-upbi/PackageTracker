// Giovanne CB 3026591 / Ricardo CB3025543
// Projeto: Rastreador de Pacotes - .NET MAUI
// CBTPRDM - Trabalho Prático 03
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PackageTracker.Models;

namespace PackageTracker.Services
{
    public class PackageService : IPackageService
    {
        public async Task<Package> GetPackageAsync(string trackingNumber)
        {
            // Simula uma chamada de API
            await Task.Delay(1500);

            // Dados fictícios para demonstração
            return trackingNumber.ToUpper() switch
            {
                "BR123456789" => CreateSamplePackage1(),
                "BR987654321" => CreateSamplePackage2(),
                "TESTE123" => CreateSamplePackage1(),
                _ => null
            };
        }

        private Package CreateSamplePackage1()
        {
            return new Package
            {
                Id = "1",
                TrackingNumber = "BR123456789",
                Status = "Em Trânsito",
                ShipDate = DateTime.Now.AddDays(-3),
                EstimatedDelivery = DateTime.Now.AddDays(2),
                CurrentLocation = "Centro de Distribuição São Paulo",
                RecipientName = "João Silva",
                Events = new List<PackageEvent>
                {
                    new PackageEvent {
                        Date = DateTime.Now.AddDays(-3),
                        Location = "Rio de Janeiro",
                        Description = "Pedido postado",
                        Status = "Postado"
                    },
                    new PackageEvent {
                        Date = DateTime.Now.AddDays(-2),
                        Location = "Rio de Janeiro",
                        Description = "Em processamento",
                        Status = "Processando"
                    },
                    new PackageEvent {
                        Date = DateTime.Now.AddDays(-1),
                        Location = "São Paulo",
                        Description = "Chegou ao centro de distribuição",
                        Status = "Em Trânsito"
                    }
                }
            };
        }

        private Package CreateSamplePackage2()
        {
            return new Package
            {
                Id = "2",
                TrackingNumber = "BR987654321",
                Status = "Entregue",
                ShipDate = DateTime.Now.AddDays(-7),
                EstimatedDelivery = DateTime.Now.AddDays(-1),
                CurrentLocation = "Entregue",
                RecipientName = "Maria Santos",
                Events = new List<PackageEvent>
                {
                    new PackageEvent {
                        Date = DateTime.Now.AddDays(-7),
                        Location = "Curitiba",
                        Description = "Pedido postado",
                        Status = "Postado"
                    },
                    new PackageEvent {
                        Date = DateTime.Now.AddDays(-5),
                        Location = "Curitiba",
                        Description = "Em processamento",
                        Status = "Processando"
                    },
                    new PackageEvent {
                        Date = DateTime.Now.AddDays(-3),
                        Location = "São Paulo",
                        Description = "Chegou ao centro de distribuição",
                        Status = "Em Trânsito"
                    },
                    new PackageEvent {
                        Date = DateTime.Now.AddDays(-1),
                        Location = "São Paulo",
                        Description = "Saiu para entrega",
                        Status = "Saiu para Entrega"
                    },
                    new PackageEvent {
                        Date = DateTime.Now.AddDays(-1).AddHours(3),
                        Location = "São Paulo",
                        Description = "Entregue ao destinatário",
                        Status = "Entregue"
                    }
                }
            };
        }
    }
}