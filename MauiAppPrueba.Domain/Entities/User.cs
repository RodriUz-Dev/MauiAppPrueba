using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppPrueba.Domain.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }        
        public string? Name { get; set; }
        [Required]
        public required string Email { get; set; }
        [Required]
        public required string Password { get; set; }        
    }
}
