﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clube.Modelo.Modelo;
using Clube.Dados.Interface;
using System.Data;
using Clube.Dados;

namespace Clube.Dados
{
    public class TipoPagamentoDados : TipoPagamento, ITipoPagamento
    {

        IAcessoDados D;
        public TipoPagamentoDados()
        {

        }
        public void Atualizar(TipoPagamento item)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(TipoPagamento item)
        {
            throw new NotImplementedException();

        }

        public IEnumerable<TipoPagamento> ConsultarTodos()
        {
            DataTable tabela;
            D = new AcessoDados();
            tabela = D.GetDataTable("sp_consTipoPagamento");

            return CarregaDados(tabela);
        }

        public IEnumerable<TipoPagamento> ConsultarDados(TipoPagamento item)
        {
            throw new NotImplementedException();
        }

        public TipoPagamento ConsultarPorID(int id)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

       
        public IEnumerable<TipoPagamento> CarregaDados(DataTable tb)
        {
            foreach (DataRow row in tb.Rows)
            {
                yield return new TipoPagamento
                {
                    cdTipoPagamento = Convert.ToInt32((row["cdTipoPagamento"])),
                    dsTipoPagamento = (row["dsTipoPagamento"]).ToString(),
                  
                };
            }

        }

        public IEnumerable<TipoPagamento> ListarTodos()
        {
            throw new NotImplementedException();
        }

        
     
    }
}
