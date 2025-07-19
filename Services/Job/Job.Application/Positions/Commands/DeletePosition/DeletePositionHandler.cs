using BuildingBlocks.CQRS;
using Job.Application.Data;
using Job.Application.Exceptions;

namespace Job.Application.Positions.Commands.DeletePosition
{
    public class DeletePositionHandler(IHikruDbContext dbContext) : ICommandHandler<DeletePositionCommand, DeletePositionResult>
    {
        public async Task<DeletePositionResult> Handle(DeletePositionCommand command, CancellationToken cancellationToken)
        {
            var positionId = command.PositionId;

            var position = await dbContext.Positions
                .FindAsync(positionId, cancellationToken) ?? throw new PositionNotFoundException(positionId);

            dbContext.Positions.Remove(position);
            await dbContext.SaveChangesAsync(cancellationToken);

            return new DeletePositionResult(true);
        }
    }
}
