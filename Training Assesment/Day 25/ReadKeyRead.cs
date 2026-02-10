using System;

class SecureTerminal
{
    static void Main()
    {
        string pin = "";
        ConsoleKeyInfo keyInfo;

        Console.Write("Enter 4-digit PIN: ");

        while (pin.Length < 4)
        {
            keyInfo = Console.ReadKey(true);

            if (char.IsDigit(keyInfo.KeyChar))
            {
                pin += keyInfo.KeyChar;
                Console.Write("*");
            }
        }

        Console.WriteLine();
        Console.WriteLine("PIN Entered: " + pin);

        Console.Write("Enter System Message: ");
        string systemMessage = Console.ReadLine();

        Console.WriteLine("System Message:");
        Console.WriteLine(systemMessage);

    }
}










