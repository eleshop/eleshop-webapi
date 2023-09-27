namespace Eleshop.Application.Exceptions.Admins;

public class AdminNotFoundException : NotFoundException
{
    public AdminNotFoundException()
    {
        this.TitleMessage = "Admin not found!";
    }
}
