using BuildingBlocks.CQRS;
using Job.Application.Data;
using Job.Application.Dtos;
using Job.Application.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Job.Application.Positions.Queries.GetPositionById
{
    public class GetPositionByIdHandler(IHikruDbContext dbContext)
        : IQueryHandler<GetPositionByIdQuery, GetPositionByIdResult>
    {
        public async Task<GetPositionByIdResult> Handle(GetPositionByIdQuery query, CancellationToken cancellationToken)
        {
            var position = await dbContext.Positions
                    .AsNoTracking()
                    .Where(p => p.Id == query.Id)
                    .Include(p => p.Department)
                    .Include(p => p.Recruiter)
                    .Select(a => new PositionDto(a.Id, a.Title, a.Description, a.Location, a.Status, a.Recruiter.Name, a.Department.Name, a.Budget, a.ClosingDate))
                    .FirstOrDefaultAsync(cancellationToken);

            if (position == null)
            {
                throw new PositionNotFoundException(query.Id);
            }

            return new GetPositionByIdResult(position);
        }
    }
}