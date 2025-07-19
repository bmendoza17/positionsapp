using BuildingBlocks.CQRS;
using Job.Application.Dtos;

namespace Job.Application.Positions.Queries.GetPositionById
{
    public record GetPositionByIdQuery(int Id)
        : IQuery<GetPositionByIdResult>;

    public record GetPositionByIdResult(PositionDto Position);
}