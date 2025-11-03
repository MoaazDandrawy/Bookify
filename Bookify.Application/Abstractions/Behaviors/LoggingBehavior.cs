using Bookify.Application.Abstractions.Messaging;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Bookify.Application.Abstractions.Behaviors
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>// IPipeLineBehavior da 3lshan y2ool en el class da haikon part mn el MediatR PipeLine
        where TRequest : IBaseCommand//howa 3aml implement l IBaseCommand 3lshan hai3ml logging l el Commands Bas
    {
        private readonly ILogger<TRequest> _logger;

        public LoggingBehavior(ILogger<TRequest> logger)
        {
            _logger = logger;
        }

        //                                  el request da el Command                    next da el Command Handler 
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var name = request.GetType().Name;//bisagl esm el Command zai ReserveBookingCommand using Reflection

            try
            {
                _logger.LogInformation("Executing command {Command}", name);

                var result = await next();//hena binafz f3ln el Command zat nafso ya3ny lw ReserveBookingCommand haibtdy fiha

                _logger.LogInformation("Command {Command} processed successfully", name);

                return result;
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Command {Command} processing failed", name);

                throw;
            }
        }
    }
}
