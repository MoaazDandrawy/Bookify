using Bookify.Domain.Abstractions;
using MediatR;

namespace Bookify.Application.Abstractions.Messaging
{
    //el command momkn yrag3 7aga w momkn la2 8er el query kda kda hairg3 7aga

    //da command msh hairg3 b 7aga
    public interface ICommand : IRequest<Result>, IBaseCommand
    {
    }
    //da command hairg3 b response
    public interface ICommand<TResponse> : IRequest<Result<TResponse>>, IBaseCommand
    {
    }
    // el interface da mohm f el Cross-cutting concerns
    public interface IBaseCommand
    {

    }
}
