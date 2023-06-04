using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP_NET_and_Databases_Infastructure.Model
{
    [Comment("Product note table")]
    public class ProductNote
    {
        [Comment("Product note Id")]
        [Key]
        public int Id { get; set; }

        [Comment("Product note text")]
        [MaxLength(500)]
        [Required]
        public string Note { get; set; } = null!;

        [Comment("Product note date")]
        [Required]
        public DateTime NoteDate { get; set; }

        [Comment("Product note product Id")]
        [Required]
        public int ProductId { get; set; }

        [Comment("Product note product")]
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; } = null!;
    }
}
