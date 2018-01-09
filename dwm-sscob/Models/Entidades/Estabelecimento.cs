using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DWM.Models.Entidades
{
    public class Estabelecimento
    {
        [Key]
        [DisplayName("CNPJ")]
        public string CNPJ { get; set; }

        [DisplayName("Nome")]
        public string Nome { get; set; }

        [DisplayName("TipoEstabelecimento")]
        public string TipoEstabelecimento { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }

        [DisplayName("SetorRecolhimento")]
        public string SetorRecolhimento { get; set; }
    }
}