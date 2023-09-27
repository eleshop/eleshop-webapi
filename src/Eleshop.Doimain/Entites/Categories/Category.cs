namespace Eleshop.Domain.Entites.Categories;

public class Category : Auditable
{
    public long UserId { get; set; }

    public string Name { get; set; } = String.Empty;
}
