using Bookify.Domain.Abstractions;
using MediatR;

namespace Bookify.Application.Abstractions.Messaging
{
    //da el mo3alg el 5as b IQuery
    //ai handler ba3d keda hai3ml implement l el Interface da zay masln GetBooksQueryHandler:IQueryHandler<GetBooksQuery,List<BooksDo>> w lzam GetBooksQuery da ykoon 3aml implement l IQuery<TResponse>
    public interface IQueryHandler<TQuery,TResponse> : IRequestHandler<TQuery,Result<TResponse>>
    where TQuery : IQuery<TResponse>//da 3lshan ydmn en elly gay da query msh string masln aw command
    {
    }
}
