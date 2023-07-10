using FreelaCash.Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelaCash.Repository.Dto
{
    public class ServicoDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo {0} e obrigatorio.")]
        [MinLength(3, ErrorMessage = "{0} deve ter no minimo 4 caracteres.")]
        [MaxLength(100, ErrorMessage = "{0} deve ter no maximo 100 caracteres.")]
        public string NomeCliente { get; set; }
        //[Required(ErrorMessage = "O campo {0} e obrigatorio.")]
        //[MinLength(3, ErrorMessage = "{0} deve ter no minimo 4 caracteres.")]
        //[MaxLength(100, ErrorMessage = "{0} deve ter no maximo 100 caracteres.")]
        //public string NomeEmpresa { get; set; }
        [Required(ErrorMessage = "O campo {0} e obrigatorio.")]
        public DateTime DataSolicitacao { get; set; }
        [Required(ErrorMessage = "O campo {0} e obrigatorio.")]
        public string DescricaoSolicitacao { get; set; }
        public int? QtdMinutosTarefa { get; set; }
        public bool TarefaConcluida { get; set; }
        public int? UserId { get; set; }
        public int EmpresaId { get; set; }
        public EmpresaDto? Empresa { get; set; }
    }
}
