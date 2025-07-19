using Job.Application.Dtos;
using Job.Domain.Models;

namespace Job.Application.Extensions
{
    public static class PositionExtensions
    {
        public static IEnumerable<PositionDto> ToPositionDtoList(this IEnumerable<Position> positions)
        {
            return positions.Select(position =>
            new PositionDto(
                position.Id,
                position.Title,
                position.Description,
                position.Location,
                position.Status,
                position.RecruiterId,
                position.DepartmentId,
                position.Budget,
                position.ClosingDate
            ));
        }
    }
}
