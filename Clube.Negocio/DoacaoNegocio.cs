using Clube.Dados;
using Clube.Dados.Interface;
using Clube.Modelo.Modelo;
using Clube.Negocio.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clube.Negocio
{
    public class DoacaoNegocio : Doacao, IDoacaoNegocio
    {
        IDoacaoDados _dados;
        IDoacaoParcelaDados _doacaoParcela;

        public DoacaoNegocio()
        {
            _dados = new DoacaoDados();
            _doacaoParcela = new DoacaoParcelaDados();

        }
        public void Atualizar(Doacao item)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Doacao item)
        {
            _dados.Cadastrar(item);
        }

        public IEnumerable<Doacao> ConsultarTodos()
        {
            var doacoes = _dados.ConsultarTodos();

            for (int i = 0; i < doacoes.Count(); i++)
            {
                if (doacoes.ToList()[i].nrParcelas > 1)
                {
                    DoacaoParcela dp = new DoacaoParcela();
                    dp.cdLancamento = doacoes.ToList()[i].cdLancamento;
                    var parcela = _doacaoParcela.ConsultarDados(dp);
                    doacoes.ToList()[i].parcelas = parcela.ToList();

                }
            }
            return doacoes;
        }

        public Doacao ConsultarPorID(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Doacao> ConsultarNegocio(Doacao item)
        {
            if (!string.IsNullOrEmpty(item.periodoDtDoacao) && !item.periodoDtDoacao.Contains("-"))
                item.periodoDtDoacao += " - " + item.periodoDtDoacao;

            if (string.IsNullOrEmpty(item.periodoDtDoacao))
                item.periodoDtDoacao = " - ";

            return _dados.ConsultarDados(item);
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DoacaoParcela> ConsultarTodasParcelasPorID(int id)
        {
            return _doacaoParcela.ConsultarTodasParcelasPorID(id);
        }

    }
}
