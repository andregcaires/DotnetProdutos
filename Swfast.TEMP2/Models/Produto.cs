using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Swfast.TEMP2.Models
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public double Preco { get; set; }

        [Required]
        public int CategoriaId { get; set; }

        public virtual Categoria Categoria { get; set; }
    }
}
