using Core.Audit.Interface;
using Core.Audit.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class Item : BaseModel, ISoftDeletedEntity
    {

        public required string Name { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public double Quantity { get; set; }
        public bool IsDeleted { get; set; } = false;

    }
}
