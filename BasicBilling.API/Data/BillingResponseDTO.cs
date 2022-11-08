namespace BasicBilling.Data;

public class BillingResponseDTO
{
  public int Id {get; set;}
  public string State {get; set;}
  public double Amount {get; set;}
  public Bill BillDetails {get; set;}
  public Client Client {get; set;}
  
}