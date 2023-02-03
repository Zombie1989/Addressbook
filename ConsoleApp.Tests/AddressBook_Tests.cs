using ConsoleApp.Models;
using ConsoleApp.Services;
using System.Runtime.CompilerServices;

namespace ConsoleApp.Tests
{
    public class AddressBook_Tests
    {
        private Menu contacts;
        Contact contact;

        public AddressBook_Tests()
        {
            // arrange
            contacts = new Menu();
            contact = new Contact();
        }

        [Fact]
        public void Should_Add_Contact_To_List()
        {
            contacts.contacts.Add(contact);
            contacts.contacts.Add(contact);
            contacts.contacts.Add(contact);

            // assert
            Assert.Equal(3, contacts.contacts.Count);
        }

        [Fact]
        public void Should_Remove_From_List()
        {
            // arrange
            contacts.contacts.Add(contact);
            contacts.contacts.Add(contact);

            // act
            contacts.contacts.Remove(contact);

            // assert
            Assert.Single(contacts.contacts);
        }
    }
}