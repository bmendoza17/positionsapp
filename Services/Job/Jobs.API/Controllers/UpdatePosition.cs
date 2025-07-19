using Carter;
using Job.Application.Entities;
using Job.Application.Positions.Commands.UpdatePosition;
using Mapster;
using MediatR;

namespace Job.API.Controllers
{
    public class UpdatePosition : ICarterModule
    {
        public record UpdatePositionRequest(PositionEntity Position);

        public record UpdatePositionResponse(bool IsUpdated);

        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("/positions", async (UpdatePositionRequest request, ISender sender) =>
            {
                var command = request.Adapt<UpdatePositionCommand>();

                var result = await sender.Send(command);

                var response = result.Adapt<UpdatePositionResponse>();

                return Results.Ok(response);
            })
            .WithName("UpdatePosition")
            .Produces<UpdatePositionResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Update Position")
            .WithDescription("Update Position");
        }
    }
}
