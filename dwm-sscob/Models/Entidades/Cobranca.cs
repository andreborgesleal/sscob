using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DWM.Models.Entidades
{
    public class Cobranca
    {
        [Key]
        [DisplayName("CobrancaID")]
        public int CobrancaID { get; set; }

        [DisplayName("CNPJ")]
        public string CNPJ { get; set; }

        [DisplayName("TaxaID")]
        public int TaxaID { get; set; }

        [DisplayName("DataVencimento")]
        public DateTime DataVencimento { get; set; }

        [DisplayName("ValorTotal")]
        public decimal ValorTotal { get; set; }

        [DisplayName("operacaoId")]
        public int operacaoId { get; set; }

        [DisplayName("SetorRecolhimento")]
        public string SetorRecolhimento { get; set; }
    }
}