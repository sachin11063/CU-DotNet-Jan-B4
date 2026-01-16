using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter login ID : ");
        string inputLine = Console.ReadLine();

        if (string.IsNullOrEmpty(inputLine))
        {
            Console.WriteLine("INVALID ACCESS LOG");
            return;
        }

        string[] values = inputLine.Split('|');

        if (values.Length != 5)
        {
            Console.WriteLine("INVALID ACCESS LOG");
            return;
        }

        //  GateCode Validation   
        string gateCode = values[0];

        if (gateCode.Length != 2 ||
            gateCode[0] < 'A' || gateCode[0] > 'Z' ||
            gateCode[1] < '0' || gateCode[1] > '9')
        {
            Console.WriteLine("INVALID ACCESS LOG");
            return;
        }

        //  User Initial Validation   
        string userPart = values[1];

        if (userPart.Length != 1 ||
            userPart[0] < 'A' || userPart[0] > 'Z')
        {
            Console.WriteLine("INVALID ACCESS LOG");
            return;
        }

        //  Access Level Validation   
        string levelPart = values[2];

        if (levelPart.Length != 1 ||
            levelPart[0] < '1' || levelPart[0] > '7')
        {
            Console.WriteLine("INVALID ACCESS LOG");
            return;
        }

        //  IsActive Validation   
        string activePart = values[3].ToLower();

        if (activePart != "true" && activePart != "false")
        {
            Console.WriteLine("INVALID ACCESS LOG");
            return;
        }

        //  Attempts Validation   
        if (!byte.TryParse(values[4], out byte attemptsCount) || attemptsCount > 200)
        {
            Console.WriteLine("INVALID ACCESS LOG");
            return;
        }

        //  Parsed Values   
        char userInitial = userPart[0];
        byte accessLevel = byte.Parse(levelPart);
        bool isActive = activePart == "true";

        //  Business Logic   
        string accessStatus;

        if (!isActive)
        {
            accessStatus = "ACCESS DENIED – INACTIVE USER";
        }
        else if (attemptsCount > 100)
        {
            accessStatus = "ACCESS DENIED – TOO MANY ATTEMPTS";
        }
        else if (accessLevel >= 5)
        {
            accessStatus = "ACCESS GRANTED – HIGH SECURITY";
        }
        else
        {
            accessStatus = "ACCESS GRANTED – STANDARD";
        }

        //  Output   
        Console.WriteLine($"{"Gate".PadRight(10)}: {gateCode}");
        Console.WriteLine($"{"User".PadRight(10)}: {userInitial}");
        Console.WriteLine($"{"Level".PadRight(10)}: {accessLevel}");
        Console.WriteLine($"{"Attempts".PadRight(10)}: {attemptsCount}");
        Console.WriteLine($"{"Status".PadRight(10)}: {accessStatus}");
    }
}
