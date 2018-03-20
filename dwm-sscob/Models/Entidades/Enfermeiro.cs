using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DWM.Models.Entidades
{
    [Table("Enfermeiro")]
    public class Enfermeiro
    {
        public Enfermeiro()
        {
            CobrancaEnfermeiro = new List<CobrancaEnfermeiro>();
        }

        [Key]
        [DisplayName("EnfermeiroID")]
        public int EnfermeiroID { get; set; }

        [DisplayName("CNPJ")]
        public string CNPJ { get; set; }

        [DisplayName("CPF")]
        public string CPF { get; set; }

        [DisplayName("Nome")]
        public string Nome { get; set; }

        [DisplayName("PIS")]
        public string PIS { get; set; }

        [DisplayName("IndSituacao")]
        public string IndSituacao { get; set; }

        [DisplayName("Observacao")]
        public string Observacao { get; set; }

        public virtual ICollection<CobrancaEnfermeiro> CobrancaEnfermeiro { get; set; }

        public virtual Estabelecimento Estabelecimento { get; set; }
    }
}