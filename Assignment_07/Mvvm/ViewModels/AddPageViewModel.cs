using Assignment_07.Mvvm.Models;
using Assignment_07.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Assignment_07.Mvvm.ViewModels;

public partial class AddPageViewModel: ObservableObject
{
    //Fältvariabel som håller en referens till ContactService 
    private readonly ContactService _contactService;
  
    public AddPageViewModel(ContactService contactService)
    {
        _contactService = contactService;// sätter den privata variabeln till den inmatade instansen 
    }

    //Egenskap för ContactModel som kan vara observerbar i användargränsnittet 
    [ObservableProperty]
    ContactModel contact = new ContactModel();

    // Spara en kontakt en kontakt
    [RelayCommand]
    public async Task SaveContact()
    {
        //Spara kontakten
       _contactService.AddContactToList(Contact);
        // återställer Contact till en ny instans av ContactModel
        Contact = new ContactModel();
        // navigera tillbaka 
        await Shell.Current.GoToAsync($"..");
    }
    // Tillbaka funktionen (knappen)
    [RelayCommand]
    public async Task GoBack()
    {
        await Shell.Current.GoToAsync($"..");
        
    }
}
