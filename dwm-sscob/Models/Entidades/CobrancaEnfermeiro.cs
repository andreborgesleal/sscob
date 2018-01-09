using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DWM.Models.Entidades
{
    public class CobrancaEnfermeiro
    {
        [Key, Column(Order = 0)]
        [DisplayName("CobrancaID")]
        public int CobrancaID { get; set; }

        [Key, Column(Order = 1)]
        [DisplayName("EnfermeiroID")]
        public int EnfermeiroID { get; set; }

        [DisplayName("Valor")]
        public decimal Valor { get; set; }
    }
}