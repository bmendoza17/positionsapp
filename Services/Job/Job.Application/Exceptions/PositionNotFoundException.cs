using BuildingBlocks.Exceptions;

namespace Job.Application.Exceptions
{
    internal class PositionNotFoundException(int id) : NotFoundException("Position", id)
    {
    }
}
