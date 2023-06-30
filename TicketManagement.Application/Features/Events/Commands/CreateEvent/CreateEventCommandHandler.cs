using AutoMapper;
using MediatR;
using TicketManagement.Application.Contracts.Infrastructure;
using TicketManagement.Application.Contracts.Persistence;
using TicketManagement.Application.Exceptions;
using TicketManagement.Application.Models.Mail;
using TicketManagement.Domain.Entities;

namespace TicketManagement.Application.Features.Events.Commands.CreateEvent
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, Guid>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public CreateEventCommandHandler(IEventRepository eventRepository, IMapper mapper, IEmailService emailService)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
            _emailService = emailService;
        }

        public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var @event = _mapper.Map<Event>(request);

            var validator = new CreateEventCommandValidator(_eventRepository);
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            @event = await _eventRepository.AddAsync(@event);

            //Sending email notification to admin address
            var email = new Email()
            {
                To = "ticketManagement.eu",
                Body = $"A new event was created: {request}",
                Subject = "A new Event was created"
            };

            try
            {
                await _emailService.SendEmail(email);
            }
            catch (Exception ex)
            {
                // this shouldn't stop the API from doing else so this can be logged
            }

            return @event.EventId;
        }
    }
}
