using Carter;
using Job.Application.Positions.Commands.DeletePosition;
using Mapster;
using MediatR;

namespace Job.API.Controllers
{
    public class DeletePosition : ICarterModule
    {
        public record DeletePositionResponse(bool IsDeleted);

        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/positions/{id}", async (int Id, ISender sender) =>
            {
                var result = await sender.Send(new DeletePositionCommand(Id));

                var response = result.Adapt<DeletePositionResponse>();

                return Results.Ok(response);
            })
            .WithName("DeletePosition")
            .Produces<DeletePositionResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Delete Position")
            .WithDescription("Delete Position");
        }
    }
}
