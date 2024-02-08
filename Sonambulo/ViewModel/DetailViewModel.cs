using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Sonambulo.ViewModel;

[QueryProperty("Text", "Text")]
public partial class DetailViewModel: ObservableObject
{
    [ObservableProperty]
    string text;

    [RelayCommand]
    public async Task GoBack()
    {
        await Shell.Current.GoToAsync("..");
    }
}
