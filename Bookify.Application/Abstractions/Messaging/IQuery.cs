using Bookify.Domain.Abstractions;
using MediatR;

namespace Bookify.Application.Abstractions.Messaging
{
    //di m3naha en kol query haitb3t hairod b response w no3o result 3lshan a2dr a3ml 3aleh el exceptions elly goa class el result da
    public interface IQuery<TResponse> : IRequest<Result<TResponse>>
    {
    }
}
