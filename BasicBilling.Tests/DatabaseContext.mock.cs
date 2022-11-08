using Microsoft.EntityFrameworkCore;
using BasicBilling.Data;

namespace BasicBilling.Mocks;

public class DataBaseContextMock
{
  public static async Task<BillingDbContext> GetDBContext()
  {
    var options = new DbContextOptionsBuilder<BillingDbContext>()
      .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
      .Options;
    var databaseContext = new BillingDbContext(options);
    databaseContext.Database.EnsureCreated();
    return databaseContext;
  }
}