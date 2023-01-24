using ConsoleApp.Services;

var menu = new Menu();
menu.FilePath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\contacts.json";

bool isrunning = true;

while (isrunning)
{
    Console.Clear();
    menu.StartMenu();
}