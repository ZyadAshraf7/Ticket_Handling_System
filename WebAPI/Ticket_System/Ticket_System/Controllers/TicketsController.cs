using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ticket_System.DTO;
using Ticket_System.Interfaces;
using Ticket_System.Models;
using Ticket_System.Repository;

namespace Ticket_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketsController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpGet]
        [Route("GetTickets")]
        public async Task<IActionResult> GetTickets([FromQuery] int page = 1, [FromQuery] int pageSize = 5)
        {
            try
            {

                var tickets = await _ticketService.GetTicketsAsync(page, pageSize);
                return Ok(tickets);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("GetTicketsSize")]
        public async Task<IActionResult> GetTicketsSize()
        {
            try
            {
                var ticketsSize = await _ticketService.GetTicketsSizeAsync();
                return Ok(ticketsSize);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("CreateTicket")]
        public async Task<IActionResult> CreateTicket([FromBody] TicketDTO ticket)
        {
            try
            {
                var createdTicket = await _ticketService.CreateTicketAsync(ticket);
                return CreatedAtAction(nameof(GetTickets), new { id = createdTicket.Id }, createdTicket);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }

        [HttpPost("{id}/handle")]
        public async Task<IActionResult> HandleTicket(int id)
        {
            try
            {
                await _ticketService.HandleTicketAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
