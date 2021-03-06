﻿using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using App_Dominio.Security;
using App_Dominio.Contratos;
using App_Dominio.Controllers;
using System.Data.Entity.Validation;
using App_Dominio.Entidades;
using DWM.Models;
using App_Dominio.Enumeracoes;
using DWM.Models.Entidades;
using DWM.Models.BI;
using DWM.Models.Pattern;
using App_Dominio.Pattern;
using System.Collections.Generic;
using App_Dominio.Repositories;
using DWM.Models.Repositories;

namespace dwm_sscob.Controllers
{
    [Authorize]
    public class AccountController : SuperController
    {
        #region Inheritance
        public override int _sistema_id() { return (int)DWM.Models.Enumeracoes.Sistema.DWMSSCOB; }

        public override string getListName()
        {
            return "Login";
        }

        public override ActionResult List(int? index, int? pageSize = 40, string descricao = null)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Login
        [AllowAnonymous]
        public ActionResult Login()
        {
            try
            {
                LoginViewModel value = new LoginViewModel();
                return View(value); // RedirectToAction("Default", "Home");
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                EmpresaSecurity<App_DominioContext> security = new EmpresaSecurity<App_DominioContext>();
                try
                {
                    #region Autorizar
                    Validate result = security.Autorizar(model.UserName.Trim(), model.Password, _sistema_id());
                    if (result.Code > 0)
                        throw new ArgumentException(result.Message);
                    #endregion

                    Sessao s = security.getSessaoCorrente();

                    string sessaoId = result.Field;

                    return RedirectToAction("Index", "Home");
                }
                catch (ArgumentException ex)
                {
                    Error(ex.Message);
                }
                catch (App_DominioException)
                {
                    Error("Erro na autorização de acesso. Favor entre em contato com o administrador do sistema");
                }
                catch (DbEntityValidationException)
                {
                    Error("Não foi possível autorizar o seu acesso. Favor entre em contato com o administrador do sistema");
                }
                catch (Exception)
                {
                    Error("Erro na autorização de acesso. Favor entre em contato com o administrador do sistema");
                }
            }
            else
                Error("Erro de preenchimento de login e senha");

            LoginViewModel value = new LoginViewModel();

            return View(value);
        }
        #endregion

        #region Register (Cadastre-se)
        [AllowAnonymous]
        public ActionResult Register()
        {
            RegisterViewModel value = new RegisterViewModel();
            return View(value);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel value, FormCollection collection)
        {
            if (ModelState.IsValid)
                try
                {
                    value.uri = this.ControllerContext.Controller.GetType().Name.Replace("Controller", "") + "/" + this.ControllerContext.RouteData.Values["action"].ToString();
                    value.senha = collection["pwd"];
                    value.confirmacaoSenha = collection["pwdConfirm"];

                    Factory<RegisterViewModel, ApplicationContext> factory = new Factory<RegisterViewModel, ApplicationContext>();
                    value = factory.Execute(new RegisterBI(), value);

                    if (value.mensagem.Code > 0)
                        throw new ArgumentException(value.mensagem.MessageBase);

                    Success("Seu cadastro foi realizado com sucesso.");

                    return RedirectToAction("Login", "Account");
                }
                catch (ArgumentException ex)
                {
                    ModelState.AddModelError("", MensagemPadrao.Message(999).ToString()); // mensagem amigável ao usuário
                    Attention(ex.Message); // Mensagem em inglês com a descrição detalhada do erro e fica no topo da tela
                }
                catch (Exception ex)
                {
                    App_DominioException.saveError(ex, GetType().FullName);
                    ModelState.AddModelError("", MensagemPadrao.Message(17).ToString()); // mensagem amigável ao usuário
                    Error(ex.Message); // Mensagem em inglês com a descrição detalhada do erro e fica no topo da tela
                }
            else
            {
                value.mensagem = new Validate()
                {
                    Code = 999,
                    Message = MensagemPadrao.Message(999).ToString(),
                    MessageBase = ModelState.Values.Where(erro => erro.Errors.Count > 0).First().Errors[0].ErrorMessage == "" ? MensagemPadrao.Message(999).ToString() : ModelState.Values.Where(erro => erro.Errors.Count > 0).First().Errors[0].ErrorMessage
                };
                ModelState.AddModelError("", value.mensagem.Message); // mensagem amigável ao usuário
                Attention(value.mensagem.MessageBase);
            }

            return View(value);
        }
        #endregion

