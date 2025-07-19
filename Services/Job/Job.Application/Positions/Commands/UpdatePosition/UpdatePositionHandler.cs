using BuildingBlocks.CQRS;
using Job.Application.Data;
using Job.Application.Entities;
using Job.Application.Exceptions;
using Job.Application.Positions.Commands.CreatePosition;
using Job.Domain.Models;

namespace Job.Application.Positions.Commands.UpdatePosition
{
    public class UpdatePositionHandler(IHikruDbContext dbContext) : ICommandHandler<UpdatePositionCommand, UpdatePositionResult>
    {
        public async Task<UpdatePositionResult> Handle(UpdatePositionCommand command, CancellationToken cancellationToken)
        {
            var positionId = command.Position.Id;

            var position = await dbContext.Positions
                .FindAsync(positionId, cancellationToken) ?? throw new PositionNotFoundException(positionId ?? -1);

            var positionEntity = command.Position;

            position.Title = positionEntity.Title;
            position.Description = positionEntity.Description;
            position.Location = positionEntity.Location;
            position.Status = positionEntity.Status;
            position.RecruiterId = positionEntity.RecruiterId;
            position.DepartmentId = positionEntity.DepartmentId;
            position.Budget = positionEntity.Budget;
            position.ClosingDate = positionEntity.ClosingDate;

            //var response = dbContext.Positions.Update(position);

            await dbContext.SaveChangesAsync(cancellationToken);

            return new UpdatePositionResult(true);
        }
    }
}
