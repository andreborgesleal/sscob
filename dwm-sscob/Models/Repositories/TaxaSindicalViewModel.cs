﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DWM.Models.Repositories
{
    public class TaxaSindicalViewModel
    {
        [DisplayName("TaxaID")]
        public int TaxaID { get; set; }

        [DisplayName("Descricao")]
        [Required]
        [StringLength(35)]
        public string Descricao { get; set; }

        [DisplayName("TipoEstabelecimento")]
        [Required]
        [StringLength(1)]
        public string TipoEstabelecimento { get; set; }

        [DisplayName("DiaVencimento")]
        public int DiaVencimento { get; set; }

        [DisplayName("AnoMes")]
        public decimal AnoMes { get; set; }

        [DisplayName("Valor")]
        public decimal Valor { get; set; }

        [DisplayName("DiaProcessamento")]
        public int DiaProcessamento { get; set; }
    }
}