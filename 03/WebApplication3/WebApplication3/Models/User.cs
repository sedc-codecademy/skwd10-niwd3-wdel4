using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication3.Models
{
    public partial class User
    {
        public User()
        {
            Invoices = new HashSet<Invoice>();
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public string RoleKey { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        public virtual Role RoleKeyNavigation { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
