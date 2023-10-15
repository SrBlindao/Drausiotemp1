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
                acessoDadosSqlServer.LimparParamentros();
                acessoDadosSqlServer.AdicionarParamentros("@Nome", cliente.Nome);
                acessoDadosSqlServer.AdicionarParamentros("DataNascimento", cliente.DataNascimento);
                acessoDadosSqlServer.AdicionarParamentros("@Sexo", cliente.Sexo);
                acessoDadosSqlServer.AdicionarParamentros("@LimiteCompra", cliente.LimiteCompra);
                string idCliente = acessoDadosSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "uspClienteInserir").ToString();
                return idCliente;
            }
            catch (Exception excepetion)
            {

                return excepetion.Message;
            }
            
        }
    }
}
