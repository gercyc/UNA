using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNA.DataAccess
{
    public class MssqlDataAccess : IServerAccess
    {
        #region Private declarations
        //conexao a ser utilizada nos metodos da classe
        private SqlConnection _connection;

        #endregion

        #region Public properties

        public string ConnectionString { get; private set; }
        #endregion

        public MssqlDataAccess(string _connectionString)
        {
            //instanciando novo objeto SqlConnection
            _connection = new SqlConnection(_connectionString);

            //atribuindo o valor da connectionString publica que a classe possui
            ConnectionString = _connectionString;
        }


        #region IServerAccesss members
 
        public DataTable Select(string _tableName, string _sqlQuery, ParameterList _parameterCollection)
        {
            try
            {
                OpenConnection();
                //criando o SqlCommand, ja enviando a conexao como parametro
                SqlCommand dbCommand = new SqlCommand(_sqlQuery, _connection);
                dbCommand.CommandType = CommandType.Text;
                dbCommand.CommandTimeout = 90;

                //se o usuario enviou uma lista de parametros, percorra e adione os parametros ao SqlCommand
                if (_parameterCollection != null)
                {
                    foreach (var parameter in _parameterCollection)
                    {

                        dbCommand.Parameters.AddWithValue(((IDbDataParameter)parameter).ParameterName, ((IDbDataParameter)parameter).Value);
                    }
                }
                //carrega o comando para um sql data adapter
                SqlDataAdapter dataAdapter = new SqlDataAdapter(dbCommand);
                //cria um novo datatable
                DataTable tableResult = new DataTable(_tableName);
                //preenche o datatable com os dados do data adapter
                dataAdapter.Fill(tableResult);
                return tableResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //sempre fechar a conexao
                CloseConnection();
            }
        }

        public object ExecuteScalar(string _sqlQuery, ParameterList _parameterCollection, CommandType _commandType = CommandType.Text)
        {
            try
            {
                OpenConnection();
                SqlCommand dbCommand = new SqlCommand(_sqlQuery, _connection);
                //definindo o tipo de comando (query ou procedure
                dbCommand.CommandType = _commandType;
                dbCommand.CommandTimeout = 90;

                //se o usuario enviou uma lista de parametros, percorra e adione os parametros ao SqlCommand
                if (_parameterCollection != null)
                {
                    foreach (var parameter in _parameterCollection)
                    {

                        dbCommand.Parameters.AddWithValue(((IDbDataParameter)parameter).ParameterName, ((IDbDataParameter)parameter).Value);
                    }
                }

                //execute scalar: retorna a primeira linha da primeira coluna de uma consulta ou a quantidade de registros afetados
                return dbCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //sempre fechar a conexao
                CloseConnection();
            }
        }
        #endregion
        //metodo para fechar a conexao (variavel _connection desta classe)
        internal void CloseConnection()
        {
            try
            {
                if (_connection.State == ConnectionState.Open)
                    _connection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //metodo para abrir a conexao (variavel _connection desta classe)
        internal void OpenConnection()
        {
            try
            {
                if (_connection.State == ConnectionState.Closed)
                    _connection.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
