using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Ticket_System.Data;
using Ticket_System.DTO;
using Ticket_System.Interfaces;
using Ticket_System.Models;

namespace Ticket_System.Repository
{
    public class TicketRepository : ITicketRepository
    {
        private readonly DataContext _context;

        public TicketRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Ticket>> GetTicketsAsync(int page, int pageSize)
        {
            return await _context.Ticket
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<Ticket> GetTicketByIdAsync(int id)
        {
            return await _context.Ticket.FindAsync(id);
        }

        public async Task<Ticket> AddTicketAsync(TicketDTO ticketDTO)
        {
            Ticket ticket = new Ticket { City = ticketDTO.City, District = ticketDTO.District, Governorate = ticketDTO.Governorate, PhoneNumber = ticketDTO.PhoneNumber,CreationDateTime = ticketDTO.CreationDateTime,IsHandled = ticketDTO.IsHandled };
            _context.Ticket.Add(ticket);
            await _context.SaveChangesAsync();
            return ticket;
        }

        public async Task UpdateTicketAsync(Ticket ticket)
        {
            _context.Ticket.Update(ticket);
            await _context.SaveChangesAsync();
        }

        public async Task<int> GetTicketsSizeAsync()
        {
            var tickets = await _context.Ticket.ToListAsync();
            return tickets.Count;
        }

        /*public async Task DeleteTicketAsync(int id)
        {
            var ticket = await _context.Ticket.FindAsync(id);
            if (ticket != null)
            {
                _context.Ticket.Remove(ticket);
                await _context.SaveChangesAsync();
            }
        }*/
    }
}
