using System;

class Program
{
    static void Main(string[] args)
    {
        string[] timezoneIdArray = new string[] {
            "GMT Standard Time",
            "Central America Standard Time",
            "SE Asia Standard Time",
            "E. South America Standard Time",
            "AUS Eastern Standard Time",
            "South Africa Standard Time",
            "Tokyo Standard Time",
        };

        Console.WriteLine("Available timezone:");
        for(int i=0; i < timezoneIdArray.Length; i++)
        {
            Console.WriteLine("{0}. {1}", i, timezoneIdArray[i]);
        }
        Console.Write("Please input a timezone id (0 - {0}): ", timezoneIdArray.Length - 1);

        int timezoneIdIndex = int.Parse(Console.ReadLine());
        if(timezoneIdIndex < 0 || timezoneIdIndex >= timezoneIdArray.Length)
        {
            Console.WriteLine("Invalid timezone id. Terminated.");
        }

        DateTime localDateTime = DateTime.Now;
        DateTime convertedDateTime = TimeZoneInfo.ConvertTime(
            localDateTime,
            TimeZoneInfo.Local,
            TimeZoneInfo.FindSystemTimeZoneById( timezoneIdArray[timezoneIdIndex] )
        );

        Console.WriteLine("Current time at {0} is {1}.", timezoneIdArray[timezoneIdIndex], convertedDateTime);
    }
}
