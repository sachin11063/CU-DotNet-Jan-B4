using System;
using System.Collections.Generic;

class Policy
{
    public string HolderName { get; set; }
    public decimal Premium { get; set; }
    public int RiskScore { get; set; }
    public DateTime RenewalDate { get; set; }

    public Policy(string holderName, decimal premium, int riskScore, DateTime renewalDate)
    {
        HolderName = holderName;
        Premium = premium;
        RiskScore = riskScore;
        RenewalDate = renewalDate;
    }

    public override string ToString()
    {
        return $"Holder: {HolderName}, Premium: {Premium}, RiskScore: {RiskScore}, RenewalDate: {RenewalDate:d}";
    }
}

class PolicyTracker
{
    Dictionary<string, Policy> policies = new Dictionary<string, Policy>();

    public void AddPolicy(string policyId, Policy policy)
    {
        policies[policyId] = policy;
    }

    public void BulkAdjustment()
    {
        foreach (var policy in policies.Values)
        {
            if (policy.RiskScore > 75)
            {
                policy.Premium += policy.Premium * 0.05m;
            }
        }
    }

    public void CleanUp()
    {
        List<string> keysToRemove = new List<string>();
        DateTime cutoffDate = DateTime.Now.AddYears(-3);

        foreach (var kvp in policies)
        {
            if (kvp.Value.RenewalDate < cutoffDate)
            {
                keysToRemove.Add(kvp.Key);
            }
        }

        foreach (var key in keysToRemove)
        {
            policies.Remove(key);
        }
    }

    public string SafeLookup(string policyId)
    {
        if (policies.TryGetValue(policyId, out Policy policy))
        {
            return policy.ToString();
        }
        return "Policy Not Found";
    }
}

class Program
{
    static void Main()
    {
        PolicyTracker tracker = new PolicyTracker();

        tracker.AddPolicy("P101", new Policy("Sachin", 12000m, 80, DateTime.Now.AddYears(-1)));
        tracker.AddPolicy("P102", new Policy("Manish", 9000m, 60, DateTime.Now.AddYears(-4)));

        tracker.BulkAdjustment();
        tracker.CleanUp();

        Console.WriteLine(tracker.SafeLookup("P101"));
        Console.WriteLine(tracker.SafeLookup("P102"));
    }
}
