using Assignment_07.Mvvm.Models;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Assignment_07.Services;

public class ContactService
{
    //Sökväg till filen som håller kontaktlist 
    private readonly string filePath = @"C:\Users\alina\OneDrive\Skrivbord\Filer\json";
    //lista som innehåller kontaktmodeller 
    public static List<ContactModel> contactList = new List<ContactModel>();
    // En specifik kontakt som hanteras 
    public ContactModel CurrentContact { get; set; }
    // En händelse som utlöser sig när kontakt uppdatera
    public event Action ContactUpdated;

    // läser in kontakter från filen och att den initierar en tjänst 
    public ContactService()
    {
        GetContactsFromList();
        ContactUpdated += () =>
        { if(CurrentContact != null)
            UpdateCurrentContact(CurrentContact.Email);
        };
    }

    //Lägger till en kontat i listan och sparar till filen
    public void AddContactToList(ContactModel contact)
    {
        contactList.Add(contact);
        FileManager.SaveToFile(filePath, JsonConvert.SerializeObject(contactList));
        ContactUpdated.Invoke();
    }

    // Hämta kontakten från listan 
    public IEnumerable<ContactModel> GetContactsFromList()
    {
        try
        {
            var contactModels = FileManager.ReadFromFile(filePath);
            if (!string.IsNullOrEmpty(contactModels))
            {
                contactList = JsonConvert.DeserializeObject<List<ContactModel>>(contactModels)!;
            }

        }catch (Exception ex) {Debug.WriteLine(ex.Message); }
       
        return contactList;
    }

    //Tar fram en kontakt från listan
    public static ContactModel GetContactFromList(Func<ContactModel, bool> expression)
    {
       
       try
        {
            var contactModel = contactList.FirstOrDefault(expression);
            if (contactModel != null)
                return contactModel;

        }catch (Exception ex) { Debug.WriteLine(ex.Message); }
         return null;
    }

   //Uppdaterar en kontakt och sparar ändringarna 
    public ContactModel UpdateContact(ContactModel contact)
    {
        var contactModel = contactList.FirstOrDefault(x => x.Id == contact.Id);
        if (contactModel != null)
        {
            if (contactModel.FirstName != contact.FirstName)
                contactModel.FirstName = contact.FirstName;

            if (contactModel.LastName != contact.LastName)
                contactModel.LastName = contact.LastName;

            if (contactModel.Email != contact.Email)
                contactModel.Email = contact.Email;

            if (contactModel.PhoneNumber != contact.PhoneNumber)
                contactModel.PhoneNumber = contact.PhoneNumber;

            if (contactModel.Address.StreetName != contact.Address.StreetName)
                contactModel.Address.StreetName = contact.Address.StreetName;

            if (contactModel.Address.StreetNumber != contact.Address.StreetNumber)
                contactModel.Address.StreetNumber = contact.Address.StreetNumber;

            if (contactModel.Address.PostalCode != contact.Address.PostalCode)
                contactModel.Address.PostalCode = contact.Address.PostalCode;

            if (contactModel.Address.City != contact.Address.City)
                contactModel.Address.City = contact.Address.City;
          
            CurrentContact = contactModel; // Uppdatera CurrentContact med den uppdaterade kontakten
            FileManager.SaveToFile(filePath, JsonConvert.SerializeObject(contactList));
            ContactUpdated.Invoke();
            return contactModel;
        }
        return null;
    }

    //Uppdaterar en kontakt baserat på email
    private void UpdateCurrentContact(string email)
    {
        CurrentContact = GetContactFromList(x => x.Email == email);
    }

    //Tar bort en kontakt och sparar informatione 
    public void RemoveContactFromList(ContactModel contact)
    {
        try
        {
            contactList.Remove(contact);
            FileManager.SaveToFile(filePath, JsonConvert.SerializeObject(contactList));
            ContactUpdated.Invoke();

        }catch (Exception ex) { Debug.WriteLine(ex); }
        
    }
   
}
