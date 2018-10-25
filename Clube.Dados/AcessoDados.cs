using Clube.Dados.Interface;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Clube.Dados
{
    public class AcessoDados : IAcessoDados
    {

        private SqlCommand Cmd;
        private SqlConnection Con;
        private bool manterConexaoAberta;
        private string chaveConexao;
        private string nomeProcedure;
        private string stringConexao;
        private int? timeOut;
        private bool iniciarTransacao;
        private int linhasAfetadas;
        private SqlTransaction transacao;
        private bool comandoSql;

        public SqlParameterCollection Parametros
        {
            get { return this.Cmd.Parameters; }
        }

        #region EnumConexao
        public enum Conexao
        {
            ABERTA
        }
        #endregion

        #region Construtores
        public AcessoDados()
        {
            this.chaveConexao = "StringConexao";
            this.Inicializar();
            this.manterConexaoAberta = false;
        }

        public AcessoDados(Conexao manterConexao)
        {
            this.chaveConexao = "StringConexao";
            this.manterConexaoAberta = manterConexao == Conexao.ABERTA;
            this.Inicializar();
        }
        #endregion

        #region InicializaConexao
        private void Inicializar()
        {
            this.nomeProcedure = String.Empty;
            this.stringConexao = String.Empty;
            this.timeOut = null;
            this.Con = new SqlConnection();
            this.Cmd = new SqlCommand();
            if (ConfigurationManager.ConnectionStrings.Count > 0)
            {
                this.stringConexao = ConfigurationManager.ConnectionStrings[chaveConexao].ConnectionString;

            }
        }
        #endregion

        #region ConexãoBanco
        private void ConexaoBanco(bool Condicao)
        {
            if (Condicao)
            {
                if (this.Con.State == ConnectionState.Closed)
                {
                    this.Con.ConnectionString = this.stringConexao;
                    if (this.timeOut.HasValue)
                    {
                        this.Cmd.CommandTimeout = Convert.ToInt32(this.timeOut);
                    }
                    this.Con.Open();
                    if (this.iniciarTransacao)
                    {
                        this.transacao = this.Con.BeginTransaction();
                        this.Cmd.Transaction = this.transacao;
                    }
                }
            }
            else if ((this.Con.State == ConnectionState.Open) && !this.manterConexaoAberta)
            {
                this.Con.Close();
                this.Con.Dispose();
            }
        }
        #endregion

        #region GetDataTable
        public DataTable GetDataTable(string nomeProcedure)
        {
            DataTable table = new DataTable();
            try
            {
                this.Cmd.CommandText = nomeProcedure;
                this.Cmd.CommandType = CommandType.StoredProcedure;
                this.Cmd.Connection = this.Con;
                this.ConexaoBanco(true);

                SqlDataAdapter da = new SqlDataAdapter(Cmd);
                //DataSet ds = new DataSet();
                //da.Fill(ds);
                da.Fill(table);
            }
            catch (SqlException sex)
            {
                if (this.iniciarTransacao)
                {
                    this.transacao.Rollback();
                }
                //throw new Exception(TUtilSFB.RetornaErroOracle(sex));
                throw sex;
            }
            catch (Exception exception)
            {
                if (this.iniciarTransacao)
                {
                    this.transacao.Rollback();
                }
                throw new Exception("Não foi possível retornar o DataTable! Mensagem de Erro: " + exception.Message.ToString());
            }
            finally
            {
                this.ConexaoBanco(false);
            }
            return table;
        }
        #endregion

        #region GetUnicoRegistro
        public object GetUnicoRegistro()
        {
            object obj3;
            try
            {
                this.Cmd.CommandText = this.nomeProcedure;
                this.Cmd.Connection = this.Con;
                this.ConexaoBanco(true);
                if (!this.comandoSql)
                {
                    this.Cmd.CommandType = CommandType.StoredProcedure;
                }
                obj3 = this.Cmd.ExecuteScalar();
            }
            catch (SqlException sex)
            {
                if (this.iniciarTransacao)
                {
                    this.transacao.Rollback();
                }
                //throw new Exception(TUtilSFB.RetornaErroOracle(sex));
                throw sex;
            }
            catch (Exception exception)
            {
                if (this.iniciarTransacao)
                {
                    this.transacao.Rollback();
                }
                throw new Exception("Não foi possível retornar um único registro. Mensagem de Erro: " + exception.Message.ToString());
            }
            finally
            {
                this.ConexaoBanco(false);
            }
            return obj3;
        }
        #endregion

        #region RetornaUnicoRegistro string nomeProcedure)
        public object GetUnicoRegistro(string nomeProcedure)
        {
            this.nomeProcedure = nomeProcedure;
            return this.GetUnicoRegistro();
        }
        #endregion

        #region ExecutaProcedimento
        public void ExecProcedure()
        {
            try
            {
                this.Cmd.CommandText = this.nomeProcedure;
                this.Cmd.Connection = this.Con;
                this.ConexaoBanco(true);
                if (!this.comandoSql)
                {
                    this.Cmd.CommandType = CommandType.StoredProcedure;
                }
                this.linhasAfetadas = this.Cmd.ExecuteNonQuery();
            }
            catch (SqlException sex)
            {
                if (this.iniciarTransacao)
                {
                    this.transacao.Rollback();
                }
                //throw new Exception(TUtilSFB.RetornaErroOracle(sex));
                throw sex;
            }
            catch (Exception exception)
            {
                if (this.iniciarTransacao)
                {
                    this.transacao.Rollback();
                }
                throw new Exception("Não foi possível executar a Procedure. Mensagem de Erro: " + exception.Message.ToString());
            }
            finally
            {
                this.ConexaoBanco(false);
            }
        }
        #endregion

        #region ExecutaProcedimento
        public void ExecProcedure(string nomeProcedure)
        {
            this.nomeProcedure = nomeProcedure;
            this.ExecProcedure();
        }
        #endregion

        #region Parametros

        #region AdicionaParametro (string nomeParametro, object valor)
        /// </summary>
        /// <param name="nomeParametro">(disrection parametro fixo como input)</param>
        /// <param name="valor">(disrection parametro fixo como input)</param>
        public void AddParametro(string nomeParametro, object valor)
        {
            try
            {
                //limpar nomeParametro quando da chamada do Oracle, agora SQL...
                //Se no inicio tem um ":"
                nomeParametro = nomeParametro.Replace(":", "").Replace(";", "");
                //acrescentar "@" no inicio se não tiver... (Conversao Oracle...)
                if (nomeParametro.Length >= 1)
                {
                    if (nomeParametro.Substring(0, 1) != "@")
                    {
                        nomeParametro = "@" + nomeParametro;
                    }
                }
                SqlParameter parameter = new SqlParameter(nomeParametro, valor);
                parameter.Size = 20000;
                parameter.Direction = ParameterDirection.Input;

                Cmd.Parameters.Add(parameter);
            }
            catch (SqlException sex)
            {
                if (this.iniciarTransacao)
                {
                    this.transacao.Rollback();
                }
                //throw new Exception(TUtilSFB.RetornaErroOracle(sex));
                throw sex;

            }
            catch (Exception exception)
            {
                if (this.iniciarTransacao)
                {
                    this.transacao.Rollback();
                }
                throw new Exception("Parametro incorreto! Mensagem de Erro:" + exception.Message.ToString());
            }
        }
        #endregion

        #region AdicionaParametro (string nomeParametro, object valor, ParameterDirection direction)
        public void AddParametro(string nomeParametro, object valor, ParameterDirection direction)
        {
            try
            {
                //limpar nomeParametro quando da chamada do Oracle, agora SQL...
                //Se no inicio tem um ":"
                nomeParametro = nomeParametro.Replace(":", "").Replace(";", "");
                //acrescentar "@" no inicio se não tiver... (Conversao Oracle...)
                if (nomeParametro.Length >= 1)
                {
                    if (nomeParametro.Substring(0, 1) != "@")
                    {
                        nomeParametro = "@" + nomeParametro;
                    }
                }

                SqlParameter parameter = new SqlParameter(nomeParametro, valor);
                parameter.Size = 20000;
                //if (directionInput)
                //{
                //    parameter.Direction = ParameterDirection.Input;
                //}
                //else
                //{
                //    parameter.Direction = ParameterDirection.Output;
                //}
                parameter.Direction = direction;

                Cmd.Parameters.Add(parameter);
            }
            catch (SqlException sex)
            {
                if (this.iniciarTransacao)
                {
                    this.transacao.Rollback();
                }
                //throw new Exception(TUtilSFB.RetornaErroOracle(sex));
                throw sex;

            }
            catch (Exception exception)
            {
                if (this.iniciarTransacao)
                {
                    this.transacao.Rollback();
                }
                throw new Exception("Parametro incorreto! Mensagem de Erro:" + exception.Message.ToString());
            }
        }
        #endregion

        #region AdicionaParametro (string nomeParametro, SqlDbType tipoParametro, ParameterDirection direcao)
        public void AddParametro(string nomeParametro, SqlDbType tipoParametro, ParameterDirection direcao)
        {
            try
            {
                //limpar nomeParametro quando da chamada do Oracle, agora SQL...
                //Se no inicio tem um ":"
                nomeParametro = nomeParametro.Replace(":", "").Replace(";", "");
                //acrescentar "@" no inicio se não tiver... (Conversao Oracle...)
                if (nomeParametro.Length >= 1)
                {
                    if (nomeParametro.Substring(0, 1) != "@")
                    {
                        nomeParametro = "@" + nomeParametro;
                    }
                }
                SqlParameter parameter = new SqlParameter(nomeParametro, tipoParametro);
                parameter.Size = 20000;
                parameter.Direction = direcao;

                Cmd.Parameters.Add(parameter);
            }
            catch (SqlException sex)
            {
                if (this.iniciarTransacao)
                {
                    this.transacao.Rollback();
                }
                //throw new Exception(TUtilSFB.RetornaErroOracle(sex));
                throw sex;

            }
            catch (Exception exception)
            {
                if (this.iniciarTransacao)
                {
                    this.transacao.Rollback();
                }
                throw new Exception("Parametro incorreto! Mensagem de Erro:" + exception.Message.ToString());
            }
        }
        #endregion

        #region AdicionaParametro (string nomeParametro, SqlDbType tipoParametro, object valor)
        public void AddParametro(string nomeParametro, SqlDbType tipoParametro, object valor)
        {
            try
            {
                //limpar nomeParametro quando da chamada do Oracle, agora SQL...
                //Se no inicio tem um ":"
                nomeParametro = nomeParametro.Replace(":", "").Replace(";", "");
                //acrescentar "@" no inicio se não tiver... (Conversao Oracle...)
                if (nomeParametro.Length >= 1)
                {
                    if (nomeParametro.Substring(0, 1) != "@")
                    {
                        nomeParametro = "@" + nomeParametro;
                    }
                }
                SqlParameter parameter = new SqlParameter(nomeParametro, tipoParametro);
                parameter.Value = valor;
                Cmd.Parameters.Add(parameter);
            }
            catch (SqlException sex)
            {
                if (this.iniciarTransacao)
                {
                    this.transacao.Rollback();
                }
                //throw new Exception(TUtilSFB.RetornaErroOracle(sex));
                throw sex;

            }
            catch (Exception exception)
            {
                if (this.iniciarTransacao)
                {
                    this.transacao.Rollback();
                }
                throw new Exception("Parametro incorreto! Mensagem de Erro:" + exception.Message.ToString());
            }
        }
        #endregion

        #region AdicionaParametro (string nomeParametro, SqlDbType tipoParametro, object valor, ParameterDirection direcao)
        public void AddParametro(string nomeParametro, SqlDbType tipoParametro, object valor, ParameterDirection direcao)
        {
            try
            {
                //limpar nomeParametro quando da chamada do Oracle, agora SQL...
                //Se no inicio tem um ":"
                nomeParametro = nomeParametro.Replace(":", "").Replace(";", "");
                //acrescentar "@" no inicio se não tiver... (Conversao Oracle...)
                if (nomeParametro.Length >= 1)
                {
                    if (nomeParametro.Substring(0, 1) != "@")
                    {
                        nomeParametro = "@" + nomeParametro;
                    }
                }
                SqlParameter parameter = new SqlParameter(nomeParametro, tipoParametro);
                parameter.Value = valor;
                parameter.Direction = direcao;

                Cmd.Parameters.Add(parameter);

            }
            catch (SqlException sex)
            {
                if (this.iniciarTransacao)
                {
                    this.transacao.Rollback();
                }
                //throw new Exception(TUtilSFB.RetornaErroOracle(sex));
                throw sex;
            }
            catch (Exception exception)
            {
                if (this.iniciarTransacao)
                {
                    this.transacao.Rollback();
                }
                throw new Exception("Parametro incorreto! Mensagem de Erro:" + exception.Message.ToString());
            }
        }
        #endregion

        #endregion

    }

}
