using Ticket_System.Interfaces;
using Ticket_System.Repository;

namespace Ticket_System.Services
{
    public class TicketBackgroundService : BackgroundService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly ILogger<TicketBackgroundService> _logger;

        public TicketBackgroundService(ILogger<TicketBackgroundService> logger, IServiceScopeFactory serviceScopeFactory)
        {
            _logger = logger;
            _serviceScopeFactory = serviceScopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using (var scope = _serviceScopeFactory.CreateScope())
                    {
                        var ticketRepository = scope.ServiceProvider.GetRequiredService<ITicketRepository>();
                        var now = DateTime.Now;
                        var tickets = await ticketRepository.GetTicketsAsync(1, int.MaxValue); // Fetch all tickets

                        foreach (var ticket in tickets)
                        {
                            if (!ticket.IsHandled && (now - ticket.CreationDateTime).TotalMinutes >= 60)
                            {
                                ticket.IsHandled = true;
                                await ticketRepository.UpdateTicketAsync(ticket);
                                _logger.LogInformation($"Ticket {ticket.Id} has been automatically handled.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An error occurred while updating tickets.");
                }

                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken); // Check every minute
            }
        }
    }
}
