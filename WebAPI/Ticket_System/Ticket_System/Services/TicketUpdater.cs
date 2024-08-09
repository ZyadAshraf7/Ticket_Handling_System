using Ticket_System.Interfaces;

namespace Ticket_System.Services
{
    public class TicketUpdater : ITicketUpdater
    {
        private readonly ITicketRepository _ticketRepository;

        public TicketUpdater(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task UpdateOldTicketsAsync()
        {
            var now = DateTime.UtcNow;
            var tickets = await _ticketRepository.GetTicketsAsync(1, int.MaxValue); // Fetch all tickets

            foreach (var ticket in tickets)
            {
                if (!ticket.IsHandled && (now - ticket.CreationDateTime).TotalMinutes >= 60)
                {
                    ticket.IsHandled = true;
                    await _ticketRepository.UpdateTicketAsync(ticket);
                }
            }
        }
    }
}
