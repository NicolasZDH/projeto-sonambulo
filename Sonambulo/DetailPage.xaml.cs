using Sonambulo.ViewModel;

namespace Sonambulo;

public partial class DetailPage : ContentPage
{
	public DetailPage(DetailViewModel detailViewModel)
	{
		InitializeComponent();
		BindingContext = detailViewModel;

    }
}