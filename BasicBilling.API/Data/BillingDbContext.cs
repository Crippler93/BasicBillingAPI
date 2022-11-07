using Microsoft.EntityFrameworkCore;

namespace BasicBilling.Data;

public class BillingDbContext : DbContext
{
  public BillingDbContext(DbContextOptions<BillingDbContext> options): base(options)
  {}

  protected override void OnModelCreating(ModelBuilder builder)
  {
    builder.Entity<Client>().HasData(new Client {Id=100, Name="Joseph Carlton"});
    builder.Entity<Client>().HasData(new Client {Id=200, Name="Maria Juarez"});
    builder.Entity<Client>().HasData(new Client {Id=300, Name="Albert Kenny"});
    builder.Entity<Client>().HasData(new Client {Id=400, Name="Jessica Philips"});
    builder.Entity<Client>().HasData(new Client {Id=500, Name="Charles Johnson"});

    builder.Entity<Bill>().HasData(new Bill {Id=1, Period=202209, Category="WATER"});
    builder.Entity<Bill>().HasData(new Bill {Id=2, Period=202210, Category="ELECTRICITY"});

    builder.Entity<Billing>().HasData(new Billing {Id=1, BillId=1, ClientId=100, State="Pending"});
    builder.Entity<Billing>().HasData(new Billing {Id=2, BillId=2, ClientId=100, State="Paid"});
    builder.Entity<Billing>().HasData(new Billing {Id=3, BillId=1, ClientId=200, State="Paid"});
    builder.Entity<Billing>().HasData(new Billing {Id=4, BillId=2, ClientId=200, State="Pending"});
    builder.Entity<Billing>().HasData(new Billing {Id=5, BillId=1, ClientId=300, State="Paid"});
    builder.Entity<Billing>().HasData(new Billing {Id=6, BillId=2, ClientId=300, State="Paid"});
    builder.Entity<Billing>().HasData(new Billing {Id=7, BillId=1, ClientId=400, State="Pending"});
    builder.Entity<Billing>().HasData(new Billing {Id=8, BillId=2, ClientId=400, State="Paid"});
    builder.Entity<Billing>().HasData(new Billing {Id=9, BillId=1, ClientId=500, State="Paid"});
    builder.Entity<Billing>().HasData(new Billing {Id=10, BillId=2, ClientId=500, State="Pending"});
  }

  public DbSet<Bill> Bills { get; set; }
  public DbSet<Client> Clients { get; set; }
  public DbSet<Billing> Billings { get; set; }
}