using App_Dominio.Controllers;
using App_Dominio.Security;
using DWM.Models.Entidades;
using DWM.Models.Persistence;
using DWM.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DWM.Controllers
{
    public class EstabelecimentosController : DwmRootController<EstabelecimentoViewModel, EstabelecimentoModel, ApplicationContext>
    {
        #region Inheritance
        public override int _sistema_id() { return (int)DWM.Models.Enumeracoes.Sistema.DWMSSCOB; }

        public override string getListName()
        {
            return "Listar Estabelecimentos";
        }
        #endregion

        #region List
        [AuthorizeFilter]
        public override ActionResult List(int? index, int? pageSize = 50, string descricao = null)
        {
            //if (ViewBag.ValidateRequest)
            //{
                if (descricao != null)
                    return ListParam(index, pageSize, descricao);
                else
                    return ListParam(index, pageSize);
            //}
            //else
            //    return View();
        }

        [AuthorizeFilter]
        public ActionResult ListParam(int? index, int? pageSize = 50, string descricao = null)
        {
            ViewBag.empresaId = DWMSessaoLocal.GetSessaoLocal().empresaId;
            if (ViewBag.ValidateRequest)
            {
                ListViewEstabelecimento l = new ListViewEstabelecimento();
                return this._List(index, pageSize, "Browse", l, null);
            }
            else
                return View();
        }
        #endregion

        #region Edit
        [AuthorizeFilter]
        public ActionResult Edit(string CNPJ)
        {
            return _Edit(new EstabelecimentoViewModel() { CNPJ = CNPJ });
        }
        #endregion

        #region Delete
        [AuthorizeFilter]
        public ActionResult Delete(string CNPJ)
        {
            return Edit(CNPJ);
        }
        #endregion
    }
}