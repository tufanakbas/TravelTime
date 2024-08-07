﻿using DataAccessLayer.Concrete;
using TravelTime.CQRS.Commands.DestinationCommands;

namespace TravelTime.CQRS.Handlers.DestinationHandlers
{
    public class UpdateDestinationCommandHandler
    {
        private readonly Context _context;

        public UpdateDestinationCommandHandler(Context context)
        {
            _context = context;
        }
        public void Handle(UpdateDestinationCommand command)
        {
            var destID = _context.Destinations.Find(command.DestinationID);
            destID.City = command.City;
            destID.DayNight = command.DayNight;
            destID.Price = command.Price;
            destID.Status = true;
            _context.SaveChanges();
        }
    }
}
