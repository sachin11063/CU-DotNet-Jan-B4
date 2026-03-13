using System;
using System.Collections.Generic;

class Student
{
    public int StudId { get; set; }
    public string SName { get; set; }

    public Student(int id, string name)
    {
        StudId = id;
        SName = name;
    }

    // Override Equals and GetHashCode so Dictionary can identify same students
    public override bool Equals(object obj)
    {
        Student s = obj as Student;
        if (s == null) return false;
        return StudId == s.StudId;
    }

    public override int GetHashCode()
    {
        return StudId.GetHashCode();
    }
}

class Program
{
    static void Main()
    {
        Dictionary<Student, int> studentMarks = new Dictionary<Student, int>();

        while (true)
        {
            Console.WriteLine("\nEnter Student Id:");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Student Name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter Marks:");
            int marks = int.Parse(Console.ReadLine());

            Student s = new Student(id, name);

            bool found = false;

            foreach (var item in studentMarks)
            {
                if (item.Key.Equals(s))
                {
                    found = true;

                    if (marks > item.Value)
                    {
                        studentMarks[item.Key] = marks;
                        Console.WriteLine("Marks updated (Improvement)");
                    }
                    else
                    {
                        Console.WriteLine("Marks not improved");
                    }
                    break;
                }
            }

            if (!found)
            {
                studentMarks.Add(s, marks);
                Console.WriteLine("Student added");
            }

            Console.WriteLine("\nCurrent Student Records:");
            foreach (var item in studentMarks)
            {
                Console.WriteLine(item.Key.StudId + " " + item.Key.SName + " " + item.Value);
            }

            Console.WriteLine("\nContinue? (y/n)");
            if (Console.ReadLine().ToLower() == "n")
                break;
        }
    }
}