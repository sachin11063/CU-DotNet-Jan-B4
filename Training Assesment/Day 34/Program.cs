using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        var network = new SocialNetwork();

        var sachin = new Person("sachin");
        var rohit = new Person("Rohit");
        var neha = new Person("Neha");
        var priya = new Person("Priya");

        network.AddPerson(sachin);
        network.AddPerson(rohit);
        network.AddPerson(neha);
        network.AddPerson(priya);

        network.AddFriendship(sachin, rohit);
        network.AddFriendship(sachin, neha);
        network.AddFriendship(rohit, priya);
        network.AddFriendship(neha, priya);

        network.ShowNetwork();
    }
}

class Person
{
    public string Name { get; }

    private readonly HashSet<Person> _friends;

    public Person(string name)
    {
        Name = name;
        _friends = new HashSet<Person>();
    }

    public IReadOnlyCollection<Person> Friends => _friends;

    public void AddFriend(Person friend)
    {
        if (friend == null)
            return;

        if (friend == this)
            return;

        _friends.Add(friend);
    }
}

class SocialNetwork
{
    private readonly List<Person> _members = new List<Person>();

    public void AddPerson(Person person)
    {
        if (person != null && !_members.Contains(person))
            _members.Add(person);
    }

    public void AddFriendship(Person a, Person b)
    {
        if (a == null || b == null)
            return;

        if (a == b)
            return;

        a.AddFriend(b);
        b.AddFriend(a);
    }

    public void ShowNetwork()
    {
        foreach (var person in _members)
        {
            var friendNames = person.Friends.Any()
                ? string.Join(", ", person.Friends.Select(f => f.Name))
                : "No friends";

            Console.WriteLine($"{person.Name}: {friendNames}");
        }
    }
}