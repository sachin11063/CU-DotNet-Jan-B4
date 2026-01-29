//HackerRank - Between Two Sets

using System;

class Result
{

    public static int getTotalX(List<int> a, List<int> b)
   {
    int gcd(int x, int y)
    {
        while (y != 0)
        {
            int r = x % y;
            x = y;
            y = r;
        }
        return x;
    }

    int lcm(int x, int y)
    {
        return (x * y) / gcd(x, y);
    }

    int baseValue = a[0];
    for (int i = 1; i < a.Count; i++)
    {
        baseValue = lcm(baseValue, a[i]);
    }

    int limitValue = b[0];
    for (int i = 1; i < b.Count; i++)
    {
        limitValue = gcd(limitValue, b[i]);
    }

    int result = 0;
    for (int value = baseValue; value <= limitValue; value += baseValue)
    {
        if (limitValue % value == 0)
        {
            result++;
        }
    }

    return result;
}

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int m = Convert.ToInt32(firstMultipleInput[1]);

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        List<int> brr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(brrTemp => Convert.ToInt32(brrTemp)).ToList();

        int total = Result.getTotalX(arr, brr);

        textWriter.WriteLine(total);

        textWriter.Flush();
        textWriter.Close();
    }
}
