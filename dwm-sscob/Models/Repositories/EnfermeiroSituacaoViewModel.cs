using App_Dominio.Component;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace dwm_sscob.Models.Repositories
{
    public class EnfermeiroSituacaoViewModel : Repository
    {
        [DisplayName("EnfermeiroID")]
        public int EnfermeiroID { get; set; }

        [DisplayName("SituacaoID")]
        public int SituacaoID { get; set; }

        [DisplayName("Data")]
        public DateTime Data { get; set; }

        [DisplayName("Competencia")]
        public decimal Competencia { get; set; }

        [DisplayName("Observacao")]
        public string Observacao { get; set; }
    }
}