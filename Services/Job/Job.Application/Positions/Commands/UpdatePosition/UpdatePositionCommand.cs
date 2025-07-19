using BuildingBlocks.CQRS;
using FluentValidation;
using Job.Application.Entities;
using Job.Domain.Enums;

namespace Job.Application.Positions.Commands.UpdatePosition
{
    public record UpdatePositionCommand(PositionEntity Position) : ICommand<UpdatePositionResult>;

    public record UpdatePositionResult(bool IsUpdated);

    public class UpdatePositionCommandValidator : AbstractValidator<UpdatePositionCommand>
    {
        public UpdatePositionCommandValidator()
        {
            RuleFor(x => x.Position.Id).NotEmpty();
            RuleFor(x => x.Position.Title).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Position.Description).NotEmpty().MaximumLength(1000);
            RuleFor(x => x.Position.Location).NotEmpty();
            RuleFor(x => x.Position.Status).NotEmpty().IsEnumName(typeof(PositionStatus), caseSensitive: false);
            RuleFor(x => x.Position.RecruiterId).NotEmpty();
            RuleFor(x => x.Position.DepartmentId).NotEmpty();
            RuleFor(x => x.Position.Budget).NotEmpty();
            RuleFor(x => x.Position.ClosingDate).NotEmpty();
        }
    }
}
