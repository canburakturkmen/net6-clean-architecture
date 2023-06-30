using AutoMapper;
using MediatR;
using TicketManagement.Application.Contracts.Persistence;
using TicketManagement.Domain.Entities;

namespace TicketManagement.Application.Features.Events.Queries.GetEventDetail
{
    public class GetEventDetailQueryHandler : IRequestHandler<GetEventDetailQuery, EventDetailVm>
    {
        private readonly IAsyncRepository<Event> _eventRepository;
        private readonly IAsyncRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;

        public GetEventDetailQueryHandler(IAsyncRepository<Event> eventRepository, IAsyncRepository<Category> categoryRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<EventDetailVm> Handle(GetEventDetailQuery request, CancellationToken cancellationToken)
        {
            var @event = await _eventRepository.GetByIdAsync(request.Id);
            var eventDetailDto = _mapper.Map<EventDetailVm>(@event);

            var category = _categoryRepository.GetByIdAsync(@event.CategoryId);

            eventDetailDto.Category = _mapper.Map<CategoryDto>(category);

            return eventDetailDto;
        }
    }
}
