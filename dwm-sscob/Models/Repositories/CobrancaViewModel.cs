using App_Dominio.Component;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DWM.Models.Repositories
{
    public class CobrancaViewModel : Repository
    {
        [DisplayName("CobrancaID")]
        public int CobrancaID { get; set; }

        [DisplayName("CNPJ")]
        [Required(ErrorMessage = "Informe o CNPJ")]
        [StringLength(14)]
        public string CNPJ { get; set; }

        [DisplayName("TaxaID")]
        [Required(ErrorMessage = "Informe a Taxa")]
        public int TaxaID { get; set; }

        [DisplayName("Data de Vencimento")]
        [Required(ErrorMessage = "Informe a Data de Vencimento")]
        public DateTime DataVencimento { get; set; }

        [DisplayName("Valor Total")]
        [Required(ErrorMessage = "Informe o Valor Total")]
        public decimal ValorTotal { get; set; }

        [DisplayName("operacaoId")]
        public int operacaoId { get; set; }

        [DisplayName("SetorRecolhimento")]
        [StringLength(40)]
        public string SetorRecolhimento { get; set; }

    }
}