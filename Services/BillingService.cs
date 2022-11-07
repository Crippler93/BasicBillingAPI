using BasicBilling.Data;
using Microsoft.EntityFrameworkCore;

namespace BasicBilling.Services;

public class BillingService
{
  public BillingDbContext _db { get; set; }

  public BillingService(BillingDbContext db)
  {
    _db = db;
  }

  public async Task<List<BillingResponseDTO>> GetBillings(string? state, int? clientId = null)
  {
    var query = from b in _db.Billings.Include(b => b.BillDetails) select new BillingResponseDTO{Id=b.Id, State=b.State, BillDetails=b.BillDetails, ClientId=b.ClientId};

    if (state != null) {
      query = query.Where(b => b.State == state);
    }

    if (clientId != null)
    {
      query = query.Where(b => b.ClientId == clientId);
    }

    return await query.ToListAsync();
  }
}