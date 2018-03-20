using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DWM.Models.Entidades
{
    [Table("TaxaSindical")]
    public class TaxaSindical
    {
        public TaxaSindical()
        {
            Cobranca = new List<Cobranca>();
        }

        [Key]
        [DisplayName("TaxaID")]
        public int TaxaID { get; set; }

        [DisplayName("Descricao")]
        public string Descricao { get; set; }

        [DisplayName("TipoEstabelecimento")]
        public string TipoEstabelecimento { get; set; }

        [DisplayName("DiaVencimento")]
        public int DiaVencimento { get; set; }

        [DisplayName("AnoMes")]
        [Column(TypeName = "numeric")]
        public decimal AnoMes { get; set; }

        [DisplayName("Valor")]
        [Column(TypeName = "numeric")]
        public decimal Valor { get; set; }

        [DisplayName("DiaProcessamento")]
        public int DiaProcessamento { get; set; }

        public virtual ICollection<Cobranca> Cobranca { get; set; }
    }
}