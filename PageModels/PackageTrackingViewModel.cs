using System.Collections.ObjectModel;
using System.Windows.Input;
using PackageTracker.Models;
using PackageTracker.Services;

namespace PackageTracker.PageModels
{
    public class PackageTrackingViewModel : BaseViewModel
    {
        private readonly IPackageService _packageService;

        private string _trackingNumber;
        private Package _currentPackage;
        private bool _isLoading;
        private string _errorMessage;

        public PackageTrackingViewModel(IPackageService packageService)
        {
            _packageService = packageService;
            SearchCommand = new Command(ExecuteSearch, CanExecuteSearch);
            BackCommand = new Command(ExecuteBack);
        }

        public string TrackingNumber
        {
            get => _trackingNumber;
            set
            {
                _trackingNumber = value;
                OnPropertyChanged();
                (SearchCommand as Command)?.ChangeCanExecute();
            }
        }

        public Package CurrentPackage
        {
            get => _currentPackage;
            set
            {
                _currentPackage = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(HasPackage));
            }
        }

        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                _isLoading = value;
                OnPropertyChanged();
            }
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(HasError));
            }
        }

        public bool HasPackage => CurrentPackage != null;
        public bool HasError => !string.IsNullOrEmpty(ErrorMessage);

        public ICommand SearchCommand { get; }
        public ICommand BackCommand { get; }

        private bool CanExecuteSearch() => !string.IsNullOrWhiteSpace(TrackingNumber);

        private async void ExecuteSearch()
        {
            if (string.IsNullOrWhiteSpace(TrackingNumber))
                return;

            try
            {
                IsLoading = true;
                ErrorMessage = string.Empty;

                var package = await _packageService.GetPackageAsync(TrackingNumber);

                if (package != null)
                {
                    CurrentPackage = package;
                }
                else
                {
                    ErrorMessage = "Pacote não encontrado. Verifique o código de rastreamento.";
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Erro ao buscar pacote: {ex.Message}";
            }
            finally
            {
                IsLoading = false;
            }
        }

        private void ExecuteBack()
        {
            CurrentPackage = null;
            TrackingNumber = string.Empty;
            ErrorMessage = string.Empty;
        }
    }
}