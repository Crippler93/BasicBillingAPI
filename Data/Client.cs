using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BasicBilling.Data;

public class Client
{
  public int Id { get; set; }
  public string Name { get; set; }

  public List<Billing> Billings {get; set;}

}