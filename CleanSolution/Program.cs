// See https://aka.ms/new-console-template for more information

using System.IO;

public static class Program
{
    public static void Main(string[] args)
    {
        string currentDir = Directory.GetCurrentDirectory();
        Console.WriteLine($"Cleaning files inside 'bin' and 'obj' folders at path: '{currentDir}'");
        Console.Write("Are you that you want to continue? (y/n): ");

        string input = Console.ReadLine() ?? string.Empty;
        if (!string.Equals("y", input, StringComparison.CurrentCultureIgnoreCase)) 
            return;

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

