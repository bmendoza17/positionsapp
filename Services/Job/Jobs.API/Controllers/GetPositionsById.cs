using Carter;
using Job.Application.Dtos;
using Job.Application.Positions.Queries.GetPositionById;
using Mapster;
using MediatR;

namespace Job.API.Controllers
{
    public record GetPositionByIdResponse(PositionDto Position);

    public class GetPositionById : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("api/positions/{positionId}", async (int positionId, ISender sender) =>
            {
                var result = await sender.Send(new GetPositionByIdQuery(positionId));

                var response = result.Adapt<GetPositionByIdResponse>();

                return Results.Ok(response);
            })
            .WithName("GetPositionById")
            .Produces<GetPositionByIdResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Get Position By Id")
            .WithDescription("Get Position By Id");
        }
    }
}