using Assignment_07.Mvvm.Models;
using Assignment_07.Mvvm.Views;
using Assignment_07.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Assignment_07.Mvvm.ViewModels;

public partial class MainPageViewModel : ObservableObject
{ 
    // Fältvariabel som håller referens till ContactService 
    private readonly ContactService _contactService;

    [ObservableProperty]
    ObservableCollection<ContactModel> contacts = new ObservableCollection<ContactModel>();

    // Konstruktorn för MainPageViewModel, tar en instans av ContactService som en parameter
    public MainPageViewModel(ContactService contactService)
    {
        _contactService = contactService; // Sätter den privata variabeln till den inmatade instansen
        Update(); // Uppdaterar listan med kontakter vid skapandet av MainPageViewModel
        UpdateContactList(); // Uppdaterar kontaktlistan genom att lyssna på ContactUpdated-händelsen

    }

    // Metod för att hantera navigeringen till Lägg till sidan 
    [RelayCommand]
    public async Task GoToAdd()
    {
        await Shell.Current.GoToAsync($"{nameof(AddPage)}");
    }

    //Metod för att hantera navigeringen till detaljer för specifik kontakt 
    [RelayCommand]
    public async Task GoToDetails(ContactModel contact)
    {
        _contactService.CurrentContact = contact;
        await Shell.Current.GoToAsync(nameof(DetailsPage));
    }

    //Metod som uppdaterar kontaktlistan gemom att hämta kontaktdata från ContactService 
    public void Update()
    {
        var _contacts = _contactService.GetContactsFromList();
        Contacts.Clear();
        foreach (var contact in _contacts)
        {
            Contacts.Add(contact);
        }
    }

    // Metod som uppdaterar kontaktlistan när ContactUpdate händelsen triggas 
    public void UpdateContactList()
    {
        _contactService.ContactUpdated += () =>
        {
            Update();
        };


    }



}
