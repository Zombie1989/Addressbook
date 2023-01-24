using ConsoleApp.Interfaces;
using ConsoleApp.Models;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;

namespace ConsoleApp.Services;

internal class Menu
{
    private List<Contact> contacts = new List<Contact>();
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

            try
            {
                var items = JsonConvert.DeserializeObject<List<Contact>>(file.Read(FilePath));
                if (items != null)
                    contacts = items;
            }
            catch { }

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

        try
        {
            var items = JsonConvert.DeserializeObject<List<Contact>>(file.Read(FilePath));
            if (items != null) 
                contacts = items;
        }
        catch { }

        Console.Write("Skriv för och efternamn till kontakten du vill få upp: ");

        

        foreach (var contact in contacts)
            if (contact.DisplayName == Console.ReadLine())
            {
                Console.WriteLine($"Namn: {contact.FirstName} {contact.LastName}");
                Console.WriteLine($"Email: {contact.Email}");
                Console.WriteLine($"Telefonnummer: {contact.PhoneNumber}");
                Console.WriteLine($"Adress: {contact.Address} {contact.County}, phonenumber: {contact.PhoneNumber}");
            }

        Console.WriteLine("\nTryck på valfri tangent för att fortsätta");




    }

    private void MenuFour()
    {
        Console.Clear();
    }


}

