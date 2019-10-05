using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNA.DataAccess
{
    /// <summary>
    /// Uma classe que é uma Lista de Parametros que serão considerados pelas consultas
    /// </summary>
    public class ParameterList : List<IDbDataParameter>
    {
        public ParameterList()
        {

        }
    }
}
