using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppPrueba.Domain.Entities
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Code { get; set; }
        [Required] 
        public string? Name { get; set; }
        public string? EntryDate { get; set; } 
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Salary { get; set; } = 0;
        public string? ImageUrl { get; set; }
    }
}
