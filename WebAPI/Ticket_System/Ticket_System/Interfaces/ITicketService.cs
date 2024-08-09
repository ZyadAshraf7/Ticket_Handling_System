using Ticket_System.DTO;
using Ticket_System.Models;

namespace Ticket_System.Interfaces
{
    public interface ITicketService
    {
        Task<IEnumerable<Ticket>> GetTicketsAsync(int page, int pageSize);
        Task<int> GetTicketsSizeAsync();
        Task<Ticket> CreateTicketAsync(TicketDTO ticket);
        Task HandleTicketAsync(int id);
    }
}
