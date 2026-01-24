namespace OopsLearning
{
    class Person
    {
        
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;


        private string department = string.Empty;
        public string Department
        { 
            get { return department; }

            set
            {
                if (value == "Accounts" || value == "Sales" || value == "IT")
                {
                    department = value;
                }

            }
        }

        private int salary;
        public int Salary
        {
            get { return salary; }
            set
            {
                if (value >= 50000 && value <= 90000)
                {
                    salary = value;
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person();
            p1.Id = 11063;
            p1.Name = "Sachin";
            p1.Department = "IT";
            p1.Salary = 70000;

            Console.WriteLine($"ID: {p1.Id}");
            Console.WriteLine($"Name: {p1.Name}");
            Console.WriteLine($"Department: {p1.Department}");
            Console.WriteLine($"Salary: {p1.Salary}");


        }
    }
}


