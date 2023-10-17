using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcessoBancoDados;
using ObjetoTransferencia;
using System.Data;

namespace Negocio
{
    public class ClienteNegocios
    {
        //Instanciar = Criar um novo objeto baseado em um modelo
        AcessoDadosSqlServer acessoDadosSqlServer = new AcessoDadosSqlServer();

        public string Inserir(Cliente cliente)
        {
            try
            {
                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@Nome", cliente.Nome);
                acessoDadosSqlServer.AdicionarParametros("DataNascimento", cliente.DataNascimento);
                acessoDadosSqlServer.AdicionarParametros("@Sexo", cliente.Sexo);
                acessoDadosSqlServer.AdicionarParametros("@LimiteCompra", cliente.LimiteCompra);
                string idCliente = acessoDadosSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspClienteInserir").ToString();
                return idCliente;
            }
            catch (Exception excepetion)
            {

                return excepetion.Message;
            }
            
        }

        public string Alterar(Cliente cliente)
        {
            try
            {
                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("IdCliente", cliente.IdCliente);
                acessoDadosSqlServer.AdicionarParametros("@Nome", cliente.Nome);
                acessoDadosSqlServer.AdicionarParametros("DataNascimento", cliente.DataNascimento);
                acessoDadosSqlServer.AdicionarParametros("@Sexo", cliente.Sexo);
                acessoDadosSqlServer.AdicionarParametros("@LimiteCompra", cliente.LimiteCompra);
                string idCliente = acessoDadosSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspClienteAlterar").ToString();
                return idCliente;
            }
            catch (Exception exception)
            {

                return exception.Message;
            }

        }

        public string Exluir(Cliente cliente)
        {
            try
            {
                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@IdCliente", cliente.IdCliente);
                string idCliente = acessoDadosSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspClienteExcluir").ToString();
                return idCliente;
            }
            catch (Exception excepetion)
            {

                return excepetion.Message;
            }
        }

        public ClienteColecao ConsultarPorNome(string nome)
        {
            try
            {
                //Criar uma colecao nova de clientes (aqui ela esta vazia)
                ClienteColecao clienteColecao = new ClienteColecao();

                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@Nome", nome);

                //DataTable - Data = dados e Table = tabela
                DataTable dataTableCliente = acessoDadosSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspClienteConsultarPorNome");

                //Percorrer o DataTable e transformar em colecao de cliente
                //Cada linha do DataTable e um cliente
                //Data = Dados e Row = Linha
                //For = Para e Each = Cada

                foreach (DataRow linha in dataTableCliente.Rows)
                {
                    //Criar um cliente vazio
                    //Colocar os dados da linha nele
                    //Adicionar ele na colecao

                    Cliente cliente = new Cliente();

                    cliente.IdCliente = Convert.ToInt32(linha["IdCliente"]);
                    cliente.Nome = Convert.ToString(linha["Nome"]);
                    cliente.DataNascimento = Convert.ToDateTime(linha["DataNascimento"]);
                    cliente.Sexo = Convert.ToBoolean(linha["Sexo"]);
                    cliente.LimiteCompra = Convert.ToDecimal(linha["LimiteCompra"]);

                    clienteColecao.Add(cliente);
                }

                return clienteColecao;
            }
            catch (Exception ex)
            {

                throw new Exception("Nao foi possivel consultar cliente por nome. Detalhes:" + ex.Message);
            }
        }

        public ClienteColecao ConsultaPorId(int idCliente)
        {
            try
            {
                ClienteColecao clienteColecao = new ClienteColecao();

                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@IdCliente", idCliente);

                DataTable dataTableCliente = acessoDadosSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "uspClienteConsultarPorId");

                foreach (DataRow linha in dataTableCliente.Rows)
                {
                    Cliente cliente = new Cliente();

                    cliente.IdCliente = Convert.ToInt32(linha["IdCliente"]);
                    cliente.Nome = Convert.ToString(linha["Nome"]);
                    cliente.DataNascimento = Convert.ToDateTime(linha["DataNascimento"]);
                    cliente.Sexo = Convert.ToBoolean(linha["Sexo"]);
                    cliente.LimiteCompra = Convert.ToDecimal(linha["LimiteCompra"]);

                    clienteColecao.Add(cliente);
                }
                return clienteColecao;
            }
            catch (Exception ex)
            {

                throw new Exception("Nao foi possivel consultar cliente por Codigo. Detalhes:" + ex.Message);
            }
        }
    }
}
