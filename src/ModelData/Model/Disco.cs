using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelData.Model
{
    public class Disco : BaseEntity
    {
        [StringLength(400)]
        [Required]
        public string Nome { get; set; }

        [Required]
        public decimal Preco { get; set; }

        [Required]
        [ForeignKey("Categoria")]
        public long Categoria_Id { get; set; }

        public virtual Categoria Categoria { get; set; }
    }
}
