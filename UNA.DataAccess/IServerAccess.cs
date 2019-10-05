using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNA.DataAccess
{
 
    /// <summary>
    /// Interface que define os métodos que serão expostos na classe concreta.
    /// </summary>
    public interface IServerAccess
    {
        /// <summary>
        /// Executa um comando SELECT no banco de dados
        /// </summary>
        /// <param name="_tableName"></param>
        /// <param name="_sqlQuery"></param>
        /// <param name="_parameterCollection"></param>
        /// <returns></returns>
        DataTable Select(string _tableName, string _sqlQuery, ParameterList _parameterCollection);
        
        /// <summary>
        /// Executa um comando de manipulação no banco. (Ex: UPDATE, DELETE, INSERT)
        /// Retorna a primeira coluna da primeira linha OU a quantidade de linhas afetadas.
        /// </summary>
        /// <param name="_sqlQuery"></param>
        /// <param name="_parameterCollection"></param>
        /// <param name="_commandType"></param>
        /// <returns></returns>
        object ExecuteScalar(string _sqlQuery, ParameterList _parameterCollection, CommandType _commandType = CommandType.Text);
    }
}
