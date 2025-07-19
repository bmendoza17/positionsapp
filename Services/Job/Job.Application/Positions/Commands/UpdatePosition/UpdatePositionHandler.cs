using BuildingBlocks.CQRS;
using Job.Application.Data;
using Job.Application.Exceptions;

namespace Job.Application.Positions.Commands.UpdatePosition
{
    public class UpdatePositionHandler(IHikruDbContext dbContext) : ICommandHandler<UpdatePositionCommand, UpdatePositionResult>
    {
        public async Task<UpdatePositionResult> Handle(UpdatePositionCommand command, CancellationToken cancellationToken)
        {
            var positionToUpdate = await dbContext.Positions
                .FindAsync([command.PositionId], cancellationToken)
                ?? throw new PositionNotFoundException(command.PositionId);

            var positionEntity = command.Position;

            positionToUpdate.Title = positionEntity.Title ?? positionToUpdate.Title;
            positionToUpdate.Description = positionEntity.Description ?? positionToUpdate.Description;
            positionToUpdate.Location = positionEntity.Location ?? positionToUpdate.Location;
            positionToUpdate.Status = positionEntity.Status ?? positionToUpdate.Status;
            positionToUpdate.RecruiterId = positionEntity.RecruiterId ?? positionToUpdate.RecruiterId;
            positionToUpdate.DepartmentId = positionEntity.DepartmentId ?? positionToUpdate.DepartmentId;
            positionToUpdate.Budget = positionEntity.Budget ?? positionToUpdate.Budget;
            positionToUpdate.ClosingDate = positionEntity.ClosingDate ?? positionToUpdate.ClosingDate;

            await dbContext.SaveChangesAsync(cancellationToken);

            return new UpdatePositionResult(true);
        }
    }
}
