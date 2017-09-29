﻿using FiscalNET.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiscalNet.Implementacoes.Icms
{
    public class Icms70 : IIcms
    {
        private decimal AliqIcmsProprio { get; set; }
        private decimal AliqRedBcIcms { get; set; }
        private decimal AliqIcmsST { get; set; }
        private decimal AliqRedBcIcmsST { get; set; }
        private decimal Mva { get; set; }
        private decimal ValorIpi { get; set; }
        private decimal DespesasAcessorias { get; set; }
        private decimal ValorFrete { get; set; }
        private decimal ValorProduto { get; set; }
        private decimal ValorSeguro { get; set; }

        public Icms70(decimal aliqIcmsProprio, decimal aliqRedBcIcms,
            decimal aliqIcmsST, decimal aliqRedBcIcmsST, decimal mva,
            decimal valorIpi, decimal despesasAcessorias,
            decimal valorFrete, decimal valorProduto,
            decimal valorSeguro)
        {
            this.AliqIcmsProprio    = aliqIcmsProprio;
            this.AliqRedBcIcms      = aliqRedBcIcms;
            this.AliqIcmsST         = aliqIcmsST;
            this.AliqRedBcIcmsST    = aliqRedBcIcmsST;
            this.Mva                = mva;
            this.ValorIpi           = valorIpi;
            this.DespesasAcessorias = despesasAcessorias;
            this.ValorFrete         = valorFrete;
            this.ValorProduto       = valorProduto;
            this.ValorSeguro        = valorSeguro;

        }

        public bool PossuiIcmsProprio
        {
            get
            {
                return true;
            }
        }

        public bool PossuiIcmsST
        {
            get
            {
                return true;
            }
        }

        public bool PossuiRedBCIcmsProprio
        {
            get
            {
                return true;
            }
        }

        public bool PossuiRedBCIcmsST
        {
            get
            {
                return true;
            }
        }

        public decimal ValorRedBaseIcms()
        {
            return new BaseReduzidaIcms(ValorIpi, DespesasAcessorias, ValorFrete, ValorProduto, ValorSeguro, AliqRedBcIcms).GerarBaseReduzidaIcms();
        }

        public decimal ValorIcms()
        {
            decimal vBaseRedIcms = new BaseReduzidaIcms(ValorIpi, DespesasAcessorias, ValorFrete, ValorProduto, ValorSeguro, AliqRedBcIcms).GerarBaseReduzidaIcms();
            return (AliqIcmsProprio / 100) * vBaseRedIcms;
        }

        public decimal ValorRedBaseIcmsST()
        {
            decimal vBaseIcmsST = new BaseIcmsST(ValorIpi, DespesasAcessorias, ValorFrete, ValorProduto, ValorSeguro, Mva).GerarBaseIcmsST();
            return vBaseIcmsST * (AliqRedBcIcmsST / 100);
        }

        public decimal ValorIcmsST()
        {                        
            decimal vBaseRedIcms = new BaseReduzidaIcms(ValorIpi, DespesasAcessorias, ValorFrete, ValorProduto, ValorSeguro, AliqRedBcIcms).GerarBaseReduzidaIcms();
            decimal vIcms = (AliqIcmsProprio / 100) * vBaseRedIcms;

            decimal vBaseIcmsST = new BaseIcmsST(ValorIpi, DespesasAcessorias, ValorFrete, ValorProduto, ValorSeguro, Mva).GerarBaseIcmsST();
            decimal vBcRedIcmsST = vBaseIcmsST * (AliqRedBcIcmsST / 100);

            return ((vBcRedIcmsST * (AliqIcmsST / 100)) - vIcms);
        }




        public decimal PercRedBaseIcms()
        {
            throw new NotImplementedException();
        }

        public decimal PercRedBaseIcmsST()
        {
            throw new NotImplementedException();
        }

        public decimal BaseIcms()
        {
            throw new NotImplementedException();
        }

        public decimal BaseIcmsST()
        {
            throw new NotImplementedException();
        }


    }
}
