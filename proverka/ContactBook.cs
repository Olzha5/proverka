using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

public class Contact
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }

    public override string ToString()
    {
        return $"ID: {Id}, Name: {FirstName} {LastName}, Phone: {PhoneNumber}, Email: {Email}";
    }
}

public class ContactBook
{
    private List<Contact> contacts = new List<Contact>();
    private int nextId = 1;
    private readonly string FilePath = "contacts.json";

    public ContactBook()
    {
        LoadContactsFromFile();
    }

    public void AddContact(string firstName, string lastName, string phoneNumber, string email)
    {
        var newContact = new Contact
        {
            Id = nextId++, // Auto-increment the ID
            FirstName = firstName,
            LastName = lastName,
            PhoneNumber = phoneNumber,
            Email = email
        };

        contacts.Add(newContact);
        SaveContactsToFile(); // Save changes immediately
        Console.WriteLine("Contact added successfully:\n{0}", newContact);
    }

    public void SaveContactsToFile()
    {
        string jsonString = JsonSerializer.Serialize(contacts);
        File.WriteAllText(FilePath, jsonString);
    }

    public void LoadContactsFromFile()
    {
        if (File.Exists(FilePath))
        {
            string jsonString = File.ReadAllText(FilePath);
            var loadedContacts = JsonSerializer.Deserialize<List<Contact>>(jsonString);
            if (loadedContacts != null)
            {
                contacts = loadedContacts;
                nextId = contacts.Any() ? contacts.Max(c => c.Id) + 1 : 1;
            }
        }
    }


// EditContact изменяет существующий контакт, найденный по ID.
        public void EditContact(int id, string firstName, string lastName, string phoneNumber, string email)
        {
            var contact = contacts.FirstOrDefault(c => c.Id == id);
            if (contact != null)
            {
                contact.FirstName = firstName;
                contact.LastName = lastName;
                contact.PhoneNumber = phoneNumber;
                contact.Email = email;
                Console.WriteLine("Contact updated successfully:\n{0}", contact);
            }
            else
            {
                Console.WriteLine($"Contact with ID {id} not found.");
            }
        }

    // DeleteContact удаляет контакт по указанному ID.
    public void DeleteContact(int id)
    {
        var contact = contacts.FirstOrDefault(c => c.Id == id);
        if (contact != null)
        {
            contacts.Remove(contact);
            SaveContactsToFile(); // Если вы сохраняете изменения после каждой операции
            Console.WriteLine($"Contact with ID {id} deleted successfully.");
        }
        else
        {
            Console.WriteLine($"Contact with ID {id} not found.");
        }
    }

    // ListAllContacts выводит все контакты в консоль.
    public void ListAllContacts()
        {
            if (contacts.Any())
            {
                Console.WriteLine("Contacts:");
                foreach (var contact in contacts)
                {
                    Console.WriteLine(contact);
                }
            }
            else
            {
                Console.WriteLine("No contacts found.");
            }
        }

        internal void AddContact(object firstName, object lastName, object phoneNumber, object email)
        {
            throw new NotImplementedException();
        }

        internal void AddContact(string firstName, object lastName, object phoneNumber, object email)
        {
            throw new NotImplementedException();
        }

        internal void AddContact(string firstName, object lastName, string phoneNumber, object email)
        {
            throw new NotImplementedException();
        }

        internal void AddContact(string firstName, string lastName, string phoneNumber, object email)
        {
            throw new NotImplementedException();
        }
}
