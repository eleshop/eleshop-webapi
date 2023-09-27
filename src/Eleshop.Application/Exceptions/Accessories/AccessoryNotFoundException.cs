namespace Eleshop.Application.Exceptions.Accessories;

public class AccessoryNotFoundException : NotFoundException
{
    public AccessoryNotFoundException()
    {
        this.TitleMessage = "Accessuary not found!";
    }
}
