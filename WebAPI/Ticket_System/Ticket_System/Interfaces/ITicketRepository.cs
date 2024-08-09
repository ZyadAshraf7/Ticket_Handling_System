using Ticket_System.DTO;
using Ticket_System.Models;

namespace Ticket_System.Interfaces
{
    public interface ITicketRepository
    {
        Task<IEnumerable<Ticket>> GetTicketsAsync(int page, int pageSize);
        Task<int> GetTicketsSizeAsync();
        Task<Ticket> GetTicketByIdAsync(int id);
        Task<Ticket> AddTicketAsync(TicketDTO ticket);
        Task UpdateTicketAsync(Ticket ticket);
        //Task DeleteTicketAsync(int id);
    }
}
