using BasicBilling.Services;
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
}