using AutoMapper;
using MediatR;
using TicketManagement.Application.Contracts.Persistence;
using TicketManagement.Domain.Entities;

namespace TicketManagement.Application.Features.Events.Commands.UpdateEvent
{
    public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand, Unit>
    {
        private readonly IAsyncRepository<Event> _eventRepository;
        private readonly IMapper _mapper;

        public UpdateEventCommandHandler(IAsyncRepository<Event> eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            var eventToUpdate = await _eventRepository.GetByIdAsync(request.EventId);

            _mapper.Map(request, eventToUpdate, typeof(UpdateEventCommand), typeof(Event));
            await _eventRepository.UpdateAsync(eventToUpdate);

            return Unit.Value;
        }
    }
}
