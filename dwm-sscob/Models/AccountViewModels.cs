using App_Dominio.Component;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DWM.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Login")]
        public string UserName { get; set; }
    }

    public class ManageUserViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Senha Atual")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "O campo {0} deve ter pelo menos {2} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Nova Senha")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmação da nova senha")]
        [Compare("Confirmação de senha", ErrorMessage = "As senhas não combinam.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginViewModel
    {
        [Required(ErrorMessage = "O campo login é de preenhcimento obrigatório e deve ser um e-mail válido")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Informe um e-mail válido")]
        [EmailAddress(ErrorMessage = "Informe o login com um formato de e-mail válido")]
        [Display(Name = "Login")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "O campo Senha é de preenhcimento obrigatório")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [Display(Name = "Lembrar-me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel : Repository
    {
        [Required(ErrorMessage = "O campo Senha é de preenhcimento obrigatório")]
        [StringLength(20, ErrorMessage = "O campo {0} deve ter pelo menos {2} caracteres e no máximo 20 caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha*")]
        public string senha { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmação de senha*")]
        [Compare("senha", ErrorMessage = "As senhas não conferem.")]
        public string confirmacaoSenha { get; set; }

        public string Keyword { get; set; }

        [Display(Name = "Administrador")]
        public string Administrador { get; set; }

        [DisplayName("Sexo")]
        public string Sexo { get; set; }

        [DisplayName("Nome")]
        [StringLength(60, ErrorMessage = "Nome deve ter no mínimo 10 e no máximo 60 caracteres", MinimumLength = 10)]
        [Required(ErrorMessage = "Informe o Nome do Condômino")]
        public string Nome { get; set; }

        [DisplayName("E-mail")]
        [StringLength(100, ErrorMessage = "E-mail deve ter no máximo 100 caracteres")]
        [Required(ErrorMessage = "E-mail deve ser informado")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Informe um e-mail válido")]
        [EmailAddress(ErrorMessage = "Informe o E-mail com um formato válido")]
        public string Email { get; set; }


        [DisplayName("Usuário ID")]
        public int? UsuarioID { get; set; }

        [DisplayName("Observação")]
        public string Observacao { get; set; }

        [DisplayName("Data Cadastro")]
        public System.DateTime DataCadastro { get; set; }

        [DisplayName("Avatar")]
        [StringLength(100, ErrorMessage = "Este campo só permite até 100 caracteres")]
        public string Avatar { get; set; }

        [DisplayName("Situação")]
        public string IndSituacao { get; set; }
    }
}