        #region Ativar credenciado
        //[AllowAnonymous]
        //public ActionResult AtivarCredenciado(string id, string key)
        //{
        //    UsuarioRepository value = new UsuarioRepository();
        //    if (id != null && id != "")
        //    {
        //        value.usuarioId = int.Parse(id);
        //        value.keyword = key;
        //        Factory<UsuarioRepository, ApplicationContext> factory = new Factory<UsuarioRepository, ApplicationContext>();
        //        value = factory.Execute(new CodigoValidacaoCredenciadoBI(), value);
        //        if (value.mensagem.Code == -1)
        //        {
        //            Condominio Condominio = DWMSessaoLocal.GetCondominioByID(value.empresaId);
        //            if (Condominio == null)
        //                throw new ArgumentException();

        //            ViewBag.Condominio = Condominio;
        //            return View(value);
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("", value.mensagem.MessageBase); // mensagem amigável ao usuário
        //            Error(value.mensagem.Message); // Mensagem em inglês com a descrição detalhada do erro e fica no topo da tela
        //        }
        //        if (value.empresaId > 0)
        //        {
        //            Condominio c = DWMSessaoLocal.GetCondominioByID(value.empresaId);
        //            return RedirectToAction("Login", "Account", new { id = c.PathInfo });
        //        }
        //    }
        //    return RedirectToAction("Login", "Account");
        //}

        //[HttpPost]
        //[AllowAnonymous]
        //public ActionResult AtivarCredenciado(UsuarioRepository value)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            if (value.usuarioId != 0)
        //            {
        //                Factory<UsuarioRepository, ApplicationContext> factory = new Factory<UsuarioRepository, ApplicationContext>();
        //                value = factory.Execute(new CodigoAtivacaoCredenciadoBI(), value);
        //                if (value.mensagem.Code > 0)
        //                    throw new App_DominioException(value.mensagem);
        //                Success("Residente ativado com sucesso. Faça seu login para acessar o sistema");
        //                Condominio c = DWMSessaoLocal.GetCondominioByID(value.empresaId);
        //                return RedirectToAction("Login", "Account", new { id = c.PathInfo });
        //            };
        //        }
        //        catch (App_DominioException ex)
        //        {
        //            ModelState.AddModelError("", ex.Result.MessageBase); // mensagem amigável ao usuário
        //            Error(ex.Result.Message); // Mensagem em inglês com a descrição detalhada do erro e fica no topo da tela
        //        }
        //        catch (Exception ex)
        //        {
        //            App_DominioException.saveError(ex, GetType().FullName);
        //            ModelState.AddModelError("", MensagemPadrao.Message(17).ToString()); // mensagem amigável ao usuário
        //            Error(ex.Message); // Mensagem em inglês com a descrição detalhada do erro e fica no topo da tela
        //        }
        //    }
        //    else
        //        Error("Dados incorretos");

        //    Condominio Condominio = DWMSessaoLocal.GetCondominioByID(value.empresaId);
        //    if (Condominio == null)
        //        throw new ArgumentException();

        //    ViewBag.Condominio = Condominio;

        //    return View(value);
        //}
        #endregion

        #region Termo de Uso e Política de Privacidade
        //[AllowAnonymous]
        //public ActionResult TermoUso(string id)
        //{
        //    if (String.IsNullOrEmpty(id))
        //        throw new ArgumentException();

        //    Condominio Condominio = DWMSessaoLocal.GetCondominioByPathInfo(id);
        //    if (Condominio == null)
        //        throw new ArgumentException();

        //    ViewBag.Condominio = Condominio;

        //    return View();
        //}

        //[AllowAnonymous]
        //public ActionResult Politica(string id)
        //{
        //    if (String.IsNullOrEmpty(id))
        //        throw new ArgumentException();

        //    Condominio Condominio = DWMSessaoLocal.GetCondominioByPathInfo(id);
        //    if (Condominio == null)
        //        throw new ArgumentException();

        //    ViewBag.Condominio = Condominio;

        //    return View();
        //}
        #endregion

