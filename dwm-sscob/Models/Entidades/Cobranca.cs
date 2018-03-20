using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DWM.Models.Entidades
{
    [Table("Cobranca")]
    public class Cobranca
    {
        public Cobranca()
        {
            CobrancaEnfermeiro = new List<CobrancaEnfermeiro>();
        }

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

        public virtual Estabelecimento Estabelecimento { get; set; }

        public virtual TaxaSindical TaxaSindical { get; set; }

        public virtual ICollection<CobrancaEnfermeiro> CobrancaEnfermeiro { get; set; }
    }
}