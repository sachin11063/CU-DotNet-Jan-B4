// namespace ADVLearning
// {
//     internal class Program
//     {
//         static void Main(string[] args)
//         {

//                 string directoryPath = @"/Users/sachinshah/Desktop/      /C Sharp/CU-DotNet-Jan-B4/Training Assesment/Day 27/"; 
//                 string filePath = "journal.txt";

//                 string path = directoryPath + filePath;  

//                 using StreamWriter sw = new StreamWriter(path, true); // use to write data to file.
//                 do
//                 {
//                     Console.WriteLine("Enter the data to write to file: ");
//                     string data = Console.ReadLine();
//                     if(data == "stop") break;
//                     sw.WriteLine(data);   
//                 }while(true);

//                 // Using StreamReader to read data from file

//                 Console.WriteLine("\nData from file: ");
//                 using StreamReader sr = new StreamReader(path);
//                 do
//                 {
//                     string line = sr.ReadLine();
//                     if(line == null)
//                        break;

//                     Console.WriteLine(line);

//                 }while(true);
//         }
//     }
// }