using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelData.Model
{
    public class Venda : BaseEntity
    {
        [Required]
        [ForeignKey("Cliente")]
        public long Cliente_Id { get; set; }

        public virtual Cliente Cliente { get; set; }

        public decimal CashBackTotal { get; set; }

        public virtual List<VendaItem> Itens { get; set; }
    }
}
