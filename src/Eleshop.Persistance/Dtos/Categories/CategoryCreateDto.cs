namespace Eleshop.Persistance.Dtos.Categories;

public class CategoryCreateDto
{
    public long UserId { get; set; }

    public string Name { get; set; } = String.Empty;
}
