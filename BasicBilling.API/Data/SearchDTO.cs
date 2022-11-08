namespace BasicBilling.Data;

public record SearchDTO
{
  public string? Category { get; set; }
  public string? State { get; set; }
  public string? ClientName { get; set; }
}