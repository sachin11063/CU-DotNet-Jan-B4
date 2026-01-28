namespace Day19._2;


abstract class UtilityBill
{
    public int ConsumerId { get; set; }
    public string ConsumerName { get; set; }
    public decimal UnitsConsumed { get; set; }
    public decimal RatePerUnit { get; set; }

    protected UtilityBill(int consumerId, string consumerName, decimal unitsConsumed, decimal ratePerUnit)
    {
        ConsumerId = consumerId;
        ConsumerName = consumerName;
        UnitsConsumed = unitsConsumed;
        RatePerUnit = ratePerUnit;
    }


    public abstract decimal CalculateBillAmount();

    public virtual decimal CalculateTax(decimal billAmount)
    {
        return billAmount + (billAmount * 0.05m);
    }
    public void PrintBill()
    {
        decimal billAmount = CalculateBillAmount();
        decimal tax = CalculateTax(billAmount);
        decimal finalAmount = billAmount + tax;

        Console.WriteLine($"Consumer ID   : {ConsumerId}");
        Console.WriteLine($"Consumer Name : {ConsumerName}");
        Console.WriteLine($"Units Used    : {UnitsConsumed}");
        Console.WriteLine($"Bill Amount   : ₹{billAmount}");
        Console.WriteLine($"Tax           : ₹{tax}");
        Console.WriteLine($"Payable Amount: ₹{finalAmount}");
    }


}
class ElectricityBill : UtilityBill
{
    public ElectricityBill(int ConsumerId, string ConsumerName, decimal UnitsConsumed, decimal RatePerUnit) 
    : base(ConsumerId, ConsumerName, UnitsConsumed, RatePerUnit)
    {
        
    }
    public override decimal CalculateBillAmount()
    {
        decimal amount = UnitsConsumed * RatePerUnit;
        if (UnitsConsumed > 300)
        {
            amount += amount * 0.10m;
        }
        return amount;
    }
}

class WaterBill : UtilityBill
{
    public WaterBill(int ConsumerId, string ConsumerName, decimal UnitsConsumed, decimal RatePerUnit) 
    : base(ConsumerId, ConsumerName, UnitsConsumed, RatePerUnit)
    {
        
    }
    public override decimal CalculateBillAmount()
    {
        return (UnitsConsumed * RatePerUnit);
    }
    public override decimal CalculateTax(decimal billAmount)
    {
        return (billAmount * 0.02m);
    }
}

class GasBill : UtilityBill
{
    public GasBill(int ConsumerId, string ConsumerName, decimal UnitsConsumed, decimal RatePerUnit) 
    : base(ConsumerId, ConsumerName, UnitsConsumed, RatePerUnit)
    {
        
    }
    public override decimal CalculateBillAmount()
    {
        return (UnitsConsumed * RatePerUnit) + 150;
    }

    public override decimal CalculateTax(decimal billAmount)
    {
        return 0;
    }
}

class Program
{
    public static void Main(string[] args)
    {
        List<UtilityBill> bills = new List<UtilityBill>
        {
            new ElectricityBill( 101, "Sachin", 350, 6.5m ),
            new WaterBill( 102, "Akash", 120, 2.0m ),
            new GasBill( 103, "Rahul", 30, 15m ),
        };

        foreach (var item in bills)
        {
            item.PrintBill();
            Console.WriteLine();
        }
    }
}