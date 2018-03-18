using App_Dominio.Component;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DWM.Models.Repositories
{
    public class EstabelecimentoViewModel : Repository
    {
        [DisplayName("CNPJ *")]
        //[StringLength(14)]
        //[MinLength(14, ErrorMessage = "O campo CNPJ deve possuir comprimento mínimo de 14 caracteres")]
        [Required]
        public string CNPJ { get; set; }

        [DisplayName("Nome *")]
        [StringLength(80)]
        [Required]
        public string Nome { get; set; }

        [DisplayName("Tipo de Estabelecimento *")]
        [StringLength(1)]
        [Required]
        public string TipoEstabelecimento { get; set; }

        [DisplayName("Email *")]
        [StringLength(100)]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DisplayName("Setor de Recolhimento")]
        [StringLength(40)]
        public string SetorRecolhimento { get; set; }

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
    }
}