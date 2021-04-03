using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_deciciones_de_Funeraria
{
    public partial class Fichas_Pago : Form
    {
        Paquetes f1 = new Paquetes();
        public Fichas_Pago()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            f1.ShowDialog();
        }
    }
}
