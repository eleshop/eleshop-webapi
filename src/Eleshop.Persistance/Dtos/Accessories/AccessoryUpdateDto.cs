using Microsoft.AspNetCore.Http;

namespace Eleshop.Persistance.Dtos.Accessories;

public class AccessoryUpdateDto
{
    public long UserId { get; set; }

    public string Name { get; set; } = String.Empty;

    public float UnitPrice { get; set; }

    public IFormFile? ImagePath { get; set; }

    public string Description { get; set; } = String.Empty;
}
