using App_Dominio.Component;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DWM.Models.Repositories
{
    public class SituacaoViewModel : Repository
    {
        [DisplayName("SituacaoID")]
        public int SituacaoID { get; set; }

        [DisplayName("Descricao")]
        [Required]
        [StringLength(20)]
        public string Descricao { get; set; }

        [DisplayName("IndSituacao")]
        [Required]
        [StringLength(1)]
        public string IndSituacao { get; set; }

    }
}