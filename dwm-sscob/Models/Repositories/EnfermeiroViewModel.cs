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

        [DisplayName("Estabelecimento *")]
        [Required]
        public string CNPJ { get; set; }

        [DisplayName("CPF *")]
        [Required]
        public string CPF { get; set; }

        [DisplayName("Nome *")]
        [Required]
        [StringLength(40)]
        public string Nome { get; set; }

        [DisplayName("PIS")]
        [StringLength(25)]
        public string PIS { get; set; }

        [DisplayName("Situação *")]
        public string IndSituacao { get; set; }

        [DisplayName("Observação")]
        [DataType(DataType.MultilineText)]
        public string Observacao { get; set; }

        public EstabelecimentoViewModel EstabelecimentoViewModel { get; set; }

        public string CNPJComFormatacao
        {
            get
            {
                return Utils.Utils.FormatCNPJ(this.CNPJ);
            }
        }

        public string CNPJSemFormatacao
        {
            get
            {
                return Utils.Utils.SemFormatacao(this.CNPJ);
            }
        }

        public string CPFComFormatacao
        {
            get
            {
                return Utils.Utils.FormatCPF(this.CPF);
            }
        }
        
        public string CPFSemFormatacao
        {
            get
            {
                return Utils.Utils.SemFormatacao(this.CPF);
            }
        }
    }
}