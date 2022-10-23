using System;
using System.Text;
using System.Security.Cryptography;

class Program
{
    static string GetHiddenConsoleInput()
    {
        //  Construct string builder instance. It is a list-like
        //  class which manages string construction.
        StringBuilder input = new StringBuilder();

        //  Infinite loop input until pressing enter.
        while (true)
        {
            var key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.Enter) break;
            if (key.Key == ConsoleKey.Backspace && input.Length > 0) input.Remove(input.Length - 1, 1);
            else if (key.Key != ConsoleKey.Backspace) input.Append(key.KeyChar);
        }
        Console.WriteLine();

        return input.ToString();
    }

    static bool MatchByteArray(ref byte[] arr1, ref byte[] arr2)
    {
        if(arr1.Length != arr2.Length)
        {
            return false;
        }
        for(int i=0; i < arr1.Length; i++)
        {
            if(arr1[i] != arr2[i])
            {
                return false;
            }
        }
        return true;
    }

    static void Main(string[] args)
    {
        //  Get password with hidden input and convert to byte array.
        Console.Write("Please input a password (input characters will be hidden): ");
        string password = GetHiddenConsoleInput();
        byte[] passwordByteArray = Encoding.ASCII.GetBytes(password);

        //  Construct a SHA256 instance. This class provides a method
        //  to encrypt given byte array with SHA256 algorithm.
        //  For more information, please see https://en.wikipedia.org/wiki/SHA-2 .
        SHA256 sha256 = SHA256.Create();

        //  Encrypt the password.
        byte[] passwordHash = sha256.ComputeHash(passwordByteArray);
        
        //  Get confirmed password with hidden input and convert to byte array.
        Console.Write("Please confirm a password (input characters will be hidden): ");
        string confirmedPassword = GetHiddenConsoleInput();
        byte[] confirmedPasswordByteArray = Encoding.ASCII.GetBytes(confirmedPassword);

        //  Encrypt the confirmed password.
        byte[] confirmedPasswordHash = sha256.ComputeHash(confirmedPasswordByteArray);

        //  Compare encrypted password and confirmed password.
        if(MatchByteArray(ref passwordHash, ref confirmedPasswordHash))
        {
            Console.WriteLine("Matched password!");
        }
        else
        {
            Console.WriteLine("Not matched password!");
        }
    }
}
