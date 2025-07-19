using BuildingBlocks.CQRS;
using Job.Application.Dtos;

namespace Job.Application.Departments.GetDepartments
{
    public record GetDepartmentsQuery()
    : IQuery<GetDepartmentsResult>;

    public record GetDepartmentsResult(List<DepartmentDto> Departments);
}
