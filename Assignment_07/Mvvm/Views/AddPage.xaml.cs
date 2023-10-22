using Assignment_07.Mvvm.ViewModels;

namespace Assignment_07.Mvvm.Views;

public partial class AddPage : ContentPage
{
	public AddPage(AddPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}