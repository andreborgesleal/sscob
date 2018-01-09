using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DWM.Models.Entidades
{
    public class Enfermeiro
    {
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
    }
}