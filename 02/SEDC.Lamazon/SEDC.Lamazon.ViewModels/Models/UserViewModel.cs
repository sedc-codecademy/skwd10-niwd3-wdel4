﻿namespace SEDC.Lamazon.ViewModels.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }

        public RoleViewModel Role { get; set; }
    }
}
