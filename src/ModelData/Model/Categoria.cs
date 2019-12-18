using System.ComponentModel.DataAnnotations;

namespace ModelData.Model
{
    public class Categoria : BaseEntity
    {     
        [StringLength(400)]
        [Required]
        public string Nome { get; set; }

        [StringLength(1000)]
        [Required]
        public string ImagemURL { get; set; }
    }
}
