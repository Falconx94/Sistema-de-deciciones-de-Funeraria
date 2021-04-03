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
    public partial class Paquetes : Form
    {
        public Paquetes()
        {
            InitializeComponent();
        }


        private void bt_Estandar_Click(object sender, EventArgs e)
        {
            Datos da = new Datos();
            da.Show();
        }

        private void bt_Economico_Click(object sender, EventArgs e)
        {
            Datos da = new Datos();
            da.Show();
        }

        private void bt_Oro_Click(object sender, EventArgs e)
        {
            Datos da = new Datos();
            da.Show();
        }

        private void bt_Diamante_Click(object sender, EventArgs e)
        {
            Datos da = new Datos();
            da.Show();
        }
    }
}
