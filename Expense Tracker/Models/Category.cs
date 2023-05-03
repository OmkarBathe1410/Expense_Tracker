using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Expense_Tracker.Models
{
    public class Category
    {
        // Primary key of a category
        [Key]
        public int CategoryId { get; set; } 

        // Title of the category
        [Column(TypeName = "nvarchar(50)")]
        public string Title { get; set; } 

        // Category will be identified by this icon
        [Column(TypeName = "nvarchar(5)")]
        public string Icon { get; set; } = ""; 

        //Income or Expense
        [Column(TypeName = "nvarchar(10)")]
        public string Type { get; set; } = "Expense";

        [NotMapped]
        public string? TitleWithIcon { 
            get{
                return this.Icon + " " + this.Title;
            } 
        }
    }
}
