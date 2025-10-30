// Giovanne CB 3026591 / Ricardo CB3025543
// Projeto: Rastreador de Pacotes - .NET MAUI
// CBTPRDM - Trabalho Prático 03
using System.Threading.Tasks;
using PackageTracker.Models;

namespace PackageTracker.Services
{
    public interface IPackageService
    {
        Task<Package> GetPackageAsync(string trackingNumber);
    }
}