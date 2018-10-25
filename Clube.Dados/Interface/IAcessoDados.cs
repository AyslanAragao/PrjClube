
using System.Data;
using System.Data.SqlClient;

namespace Clube.Dados.Interface
{
    public interface IAcessoDados
    {
        SqlParameterCollection Parametros
        {
            get;
        }

        object GetUnicoRegistro();

        DataTable GetDataTable(string nomeProcedure);

        void AddParametro(string nomeParametro, object valor);

        object GetUnicoRegistro(string nomeProcedure);

        void AddParametro(string nomeParametro, SqlDbType tipoParametro, object valor);

        void AddParametro(string nomeParametro, SqlDbType tipoParametro, ParameterDirection direcao);

        void AddParametro(string nomeParametro, SqlDbType tipoParametro, object valor, ParameterDirection direcao);

        void ExecProcedure(string nomeProcedure);


    }

}

