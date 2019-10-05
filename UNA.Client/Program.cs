using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UNA.DataAccess;

namespace UNA.Client
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmProduto());
        }
        /// <summary>
        /// Já deixando um objeto de conexao exposto para toda a aplicação. 
        /// *** PRÁTICA NÃO RECOMENDADA, USADO PARA FINS DIDÁTICOS ***
        /// Existem N maneiras de fazer isso e com melhores práticas:
        /// </summary>
        public static IServerAccess ServerAccess = new MssqlDataAccess("Data Source = (local); Initial Catalog = UnaAds; Trusted_Connection = True;");

    }
}
