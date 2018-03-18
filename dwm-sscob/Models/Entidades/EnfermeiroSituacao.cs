using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DWM.Models.Entidades
{
    [Table("EnfermeiroSituacao")]
    public class EnfermeiroSituacao
    {
        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("EnfermeiroID")]
        public int EnfermeiroID { get; set; }

        [Key, Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("SituacaoID")]
        public int SituacaoID { get; set; }

        [Key, Column(Order = 2)]
        [DisplayName("Data")]
        public DateTime Data { get; set; }

        [DisplayName("Competencia")]
        [Column(TypeName = "numeric")]
        public decimal Competencia { get; set; }

        [DisplayName("Observacao")]
        public string Observacao { get; set; }

        public virtual Enfermeiro Enfermeiro { get; set; }

        public virtual Situacao Situacao { get; set; }
    }
}