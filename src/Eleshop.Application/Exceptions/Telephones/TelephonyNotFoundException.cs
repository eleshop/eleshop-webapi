namespace Eleshop.Application.Exceptions.Telephones;

public class TelephonyNotFoundException : NotFoundException
{
    public TelephonyNotFoundException()
    {
        this.TitleMessage = "Telephony not found!";
    }
}
