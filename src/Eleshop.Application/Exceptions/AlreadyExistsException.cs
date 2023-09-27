using System.Net;

namespace Eleshop.Application.Exceptions;

public class AlreadyExistsException : ClientException
{
    public override HttpStatusCode StatusCode { get; } = HttpStatusCode.NotFound;

    public override string TitleMessage { get; protected set; } = String.Empty;
}
