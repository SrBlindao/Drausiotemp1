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

namespace Apresentacao
{
    public partial class FrmClienteCadastrar : Form
    {   
        //construtor
        public FrmClienteCadastrar(AcaoNaTela acaoNaTela, Cliente cliente)
        {
            InitializeComponent();

            if(acaoNaTela == AcaoNaTela.Inserir)
            {
                this.Text = "Inserir Cliente";
            }

            else if(acaoNaTela == AcaoNaTela.Alterar)
            {
                this.Text = "Alterar Cliente";
            }

            else if(acaoNaTela == AcaoNaTela.Consultar)
            {
                this.Text = "Consultar Cliente";
            }
        }
    }
}
