using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Swfast.Domain.Models
{
    public class Produto : Entity
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        public double Preco { get; set; }

        public int CategoriaId { get; set; }

        public virtual Categoria Categoria { get; set; }
    }
}