        #region Alterar Senha
        public ActionResult AlterarSenha()
        {
            return View();
        }

        #endregion

        #region Esqueci minha senha
        [AllowAnonymous]
        public ActionResult Forgot()
        {
            return View(); // RedirectToAction("Default", "Home");
        }

        [ValidateInput(false)]
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Forgot(UsuarioViewModel value, FormCollection collection)
        {
            try
            {
                if (string.IsNullOrEmpty(collection["empresaId"]))
                    throw new Exception("Identificador do condomínio não localizado. Favor entrar em contato com a administração.");

                value.uri = this.ControllerContext.Controller.GetType().Name.Replace("Controller", "") + "/" + this.ControllerContext.RouteData.Values["action"].ToString();
                FactoryLocalhost<UsuarioViewModel, ApplicationContext> factory = new FactoryLocalhost<UsuarioViewModel, ApplicationContext>();
                //value = factory.Execute(new EsqueciMinhaSenhaBI(), value);
                if (factory.Mensagem.Code > 0)
                    throw new App_DominioException(factory.Mensagem);

                Success("E-mail com as intruções de renovação de senha enviado com sucesso");
            }
            catch (App_DominioException ex)
            {
                ModelState.AddModelError("", ex.Result.MessageBase); // mensagem amigável ao usuário
                Error(ex.Result.Message); // Mensagem em inglês com a descrição detalhada do erro e fica no topo da tela
                return View(value);
            }
            catch (Exception ex)
            {
                App_DominioException.saveError(ex, GetType().FullName);
                ModelState.AddModelError("", MensagemPadrao.Message(17).ToString()); // mensagem amigável ao usuário
                Error(ex.Message); // Mensagem em inglês com a descrição detalhada do erro e fica no topo da tela
                return View(value);
            }

            return RedirectToAction("Login", "Account", new { id = collection["PathInfo"] });
        }

        [AllowAnonymous]
        public ActionResult EsqueciMinhaSenha(string id, string key)
        {
            UsuarioRepository value = new UsuarioRepository();
            if (id != null && id != "")
            {
                value.usuarioId = int.Parse(id);
                value.keyword = key;
                Factory<UsuarioRepository, ApplicationContext> factory = new Factory<UsuarioRepository, ApplicationContext>();
                if (value.mensagem.Code == -1)
                {
                    return View(value);
                }
                else
                {
                    ModelState.AddModelError("", value.mensagem.MessageBase); // mensagem amigável ao usuário
                    Error(value.mensagem.Message); // Mensagem em inglês com a descrição detalhada do erro e fica no topo da tela
                }
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult EsqueciMinhaSenha(UsuarioRepository value)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (value.usuarioId != 0)
                    {
                        Factory<UsuarioRepository, ApplicationContext> factory = new Factory<UsuarioRepository, ApplicationContext>();
                        if (value.mensagem.Code > 0)
                            throw new App_DominioException(value.mensagem);
                        Success("Senha alterada com sucesso. Faça seu login para acessar o sistema");
                        return RedirectToAction("Login", "Account");
                    };
                }
                catch (App_DominioException ex)
                {
                    ModelState.AddModelError("", ex.Result.MessageBase); // mensagem amigável ao usuário
                    Error(ex.Result.Message); // Mensagem em inglês com a descrição detalhada do erro e fica no topo da tela
                }
                catch (Exception ex)
                {
                    App_DominioException.saveError(ex, GetType().FullName);
                    ModelState.AddModelError("", MensagemPadrao.Message(17).ToString()); // mensagem amigável ao usuário
                    Error(ex.Message); // Mensagem em inglês com a descrição detalhada do erro e fica no topo da tela
                }
            }
            else
                Error("Dados incorretos");

            return View(value);
        }

        #endregion

        [AllowAnonymous]
        public ActionResult LogOff()
        {
            System.Web.HttpContext web = System.Web.HttpContext.Current;

            SessaoLocal s = DWMSessaoLocal.GetSessaoLocal();

            if (s != null)
            {
                new EmpresaSecurity<App_DominioContext>().EncerrarSessao(web.Session.SessionID);
                return RedirectToAction("Login", "Account");
            }

            return RedirectToAction("Login", "Account", new { id = "" });
        }

    }
}