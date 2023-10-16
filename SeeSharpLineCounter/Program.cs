using System;
using System.IO;

class Program
{
    static void Main()
    {
        Console.Write("Enter the folder path: ");
        string folderPath = Console.ReadLine();

        int totalLines = CountLinesInCSharpFiles(folderPath);

        Console.WriteLine($"Total lines in C# files: {totalLines}");
        // Wait for the user to press Enter
        Console.ReadLine();
    }

    static int CountLinesInCSharpFiles(string folderPath)
    {
        int totalLines = 0;

        // Get all C# files in the specified folder and its subfolders
        string[] csFiles = Directory.GetFiles(folderPath, "*.cs", SearchOption.AllDirectories);

        foreach (string csFile in csFiles)
        {
            // Skip files in the "bin" directory
            if ((csFile.ToLower().Contains("\\bin\\")) || (csFile.ToLower().Contains("\\debug\\")) || (csFile.ToLower().Contains("\\release\\")))
            {
                continue;
            }

            // Read the contents of the file
            string[] fileLines = File.ReadAllLines(csFile);

            // Increment the total lines count by the number of lines in the file
            totalLines += fileLines.Length;
        }

        return totalLines;
    }
}
