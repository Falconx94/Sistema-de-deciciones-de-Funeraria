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
    public partial class Paquete_Sugerido : Form
    {
        Fichas_Pago fp = new Fichas_Pago();
        public Paquete_Sugerido()
        {
            InitializeComponent();
            resp_1.Text = "";
            resp_2.Text = "";
            resp_3.Text = "";
        }

        private void Paquete_Sugerido_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            fp.ShowDialog();
        }
    }
}
