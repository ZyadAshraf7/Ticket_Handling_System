using System.ComponentModel.DataAnnotations;

namespace Ticket_System.DTO
{
    public class TicketDTO
    {
        [Required]
        public DateTime CreationDateTime { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        public string Governorate { get; set; } = string.Empty;

        [Required]
        public string City { get; set; } = string.Empty;

        [Required]
        public string District { get; set; } = string.Empty;

        public bool IsHandled { get; set; }
    }
}
