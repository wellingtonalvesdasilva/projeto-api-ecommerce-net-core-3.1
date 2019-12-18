using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelData.Model
{
    public class VendaItem : BaseEntity
    {
        [Required]
        [ForeignKey("Venda")]
        public long Venda_Id { get; set; }

        public virtual Venda Venda { get; set; }

        [Required]
        [ForeignKey("Disco")]
        public long Disco_Id { get; set; }

        public virtual Disco Disco { get; set; }

        public decimal PrecoUnitario { get; set; }

        public int Quantidade { get; set; }

        public decimal CashBackUnitario { get; set; }
    }
}
