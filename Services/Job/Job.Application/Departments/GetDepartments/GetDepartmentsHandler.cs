using BuildingBlocks.CQRS;
using Job.Application.Data;
using Job.Application.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Job.Application.Departments.GetDepartments
{
    public class GetDepartmentsHandler(IHikruDbContext hikruDbContext) : IQueryHandler<GetDepartmentsQuery, GetDepartmentsResult>
    {
        public async Task<GetDepartmentsResult> Handle(GetDepartmentsQuery query, CancellationToken cancellationToken)
        {
            var departments = await hikruDbContext.Departments
                .AsNoTracking()
                .Select(a => new DepartmentDto(a.Id, a.Name, a.Description))
                .ToListAsync(cancellationToken);

            if (departments == null || departments.Count == 0)
            {
                return new GetDepartmentsResult([]);
            }

            return new GetDepartmentsResult(departments);
        }
    }
}
