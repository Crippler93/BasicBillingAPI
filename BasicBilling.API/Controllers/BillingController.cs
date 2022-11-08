using BasicBilling.Data;
using BasicBilling.Services;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace BasicBilling.Controllers;

[ApiController]
[Route("[controller]")]
public class BillingController: ControllerBase
{
  private BillingService _billingService { get; set; }

  public BillingController(BillingService billingService)
  {
    _billingService = billingService; 
  }

  [HttpGet]
  [Route("pending")]
  public async Task<IResult> GetPedingBillings([FromQuery] int? ClientId)
  {
    var billings = await _billingService.GetBillings("Pending", ClientId);
    return Results.Ok(billings);
  }

  [HttpGet]
  [Route("search")]
  public async Task<IResult> Search([FromQuery] SearchDTO? searchDTO)
  {
    var billings = await _billingService.Search(searchDTO);
    return Results.Ok(billings);
  }

  [HttpPost]
  [Route("bills")]
  public async Task<IResult> CreateBill(BillDTO billDTO)
  {
    var bill = await _billingService.CreateBill(billDTO);
    if (bill == null)
    {
      return Results.BadRequest();
    }
    return Results.Created(new Uri(Request.GetEncodedUrl() + "/" + bill.Id), bill);
  }
}