using Carter;
using Job.Application.Dtos;
using Job.Application.Positions.Commands.CreatePosition;
using Mapster;
using MediatR;

namespace Job.API.Controllers
{
    public record CreatePositionRequest(PositionDto Position);

    public record CreatePositionResponse(int Id);

    public class CreatePosition : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("api/positions",
                async (CreatePositionRequest request, ISender sender) =>
            {
                var command = request.Adapt<CreatePositionCommand>();

                var comand = new CreatePositionCommand(new PositionDto(0, "as", "lo", string.Empty, "ho", 1, 34, 10, DateTime.Now));

                var result = await sender.Send(comand);

                var response = result.Adapt<CreatePositionResponse>();

                return Results.Created($"/positions/{response.Id}", response);
            })
            .WithName("CreatePosition")
            .Produces<CreatePositionResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Create Position")
            .WithDescription("Create Position");
        }
    }
}
