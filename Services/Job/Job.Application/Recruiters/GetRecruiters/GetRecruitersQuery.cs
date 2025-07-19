using BuildingBlocks.CQRS;
using Job.Application.Dtos;

namespace Job.Application.Recruiters.GetRecruiters
{
    public record GetRecruitersQuery()
    : IQuery<GetRecruitersResult>;

    public record GetRecruitersResult(List<RecruiterDto> Recruiters);
}
