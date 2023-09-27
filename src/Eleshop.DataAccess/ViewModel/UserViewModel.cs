using Eleshop.Domain.Entites;
using Eleshop.Domain.Enums;

namespace Eleshop.DataAccess.ViewModel;

public class UserViewModel : Auditable
{
    public long Id { get; set; }

    public string FirstName { get; set; } = String.Empty;

    public string LastName { get; set; } = String.Empty;

    public string PhoneNumber { get; set; } = String.Empty;

    public bool PhoneNumberConfirmed { get; set; }

    public string ImagePath { get; set; } = String.Empty;

    public string PassportSerialNumber { get; set; } = String.Empty;

    public DateTime BirthDate { get; set; }

    public string Region { get; set; } = String.Empty;

    public string District { get; set; } = String.Empty;

    public string Address { get; set; } = String.Empty;

    public IdentityRole IdentityRole { get; set; }
}
