using BuildingBlocks.CQRS;
using Job.Application.Data;
using Job.Domain.Models;

namespace Job.Application.Positions.Commands.CreatePosition
{
    public class CreatePositionHandler
        (IHikruDbContext dbContext)
        : ICommandHandler<CreatePositionCommand, CreatePositionResult>
    {
        public async Task<CreatePositionResult> Handle(CreatePositionCommand command, CancellationToken cancellationToken)
        {
            var positionEntity = command.Position;

            var positionModel = new Position() {
                Title = positionEntity.Title,
                Description = positionEntity.Description,
                Location = positionEntity.Location,
                Status = positionEntity.Status,
                RecruiterId = positionEntity.RecruiterId,
                DepartmentId = positionEntity.DepartmentId,
                Budget = positionEntity.Budget,
                ClosingDate = positionEntity.ClosingDate
            };

            var response = await dbContext.Positions.AddAsync(positionModel, cancellationToken);

            await dbContext.SaveChangesAsync(cancellationToken);

            return new CreatePositionResult(response.Entity.Id);
        }
    }
}