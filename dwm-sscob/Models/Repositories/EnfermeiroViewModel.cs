using App_Dominio.Component;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DWM.Models.Repositories
{
    public class EnfermeiroViewModel : Repository
    {
        [DisplayName("EnfermeiroID")]
        public int EnfermeiroID { get; set; }

        [DisplayName("CNPJ")]
        [Required]
        [StringLength(14)]
        public string CNPJ { get; set; }

        [DisplayName("CPF")]
        [Required]
        [StringLength(11)]
        public string CPF { get; set; }

        [DisplayName("Nome")]
        [Required]
        [StringLength(40)]
        public string Nome { get; set; }

        [DisplayName("PIS")]
        [StringLength(25)]
        public string PIS { get; set; }

        [DisplayName("IndSituacao")]
        [Required]
        [StringLength(1)]
        public string IndSituacao { get; set; }
    }
}