using BuildingBlocks.CQRS;
using Job.Application.Dtos;

namespace Job.Application.Positions.Queries.GetPositions
{
    public record GetPositionsQuery()
    : IQuery<GetDepartmentsResult>;

    public record GetDepartmentsResult(List<PositionDto> Positions);
}
