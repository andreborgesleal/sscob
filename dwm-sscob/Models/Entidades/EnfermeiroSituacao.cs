using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DWM.Models.Entidades
{
    public class EnfermeiroSituacao
    {
        [Key, Column(Order = 0)]
        [DisplayName("EnfermeiroID")]
        public int EnfermeiroID { get; set; }

        [Key, Column(Order = 1)]
        [DisplayName("SituacaoID")]
        public int SituacaoID { get; set; }

        [Key, Column(Order = 2)]
        [DisplayName("Data")]
        public DateTime Data { get; set; }

        [DisplayName("Competencia")]
        public decimal Competencia { get; set; }

        [DisplayName("Observacao")]
        public string Observacao { get; set; }

    }
}