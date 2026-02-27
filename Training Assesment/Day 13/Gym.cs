using System;

public class GymMembership
{
    public static double CalculateMembershipAmount(
        bool treadmill,
        bool weightLifting,
        bool zumba)
    {
        double total = 1000; // fixed monthly charge

        bool anyServiceSelected = treadmill || weightLifting || zumba;

        if (treadmill)
            total += 300;

        if (weightLifting)
            total += 500;

        if (zumba)
            total += 250;

        // add penalty if no service selected
        if (!anyServiceSelected)
            total += 200;

        // add 5% gst
        double gst = total * 0.05;
        total += gst;

        return total;
    }

    // example usage
    public static void Main()
    {
        double amount = CalculateMembershipAmount(true, false, true);
        Console.WriteLine("total membership amount: rs. " + amount);
    }
}