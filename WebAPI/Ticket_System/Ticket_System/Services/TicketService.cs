using Ticket_System.DTO;
using Ticket_System.Interfaces;
using Ticket_System.Models;

namespace Ticket_System.Services
{
    public class TicketService:ITicketService
    {
        private readonly ITicketRepository _ticketRepository;

        public TicketService(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task<IEnumerable<Ticket>> GetTicketsAsync(int page, int pageSize)
        {
            return await _ticketRepository.GetTicketsAsync(page, pageSize);
        }

        public async Task<Ticket> CreateTicketAsync(TicketDTO ticket)
        {
            ticket.CreationDateTime = DateTime.Now;
            ticket.IsHandled = false;
            return await _ticketRepository.AddTicketAsync(ticket);
        }

        public async Task HandleTicketAsync(int id)
        {
            var ticket = await _ticketRepository.GetTicketByIdAsync(id);
            if (ticket != null)
            {
                ticket.IsHandled = true;
                await _ticketRepository.UpdateTicketAsync(ticket);
            }
        }

        public async Task<int> GetTicketsSizeAsync()
        {
            return await _ticketRepository.GetTicketsSizeAsync();
        }
    }
}
