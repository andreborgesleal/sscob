﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DWM.Models.Entidades
{
    public class Situacao
    {
        public Situacao()
        {
            EnfermeiroSituacao = new HashSet<EnfermeiroSituacao>();
        }

        [Key]
        [DisplayName("SituacaoID")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SituacaoID { get; set; }

        [DisplayName("Descricao")]
        public string Descricao { get; set; }

        [DisplayName("IndSituacao")]
        public string IndSituacao { get; set; }

        public virtual ICollection<EnfermeiroSituacao> EnfermeiroSituacao { get; set; }
    }
}