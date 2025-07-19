using BuildingBlocks.CQRS;
using FluentValidation;
using Job.Application.Dtos;
using Job.Domain.Enums;
using MediatR;

namespace Job.Application.Positions.Commands.CreatePosition
{
    public record CreatePositionCommand(PositionDto Position) : ICommand<CreatePositionResult>;

    public record CreatePositionResult(int Id);

    public class CreatePositionCommandValidator : AbstractValidator<CreatePositionCommand>
    {
        public CreatePositionCommandValidator()
        {
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
