﻿using System;
using System.Collections.Generic;
using App_Dominio.Contratos;
using App_Dominio.Entidades;
using App_Dominio.Component;
using DWM.Models.Repositories;
using DWM.Models.Entidades;
using System.Web.Mvc;
using DWM.Models.Persistence;
using App_Dominio.Models;
using System.Linq;
using App_Dominio.Enumeracoes;
using App_Dominio.Security;

namespace DWM.Models.BI
{
    public class HomeBI : DWMContextLocal, IProcess<HomeViewModel, ApplicationContext>
    {
        #region Constructor
        public HomeBI() { }

        public HomeBI(ApplicationContext _db, SecurityContext _seguranca_db)
        {
            Create(_db, _seguranca_db);
        }
        #endregion

        public IEnumerable<HomeViewModel> List(params object[] param)
        {
            throw new NotImplementedException();
        }

        public IPagedList PagedList(int? index, int pageSize = 50, params object[] param)
        {
            throw new NotImplementedException();
        }

        public HomeViewModel Run(Repository value)
        {
            HomeViewModel home = (HomeViewModel) value;
            EmpresaSecurity<SecurityContext> es = new EmpresaSecurity<SecurityContext>();

            try
            {
                es.seguranca_db = this.seguranca_db;
                home.UsuarioGrupos = es._getUsuarioGrupo(SessaoLocal.usuarioId).ToList();

                //home.ContabilidadeCompetencia = "Fevereiro/2017";

                //home.ValorInadimplenciaTotal = 0; // (decimal)468874.54;
                //home.ValorInadimplenciaCompetencia = 0; // (decimal)28274.29;
                //home.ValorSaldoAnterior = 0; // (decimal)18740.36;
                //home.ValorSaldoAtual = 0; // (decimal)12230.57;
                //home.ValorReceitaCompetenciaRealizada = (decimal)528196.31;
                //home.ValorReceitaCompetenciaPlanejada = (decimal)550000.0;
                //home.ValorDespesaCompetenciaRealizada = (decimal)253331.33;

                //home.ValorInadimplenciaTotal = 0; // Math.Round(home.ValorInadimplenciaTotal/1000, 0);
                //home.ValorInadimplenciaCompetencia = 0; // Math.Round(home.ValorInadimplenciaCompetencia / 1000, 0);
                //home.ValorSaldoAnterior = 0; // Math.Round(home.ValorSaldoAnterior / 1000, 0);
                //home.ValorReceitaCompetenciaRealizada = Math.Round(home.ValorReceitaCompetenciaRealizada / 1000, 0);
                //home.ValorReceitaCompetenciaPlanejada = Math.Round(home.ValorReceitaCompetenciaPlanejada / 1000, 0);
                //home.ValorDespesaCompetenciaRealizada = Math.Round(home.ValorDespesaCompetenciaRealizada / 1000, 0);

                //home.ValorSaldoAtual = home.ValorSaldoAnterior + home.ValorReceitaCompetenciaRealizada - home.ValorDespesaCompetenciaRealizada;

                //home.DRE = (from bal in db.Balancetes
                //            where bal.CondominioID == sessaoCorrente.empresaId
                //            orderby bal.Natureza, bal.descricao
                //            select new BalanceteViewModel
                //            {
                //                empresaId = bal.CondominioID,
                //                CondominioID = bal.CondominioID,
                //                planoContaID = bal.planoContaID,
                //                descricao = bal.descricao,
                //                Natureza = bal.Natureza,
                //                SaldosContabeis = (from sal in db.SaldosContabeis
                //                                   where sal.CondominioID == bal.CondominioID
                //                                            && sal.planoContaID == bal.planoContaID
                //                                   orderby sal.Competencia descending
                //                                   select new SaldoContabilViewModel()
                //                                   {
                //                                       CondominioID = sal.CondominioID,
                //                                       planoContaID = sal.planoContaID,
                //                                       Competencia = sal.Competencia,
                //                                       ValorSaldo = Math.Round(sal.ValorSaldo / 1000, 0),
                //                                       mensagem = new Validate() { Code = 0, Message = "Registro incluído com sucesso", MessageBase = "Registro incluído com sucesso", MessageType = MsgType.SUCCESS }
                //                                   }).Take(7)
                //            }).ToList();

                //home.TotalUnidadesCadastradas = (from cu in db.CondominoUnidades
                //                                 where cu.CondominioID == sessaoCorrente.empresaId
                //                                        && cu.DataFim == null
                //                                 select cu).Count();
                //home.TotalCondominos = (from cu in db.CondominoUnidades
                //                        join cre in db.Credenciados on cu.CondominoID equals cre.CondominoID
                //                        where cu.CondominioID == sessaoCorrente.empresaId
                //                                && cu.DataFim == null
                //                                && cre.IndVisitantePermanente != "S"
                //                        select cre).Count() + home.TotalUnidadesCadastradas; // total de credenciados diferentes de visitantes permanentes + total de titulares

                
                //IList<ChartJS> js = new List<ChartJS>();
                //foreach (BalanceteViewModel bal in home.DRE.Where(info => info.Natureza == "D"))
                //    js.Add(new ChartJS() { device = bal.descricao, geekbench = bal.SaldosContabeis.FirstOrDefault().ValorSaldo });

                //js.Add(new ChartJS() { device = "Taxa condominial", geekbench = 380 });
                //js.Add(new ChartJS() { device = "Taxa extra", geekbench = 180 });
                //js.Add(new ChartJS() { device = "Infração", geekbench = 980 });
                //js.Add(new ChartJS() { device = "Aluguel espaço", geekbench = 80 });
                //js.Add(new ChartJS() { device = "Fundo de reserva", geekbench = 280 });
                //js.Add(new ChartJS() { device = "Acordo judicial", geekbench = 780 });
                //js.Add(new ChartJS() { device = "Outros", geekbench = 880 });
                //js.Add(new ChartJS() { device = "Fundo de reserva", geekbench = 280 });
                //js.Add(new ChartJS() { device = "Acordo judicial", geekbench = 780 });
                //js.Add(new ChartJS() { device = "Outros", geekbench = 880 });

                //home.js = new JsonResult()
                //{
                //    Data = js.ToList(),
                //    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                //};
            }
            catch (Exception ex)
            {
                home.mensagem = new Validate() { Code = 999, MessageBase = ex.Message, Message = "Ocorreu um erro na recuperação dos dados" };
            }

            return home;
        }


    }
}