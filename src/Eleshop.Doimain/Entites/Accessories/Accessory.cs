namespace Eleshop.Domain.Entites.Accessories;

public class Accessory : Auditable
{
    public long CategoryId { get; set; }

    public long UserId { get; set; }

    public string Name { get; set; } = String.Empty;

    public float UnitPrice { get; set; }

    public string ImagePath { get; set; } = String.Empty;

    public string Description { get; set; } = String.Empty;
}
