using System.ComponentModel.DataAnnotations.Schema;

namespace LeadManager.Domain.Entities
{
    public class Lead
    {
        public int Id { get; set; }

        [ForeignKey("Contact")]
        public int ContactId { get; set; }
        public string Suburb { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        [Column("created_at")]
        public DateTime DateCreated { get; set; }

        public Contact Contact { get; set; }
    }
}
