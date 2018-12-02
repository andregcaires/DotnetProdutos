using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Swfast.Domain.Models
{
    public class Categoria : Entity
    {
        [Required]
        public string Nome { get; set; }

        public List<Produto> Produtos { get; set; }
    }
}
