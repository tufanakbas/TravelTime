using DataAccessLayer.Concrete;
using TravelTime.CQRS.Commands.DestinationCommands;

namespace TravelTime.CQRS.Handlers.DestinationHandlers
{
    public class RemoveDestinationCommandHandler
    {
        private readonly Context _context;

        public RemoveDestinationCommandHandler(Context context)
        {
            _context = context;
        }

        public void Handle(RemoveDestinationCommand command)
        {
            var destID = _context.Destinations.Find(command.Id);
            _context.Destinations.Remove(destID);
            _context.SaveChanges();
        }
    }
}
