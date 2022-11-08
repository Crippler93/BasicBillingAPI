namespace BasicBilling.Data;

public record BillingResponseDTO
{
  public int Id { get; set; }
  public string State { get; set; }
  public Bill BillDetails { get; set; }
  public Client Client { get; set; }
}