using System;
using System.Text;

class Program
{
    static void Main()
    {
        string input = "abcdu";
        string result = Transform(input);
        Console.WriteLine(result);
    }

    static string Transform(string input)
    {
        string vowels = "aeiou";
        StringBuilder output = new StringBuilder();

        foreach (char c in input)
        {
            if (vowels.Contains(c))
            {
                int index = vowels.IndexOf(c);
                char nextVowel = vowels[(index + 1) % vowels.Length];
                output.Append(nextVowel);
            }
            else if (c >= 'a' && c <= 'z')
            {
                char nextChar = c == 'z' ? 'a' : (char)(c + 1);

                while ("aeiou".Contains(nextChar))
                {
                    nextChar = nextChar == 'z' ? 'a' : (char)(nextChar + 1);
                }

                output.Append(nextChar);
            }
            else
            {
                output.Append(c);
            }
        }

        return output.ToString();
    }
}