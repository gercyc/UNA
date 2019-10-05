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
    public partial class FrmEditarProduto : Form
    {
        private DataRow focusedRow;
        //acao do formulario. Padrao = E (Edição)
        string Action = "E";


        public FrmEditarProduto()
        {
            InitializeComponent();
            IndexCombos();
        }

        public FrmEditarProduto(DataRow focusedRow, string action = "E") : this()
        {
            this.focusedRow = focusedRow;
            this.Action = action;
            IndexForm(focusedRow);
        }

        private void IndexForm(DataRow focusedRow)
        {
            //definindo os valores que serao exibidos no formulario de acordo com o produto selecionado
            txtCodProduto.Text = focusedRow["CodigoProduto"].ToString();
            txtDescProduto.Text = focusedRow["DescricaoProduto"].ToString();
            txtNcm.Text = focusedRow["Ncm"].ToString();
            cbUnMedida.Text = focusedRow["CodUnidadeMedida"].ToString();
            cbCategoria.Text = focusedRow["DescricaoCategoria"].ToString();
        }
        private void IndexCombos()
        {
            //carregando valores  nos combos do formulario
            cbUnMedida.DataSource = Program.ServerAccess.Select("UnidadeMedida", "SELECT IdUnidadeMedida, CodUnidadeMedida from UnidadeMedida", null);
            cbUnMedida.ValueMember = "IdUnidadeMedida";
            cbUnMedida.DisplayMember = "CodUnidadeMedida";

            cbCategoria.DataSource = Program.ServerAccess.Select("CategoriaProduto", "SELECT IdCategoria, DescricaoCategoria from CategoriaProduto", null);
            cbCategoria.ValueMember = "IdCategoria";
            cbCategoria.DisplayMember = "DescricaoCategoria";
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            //se o produto não for valido, ou seja algum campo em branco,
            //exibe a mensagem ao usuario para efetuar a correcao
            if (!IsValid())
            {
                MessageBox.Show("Preencha todos os campos!!!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //edicao
            if (focusedRow != null && Action == "E")
            {
                //produto que sera editado
                int currentId = (int)focusedRow["IdProduto"];

                //nova lista de parametros
                ParameterList pList = new ParameterList();
                //adicionando parametros à lista
                pList.Add(new SqlParameter("@IdProduto", currentId));
                pList.Add(new SqlParameter("@CodigoProduto", txtCodProduto.Text));
                pList.Add(new SqlParameter("@DescricaoProduto", txtDescProduto.Text));
                pList.Add(new SqlParameter("@Ncm", txtNcm.Text));
                pList.Add(new SqlParameter("@IdUnidadeMedida", ((DataRowView)cbUnMedida.SelectedItem)[0]));
                pList.Add(new SqlParameter("@IdCategoria", ((DataRowView)cbCategoria.SelectedItem)[0]));

                //atualizando a o produto que foi editado (DataRow em memoria)
                focusedRow["CodigoProduto"] = txtCodProduto.Text;
                focusedRow["DescricaoProduto"] = txtDescProduto.Text;
                focusedRow["Ncm"] = txtNcm.Text;
                focusedRow["IdUnidadeMedida"] = ((DataRowView)cbUnMedida.SelectedItem)[0];
                focusedRow["CodUnidadeMedida"] = cbUnMedida.Text;
                focusedRow["IdCategoria"] = ((DataRowView)cbCategoria.SelectedItem)[0];
                focusedRow["DescricaoCategoria"] = cbCategoria.Text;

                //comando de update
                string queryUpdate = @"UPDATE dbo.Produtos 
                                        SET
                                          CodigoProduto = @CodigoProduto
                                         ,DescricaoProduto = @DescricaoProduto
                                         ,Ncm = Ncm
                                         ,IdUnidadeMedida = @IdUnidadeMedida
                                         ,IdCategoria = @IdCategoria
                                        WHERE
                                          IdProduto = @IdProduto";

                //executando o comando, mandando junto a lista de parametros
                Program.ServerAccess.ExecuteScalar(queryUpdate, pList);
                MessageBox.Show("Produto atualizado");
                this.Dispose();
            }
            else
            {
                //se a acao foi diferente de E, (I  = Inclusao)

                //comando de inserção
                string _sqlInsert = @"INSERT INTO Produtos (CodigoProduto, DescricaoProduto, Ncm, IdUnidadeMedida, IdCategoria)
  VALUES (@CodigoProduto, @DescricaoProduto, @Ncm, @IdUnidadeMedida, @IdCategoria)";

                //criando nova lista de parametros e adicionando
                ParameterList pList = new ParameterList();
                pList.Add(new SqlParameter("@CodigoProduto", txtCodProduto.Text));
                pList.Add(new SqlParameter("@DescricaoProduto", txtDescProduto.Text));
                pList.Add(new SqlParameter("@Ncm", txtNcm.Text));
                pList.Add(new SqlParameter("@IdUnidadeMedida", ((DataRowView)cbUnMedida.SelectedItem)[0]));
                pList.Add(new SqlParameter("@IdCategoria", ((DataRowView)cbCategoria.SelectedItem)[0]));

                //executando o comando no SGBD
                Program.ServerAccess.ExecuteScalar(_sqlInsert, pList);
                MessageBox.Show("Produto inserido");
                //terminou com sucesso? fecha a tela
                this.Dispose();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //fecha a tela
            this.Dispose();
        }

        /// <summary>
        /// Verifica se o produto que está sendo inserido é valido.
        /// Todos os campos são obrigatorios
        /// </summary>
        /// <returns></returns>
        private bool IsValid()
        {
            return txtCodProduto.Text.Length > 0
                && txtDescProduto.Text.Length > 0
                && txtNcm.Text.Length > 0
                && cbCategoria.SelectedItem != null
                && cbUnMedida.SelectedItem != null;
        }
    }
}
