using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelaCash.Repository.Dto
{
    public class EmpresaDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo {0} e obrigatorio.")]
        [MinLength(3, ErrorMessage = "{0} deve ter no minimo 4 caracteres.")]
        [MaxLength(100, ErrorMessage = "{0} deve ter no maximo 100 caracteres.")]
        public string Nome { get; set; }
    }
}
