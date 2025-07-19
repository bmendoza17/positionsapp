using BuildingBlocks.CQRS;
using FluentValidation;

namespace Job.Application.Positions.Commands.DeletePosition
{
    public record DeletePositionCommand(int PositionId) : ICommand<DeletePositionResult>;

    public record DeletePositionResult(bool IsDeleted);

    internal class DeletePositionCommandValidator : AbstractValidator<DeletePositionCommand>
    {
        public DeletePositionCommandValidator()
        {
            RuleFor(x => x.PositionId)
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
