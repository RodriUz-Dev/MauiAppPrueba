using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppPrueba.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }        
        public required string Email { get; set; }        
        public required string Password { get; set; }
    }
}
