using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DWM.Models.Entidades
{
    public class Situacao
    {
        [Key]
        [DisplayName("SituacaoID")]
        public int SituacaoID { get; set; }

        [DisplayName("Descricao")]
        public string Descricao { get; set; }

        [DisplayName("IndSituacao")]
        public string IndSituacao { get; set; }
    }
}