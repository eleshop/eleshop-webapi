using Eleshop.Application.Exceptions;
using System.Net;

namespace Eleshop.Application.Exseptions;

public class TooManyRequestException : ClientException
{
    public override HttpStatusCode StatusCode { get; } = HttpStatusCode.TooManyRequests;

    public override string TitleMessage { get; protected set; } = String.Empty;
}
