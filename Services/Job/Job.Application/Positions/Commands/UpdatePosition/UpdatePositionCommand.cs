using BuildingBlocks.CQRS;
using FluentValidation;
using Job.Application.Entities;
using Job.Domain.Enums;

namespace Job.Application.Positions.Commands.UpdatePosition
{
    public record UpdatePositionCommand(int PositionId, PositionUpdateEntity Position) : ICommand<UpdatePositionResult>;

    public record UpdatePositionResult(bool IsUpdated);

    public class UpdatePositionCommandValidator : AbstractValidator<UpdatePositionCommand>
    {
        public UpdatePositionCommandValidator()
        {
            RuleFor(x => x.Position.Title).MaximumLength(100);
            RuleFor(x => x.Position.Description).MaximumLength(1000);
            RuleFor(x => x.Position.Status).IsEnumName(typeof(PositionStatus), caseSensitive: false);
        }
    }
}
