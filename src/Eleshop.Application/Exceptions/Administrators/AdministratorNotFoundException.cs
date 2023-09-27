namespace Eleshop.Application.Exceptions.Administrators;

public class AdministratorNotFoundException : NotFoundException
{
    public AdministratorNotFoundException()
    {
        this.TitleMessage = "Administrator not found!";
    }
}
