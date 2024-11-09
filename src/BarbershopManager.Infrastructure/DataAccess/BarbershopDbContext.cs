using BarbershopManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BarbershopManager.Infrastructure.DataAccess;
internal class BarbershopDbContext : DbContext
{
    public BarbershopDbContext(DbContextOptions options) : base(options)    
    {
        
    }
    public DbSet<Income> Incomes { get; set; }
    public DbSet<User> Users { get; set; }

}
