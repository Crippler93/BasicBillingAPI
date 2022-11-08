namespace BasicBilling.Data;

public class Billing
{
  public int Id { get; set; }
  public string State { get; set; }
  public int BillId { get; set; }
  public Bill BillDetails {get; set;}

  public int ClientId {get; set;}
  public Client Client {get; set;}
}