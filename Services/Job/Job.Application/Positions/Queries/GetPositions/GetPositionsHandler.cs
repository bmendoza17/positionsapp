using BuildingBlocks.CQRS;
using Job.Application.Data;
using Job.Application.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Job.Application.Positions.Queries.GetPositions
{
    public class GetPositionsHandler(IHikruDbContext hikruDbContext) : IQueryHandler<GetPositionsQuery, GetDepartmentsResult>
    {
        public async Task<GetDepartmentsResult> Handle(GetPositionsQuery query, CancellationToken cancellationToken)
        {
            var positions = await hikruDbContext.Positions
                .AsNoTracking()
                .Include(p => p.Department)
                .Include(p => p.Recruiter)
                .Select(a => new PositionDto(a.Id, a.Title, a.Description, a.Location, a.Status, a.Recruiter.Name, a.Department.Name, a.Budget, a.ClosingDate))
                .ToListAsync(cancellationToken);

            if (positions == null || positions.Count == 0)
            {
                return new GetDepartmentsResult([]);
            }

            return new GetDepartmentsResult(positions);
        }
    }
}
