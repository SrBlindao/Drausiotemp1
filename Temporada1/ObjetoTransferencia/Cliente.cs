using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjetoTransferencia
{
    public class Cliente
    {
        /*METODO GERAL E COMUM OUTRAS LINGUAGENS
        //Variavel 
        private int idCliente;

        //GET = Pegar
        public int getidCliente()
        {
            return idCliente;
        }

        //SET = SETAR
        public void setIdCliente (int idClienteEnviado)
        {
            idCliente = idClienteEnviado;
        }*/

        //Metodo DOTNET
        //PROP = ATALHO

        public int idCliente { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public Boolean Sexo { get; set; }
        public decimal LimiteCompra { get; set; }
    }
}
