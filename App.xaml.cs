// Giovanne CB 3026591 / Ricardo CB3025543
// Projeto: Rastreador de Pacotes - .NET MAUI
// CBTPRDM - Trabalho Prático 03
namespace PackageTracker
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new Pages.MainPage();
        }
    }
}