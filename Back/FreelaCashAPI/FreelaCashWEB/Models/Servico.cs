using FreelaCash.Dominio.Identity;
using System.ComponentModel;

namespace FreelaCashWEB.Models
{
    public class Servico
    {
        public int Id { get; set; }
        [DisplayName("Nome Cliente")]
        public string NomeCliente { get; set; }
        [DisplayName("Data de Solic...")]
        public DateTime DataSolicitacao { get; set; }
        [DisplayName("Descricao Solic...")]
        public string DescricaoSolicitacao { get; set; }
        [DisplayName("Quantidade Minutos")]
        public int? QtdMinutosTarefa { get; set; }
        [DisplayName("Tarefa concluida")]
        public bool TarefaConcluida { get; set; }
        [DisplayName("Usuario")]
        public int UserId { get; set; }
        public User? User { get; set; }
        [DisplayName("Empresa")]
        public int EmpresaId { get; set; }
        public Empresa? Empresa { get; set; }
    }
}
