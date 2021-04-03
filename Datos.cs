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
    public partial class Datos : Form
    {
        public int ingresos, hijos;
        public byte estadocivil;
        public double acumulables;
        public string paquete, Cliente, Domicilio;
        reglas r = new reglas();
        Paquete_Sugerido ps = new Paquete_Sugerido();
        public Datos()
        {
            InitializeComponent();
            //resp_1.Text = "";
            resp_2.Text = "";
            resp_3.Text = "";
            bt_Continue.Enabled = false;
        }

        private void txt_Ingresos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                Valida_datos();
            }
        }
        public void Capturar()
        {
            Cliente = txt_Cliente.Text;
            Domicilio = txt_Domicilio.Text;
            ingresos = Convert.ToInt32(txt_Ingresos.Text);
            r.Desicion_Rules(estadocivil, hijos, ingresos);
            resp_2.Text = Convert.ToString(acumulables);
            r.Acumulable(acumulables);
            resp_3.Text = paquete;
        }

        private void rb_EC_Soltero_Click(object sender, EventArgs e)
        {
            rb_EC_Casado.Checked = false;
            CBox_Hijos.Enabled = false;
            hijos = 0;
        }

        private void rb_EC_Casado_Click(object sender, EventArgs e)
        {
            rb_EC_Soltero.Checked = false;
        }

        public void Valida_datos()
        {   
            if(rb_EC_Casado.Checked == true)
            {
                estadocivil = 1;
                hijos = Convert.ToInt32(CBox_Hijos.Text);
                Capturar();
                bt_Continue.Enabled = true;
            }
            else if(rb_EC_Soltero.Checked == true)
            {
                estadocivil = 0;
                Capturar();
                bt_Continue.Enabled = true;
            }
            else
            {
                MessageBox.Show("Seleccione un estado civil");
            }
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ps.ShowDialog();
        }
    }
}
