namespace Day19;


abstract class Vehicle
{
    public string ModelName { get; set; }
    public abstract void Move();
    public Vehicle(string ModelName)
    {
        this.ModelName = ModelName;
    }
    public virtual void GetFuelStatus()
    {
        Console.WriteLine("Fuel Level is Stable.");
    }
}

class ElectricCar : Vehicle
{
    public ElectricCar(string ModelName) : base(ModelName)
    {

    }
    public override void Move()
    {
        Console.WriteLine($"Your {ModelName} is gliding silently on battery power.");
    }
    public override void GetFuelStatus()
    {
        Console.WriteLine($"Your {ModelName} battery is at 80 %");
    }
}

class HeavyTruck : Vehicle
{
    public HeavyTruck(string ModelName) : base(ModelName)
    {

    }
    public override void Move()
    {
        Console.WriteLine($"Your {ModelName} is is hauling cargo with high-torque diesel power.");
    }

}

class CargoPlane : Vehicle
{
    public CargoPlane(string ModelName) : base(ModelName)
    {

    }
    public override void Move()
    {
        Console.WriteLine($"Your {ModelName} is ascending to 30,000 feet.");
    }

    public override void GetFuelStatus()
    {
        base.GetFuelStatus();
        Console.WriteLine("Checking jet fuel reserves...");
    }

}

class Program
{
    static void Main(string[] args)
    {
        Vehicle[] vehicles =
        {
        new ElectricCar ( "Tesla" ),
        new HeavyTruck ( "Volvo" ),
        new CargoPlane ( "Boeing 747 Cargo" )
        };

        foreach (Vehicle vehicle in vehicles)
        {
            Console.WriteLine($"--- {vehicle.ModelName} ---");
            vehicle.Move();
            vehicle.GetFuelStatus();
            Console.WriteLine();
        }
    }

}

