// See https://aka.ms/new-console-template for more information

using System.IO;

public static class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Cleaning BIN and OBJ Folders Inside the current Directory");

        Console.Write("Are you that you want to continue? (y/n): ");

        var input = Console.ReadLine();
        if (!string.Equals("y", input, StringComparison.CurrentCultureIgnoreCase)) 
            return;

        var currentDir = Directory.GetCurrentDirectory();

        string pattern = "bin";
        string[] subDirs = SearchDirectories(currentDir, pattern);
        DeleteDirectories(subDirs);

        pattern = "obj";
        subDirs = SearchDirectories(currentDir, pattern);
        DeleteDirectories(subDirs);

        Console.WriteLine("Solution has been cleaned!!!");

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }

    private static void DeleteDirectories(string[] subDirs)
    {
        foreach (string dir in subDirs)
        {
            Console.WriteLine($"Deleting {dir}");
            Directory.Delete(dir, true);
        }
    }

    private static string[] SearchDirectories(string currentDir, string pattern)
    {
        return Directory.GetDirectories(currentDir, pattern, SearchOption.AllDirectories);
    }
}

