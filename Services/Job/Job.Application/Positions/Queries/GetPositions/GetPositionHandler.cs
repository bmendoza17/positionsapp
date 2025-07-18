using BuildingBlocks.CQRS;
using Job.Application.Data;
using Job.Application.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Job.Application.Positions.Queries.GetPositions
{
    public class GetPositionsHandler(IHikruDbContext hikruDbContext) : IQueryHandler<GetPositionsQuery, GetPositionsResult>
    {
        public async Task<GetPositionsResult> Handle(GetPositionsQuery query, CancellationToken cancellationToken)
        {
            var positions = await hikruDbContext.Positions
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            if (positions == null || positions.Count == 0)
            {
                return new GetPositionsResult([]);
            }

            return new GetPositionsResult([.. positions.ToPositionDtoList()]);
        }
    }
}
