using Cymax.WebApp.DataContext;
using Cymax.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cymax.WebApp.Controllers;
public class EmployeeController : Controller
{
    private readonly ApplicationDbContext _dbContext;

    public EmployeeController(ApplicationDbContext dbContext)
    {
        this._dbContext = dbContext;
    }
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> Index()
    {
        var employeeList = (await _dbContext.Employees.ToListAsync()) ?? new List<Employee>();
        return View(employeeList);
    }
}
