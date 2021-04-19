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
            if(MessageBox.Show("Estandar: Ataúd Metálico, Mobiliario para 50 personas, Traslado C-I-P, 4 sirios. $15,600.00. ¿Desea contratar este paquete?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Information)== DialogResult.Yes)
            {
                Datos da = new Datos();
                da.Show();
                this.Hide();
            }
            else
            {
                bt_Economico.Focus();
            }
        }

        private void bt_Economico_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Economico: Velación en capilla, Flores, Servicio de Cafetería Ilimitado $28,400.00 ¿Desea contratar este paquete?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Datos da = new Datos();
                da.Show();
                this.Hide();
            }
            else
            {
               bt_Oro.Focus();
            }
        }

        private void bt_Oro_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Oro: Misa de cuerpo presente, Ataúd de Madera, Sirios Ilimitados $65,400.00. ¿Desea contratar este paquete?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Datos da = new Datos();
                da.Show();
                this.Hide();
            }
            else
            {
                bt_Diamante.Focus();
            }
        }

        private void bt_Diamante_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Diamante: Ataúd es de madera fina o plus (Cedro, Caoba), Cremación.  $105,200.00. ¿Desea contratar este paquete?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Datos da = new Datos();
                da.Show();
                this.Hide();
            }
            else
            {
                bt_Estandar.Focus();
            }
        }
    }
}
