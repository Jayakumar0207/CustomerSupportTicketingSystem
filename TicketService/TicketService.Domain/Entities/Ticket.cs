using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketService.Domain.Entities
{
    [Table("Tickets")]
    public class Ticket
    {
        [Key]
        public int TicketId { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        [Required]
        [StringLength(1000)]
        public string Description { get; set; }
        public TicketStatus Status { get; set; } // Open, In Progress, Resolved
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        //Navigation property for related comments
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();

    }
    public enum TicketStatus
    {
        Open = 0,
        InProgress = 1,
        Closed = 2,
        Cancelled = 3
    }
}
