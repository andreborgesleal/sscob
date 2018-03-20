using App_Dominio.Controllers;
using DWM.Models.Entidades;
using DWM.Models.Repositories;
using DWM.Models.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using App_Dominio.Security;
using App_Dominio.Pattern;

namespace DWM.Controllers
{
    public class EnfermeirosController : DwmRootController<EnfermeiroViewModel, EnfermeiroModel, ApplicationContext>
    {

        #region Inheritance
        public override int _sistema_id() { return (int)DWM.Models.Enumeracoes.Sistema.DWMSSCOB; }

        public override string getListName()
        {
            return "Listar Enfermeiros";
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
                ListViewEnfermeiro l = new ListViewEnfermeiro();
                return this._List(index, pageSize, "Browse", l, null);
            }
            else
                return View();
        }
        #endregion

        #region Edit
        [AuthorizeFilter]
        public ActionResult Edit(int EnfermeiroID)
        {
            return _Edit(new EnfermeiroViewModel() { EnfermeiroID = EnfermeiroID });
        }
        #endregion

        #region Delete
        [AuthorizeFilter]
        public ActionResult Delete(int EnfermeiroID)
        {
            return Edit(EnfermeiroID);
        }
        #endregion
    }
}