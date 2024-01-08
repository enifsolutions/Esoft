using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BankApplication.Models.User;

namespace BankApplication.Data
{
    public class BankApplicationContext : DbContext
    {
        public BankApplicationContext (DbContextOptions<BankApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<BankApplication.Models.User.UserViewModel> UserViewModel { get; set; } = default!;
    }
}
