using ChatTest.Common.DbModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatTest.Common
{
    public class SignalDbContext : DbContext
    {
        public SignalDbContext(DbContextOptions<SignalDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }
        public DbSet<SignalDataModel> Signals { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
