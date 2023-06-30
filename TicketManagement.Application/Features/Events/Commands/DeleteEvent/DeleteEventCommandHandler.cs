using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagement.Application.Contracts.Persistence;
using TicketManagement.Domain.Entities;

namespace TicketManagement.Application.Features.Events.Commands.DeleteEvent
{
    public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand, Unit>
    {
        private readonly IAsyncRepository<Event> _eventRepository;

        public DeleteEventCommandHandler(IAsyncRepository<Event> eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<Unit> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {
            var eventToDelete = await _eventRepository.GetByIdAsync(request.EventId);

            await _eventRepository.DeleteAsync(eventToDelete);

            return Unit.Value;
        }
    }
}
