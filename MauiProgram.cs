// Giovanne CB 3026591 / Ricardo CB3025543
// Projeto: Rastreador de Pacotes - .NET MAUI
// CBTPRDM - Trabalho Prático 03

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;
using PackageTracker.Pages;
using PackageTracker.PageModels;
using PackageTracker.Services;

namespace PackageTracker
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            // Registro de serviços
            builder.Services.AddSingleton<IPackageService, PackageService>();
            builder.Services.AddTransient<PackageTrackingViewModel>();
            builder.Services.AddTransient<MainPage>();

            return builder.Build();
        }
    }
}