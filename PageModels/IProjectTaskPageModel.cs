using CommunityToolkit.Mvvm.Input;
using PackageTracker.Models;

namespace PackageTracker.PageModels
{
    public interface IProjectTaskPageModel
    {
        IAsyncRelayCommand<ProjectTask> NavigateToTaskCommand { get; }
        bool IsBusy { get; }
    }
}