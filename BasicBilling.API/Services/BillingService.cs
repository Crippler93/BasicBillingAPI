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
    var query = from b in _db.Billings.Include(b => b.BillDetails) select new BillingResponseDTO{Id=b.Id, State=b.State, BillDetails=b.BillDetails, Client=b.Client};

    if (state != null) {
      query = query.Where(b => b.State == state);
    }

    if (clientId != null)
    {
      query = query.Where(b => b.Client.Id == clientId);
    }

    return await query.ToListAsync();
  }

  public async Task<List<BillingResponseDTO>> Search(SearchDTO searchDTO)
  {
    var query = from b in _db.Billings.Include(b => b.BillDetails).Include(b => b.Client) select new BillingResponseDTO{Id=b.Id, State=b.State, BillDetails=b.BillDetails, Client=b.Client};

    if (!String.IsNullOrEmpty(searchDTO.ClientName)) {
      query = query.Where(b => b.Client.Name.Contains(searchDTO.ClientName));
    }

    if (!String.IsNullOrEmpty(searchDTO.Category)) {
      query = query.Where(b => b.BillDetails.Category == searchDTO.Category);
    }

    if (!String.IsNullOrEmpty(searchDTO.State)) {
      query = query.Where(b => b.State == searchDTO.State);
    }

    return await query.ToListAsync();
  }
}