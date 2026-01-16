using System;

class Program
{
    static void Main()
    { 
        Console.WriteLine("Enter login details in the format:");
        Console.WriteLine("<UserName>|<LoginMessage>");
     

        // read input 
        string input = Console.ReadLine();

        // split username & message
        string[] parts = input.Split('|');
        string userName = parts[0];
        string loginMessage = parts[1];

        // clean the login message
        string cleanMessage = loginMessage.Trim().ToLower();

        // check for keyword "successful"
        bool hasSuccessful = cleanMessage.Contains("successful");

        // standard message
        string standardMessage = "login successful";

        // decide status
        string status;

        if (!hasSuccessful)
        {
            status = "LOGIN FAILED";
        }
        else if (cleanMessage.Equals(standardMessage))
        {
            status = "LOGIN SUCCESS";
        }
        else
        {
            status = "LOGIN SUCCESS (CUSTOM MESSAGE)";
        }

        //output
        Console.WriteLine();
        Console.WriteLine("Result:");
        Console.WriteLine($"User     : {userName}");
        Console.WriteLine($"Message  : {cleanMessage}");
        Console.WriteLine($"Status   : {status}");
    }
}
