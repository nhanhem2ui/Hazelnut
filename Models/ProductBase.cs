using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Hazelnut.Models
{
    public abstract class ProductBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string? ImagePath { get; set; }
    }
}
