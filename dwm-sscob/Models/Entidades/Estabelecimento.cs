using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DWM.Models.Entidades
{
    [Table("Estabelecimento")]
    public class Estabelecimento
    {
        public Estabelecimento()
        {
            Cobranca = new List<Cobranca>();
            Enfermeiro = new List<Enfermeiro>();
        }

        [Key]
        [DisplayName("CNPJ")]
        [StringLength(14)]
        public string CNPJ { get; set; }

        [DisplayName("Nome")]
        [StringLength(80)]
        public string Nome { get; set; }

        [DisplayName("TipoEstabelecimento")]
        [StringLength(1)]
        public string TipoEstabelecimento { get; set; }

        [DisplayName("Email")]
        [StringLength(100)]
        public string Email { get; set; }

        [DisplayName("SetorRecolhimento")]
        [StringLength(40)]
        public string SetorRecolhimento { get; set; }

        public virtual ICollection<Cobranca> Cobranca { get; set; }

        public virtual ICollection<Enfermeiro> Enfermeiro { get; set; }
    }
}