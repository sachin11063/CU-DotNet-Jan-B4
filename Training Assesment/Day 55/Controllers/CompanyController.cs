using Microsoft.AspNetCore.Mvc;
using Day_55.Models;

namespace Day_55.Controllers;

public class CompanyController : Controller
{
    public IActionResult Dashboard()
    {
        var employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "Sachin",    Position = "Lead Engineer",     Salary = 118000 },
            new Employee { Id = 2, Name = "Shashank",   Position = "Product Designer",  Salary = 94500  },
            new Employee { Id = 3, Name = "Nishant",   Position = "DevOps Specialist", Salary = 105000 },
            new Employee { Id = 4, Name = "Sneha",  Position = "QA Analyst",        Salary = 82000  },
            new Employee { Id = 5, Name = "Vikram",  Position = "Backend Developer", Salary = 97000  },
        };

        ViewBag.DailyAnnouncement = "Q2 All-Hands is on Friday, June 14th at 2:00 PM in the Main Auditorium.";

        ViewData["DepartmentName"] = "Engineering & Product";
        ViewData["ServerStatus"]   = "Operational";
        ViewData["IsActive"]       = true;

        return View(employees);
    }
}