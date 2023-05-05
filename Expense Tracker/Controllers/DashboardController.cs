using Expense_Tracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Security.Cryptography.Xml;

namespace Expense_Tracker.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;
        public DashboardController(ApplicationDbContext context) {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            //Last 7 days transactions
            DateTime StartDate = DateTime.Today.AddDays(-6);
            DateTime EndDate = DateTime.Today;

            List<Transaction> SelectedTransactions = await _context.Transactions.Include(x => x.Category)
                .Where(y => y.Date >= StartDate && y.Date <= EndDate).ToListAsync();

            //Total Income
            int TotalIncome = SelectedTransactions
                .Where(i => i.Category.Type == "Income")
                .Sum(j => j.Amount);

            ViewBag.TotalIncome = TotalIncome.ToString("₹0");
            
            //Total Expense
            int TotalExpense = SelectedTransactions
                .Where(i => i.Category.Type == "Expense")
                .Sum(j => j.Amount);

            ViewBag.TotalExpense = TotalExpense.ToString("₹0");

            //Balance Amount = Total Income - Expense
            CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US");
            culture.NumberFormat.CurrencyNegativePattern = 1;
            int Balance = TotalIncome - TotalExpense;
            ViewBag.Balance = String.Format(culture, "{0:₹0}", Balance);

            //Doughnut Chart - Expense By Category
            ViewBag.DoughnutChartData = SelectedTransactions
                .Where(i => i.Category.Type == "Expense")
                .GroupBy(j => j.Category.CategoryId)
                .Select(k => new
                {
                    //Y_Value = Proportion of the doughnut to be assigned to each part
                    amount = k.Sum(j => j.Amount),

                    //Text = Text show in each part
                    formattedAmount = k.Sum(j => j.Amount).ToString("₹0"),

                    //XValue = Titlw of each part
                    categoryTitleWithIcon = k.First().Category.Icon + " " + k.First().Category.Title,
                })
                .ToList();


            return View();
        }
    }
}
