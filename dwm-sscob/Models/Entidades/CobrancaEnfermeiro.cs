using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DWM.Models.Entidades
{
    [Table("CobrancaEnfermeiro")]
    public class CobrancaEnfermeiro
    {
        [Key, Column(Order = 0)]
        [DisplayName("CobrancaID")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CobrancaID { get; set; }

        [Key, Column(Order = 1)]
        [DisplayName("EnfermeiroID")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EnfermeiroID { get; set; }

        [DisplayName("Valor")]
        [Column(TypeName = "numeric")]
        public decimal Valor { get; set; }

        public virtual Cobranca Cobranca { get; set; }

        public virtual Enfermeiro Enfermeiro { get; set; }
    }
}