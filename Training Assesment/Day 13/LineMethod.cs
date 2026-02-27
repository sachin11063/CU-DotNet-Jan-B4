
namespace CSLearning
{
	internal class DataType
    {	
        static void PrintLine(int num = 40, char ch = '-')
        {
            for (int i = 0; i < num; i++)
            {
                Console.Write(ch);
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            PrintLine();
            PrintLine(ch:'$');
            PrintLine(60, '+');
            PrintLine(ch: '@', num: 70);
            PrintLine('$');
            PrintLine(70);

        }

    }
}

