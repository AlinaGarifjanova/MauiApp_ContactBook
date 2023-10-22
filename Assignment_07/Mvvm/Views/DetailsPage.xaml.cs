using Assignment_07.Mvvm.Models;
using Assignment_07.Mvvm.ViewModels;

namespace Assignment_07.Mvvm.Views;


public partial class DetailsPage : ContentPage
{

    public DetailsPage(DetailsPageViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }

}