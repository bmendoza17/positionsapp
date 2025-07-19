using BuildingBlocks.CQRS;
using Job.Application.Data;
using Job.Application.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Job.Application.Recruiters.GetRecruiters
{
    public class GetRecruitersHandler(IHikruDbContext hikruDbContext) : IQueryHandler<GetRecruitersQuery, GetRecruitersResult>
    {
        public async Task<GetRecruitersResult> Handle(GetRecruitersQuery query, CancellationToken cancellationToken)
        {
            var positions = await hikruDbContext.Recruiters
                .AsNoTracking()
                .Select(a => new RecruiterDto(a.Id, a.Name, a.Email))
                .ToListAsync(cancellationToken);

            if (positions == null || positions.Count == 0)
            {
                return new GetRecruitersResult([]);
            }

            return new GetRecruitersResult(positions);
        }
    }
}
