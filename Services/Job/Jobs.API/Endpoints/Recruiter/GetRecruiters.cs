using Carter;
using Job.Application.Dtos;
using Job.Application.Recruiters.GetRecruiters;
using Mapster;
using MediatR;

namespace Job.API.Controllers
{
    public record GetRecruitersResponse(IEnumerable<RecruiterDto> Recruiters);

    public class GetRecruiters : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("api/recruiters", async (ISender sender) =>
            {
                var result = await sender.Send(new GetRecruitersQuery());

                var response = result.Adapt<GetRecruitersResponse>();

                return Results.Ok(response);
            })
            .WithName("GetRecruiters")
            .Produces<GetRecruitersResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Get Recruiters")
            .WithDescription("Get Recruiters");
        }
    }
}