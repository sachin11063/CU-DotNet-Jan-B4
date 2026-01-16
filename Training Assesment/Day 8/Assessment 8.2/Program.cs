using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter Value: ");
        string input = Console.ReadLine();
        string[] parts = input.Split('#');

        string transactionId = parts[0];
        string accountHolder = parts[1];
        string narration = parts[2];

        //Normalize narration
        narration = narration.Trim();

        //Replace multiple spaces with single space
        while (narration.Contains("  "))
        {
            narration = narration.Replace("  ", " ");
        }

        narration = narration.ToLower();

        //Keyword identification
        bool hasKeyword =
            narration.Contains("deposit") ||
            narration.Contains("withdrawal") ||
            narration.Contains("transfer");

        //Compare with standard narration
        string standardNarration = "cash deposit successful";
        bool isStandard = narration.Equals(standardNarration);

        string category;

        if (!hasKeyword)
        {
            category = "NON-FINANCIAL TRANSACTION";
        }
        else if (isStandard)
        {
            category = "STANDARD TRANSACTION";
        }
        else
        {
            category = "CUSTOM TRANSACTION";
        }

        //output
        Console.WriteLine("Transaction ID : " + transactionId);
        Console.WriteLine("Account Holder : " + accountHolder);
        Console.WriteLine("Narration      : " + narration);
        Console.WriteLine("Category       : " + category);
    }
}
