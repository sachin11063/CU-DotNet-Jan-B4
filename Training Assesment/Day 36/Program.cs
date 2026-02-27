using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;

class EmployeeNode
{
    public string Name;
    public string Position;
    public List<EmployeeNode> Reports = new List<EmployeeNode>();

    public EmployeeNode(string n, string p) { Name = n; Position = p; }
    public void Add(EmployeeNode e) => Reports.Add(e);
}

class OrgTree
{
    public EmployeeNode Root;
    public OrgTree(EmployeeNode root) { Root = root; }

    public void Display() => Print(Root, 0);

    void Print(EmployeeNode node, int depth)
    {
        Console.WriteLine($"{new string(' ', depth * 2)}{node.Name} ({node.Position})");
        foreach (var r in node.Reports)
            Print(r, depth + 1);
    }
}

class Program
{
    static void Main()
    {
        var ceo = new EmployeeNode("Sachin", "CEO");
        var cto = new EmployeeNode("Manish", "CTO");
        var dev = new EmployeeNode("Sara", "Dev");

        ceo.Add(cto);
        cto.Add(dev);

        new OrgTree(ceo).Display();
    }
}

//----------------------DAY 38------------------------
//--INNER JOIN
//SELECT p.ProductName, c.CategoryName
//FROM Products p
//JOIN Categories c ON p.CategoryID = c.CategoryID;

//--GROUP BY
//SELECT c.CategoryName, SUM(p.UnitsInStock)
//FROM Products p
//JOIN Categories c ON p.CategoryID = c.CategoryID
//GROUP BY c.CategoryName;

//--SUBQUERY
//SELECT ProductName
//FROM Products
//WHERE UnitPrice > (SELECT AVG(UnitPrice) FROM Products);

//--SELF JOIN
//SELECT e.FirstName, m.FirstName AS Manager
//FROM Employees e
//LEFT JOIN Employees m ON e.ReportsTo = m.EmployeeID;

//--NOT EXISTS
//SELECT CompanyName
//FROM Customers c
//WHERE NOT EXISTS (
//    SELECT 1 FROM Orders o WHERE o.CustomerID = c.CustomerID
//);