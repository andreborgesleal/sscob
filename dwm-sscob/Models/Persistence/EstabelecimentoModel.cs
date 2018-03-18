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
    public class EstabelecimentoModel : CrudModelLocal<Estabelecimento, EstabelecimentoViewModel>
    {
        #region Constructor
        public EstabelecimentoModel()
        {
        }

        public EstabelecimentoModel(ApplicationContext _db, SecurityContext _seguranca_db)
        {
            this.Create(_db, _seguranca_db);
        }
        #endregion

        #region Métodos da classe CrudContext
        public override Estabelecimento MapToEntity(EstabelecimentoViewModel value)
        {
            Estabelecimento entity = Find(value);

            if (entity == null)
            {
                entity = new Estabelecimento();
            }

            entity.CNPJ = Utils.Utils.SemFormatacao(value.CNPJ);
            entity.Nome = value.Nome.ToUpper();
            entity.TipoEstabelecimento = value.TipoEstabelecimento;
            entity.Email = value.Email.ToLower();
            entity.SetorRecolhimento = value.SetorRecolhimento;

            return entity;
        }

        public override EstabelecimentoViewModel MapToRepository(Estabelecimento entity)
        {
            EstabelecimentoViewModel e = new EstabelecimentoViewModel()
            {
                CNPJ = entity.CNPJ,
                Nome = entity.Nome,
                TipoEstabelecimento = entity.TipoEstabelecimento,
                Email = entity.Email,
                SetorRecolhimento = entity.SetorRecolhimento,
                mensagem = new Validate() { Code = 0, Message = "Registro processado com sucesso", MessageBase = "Registro processado com sucesso", MessageType = MsgType.SUCCESS }
            };

            return e;
        }

        public override Estabelecimento Find(EstabelecimentoViewModel key)
        {
            return db.Estabelecimento.Find(key.CNPJSemFormatacao);
        }

        public override Validate Validate(EstabelecimentoViewModel value, Crud operation)
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
                value.mensagem.Message = MensagemPadrao.Message(5, "CNPJ").ToString();
                value.mensagem.MessageBase = "CNPJ deve ser informado";
                value.mensagem.MessageType = MsgType.WARNING;
                return value.mensagem;
            }

            if (String.IsNullOrEmpty(value.Nome))
            {
                value.mensagem.Code = 5;
                value.mensagem.Message = MensagemPadrao.Message(5, "Nome").ToString();
                value.mensagem.MessageBase = "Nome deve ser informado";
                value.mensagem.MessageType = MsgType.WARNING;
                return value.mensagem;
            }

            if (String.IsNullOrEmpty(value.Email))
            {
                value.mensagem.Code = 5;
                value.mensagem.Message = MensagemPadrao.Message(5, "Email").ToString();
                value.mensagem.MessageBase = "Email deve ser informado";
                value.mensagem.MessageType = MsgType.WARNING;
                return value.mensagem;
            }

            if (String.IsNullOrEmpty(value.TipoEstabelecimento))
            {
                value.mensagem.Code = 5;
                value.mensagem.Message = MensagemPadrao.Message(5, "TipoEstabelecimento").ToString();
                value.mensagem.MessageBase = "TipoEstabelecimento deve ser informado";
                value.mensagem.MessageType = MsgType.WARNING;
                return value.mensagem;
            }

            if (!Utils.Utils.IsCnpj(value.CNPJSemFormatacao))
            {
                
                value.mensagem.Code = 30;
                value.mensagem.Message = MensagemPadrao.Message(30, "CNPJ").ToString();
                value.mensagem.MessageBase = "O CNPJ informado é inválido";
                value.mensagem.MessageType = MsgType.WARNING;
                return value.mensagem;
            }

            return value.mensagem;
        }

        public override EstabelecimentoViewModel AfterInsert(EstabelecimentoViewModel value)
        {
            var result = seguranca_db.Database.SqlQuery<Object>($"exec dbo.IncluirUsuarioEstabelecimento @P_CNPJ = '{value.CNPJ}', @P_NOME='{value.Nome}', @P_EMAIL = '{value.Email}'").ToList();
            return base.AfterInsert(value);
        }
        #endregion
    }

    public class ListViewEstabelecimento : ListViewModelLocal<EstabelecimentoViewModel>
    {
        #region Constructor
        public ListViewEstabelecimento() { }
        public ListViewEstabelecimento(ApplicationContext _db, SecurityContext _seguranca_db)
        {
            this.Create(_db, _seguranca_db);
        }
        #endregion

        #region Métodos da classe ListViewRepository
        public override IEnumerable<EstabelecimentoViewModel> Bind(int? index, int pageSize = 50, params object[] param)
        {
            return (from e in db.Estabelecimento
                     orderby e.Nome
                     select new EstabelecimentoViewModel
                     {
                         empresaId = sessaoCorrente.empresaId,
                         CNPJ = e.CNPJ,
                         Email = e.Email,
                         Nome = e.Nome,
                         SetorRecolhimento = e.SetorRecolhimento,
                         TipoEstabelecimento = e.TipoEstabelecimento,
                     }).ToList();
            }

        public override Repository getRepository(object id)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}