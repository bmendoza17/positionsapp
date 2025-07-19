using BuildingBlocks.CQRS;
using Job.Application.Data;
using Microsoft.EntityFrameworkCore;

namespace Job.Application.Positions.Commands.CreatePosition
{
    public class CreatePositionHandler
        (IHikruDbContext dbContext)
        : ICommandHandler<CreatePositionCommand, CreatePositionResult>
    {
        public async Task<CreatePositionResult> Handle(CreatePositionCommand command, CancellationToken cancellationToken)
        {
            //create Product entity from command object
            //save to database
            //return CreateProductResult result               

            //var product = new Job
            //{
            //    Name = command.Name,
            //    Category = command.Category,
            //    Description = command.Description,
            //    ImageFile = command.ImageFile,
            //    Price = command.Price
            //};

            ////save to database
            //session.Store(product);
            //await session.SaveChangesAsync(cancellationToken);

            //return result

            var respose = await dbContext.Recruiters.ToListAsync();

            return new CreatePositionResult(0);
        }
    }
}