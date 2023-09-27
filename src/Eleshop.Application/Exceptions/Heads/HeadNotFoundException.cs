namespace Eleshop.Application.Exceptions.Heads;

public class HeadNotFoundException : NotFoundException
{
    public HeadNotFoundException()
    {
        this.TitleMessage = "Head not found!";
    }
}
