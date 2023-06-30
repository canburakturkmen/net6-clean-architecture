using TicketManagement.Application.Features.Events.Queries.GetEventsExport;
using System.Collections.Generic;

namespace TicketManagement.Application.Contracts.Infrastructure
{
    public interface ICsvExporter
    {
        byte[] ExportEventsToCsv(List<EventExportDto> eventExportDtos);
    }
}
