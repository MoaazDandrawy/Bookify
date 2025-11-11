using Bookify.Application.Apartments.SearchApartments;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bookify.Api.Controllers.Apartments
{
    [ApiController]
    [Route("api/apartments")]
    public class ApartmentsController : ControllerBase
    {
        private readonly ISender _sender;

        public ApartmentsController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<IActionResult> SearchApartments(DateOnly startDate,DateOnly endDate,CancellationToken cancellationToken)
        {
            var query = new SearchApartmentsQuery(startDate, endDate);

                //hena el MediatR 3bara 3ab 3an waseet ben el Query w el QueryHandler
            var result = await _sender.Send(query, cancellationToken);
            
            //hoa hena rag3 3la tool mn 8er ai check 3lshan hoa mota2kd en mfish 7aga hatdrb hena
            return Ok(result.Value);
        }
    }
}
