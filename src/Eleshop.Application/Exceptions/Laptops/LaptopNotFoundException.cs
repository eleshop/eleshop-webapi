namespace Eleshop.Application.Exceptions.Laptops;

public class LaptopNotFoundException : NotFoundException
{
    public LaptopNotFoundException()
    {
        this.TitleMessage = "Laptop not found!";
    }
}
