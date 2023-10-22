using Assignment_07.Mvvm.Models;
using Assignment_07.Mvvm.ViewModels;
using Assignment_07.Services;

namespace Assignment_07.Mvvm.Views;


public partial class EditPage : ContentPage
{

    public EditPage(EditPageViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
       
    }

}