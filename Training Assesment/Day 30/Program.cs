using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

class Person
{
    public string Name { get; set; }
    public decimal Paid { get; set; }
    public decimal Balance { get; set; }

    public Person(string name, decimal paid)
    {
        Name = name;
        Paid = paid;
    }
}

class Transaction
{
    public string Payer { get; set; }
    public string Receiver { get; set; }
    public decimal Amount { get; set; }

    public Transaction(string payer, string receiver, decimal amount)
    {
        Payer = payer;
        Receiver = receiver;
        Amount = amount;
    }
}

class Program
{
    static void Main(string[] args)
    {
        var people = new List<Person>
        {
            new Person("Aman", 900m),
            new Person("Akash", 0m),
            new Person("Sachin", 1290m)
        };

        var transactions = SettleExpenses(people);

        using (var writer = new StreamWriter("output.csv"))
        {
            writer.WriteLine("Payer,Receiver,Amount");
            foreach (var t in transactions)
            {
                writer.WriteLine($"{t.Payer},{t.Receiver},{t.Amount:F2}");
            }
        }

        foreach (var t in transactions)
        {
            Console.WriteLine($"{t.Payer},{t.Receiver},{t.Amount:F2}");
        }
    }

    static List<Transaction> SettleExpenses(List<Person> people)
    {
        decimal total = people.Sum(p => p.Paid);
        decimal fairShare = total / people.Count;

        foreach (var person in people)
        {
            person.Balance = person.Paid - fairShare;
        }

        var creditors = new Queue<Person>(people.Where(p => p.Balance > 0).OrderByDescending(p => p.Balance));
        var debtors = new Queue<Person>(people.Where(p => p.Balance < 0).OrderBy(p => p.Balance));

        var transactions = new List<Transaction>();

        while (creditors.Count > 0 && debtors.Count > 0)
        {
            var creditor = creditors.Peek();
            var debtor = debtors.Peek();

            decimal amount = Math.Min(creditor.Balance, -debtor.Balance);
            amount = Math.Round(amount, 2);

            transactions.Add(new Transaction(debtor.Name, creditor.Name, amount));

            creditor.Balance -= amount;
            debtor.Balance += amount;

            if (Math.Round(creditor.Balance, 2) == 0)
                creditors.Dequeue();

            if (Math.Round(debtor.Balance, 2) == 0)
                debtors.Dequeue();
        }

        return transactions;
    }
}