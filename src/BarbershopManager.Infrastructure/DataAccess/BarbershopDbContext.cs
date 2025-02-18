using BarbershopManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BarbershopManager.Infrastructure.DataAccess;
internal class BarbershopDbContext : DbContext
{
    public BarbershopDbContext(DbContextOptions<BarbershopDbContext> options) : base(options)    
    {
        
    }

    public DbSet<Income> Incomes { get; set; }
    public DbSet<User> Users { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Income>().ToTable(nameof(Incomes));

        modelBuilder.Entity<Income>().Property(income => income.Nome).HasMaxLength(60);
        modelBuilder.Entity<Income>().Property(income => income.Preco).HasColumnType("decimal(10,2)");


        modelBuilder.Entity<User>().ToTable(nameof(Users));
        modelBuilder.Entity<User>().Property(user => user.Name).HasMaxLength(80);
        modelBuilder.Entity<User>().Property(user => user.Email).HasMaxLength(100);
        modelBuilder.Entity<User>().Property(user => user.Password).HasMaxLength(30); 
	}
}
