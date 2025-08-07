using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace TicketService.Domain.Entities
{
    [Table("Comments")]
    public class Comment
    {
        [Key]        
        public int CommentID { get; set; }
        [ForeignKey("Ticket")]
        public int TicketID { get; set; }
        [StringLength(500)]
        public string? Message { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        //Navigation back to the Ticket
        public Ticket Ticket { get; set; }
    }
}
