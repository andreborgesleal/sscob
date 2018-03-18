using System;
using System.Collections.Generic;
using App_Dominio.Contratos;
using App_Dominio.Entidades;
using App_Dominio.Component;
using DWM.Models.Repositories;
using DWM.Models.Entidades;
using System.Web.Mvc;
using DWM.Models.Persistence;
using App_Dominio.Enumeracoes;
using App_Dominio.Security;
using System.Linq;
using System.Data.Entity.Infrastructure;
using App_Dominio.Models;

namespace DWM.Models.BI
{
    public class RegisterBI : DWMContextLocal, IProcess<RegisterViewModel, ApplicationContext>
    {
        #region Constructor
        public RegisterBI() { }

        public override void Create(ApplicationContext _db, SecurityContext _seguranca_db)
        {
            this.db = _db;
            this.seguranca_db = _seguranca_db;
        }

        #endregion

        private Validate Validate(RegisterViewModel value)
        {
            value.mensagem = new Validate() { Code = 0, Message = MensagemPadrao.Message(0).ToString() };

            #region validar senha e confirmação de senha
            if (value.senha == null || value.senha == "")
            {
                value.mensagem.Code = 5;
                value.mensagem.Message = MensagemPadrao.Message(5, "Senha").ToString();
                value.mensagem.MessageBase = "Senha deve ser informada";
                value.mensagem.MessageType = MsgType.WARNING;
                return value.mensagem;
            }

            if (value.senha != value.confirmacaoSenha)
            {
                value.mensagem.Code = 5;
                value.mensagem.Message = MensagemPadrao.Message(5, "Senha").ToString();
                value.mensagem.MessageBase = "Senha e confirmação de senha não conferem";
                value.mensagem.MessageType = MsgType.WARNING;
                return value.mensagem;
            }
            #endregion

            return value.mensagem;
        }

        public RegisterViewModel Run(Repository value)
        {
            RegisterViewModel r = (RegisterViewModel)value;
            try
            {
                #region validar cadastro
                Validate validate = Validate(r);
                if (validate.Code > 0)
                    throw new ArgumentException(validate.MessageBase);
                #endregion

                #region Cadastrar o condômino como um usuário em DWM-Segurança

                #region Usuario 
                EmpresaSecurity<SecurityContext> security = new EmpresaSecurity<SecurityContext>();

                Usuario user = new Usuario()
                {
                    nome = r.Nome.Trim().Length > 40 ? r.Nome.Substring(0, 40).ToUpper() : r.Nome.Trim().ToUpper(),
                    login = r.Email,
                    empresaId = 10,
                    dt_cadastro = Funcoes.Brasilia(),
                    isAdmin = "N",
                    senha = security.Criptografar(r.senha)
                };

                seguranca_db.Usuarios.Add(user);
                #endregion

                #region UsuarioGrupo
                UsuarioGrupo ug = new UsuarioGrupo()
                {
                    Usuario = user,
                    grupoId = 10,
                    situacao = "A"
                };

                seguranca_db.UsuarioGrupos.Add(ug);
                #endregion

                seguranca_db.SaveChanges();

                #endregion


                r.IndSituacao = "A";
                db.SaveChanges();
            }
            catch (ArgumentException ex)
            {
                r.mensagem = new Validate() { Code = 999, Message = MensagemPadrao.Message(999).ToString(), MessageBase = ex.Message };
            }
            catch (App_DominioException ex)
            {
                r.mensagem = ex.Result;

                if (ex.InnerException != null)
                    r.mensagem.MessageBase = new App_DominioException(ex.InnerException.Message ?? ex.Message, GetType().FullName).Message;
                else
                    r.mensagem.MessageBase = new App_DominioException(ex.Result.Message, GetType().FullName).Message;
            }
            catch (DbUpdateException ex)
            {
                r.mensagem.MessageBase = ex.InnerException.InnerException.Message ?? ex.Message;
                if (r.mensagem.MessageBase.ToUpper().Contains("REFERENCE"))
                {
                    if (r.mensagem.MessageBase.ToUpper().Contains("DELETE"))
                    {
                        r.mensagem.Code = 16;
                        r.mensagem.Message = MensagemPadrao.Message(16).ToString();
                        r.mensagem.MessageType = MsgType.ERROR;
                    }
                    else
                    {
                        r.mensagem.Code = 28;
                        r.mensagem.Message = MensagemPadrao.Message(28).ToString();
                        r.mensagem.MessageType = MsgType.ERROR;
                    }
                }
                else if (r.mensagem.MessageBase.ToUpper().Contains("PRIMARY"))
                {
                    r.mensagem.Code = 37;
                    r.mensagem.Message = MensagemPadrao.Message(37).ToString();
                    r.mensagem.MessageType = MsgType.WARNING;
                }
                else if (r.mensagem.MessageBase.ToUpper().Contains("UNIQUE KEY"))
                {
                    r.mensagem.Code = 54;
                    r.mensagem.Message = MensagemPadrao.Message(54).ToString();
                    r.mensagem.MessageType = MsgType.WARNING;
                }
                else
                {
                    r.mensagem.Code = 44;
                    r.mensagem.Message = MensagemPadrao.Message(44).ToString();
                    r.mensagem.MessageType = MsgType.ERROR;
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                r.mensagem = new Validate() { Code = 42, Message = MensagemPadrao.Message(42).ToString(), MessageBase = ex.EntityValidationErrors.Select(m => m.ValidationErrors.First().ErrorMessage).First() };
            }
            catch (Exception ex)
            {
                r.mensagem.Code = 17;
                r.mensagem.Message = MensagemPadrao.Message(17).ToString();
                r.mensagem.MessageBase = new App_DominioException(ex.InnerException.InnerException.Message ?? ex.Message, GetType().FullName).Message;
                r.mensagem.MessageType = MsgType.ERROR;
            }
            return r;
        }

        public IEnumerable<RegisterViewModel> List(params object[] param)
        {
            throw new NotImplementedException();
        }

        public IPagedList PagedList(int? index, int pageSize = 50, params object[] param)
        {
            throw new NotImplementedException();
        }
    }
}