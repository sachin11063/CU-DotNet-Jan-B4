using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        StudentAnalytics();
        EmployeeProcessing();
        ProductInventory();
        LibraryManagement();
        CustomerOrders();
        MovieStreaming();
        BankAnalyzer();
        EcommerceCart();
        SocialMediaAnalytics();
    }

    // 1. Student Performance Analytics
    static void StudentAnalytics()
    {
        var students = new List<Student>
        {
            new Student{Id=1, Name="Amit", Class="10A", Marks=85},
            new Student{Id=2, Name="Neha", Class="10A", Marks=72},
            new Student{Id=3, Name="Rahul", Class="10B", Marks=90},
            new Student{Id=4, Name="Pooja", Class="10B", Marks=60},
            new Student{Id=5, Name="Kiran", Class="10A", Marks=95}
        };

        var top3 = students.OrderByDescending(x => x.Marks).Take(3);

        var avgByClass = students
            .GroupBy(x => x.Class)
            .Select(g => new { Class = g.Key, Avg = g.Average(x => x.Marks) });

        var belowAvg = students
            .GroupBy(x => x.Class)
            .SelectMany(g =>
            {
                var avg = g.Average(x => x.Marks);
                return g.Where(x => x.Marks < avg);
            });

        var ordered = students.OrderBy(x => x.Class)
                              .ThenByDescending(x => x.Marks);
    }

    // 2. Employee Salary Processing
    static void EmployeeProcessing()
    {
        var employees = new List<Employee>
        {
            new Employee{Id=1, Name="Ravi", Dept="IT", Salary=80000, JoinDate=new DateTime(2019,1,10)},
            new Employee{Id=2, Name="Anita", Dept="HR", Salary=60000, JoinDate=new DateTime(2021,3,5)},
            new Employee{Id=3, Name="Suresh", Dept="IT", Salary=120000, JoinDate=new DateTime(2018,7,15)},
            new Employee{Id=4, Name="Meena", Dept="Finance", Salary=90000, JoinDate=new DateTime(2022,9,1)}
        };

        var salaryStats = employees.GroupBy(x => x.Dept)
            .Select(g => new
            {
                Dept = g.Key,
                Max = g.Max(x => x.Salary),
                Min = g.Min(x => x.Salary)
            });

        var countByDept = employees.GroupBy(x => x.Dept)
            .Select(g => new { Dept = g.Key, Count = g.Count() });

        var joinedAfter2020 = employees.Where(x => x.JoinDate.Year > 2020);

        var annual = employees.Select(x => new
        {
            x.Name,
            AnnualSalary = x.Salary * 12
        });
    }

    // 3. Product Inventory
    static void ProductInventory()
    {
        var products = new List<Product>
        {
            new Product{Id=1, Name="Laptop", Category="Electronics", Price=50000},
            new Product{Id=2, Name="Phone", Category="Electronics", Price=20000},
            new Product{Id=3, Name="Table", Category="Furniture", Price=5000}
        };

        var sales = new List<Sale>
        {
            new Sale{ProductId=1, Qty=10},
            new Sale{ProductId=2, Qty=20}
        };

        var revenue = products.GroupJoin(sales,
            p => p.Id,
            s => s.ProductId,
            (p, s) => new
            {
                p.Name,
                Revenue = s.Sum(x => x.Qty * p.Price)
            });

        var bestSelling = revenue.OrderByDescending(x => x.Revenue).FirstOrDefault();

        var zeroSales = products.GroupJoin(sales,
            p => p.Id,
            s => s.ProductId,
            (p, s) => new { p, s })
            .Where(x => !x.s.Any())
            .Select(x => x.p);
    }

    // 4. Library Management
    static void LibraryManagement()
    {
        var books = new List<Book>
        {
            new Book{Title="C# Basics", Author="John", Genre="Tech", Year=2018, Price=500},
            new Book{Title="Java Advanced", Author="Mike", Genre="Tech", Year=2016, Price=700},
            new Book{Title="History India", Author="Raj", Genre="History", Year=2019, Price=400}
        };

        var recent = books.Where(x => x.Year > 2015);

        var countByGenre = books.GroupBy(x => x.Genre)
            .Select(g => new { Genre = g.Key, Count = g.Count() });

        var expensivePerGenre = books.GroupBy(x => x.Genre)
            .Select(g => g.OrderByDescending(x => x.Price).First());

        var authors = books.Select(x => x.Author).Distinct();
    }

    // 5. Customer Order Analysis
    static void CustomerOrders()
    {
        var customers = new List<Customer>
        {
            new Customer{Id=1, Name="Ajay", City="Delhi"},
            new Customer{Id=2, Name="Sunita", City="Mumbai"}
        };

        var orders = new List<Order>
        {
            new Order{OrderId=1, CustomerId=1, Amount=20000},
            new Order{OrderId=2, CustomerId=1, Amount=40000}
        };

        var totalPerCustomer = customers.GroupJoin(orders,
            c => c.Id,
            o => o.CustomerId,
            (c, o) => new
            {
                c.Name,
                Total = o.Sum(x => x.Amount)
            });

        var noOrders = customers.GroupJoin(orders,
            c => c.Id,
            o => o.CustomerId,
            (c, o) => new { c, o })
            .Where(x => !x.o.Any())
            .Select(x => x.c);

        var above50k = totalPerCustomer.Where(x => x.Total > 50000);

        var sorted = totalPerCustomer.OrderByDescending(x => x.Total);
    }

    // 6. Movie Streaming
    static void MovieStreaming()
    {
        var movies = new List<Movie>
        {
            new Movie{Title="Inception", Genre="SciFi", Rating=9, Year=2010},
            new Movie{Title="Avatar", Genre="SciFi", Rating=8.5, Year=2009},
            new Movie{Title="Titanic", Genre="Drama", Rating=8, Year=1997}
        };

        var highRated = movies.Where(x => x.Rating > 8);

        var avgByGenre = movies.GroupBy(x => x.Genre)
            .Select(g => new { Genre = g.Key, Avg = g.Average(x => x.Rating) });

        var latestPerGenre = movies.GroupBy(x => x.Genre)
            .Select(g => g.OrderByDescending(x => x.Year).First());

        var top5 = movies.OrderByDescending(x => x.Rating).Take(5);
    }

    // 7. Bank Analyzer
    static void BankAnalyzer()
    {
        var transactions = new List<BankTransaction>
        {
            new BankTransaction{Acc=101, Amount=5000, Type="Credit"},
            new BankTransaction{Acc=101, Amount=2000, Type="Debit"},
            new BankTransaction{Acc=102, Amount=10000, Type="Debit"}
        };

        var balance = transactions.GroupBy(x => x.Acc)
            .Select(g => new
            {
                Acc = g.Key,
                Balance = g.Where(x => x.Type=="Credit").Sum(x => x.Amount)
                         - g.Where(x => x.Type=="Debit").Sum(x => x.Amount)
            });

        var suspicious = balance.Where(x => x.Balance < 0);

        var highestTx = transactions.GroupBy(x => x.Acc)
            .Select(g => new
            {
                Acc = g.Key,
                Max = g.Max(x => x.Amount)
            });
    }

    // 8. Ecommerce Cart
    static void EcommerceCart()
    {
        var cart = new List<CartItem>
        {
            new CartItem{Name="TV", Category="Electronics", Price=30000, Qty=1},
            new CartItem{Name="Sofa", Category="Furniture", Price=15000, Qty=1}
        };

        var total = cart.Sum(x => x.Price * x.Qty);

        var categoryCost = cart.GroupBy(x => x.Category)
            .Select(g => new
            {
                Category = g.Key,
                Total = g.Sum(x =>
                    x.Category == "Electronics"
                    ? x.Price * x.Qty * 0.9
                    : x.Price * x.Qty)
            });
    }

    // 9. Social Media Analytics
    static void SocialMediaAnalytics()
    {
        var users = new List<User>
        {
            new User{Id=1, Name="A", Country="India"},
            new User{Id=2, Name="B", Country="USA"}
        };

        var posts = new List<Post>
        {
            new Post{UserId=1, Likes=100},
            new Post{UserId=1, Likes=50}
        };

        var topUsers = users.GroupJoin(posts,
            u => u.Id,
            p => p.UserId,
            (u, p) => new
            {
                u.Name,
                TotalLikes = p.Sum(x => x.Likes)
            })
            .OrderByDescending(x => x.TotalLikes);

        var groupedByCountry = users.GroupBy(x => x.Country);

        var inactive = users.GroupJoin(posts,
            u => u.Id,
            p => p.UserId,
            (u, p) => new { u, p })
            .Where(x => !x.p.Any())
            .Select(x => x.u);

        var avgLikes = posts.Average(x => x.Likes);
    }
}

class Student {
     public int Id; 
     public string Name; 
     public string Class; 
     public int Marks; 
}
class Employee {
    public int Id; 
    public string Name; 
    public string Dept; 
    public double Salary; 
    public DateTime JoinDate; 
}
class Product { 
    public int Id; 
    public string Name; 
    public string Category; 
    public double Price; 
    
}
class Sale { 
    public int ProductId; 
    public int Qty; 
}
class Book { 
    public string Title; 
    public string Author; 
    public string Genre; 
    public int Year; 
    public double Price; 
}
class Customer { 
    public int Id; 
    public string Name; 
    public string City; 
}
class Order { 
    public int OrderId; 
    public int CustomerId; 
    public double Amount; 
}
class Movie { 
    public string Title; 
    public string Genre; 
    public double Rating; 
    public int Year; 
}
class BankTransaction { 
    public int Acc; 
    public double Amount; 
    public string Type; 
}
class CartItem { 
    public string Name; 
public string Category; 
public double Price; 
public int Qty;
}
class User { 
    public int Id; 
    public string Name; 
    public string Country; 
}
class Post { 
    public int UserId; 
    public int Likes; 
}