using Assignment_07.Mvvm.Models;
using Assignment_07.Mvvm.Views;
using Assignment_07.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace Assignment_07.Mvvm.ViewModels;

public partial class DetailsPageViewModel :ObservableObject
{
    //Fältvariabel som håller en referens till ContactService 
    private readonly ContactService _contactService;

    public DetailsPageViewModel(ContactService contactService)
    {
        _contactService = contactService;//Sätter den privata variabeln till den inmatade instansen 
        Contact = _contactService.CurrentContact; // Sätter kontakt egenskaperna till akuella kontakten från ContactService
    }
    // Egenskap för ContactModel som kan vara observerbar i användargränssnittet 
    [ObservableProperty]
    ContactModel contact = new ContactModel();

    //Metod för att gå tillbaka 
    [RelayCommand]
    public async Task GoBack()
    {
        await Shell.Current.Navigation.PopAsync();
    }
    // Metod för att gå till Edit delen 
    [RelayCommand]
    public async Task GoToEdit()
    {
        await Shell.Current.GoToAsync(nameof(EditPage));
    }   
   //Metod för att ta bort en kontakt 
    [RelayCommand]
    public async Task DeleteContact()
    {
        //Ta bort en kontakt 
        _contactService.RemoveContactFromList(Contact);

        // Gå tillbaka till huvudsidan
        await Shell.Current.GoToAsync("../..");
    }

    


}
