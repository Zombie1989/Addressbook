using ConsoleApp.Interfaces;
using ConsoleApp.Models;
using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;

namespace ConsoleApp.Services;

public class Menu
{
    public List<Contact> contacts = new List<Contact>();
    private FileService file = new FileService();

    public string FilePath { get; set; } = null!;

    public void StartMenu()
    {
        Console.WriteLine("Adressbok");
        Console.WriteLine("1. Skapa en kontakt");
        Console.WriteLine("2. Visa alla kontakter");
        Console.WriteLine("3. Visa en specifik kontakt");
        Console.WriteLine("4. Ta bort en specifik kontakt");
        Console.Write("Välj ett av alternativen ovan: ");

        try
        {
            var items = JsonConvert.DeserializeObject<List<Contact>>(file.Read(FilePath));
            if (items != null)
                contacts = items;
        }
        catch { }

        var menu = Console.ReadLine();

        switch (menu)
        {
            case "1":
                MenuOne();
                break;
            case "2":
                MenuTwo();
                break;
            case "3":
                MenuThree();
                break;
            case "4":
                MenuFour();
                break;


            default:
                Console.WriteLine("Felaktig input");
                break;
        }
    }

    private void MenuOne()
    {
        Console.Clear();
        Console.WriteLine("Lägg till en ny kontakt");

        Contact contact = new Contact();

        Console.Write("Ange förnamn: ");
        contact.FirstName = Console.ReadLine() ?? "";

        Console.Write("Ange efternamn: ");
        contact.LastName = Console.ReadLine() ?? "";

        Console.Write("Ange E-mail: ");
        contact.Email = Console.ReadLine() ?? "";

        Console.Write("Ange telefonnummer: ");
        contact.PhoneNumber = Console.ReadLine() ?? "";

        Console.Write("Ange adress: ");
        contact.Address = Console.ReadLine() ?? "";

        Console.Write("Ange postnummer: ");
        contact.PostalCode = Console.ReadLine() ?? "";

        Console.Write("Ange ort: ");
        contact.County = Console.ReadLine() ?? "";

        contacts.Add(contact);

        file.Save(FilePath, JsonConvert.SerializeObject(contacts));
    }

    private void MenuTwo()
    {
        Console.Clear();

        Console.WriteLine("Personer i adressboken");

        foreach (var contact in contacts)
        {
            Console.WriteLine($"Namn: {contact.FirstName} {contact.LastName} - E-mail: {contact.Email}");
        }

        Console.WriteLine("\nTryck på valfri tangent för att fortsätta");

        Console.ReadKey();
    }

    private void MenuThree()
    {
        Console.Clear();
        Console.Write("Skriv för och efternamn till kontakten du vill få upp: ");
        var input = Console.ReadLine();
        var contact = FindContact(input!);

        if (contact == null)
        {
            Console.WriteLine($"Kontakten {input} finns inte");
        }
        else
        {
            Console.Clear();
            Console.WriteLine($"Namn: {contact.FirstName} {contact.LastName}");
            Console.WriteLine($"Email: {contact.Email}");
            Console.WriteLine($"Telefonnummer: {contact.PhoneNumber}");
            Console.WriteLine($"Adress: {contact.Address} {contact.County}");
        }




        Console.WriteLine("\nTryck på valfri tangent för att fortsätta");

        Console.ReadKey();
    }

    private void MenuFour()
    {
        Console.Clear();

        Console.WriteLine("Skriv för och efternamn till kontakten du vill radera");
        var input = Console.ReadLine();
        var contact = FindContact(input!);

        if (contact == null)
        {
            Console.WriteLine($"Kontakten {input} finns inte, tryck på valfri tangent för att fortsätta");
            Console.ReadKey();
        }
        else
        {
            Console.Clear();
            Console.WriteLine($"Vill du radera {input}? y/n");
            var yn = Console.ReadLine();
            var test = contact;

            if (yn == "y")
            {
                Console.Clear();
                contacts.Remove(contact);
                Console.WriteLine($"Du tog bort kontakten {input} tryck på valfri tangent för att fortsätta");
                file.Save(FilePath, JsonConvert.SerializeObject(contacts));
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Ingen kontakt togs bort tryck på valfri tangent för att fortsätta");
                Console.ReadKey();
            }

        }

    }

    private Contact FindContact(string search)
    {
        foreach (var contact in contacts)
            if (contact.DisplayName == search)
            {
                return contact;
            }
        return null!;
    }
}