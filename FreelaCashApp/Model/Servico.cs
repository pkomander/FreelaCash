using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelaCashApp.Model
{
    public class Servico
    {
        public int Id { get; set; }
        public string NomeCliente { get; set; }
        public DateTime DataSolicitacao { get; set; }
        public string DescricaoSolicitacao { get; set; }
        public int? QtdMinutosTarefa { get; set; }
        public bool TarefaConcluida { get; set; }
        public int? UserId { get; set; }
        public int EmpresaId { get; set; }
    }
}
