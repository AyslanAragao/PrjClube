﻿using Clube.Dados;
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
    public class ParticipanteNegocio : Participante, IParticipanteNegocio
    {
        IParticipanteDados _participante;

        public ParticipanteNegocio()
        {
            _participante = new ParticipanteDados();

        }
        public void Atualizar(Participante item)
        {
            _participante.Atualizar(item);
        }

        public void Cadastrar(Participante item)
        {
            _participante.Cadastrar(item);
        }

        public IEnumerable<Participante> ConsultarTodos()
        {
           return _participante.ConsultarTodos();
        }

        public Participante ConsultarPorID(int id)
        {
            return _participante.ConsultarPorID(id);
        }

        public IEnumerable<Participante> ConsultarNegocio(Participante item)
        {
            if (!string.IsNullOrEmpty(item.periodoDtCadastro) && !item.periodoDtCadastro.Contains("-"))
                item.periodoDtCadastro  += " - " + item.periodoDtCadastro;

            if (string.IsNullOrEmpty(item.periodoDtCadastro))
                item.periodoDtCadastro = " - ";

            if (!string.IsNullOrEmpty(item.periodoDtEntrada) && !item.periodoDtEntrada.Contains("-"))
                item.periodoDtEntrada += " - " + item.periodoDtEntrada;

            if (string.IsNullOrEmpty(item.periodoDtEntrada))
                item.periodoDtEntrada = " - ";

            return _participante.ConsultarDados(item);
        }

        public void Deletar(int id)
        {
            _participante.Deletar(id);
        }
    }
}
