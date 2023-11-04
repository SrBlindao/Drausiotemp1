using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ObjetoTransferencia;
using Negocio;

namespace Apresentacao
{
    public partial class FrmClienteCadastrar : Form
    {
        AcaoNaTela acaoNaTelaSelecionada;

        //construtor
        public FrmClienteCadastrar(AcaoNaTela acaoNaTela, Cliente cliente)
        {
            InitializeComponent();

            this.acaoNaTelaSelecionada = acaoNaTela;

            if(acaoNaTela == AcaoNaTela.Inserir)
            {
                this.Text = "Inserir Cliente";
            }

            else if(acaoNaTela == AcaoNaTela.Alterar)
            {
                this.Text = "Alterar Cliente";
                textBoxCodigo.Text = cliente.IdCliente.ToString();
                textBoxNome.Text = cliente.Nome;
                dateDataNascimento.Value = cliente.DataNascimento;
                if(cliente.Sexo == true)
                {
                    radioSexoMasculino.Checked = true;
                }

                else
                
                    radioSexoFeminino.Checked = true;

                textBoxLimiteCompra.Text = cliente.LimiteCompra.ToString();
                
            }

            else if(acaoNaTela == AcaoNaTela.Consultar)
            {   
                //Carregar campos da tela
                this.Text = "Consultar Cliente";
                textBoxCodigo.Text = cliente.IdCliente.ToString();
                textBoxNome.Text = cliente.Nome;
                dateDataNascimento.Value = cliente.DataNascimento;
                if (cliente.Sexo == true)
                {
                    radioSexoMasculino.Checked = true;
                }

                else

                    radioSexoFeminino.Checked = true;

                textBoxLimiteCompra.Text = cliente.LimiteCompra.ToString();

                //Desabilitar campos da tela
                textBoxNome.ReadOnly = true;
                textBoxNome.TabStop = false;

                dateDataNascimento.Enabled = false;

                radioSexoMasculino.Enabled = false;
                radioSexoFeminino.Enabled = false;

                textBoxLimiteCompra.ReadOnly = true;
                textBoxLimiteCompra.TabStop = false;

                buttonSalvar.Visible = false;
                buttonCancelar.Text = "Fechar";

                buttonCancelar.Focus();
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            //Verificar se e insercao ou alteracao
            if(acaoNaTelaSelecionada == AcaoNaTela.Inserir)
            {
                Cliente cliente = new Cliente();
                cliente.Nome = textBoxNome.Text;
                cliente.DataNascimento = dateDataNascimento.Value;
                if (radioSexoMasculino.Checked == true)
                    cliente.Sexo = true;
                else
                    cliente.Sexo = false;

                cliente.LimiteCompra = Convert.ToDecimal(textBoxLimiteCompra.Text);

                ClienteNegocios clienteNegocios = new ClienteNegocios();

                string retorno = clienteNegocios.Inserir(cliente);

                //Tenta converter para inteiro
                //Se der tudo certo e porque devolveu o codigo do cliente
                //Se der errado tem a mensagem de erro

                try
                {
                    int idCliente = Convert.ToInt32(retorno);
                    MessageBox.Show("Cliente inserido com sucesso. Codigo:" + idCliente.ToString());

                    this.DialogResult = DialogResult.Yes;
                }
                catch
                {
                    MessageBox.Show("Nao foi possivel inserir. Detalhes: " + retorno, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    this.DialogResult = DialogResult.No;
                }

            }

            else if (acaoNaTelaSelecionada == AcaoNaTela.Alterar)
            {       
                    //Crio um cliente
                    Cliente cliente = new Cliente();

                    //Coloco os campos da tela no objeto cliente, e envio para alterar no banco
                    cliente.IdCliente = Convert.ToInt32(textBoxCodigo.Text);

                    cliente.Nome = textBoxNome.Text;
                    cliente.DataNascimento = dateDataNascimento.Value;
                    if (radioSexoMasculino.Checked == true)
                        cliente.Sexo = true;
                    else
                        cliente.Sexo = false;

                    cliente.LimiteCompra = Convert.ToDecimal(textBoxLimiteCompra.Text);

                    ClienteNegocios clienteNegocios = new ClienteNegocios();

                    string retorno = clienteNegocios.Alterar(cliente);

                    //Tenta converter para inteiro
                    //Se der tudo certo e porque devolveu o codigo do cliente
                    //Se der errado tem a mensagem de erro

                    try
                    {
                        int idCliente = Convert.ToInt32(retorno);
                        MessageBox.Show("Cliente alterado com sucesso. Codigo:" + idCliente.ToString());

                        this.DialogResult = DialogResult.Yes;
                    }
                    catch
                    {
                        MessageBox.Show("Nao foi possivel alterar. Detalhes: " + retorno, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        this.DialogResult = DialogResult.No;
                    }
            }
        }
    }
}
