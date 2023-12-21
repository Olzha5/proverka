using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Program
{
    // Главный класс для управления книгой контактов в консольном приложении.
    static ContactBook contactBook = new ContactBook();
    private static string firstName;
    private static string phoneNumber;
    private static string lastName;
    private static string email;

    // Главная точка входа для приложения.
    static void Main(string[] args)
    {
        // Простейшая система входа для демонстрационных целей
        Console.Write("Enter login: ");
        string login = Console.ReadLine();
        Console.Write("Enter password: ");
        string password = Console.ReadLine();

        if (login == "admin" && password == "admin") // Проверка учетных данных
        {
            while (true)
            {
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1: Add Contact");
                Console.WriteLine("2: Search Contacts");
                Console.WriteLine("3: Edit Contact");
                Console.WriteLine("4: Delete Contact");
                Console.WriteLine("5: List All Contacts");
                Console.WriteLine("6: Exit");
                Console.Write("Enter option: ");

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        AddContact();
                        break;
                    case "2":
                        SearchContacts();
                        break;
                    case "3":
                        EditContact();
                        break;
                    case "4":
                        DeleteContact();
                        break;
                    case "5":
                        ListAllContacts();
                        break;
                    case "6":
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
        else
        {
            Console.WriteLine("Invalid credentials.");
        }
    }

    static void AddContact()
    {
        Console.Write("Enter first name: ");
        string firstName = Console.ReadLine();
        Console.Write("Enter last name: ");
        string lastName = Console.ReadLine();
        Console.Write("Enter phone number: ");
        string phoneNumber = Console.ReadLine();
        Console.Write("Enter email: ");
        string email = Console.ReadLine();

        contactBook.AddContact(firstName, lastName, phoneNumber, email);
    }
    // Поиск контактов на основе запроса пользователя.
    static void SearchContacts()
    {
        Console.Write("Enter search query: ");
        // ...
        // Выводим все найденные контакты.
        // ...
    }

    // Редактирует существующий контакт, идентифицированный по ID.
    static void EditContact()
    {
        Console.Write("Enter the ID of the contact to edit: ");
        // ...
        // Обновляем информацию контакта и выводим результат.
        // ...
    }

    // Удаляет контакт по ID, предоставленному пользователем.
    static void DeleteContact()
    {
        Console.Write("Enter the ID of the contact to delete: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            contactBook.DeleteContact(id);
            Console.WriteLine($"Contact with ID {id} deleted successfully.");
        }
        else
        {
            Console.WriteLine("Invalid ID format.");
        }
    }

    // Отображает список всех контактов в книге.
    static void ListAllContacts()
    {
        contactBook.ListAllContacts();
    }
}
