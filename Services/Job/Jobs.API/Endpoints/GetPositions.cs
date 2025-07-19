using Carter;
using Job.Application.Dtos;
using Job.Application.Positions.Queries.GetPositions;
using Mapster;
using MediatR;

namespace Job.API.Controllers
{
    public record GetPositionsResponse(IEnumerable<PositionDto> Positions);

    public class GetPositions : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("api/positions", async (ISender sender) =>
            {
                var result = await sender.Send(new GetPositionsQuery());

                var response = result.Adapt<GetPositionsResponse>();

                return Results.Ok(response);
            })
            .WithName("GetPositions")
            .Produces<GetPositionsResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Get Positions")
            .WithDescription("Get Positions");
        }
    }
}