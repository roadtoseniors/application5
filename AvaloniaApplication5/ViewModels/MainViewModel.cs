using CommunityToolkit.Mvvm.ComponentModel;

namespace AvaloniaApplication5.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty] private string _greeting = "Welcome to Avalonia!";
}