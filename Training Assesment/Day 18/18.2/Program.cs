
class Employee
{
    public int EmployeeId { get; set; }
    public string EmployeeName { get; set; }
    public decimal BasicSalary { get; set; }
    public int ExperienceInYears { get; set; }

    public Employee(int EmployeeId, string EmployeeName, decimal BasicSalary, int ExperienceInYears)
    {
        this.EmployeeId = EmployeeId;
        this.EmployeeName = EmployeeName;
        this.BasicSalary = BasicSalary;
        this.ExperienceInYears = ExperienceInYears;
    }

    public decimal CalculateAnnualSalary()
    {
        return BasicSalary * 12;
    }

    public void DisplayEmployeeDetails()
    {
        Console.WriteLine($"EmployeeId: {EmployeeId}");
        Console.WriteLine($"EmployeeName: {EmployeeName}");
        Console.WriteLine($"BasicSalary: {BasicSalary}");
        Console.WriteLine($"ExperienceInYears: {ExperienceInYears} Years");
        Console.WriteLine($"AnnualSalary: {CalculateAnnualSalary()}");
    }

}

class PermanentEmployee : Employee
{
    public PermanentEmployee(int employeeId, string employeeName, decimal basicSalary, int experienceInYears)
        : base(employeeId, employeeName, basicSalary, experienceInYears)
    {

    }
    public new decimal CalculateAnnualSalary()
    {
        decimal Hra = BasicSalary * 0.2m;
        decimal SpecialAllowance = BasicSalary * 0.1m;
        decimal Bonus = 0;
        if (ExperienceInYears >= 5)
        {
            Bonus = 50000;
        }
        return (BasicSalary + Hra + SpecialAllowance) * 12 + Bonus;
    }
}

class ContractEmployee : Employee
{
    public int ContractDurationInMonths { get; set; }
    public ContractEmployee(int employeeId, string employeeName, decimal basicSalary, int experienceInYears, int contractDurationInMonths)
        : base(employeeId, employeeName, basicSalary, experienceInYears)
    {
        ContractDurationInMonths = contractDurationInMonths;
    }

    public new decimal CalculateAnnualSalary()
    {
        decimal Bonus = 0;
        if (ContractDurationInMonths >= 12)
        {
            Bonus = 30000;
        }
        return (BasicSalary * 12) + Bonus;
    }
}

class InternEmployee : Employee
{
    public InternEmployee(int employeeId, string employeeName, decimal basicSalary, int experienceInYears)
        : base(employeeId, employeeName, basicSalary, experienceInYears)
    {

    }

    public new decimal CalculateAnnualSalary()
    {
        return BasicSalary * 12;
    }

}


class Program
{
    public static void Main(string[] args)
    {
        Employee emp1 = new PermanentEmployee(101, "Sachin", 140000, 6);

        PermanentEmployee emp2 = new PermanentEmployee(102, "Akash", 70000, 6);

        ContractEmployee emp3 = new ContractEmployee(103, "Rahul", 30000, 3, 14);

        InternEmployee emp4 = new InternEmployee(104, "Swaraj", 15000, 0);

        emp1.DisplayEmployeeDetails();
        Console.WriteLine();

        emp2.DisplayEmployeeDetails();
        Console.WriteLine();

        emp3.DisplayEmployeeDetails();
        Console.WriteLine();

        emp4.DisplayEmployeeDetails();
    }
}
