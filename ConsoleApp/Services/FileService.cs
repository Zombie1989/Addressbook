namespace ConsoleApp.Services;

internal class FileService
{
    internal void Save(string filePath, string content)
    {
        using var sw = new StreamWriter(filePath);
        sw.WriteLine(content);
    }

    internal string Read(string filePath)
    {
        try
        {
            using var sr = new StreamReader(filePath);
            return sr.ReadToEnd();
        }
        catch { return null!; }
    }
}
