using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    class CollageManagement
    {
        Dictionary<string, Dictionary<string, int>> studentRecords = new Dictionary<string, Dictionary<string, int>>();

        Dictionary<string, LinkedList<KeyValuePair<string, int>>> studentSubjectsOrder = new Dictionary<string, LinkedList<KeyValuePair<string, int>>>();

        Dictionary<string, Dictionary<string, int>> subjectsRecords = new Dictionary<string, Dictionary<string, int>>();

        Dictionary<string, LinkedList<KeyValuePair<string, int>>> subjectsStudentsOrder = new Dictionary<string, LinkedList<KeyValuePair<string, int>>>();


        public int AddStudent(string studentId, string subject, int marks)
        {
            if (!studentRecords.ContainsKey(studentId))
                studentRecords[studentId] = new Dictionary<string, int>();

            if (!subjectsRecords.ContainsKey(subject))
                subjectsRecords[subject] = new Dictionary<string, int>();

            if (!subjectsStudentsOrder.ContainsKey(subject))
                subjectsStudentsOrder[subject] = new LinkedList<KeyValuePair<string, int>>();

            if (!studentRecords[studentId].ContainsKey(subject))
            {
                studentRecords[studentId][subject] = marks;
                subjectsRecords[subject][studentId] = marks;

                subjectsStudentsOrder[subject].AddLast(new KeyValuePair<string, int>(studentId, marks));
            }
            else
            {
                if (marks > studentRecords[studentId][subject])
                {
                    studentRecords[studentId][subject] = marks;
                    subjectsRecords[subject][studentId] = marks;

                    var node = subjectsStudentsOrder[subject].First;
                    while (node != null)
                    {
                        if (node.Value.Key == studentId)
                        {
                            node.Value = new KeyValuePair<string, int>(studentId, marks);
                            break;
                        }
                        node = node.Next;
                    }
                }
            }

            return 1;
        }


        public int RemoveStudent(string studentId)
        {
            if (!studentRecords.ContainsKey(studentId))
                return -1;

            foreach (var subject in studentRecords[studentId].Keys)
            {
                subjectsRecords[subject].Remove(studentId);

                var node = subjectsStudentsOrder[subject].First;
                while (node != null)
                {
                    if (node.Value.Key == studentId)
                    {
                        subjectsStudentsOrder[subject].Remove(node);
                        break;
                    }
                    node = node.Next;
                }
            }

            studentRecords.Remove(studentId);

            return 1;
        }


        public string TopStudent(string subject)
        {
            if (!subjectsStudentsOrder.ContainsKey(subject))
                return "";

            int max = subjectsRecords[subject].Values.Max();

            List<string> res = new List<string>();

            foreach (var pair in subjectsStudentsOrder[subject])
            {
                if (pair.Value == max)
                    res.Add(pair.Key + " " + pair.Value);
            }

            return string.Join("\n", res);
        }


        public string Result()
        {
            List<string> output = new List<string>();

            foreach (var student in studentRecords)
            {
                double avg = student.Value.Values.Average();
                output.Add(student.Key + " " + avg.ToString("F2"));
            }

            return string.Join("\n", output);
        }
    }


    public static void Main()
{
    CollageManagement cm = new CollageManagement();

    Console.WriteLine("College Management System");
    Console.WriteLine("Enter commands:");
    Console.WriteLine("ADD <StudentId> <Subject> <Marks>");
    Console.WriteLine("REMOVE <StudentId>");
    Console.WriteLine("TOP <Subject>");
    Console.WriteLine("RESULT");
    Console.WriteLine("Type EXIT to stop\n");

    while (true)
    {
        Console.Write("Enter Command: ");
        string input = Console.ReadLine();

        if (input.ToUpper() == "EXIT")
            break;

        string[] parts = input.Split(' ');

        if (parts[0] == "ADD")
        {
            cm.AddStudent(parts[1], parts[2], int.Parse(parts[3]));
        }
        else if (parts[0] == "REMOVE")
        {
            cm.RemoveStudent(parts[1]);
        }
        else if (parts[0] == "TOP")
        {
            Console.WriteLine(cm.TopStudent(parts[1]));
        }
        else if (parts[0] == "RESULT")
        {
            Console.WriteLine(cm.Result());
        }
    }
}
}