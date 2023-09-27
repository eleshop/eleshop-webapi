namespace Eleshop.Domain.Entites.Laptops;

public class Laptop : Auditable
{
    public long CategoryId { get; set; }

    public long UserId { get; set; }

    public string Name { get; set; } = String.Empty;

    public float UnitPrice { get; set; }
    
    public string Description { get; set; } = String.Empty;

    public string ImagePath { get; set; } = String.Empty;

    public string Core { get; set; } = String.Empty;

    public string Company { get; set; } = String.Empty;

    public string Cpu { get; set; } = String.Empty;

    public string CpuHz { get; set; } = String.Empty;

    public string Ram { get; set; } = String.Empty;

    public string Ssd { get; set; } = String.Empty;

    public string Os { get; set; } = String.Empty;

    public string OsVersion { get; set; } = String.Empty;
}
