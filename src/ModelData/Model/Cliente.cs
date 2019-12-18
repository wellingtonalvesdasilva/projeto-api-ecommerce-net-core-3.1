using System.ComponentModel.DataAnnotations;

namespace ModelData.Model
{
    public class Cliente : BaseEntity
    {
        [StringLength(400)]
        public string Nome { get; set; }
    }
}
