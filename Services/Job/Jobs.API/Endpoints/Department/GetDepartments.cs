using Carter;
using Job.Application.Dtos;
using Mapster;
using MediatR;
using Job.Application.Departments.GetDepartments;

namespace Job.API.Controllers
{
    public record GetDepartmentsResponse(IEnumerable<DepartmentDto> Departments);

    public class GetDepartments : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("api/departments", async (ISender sender) =>
            {
                var result = await sender.Send(new GetDepartmentsQuery());

                var response = result.Adapt<GetDepartmentsResponse>();

                return Results.Ok(response);
            })
            .WithName("GetDepartments")
            .Produces<GetDepartmentsResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Get Departments")
            .WithDescription("Get Departments");
        }
    }
}