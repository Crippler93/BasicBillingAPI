using BasicBilling.Data;
using BasicBilling.Errors;
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
    var query = from b in _db.Billings.Include(b => b.BillDetails) select new BillingResponseDTO{Id=b.Id, State=b.State, BillDetails=b.BillDetails, Client=b.Client, Amount=b.Amount};

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
    var query = from b in _db.Billings.Include(b => b.BillDetails).Include(b => b.Client) select new BillingResponseDTO{Id=b.Id, State=b.State, BillDetails=b.BillDetails, Client=b.Client, Amount=b.Amount};

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

  public async Task<Bill> CreateBill(BillDTO billDTO)
  {
    if (billDTO.Period.ToString().Length != 6 || String.IsNullOrEmpty(billDTO.Category))
    {
      return null;
    }
    var bill = new Bill() {
      Category = billDTO.Category,
      Period = billDTO.Period
    };
    _db.Bills.Add(bill);
    await _db.SaveChangesAsync();
    return bill;
  }

  public async Task<Billing> PayBilling(PayDTO payDTO)
  {
    if (payDTO.Period.ToString().Length != 6 || String.IsNullOrEmpty(payDTO.Category))
    {
      throw new BadRequestException();
    }

    var billingToPaid = await (_db.Billings
      .Include(b => b.Client)
      .Include(b => b.BillDetails)
      .Where(b => b.Client.Id == payDTO.ClientId && b.BillDetails.Category == payDTO.Category && b.BillDetails.Period == payDTO.Period && b.State == "Pending"))
      .FirstOrDefaultAsync();

    if (billingToPaid == null) {
      throw new NotFoundException();
    }

    billingToPaid.State = "Paid";

    await _db.SaveChangesAsync();
    return billingToPaid;
  }
}