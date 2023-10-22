using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMaui.UnitTests
{
    
    public class ContactServiceTest
    {
        [Fact]
        public void AddContact_ContactIsAddedToList()
        {
            // Arrange
            var contactManager = new ContactManager();
            var newContact = new Contact { Name = "Elin", Email = "elin@example.se" };

            // Act
            contactManager.AddContact(newContact);

            // Assert
            Assert.Contains(newContact, contactManager.Contacts);
        }

        [Fact]
        public void AddContact_NullContact_ThrowsArgumentNullException()
        {
            // Arrange
            var contactManager = new ContactManager();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => contactManager.AddContact(null!));
        }
    }
}

// Sample Contact class for illustration
public class Contact
{
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
}

// Sample ContactManager class for illustration
public class ContactManager
{
    public List<Contact> Contacts { get; } = new List<Contact>();

    public void AddContact(Contact contact)
    {
        if (contact == null)
        {
            throw new ArgumentNullException(nameof(contact));
        }

        Contacts.Add(contact);
    }
}
