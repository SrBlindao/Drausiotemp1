using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Negocio;
using ObjetoTransferencia;

namespace Apresentacao
{
    public partial class FrmClienteSelecionar : Form
    {
        public FrmClienteSelecionar()
        {
            InitializeComponent();
            dataGridViewPrincipal.AutoGenerateColumns = false;
        }

        private void buttonPesquisar_Click(object sender, EventArgs e)
        {
            AtualizarGrid();
        }

        private void AtualizarGrid()
        {
            ClienteNegocios clienteNegocios = new ClienteNegocios();

            ClienteColecao clienteColecao = new ClienteColecao();
            clienteColecao = clienteNegocios.ConsultarPorNome(textBoxPesquisa.Text);

            dataGridViewPrincipal.DataSource = null;
            dataGridViewPrincipal.DataSource = clienteColecao;

            dataGridViewPrincipal.Update();
            dataGridViewPrincipal.Refresh();
        }

        private void buttonFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonExcluir_Click(object sender, EventArgs e)
        {
            //Verificar se tem algum registro selecionado
            if(dataGridViewPrincipal.SelectedRows.Count == 0)
            {
                MessageBox.Show("Nenhum cliente selecionado.");
                return;
            }

            //Perguntar se realmente quer excluir
            DialogResult resultado = MessageBox.Show("Tem certeza?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(resultado == DialogResult.No)
            {
                return;
            }

            //Pegar o cliete selecionado no grid
            Cliente clienteSelecionado = (dataGridViewPrincipal.SelectedRows[0].DataBoundItem as Cliente);

            //Instanciar a regra de negocio
            ClienteNegocios clienteNegocios = new ClienteNegocios();

            //Chama o metodo para excluir
            string retorno = clienteNegocios.Exluir(clienteSelecionado);

            //Verifica se excluiu com sucesso
            //Se o retorno for um numero e porque deu certo, senao e a mensagem de erro
            try
            {
                int idCliente = Convert.ToInt32(retorno);
                MessageBox.Show("Cliente excluido com sucesso.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                AtualizarGrid();
            }
            catch
            {

                MessageBox.Show("Nao foi possivel excluir. Detalhes: " + retorno, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonInserir_Click(object sender, EventArgs e)
        {
            //Instanciar o formulario de cadastro
            FrmClienteCadastrar frmClienteCadastrar = new FrmClienteCadastrar(AcaoNaTela.Inserir, null);
            DialogResult dialogResult = frmClienteCadastrar.ShowDialog();
            if(dialogResult == DialogResult.Yes)
            {
                AtualizarGrid();
            }
        }

        private void buttonAlterar_Click(object sender, EventArgs e)
        {
            //Verificar se tem algum registro selecionado
            if (dataGridViewPrincipal.SelectedRows.Count == 0)
            {
                MessageBox.Show("Nenhum cliente selecionado.");
                return;
            }

            //Pegar o cliete selecionado no grid
            Cliente clienteSelecionado = (dataGridViewPrincipal.SelectedRows[0].DataBoundItem as Cliente);

            //Instanciar o formulario de cadastro
            FrmClienteCadastrar frmClienteCadastrar = new FrmClienteCadastrar(AcaoNaTela.Alterar, clienteSelecionado);

            DialogResult dialogResult = frmClienteCadastrar.ShowDialog();
            if (dialogResult == DialogResult.Yes)
            {
                AtualizarGrid();
            }
        }

        private void buttonConsultar_Click(object sender, EventArgs e)
        {
            //Verificar se tem algum registro selecionado
            if (dataGridViewPrincipal.SelectedRows.Count == 0)
            {
                MessageBox.Show("Nenhum cliente selecionado.");
                return;
            }

            //Pegar o cliete selecionado no grid
            Cliente clienteSelecionado = (dataGridViewPrincipal.SelectedRows[0].DataBoundItem as Cliente);

            //Instanciar o formulario de cadastro
            FrmClienteCadastrar frmClienteCadastrar = new FrmClienteCadastrar(AcaoNaTela.Consultar, clienteSelecionado);
            frmClienteCadastrar.ShowDialog();
        }
    }
}
