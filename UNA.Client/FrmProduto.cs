using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UNA.DataAccess;

namespace UNA.Client
{
    public partial class FrmProduto : Form
    {
        //query principal
        string Query = @"SELECT
  p.IdProduto
 ,p.CodigoProduto
 ,p.DescricaoProduto
 ,p.Ncm
 ,p.IdUnidadeMedida
 ,Un.CodUnidadeMedida
 ,p.IdCategoria
 ,c.DescricaoCategoria
FROM Produtos p
JOIN UnidadeMedida Un
  ON p.IdUnidadeMedida = Un.IdUnidadeMedida
JOIN CategoriaProduto c
  ON p.IdCategoria = c.IdCategoria";

        public FrmProduto()
        {
            InitializeComponent();
            //para não gerar as colunas no grid, pois as mesmas foram definidas no modo DESIGN
            gridProdutos.AutoGenerateColumns = false;
        }

        private void FrmProduto_Load(object sender, EventArgs e)
        {
            //chamada do metodo de obter os produtos
            btnRefresh_Click(null, null);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            //define a fonte de dados do grid de produtos.
            //o 1º parametro é o nome da tabela, em seguida a consulta SQL que sera executada.
            //como a busca é para listar todos os produtos, o 3º parametro foi enviado um 'null'
            gridProdutos.DataSource = Program.ServerAccess.Select("Produtos", Query, null);
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            //criando a classe de parametro e adicionando um parametro, com nome e valor
            ParameterList pList = new ParameterList();
            pList.Add(new SqlParameter("@CodigoProduto", txtNumChamado.Text));
            //redefinindo a fonte de dados do grid com os produtos encontrados na busca, concatentando uma condicao
            gridProdutos.DataSource = Program.ServerAccess.Select("Produtos", Query + " WHERE CodigoProduto like @CodigoProduto", pList);
        }

        //evento que acontecera quandoo usuario clicar 2x em alguma linha do grid
        private void gridProdutos_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //obtendo a linha atual
            DataRow focusedRow = ((DataTable)gridProdutos.DataSource).Rows[e.RowIndex];
            //criando nova instancia do formulario de edicao/inclusao
            FrmEditarProduto frmEditarProduto = new FrmEditarProduto(focusedRow);
            //exibindo o form
            frmEditarProduto.ShowDialog();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            DataRow newRow = ((DataTable)gridProdutos.DataSource).NewRow();
            //criando nova instancia do formulario de edicao/inclusao
            //passando um 2º parametro que é a acao da tela. I = Inclusão
            FrmEditarProduto frmEditarProduto = new FrmEditarProduto(newRow, "I");
            //exibindo o form
            frmEditarProduto.ShowDialog();
            
            //depois que o produto foi criado, é necessário "pegar" esse novo produto
            //que é um DataRow (newRow) e adiciona-lo a fonte de dados do grid, sem precisar ir ao BD novamente
            ((DataTable)gridProdutos.DataSource).ImportRow(newRow);
            //atualizando a visao do grid
            gridProdutos.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (gridProdutos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione a linha que deseja excluir!!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show("Certeza que deseja excluir o registro?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (dr == DialogResult.Yes)
            {
                //obtendo a linha atual
                var focusedGridRow = gridProdutos.SelectedRows[0];
                DataRow focusedRow = ((DataTable)gridProdutos.DataSource).Rows[focusedGridRow.Index];

                //query de deleção
                string _sqlDelete = "DELETE FROM PRODUTOS WHERE IdProduto = @IdProduto";
                //criando nova lista de parametros
                ParameterList pList = new ParameterList();
                pList.Add(new SqlParameter("@IdProduto", focusedRow["IdProduto"]));

                //depois que o produto foi removido, é necessário remover esse produto
                //que é um DataRow (focusedRow) da fonte de dados do grid, sem precisar ir ao BD novamente
                Program.ServerAccess.ExecuteScalar(_sqlDelete, pList);
                ((DataTable)gridProdutos.DataSource).Rows.Remove(focusedRow);

                //atualizando a visao do grid
                gridProdutos.Refresh();

                MessageBox.Show("Produto excluido com sucesso");
            }
        }
    }
}
