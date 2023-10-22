using Assignment_07.Mvvm.Models;
using Assignment_07.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Assignment_07.Mvvm.ViewModels;

public partial class EditPageViewModel : ObservableObject
{
    // en referens till ContactService som är privat 
    private readonly ContactService _contactService;
   
    // En egenskap för ContactModel som kan vara observerbat i användargränssnittet 
    [ObservableProperty]
    ContactModel contact = new ContactModel();

    //En struktur för editpageviewmodel och tar in ContactService som parameter 
    public EditPageViewModel(ContactService contactService)
    {
        _contactService = contactService; // Sätter den privata variabeln till den inmatade instansen
        Contact = _contactService.CurrentContact; // Sätter Contact-egenskaperna till den aktuella kontakten från ContactService
     
    }

    //Metod för att spara ändringar i kontaken 
    [RelayCommand]
    public async Task SaveContact()
    {
        //Spara kontakten
        _contactService.UpdateContact(Contact);
       
        await Shell.Current.GoToAsync($"../.."); 
    }

    // en navigering tillbaka till föregående vy
    [RelayCommand]
    public async Task GoBack()
    {
        await Shell.Current.GoToAsync($"..");
    }

   
}
