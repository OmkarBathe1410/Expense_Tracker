using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Expense_Tracker.Models
{
    public class Transaction
    {
        // Primary Key
        [Key]
        public int TransactionId { get; set; }

        // Category of transaction (FKey)
        public int CategoryId { get; set; }
        public Category? Category { get; set; } // To create a navigation property.

        // Transaction amount
        public int Amount { get; set; }

        // To specify the description of the transaction '?'=> It can be null.
        [Column(TypeName = "nvarchar(75)")]
        public string? Note { get; set; } 

        // Date of transaction
        public DateTime Date { get; set; } = DateTime.Now;

        [NotMapped]
        public string? CategoryTitleWithIcon
        {
            get
            {
                return Category == null ? "" : Category.Icon + " " + Category.Title;
            }
        }

        [NotMapped]
        public string? FormattedAmount
        {
            get
            {
                return ((Category == null || Category.Type == "Expense") ? "-" : "+") + Amount.ToString("₹0");
            }
        }
    }
}
