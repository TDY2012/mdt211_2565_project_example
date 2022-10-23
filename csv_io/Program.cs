using System;
using System.IO;

class Program
{
    static void ReadCsv()
    {
        //  Get csv file path from user.
        Console.Write("Please input csv file path to read: ");
        string csvFilePath = Console.ReadLine();

        //  Read all csv content as lines of string
        //  and display them.
        string[] lines = File.ReadAllLines(csvFilePath);
        foreach(string line in lines)
        {
            Console.WriteLine(line);
        }
    }

    static void WriteCsv()
    {
        //  Get csv file path from user.
        Console.Write("Please input csv file path to write: ");
        string csvFilePath = Console.ReadLine();

        //  Get number of person to be added.
        Console.Write("Please input number of persons to be added: ");
        int numPerson = int.Parse(Console.ReadLine());

        //  Get each person info.
        List<string> lines = new List<string>();
        while(numPerson > 0)
        {
            lines.Add(Person.InputPersonInfo());
            numPerson--;
        }

        //  Write all person info to a csv file.
        File.WriteAllLines(csvFilePath, lines);
    }

    static void Main(string[] args)
    {
        //  Display menu and let user select it.
        Console.WriteLine("Menu");
        Console.WriteLine("0. Read CSV");
        Console.WriteLine("1. Write CSV");
        Console.Write("Please input menu (0 - 1): ");
        int menuIndex = int.Parse(Console.ReadLine());

        //  Go to specific page given the selected menu index.
        if(menuIndex == 0)
        {
            ReadCsv();
        }
        else if(menuIndex == 1)
        {
            WriteCsv();
        }
    }
}