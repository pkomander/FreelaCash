using FreelaCash.Dominio.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelaCash.Dominio
{
    public class Servico
    {
        [Key]
        public int Id { get; set; }
        public string NomeCliente { get; set; }
        //public string NomeEmpresa { get; set; }
        public DateTime DataSolicitacao { get; set; }
        public string DescricaoSolicitacao { get; set; }
        public int? QtdMinutosTarefa { get; set; }
        public bool TarefaConcluida { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public int EmpresaId { get; set; }
        public Empresa? Empresa { get; set; }
    }
}
