using BuildingBlocks.CQRS;
using Job.Application.Dtos;

namespace Job.Application.Positions.Queries.GetPositions
{
    public record GetPositionsQuery()
    : IQuery<GetPositionsResult>;

    public record GetPositionsResult(List<PositionDto> Positions);
}
