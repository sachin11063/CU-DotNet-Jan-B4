namespace Day19._2;


abstract class UtilityBill
{
    public int ConsumerId { get; set; }
    public string ConsumerName { get; set; }
    public decimal UnitsConsumed { get; set; }
    public decimal RatePerUnit { get; set; }

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
            new ElectricityBill
            {
                ConsumerId = 101,
                ConsumerName = "Sachin",
                UnitsConsumed = 350,
                RatePerUnit = 6.5m
            },

            new WaterBill
            {
                ConsumerId = 102,
                ConsumerName = "Akash",
                UnitsConsumed = 120,
                RatePerUnit = 2.0m
            },

            new GasBill
            {
                ConsumerId = 103,
                ConsumerName = "Rahul",
                UnitsConsumed = 30,
                RatePerUnit = 15m
            }
        };

        foreach (var item in bills)
        {
            item.PrintBill();
            Console.WriteLine();
        }
    }
}