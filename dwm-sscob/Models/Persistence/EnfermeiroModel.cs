using App_Dominio.Component;
using App_Dominio.Contratos;
using App_Dominio.Entidades;
using App_Dominio.Enumeracoes;
using App_Dominio.Models;
using App_Dominio.Security;
using DWM.Models.Entidades;
using DWM.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DWM.Models;

namespace DWM.Models.Persistence
{
    public class EnfermeiroModel : CrudModelLocal<Enfermeiro, EnfermeiroViewModel>
    {
        #region Constructor
        public EnfermeiroModel()
        {
        }

        public EnfermeiroModel(ApplicationContext _db, SecurityContext _seguranca_db)
        {
            this.Create(_db, _seguranca_db);
        }
        #endregion

        #region Métodos da classe CrudContext
        public override Enfermeiro MapToEntity(EnfermeiroViewModel value)
        {
            Enfermeiro entity = Find(value);

            if (entity == null)
            {
                entity = new Enfermeiro();
            }

            entity.CNPJ = Utils.Utils.SemFormatacao(value.CNPJ);
            entity.Nome = value.Nome.ToUpper();
            entity.CPF = Utils.Utils.SemFormatacao(value.CPF);
            entity.PIS = value.PIS;
            entity.Observacao = value.Observacao;
            entity.IndSituacao = value.IndSituacao; // A - Ativo, I - Inativo

            return entity;
        }

        public override EnfermeiroViewModel MapToRepository(Enfermeiro entity)
        {
            EnfermeiroViewModel e = new EnfermeiroViewModel()
            {
                CNPJ = entity.CNPJ,
                Nome = entity.Nome,
                CPF = entity.CPF,
                PIS = entity.PIS,
                IndSituacao = entity.IndSituacao,
                Observacao = entity.Observacao,
                mensagem = new Validate() { Code = 0, Message = "Registro processado com sucesso", MessageBase = "Registro processado com sucesso", MessageType = MsgType.SUCCESS }
            };

            return e;
        }

        public override Enfermeiro Find(EnfermeiroViewModel key)
        {
            return db.Enfermeiro.Find(key.EnfermeiroID);
        }

        public override Validate Validate(EnfermeiroViewModel value, Crud operation)
        {
            value.mensagem = new Validate() { Code = 0, Message = MensagemPadrao.Message(0).ToString() };

            if (value.mensagem.Code != 0)
                return value.mensagem;

            if (value.empresaId == 0)
            {
                value.mensagem.Code = 35;
                value.mensagem.Message = MensagemPadrao.Message(35).ToString();
                value.mensagem.MessageBase = "Sua sessão expirou. Faça um novo login no sistema";
                value.mensagem.MessageType = MsgType.WARNING;
                return value.mensagem;
            }

            if (String.IsNullOrEmpty(value.CNPJ))
            {
                value.mensagem.Code = 5;
                value.mensagem.Message = MensagemPadrao.Message(5, "CNPJ *").ToString();
                value.mensagem.MessageBase = "CNPJ deve ser informado";
                value.mensagem.MessageType = MsgType.WARNING;
                return value.mensagem;
            }

            if (String.IsNullOrEmpty(value.Nome))
            {
                value.mensagem.Code = 5;
                value.mensagem.Message = MensagemPadrao.Message(5, "Nome *").ToString();
                value.mensagem.MessageBase = "Nome deve ser informado";
                value.mensagem.MessageType = MsgType.WARNING;
                return value.mensagem;
            }

            if (String.IsNullOrEmpty(value.CPF))
            {
                value.mensagem.Code = 5;
                value.mensagem.Message = MensagemPadrao.Message(5, "Email *").ToString();
                value.mensagem.MessageBase = "Email deve ser informado";
                value.mensagem.MessageType = MsgType.WARNING;
                return value.mensagem;
            }

            if (!Utils.Utils.IsCpf(value.CPFSemFormatacao))
            {

                value.mensagem.Code = 29;
                value.mensagem.Message = MensagemPadrao.Message(29, "CPF *").ToString();
                value.mensagem.MessageBase = "O CPF informado é inválido";
                value.mensagem.MessageType = MsgType.WARNING;
                return value.mensagem;
            }

            return value.mensagem;
        }
        #endregion
    }

    public class ListViewEnfermeiro : ListViewModelLocal<EnfermeiroViewModel>
    {
        #region Constructor
        public ListViewEnfermeiro() { }
        public ListViewEnfermeiro(ApplicationContext _db, SecurityContext _seguranca_db)
        {
            this.Create(_db, _seguranca_db);
        }
        #endregion

        #region Métodos da classe ListViewRepository
        private bool IsAdmin()
        {
            EmpresaSecurity<SecurityContext> security = new EmpresaSecurity<SecurityContext>();
            if (security.getGruposByCurrentUser().Contains("Administração"))
                return true;
            else
                return false;
        }

        public override IEnumerable<EnfermeiroViewModel> Bind(int? index, int pageSize = 50, params object[] param)
        {
            IEnumerable<EnfermeiroViewModel> result;
            var email = DWMSessaoLocal.GetSessaoLocal().login;

            if (IsAdmin())
            {
                result = (from e in db.Enfermeiro
                              orderby e.Nome
                              select new EnfermeiroViewModel
                              {
                                  empresaId = sessaoCorrente.empresaId,
                                  CNPJ = e.CNPJ,
                                  CPF = e.CPF,
                                  Nome = e.Nome,
                                  IndSituacao = e.IndSituacao,
                                  EnfermeiroID = e.EnfermeiroID,
                                  PIS = e.PIS,
                                  Observacao = e.Observacao,
                                  EstabelecimentoViewModel = new EstabelecimentoViewModel()
                                  {
                                      CNPJ = e.CNPJ,
                                      Nome = e.Estabelecimento.Nome
                                  }
                              }).ToList();
            }
            else
            {
                result = (from e in db.Enfermeiro
                          join est in db.Estabelecimento on e.CNPJ equals est.CNPJ
                          where est.Email == email
                          orderby e.Nome
                          select new EnfermeiroViewModel
                          {
                              empresaId = sessaoCorrente.empresaId,
                              CNPJ = e.CNPJ,
                              CPF = e.CPF,
                              Nome = e.Nome,
                              IndSituacao = e.IndSituacao,
                              EnfermeiroID = e.EnfermeiroID,
                              PIS = e.PIS,
                              Observacao = e.Observacao,
                              EstabelecimentoViewModel = new EstabelecimentoViewModel()
                              {
                                  CNPJ = e.CNPJ,
                                  Nome = e.Estabelecimento.Nome
                              }
                          }).ToList();
            }

            return result;
        }

        public override Repository getRepository(object id)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}