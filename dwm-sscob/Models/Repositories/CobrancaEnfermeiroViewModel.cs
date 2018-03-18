using App_Dominio.Component;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DWNM.Models.Repositories
{
    public class CobrancaEnfermeiroViewModel : Repository
    {
        [DisplayName("CobrancaID")]
        public int CobrancaID { get; set; }

        [DisplayName("EnfermeiroID")]
        public int EnfermeiroID { get; set; }

        [DisplayName("Valor")]
        public decimal Valor { get; set; }
    }
}