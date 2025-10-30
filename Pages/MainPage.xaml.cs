// Giovanne CB 3026591 / Ricardo CB3025543
// Projeto: Rastreador de Pacotes - .NET MAUI
// CBTPRDM - Trabalho Prático 03
using PackageTracker.PageModels;
using PackageTracker.Services;

namespace PackageTracker.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            // Configura o ViewModel manualmente
            var packageService = new PackageService();
            var viewModel = new PackageTrackingViewModel(packageService);

            BindingContext = viewModel;
        }
    }
}