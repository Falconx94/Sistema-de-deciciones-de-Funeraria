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
        public int hijos;
        public byte estadocivil;
        public double acumulables, ingresos, total, enganche, totalsup, mensualidad;
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
        public void Desicion_Rules() // En base al ingreso registrado, registrar el procentaje de su ingreso acumulable
        {
            // soltero 0, casado 1
            try
            {
                if (estadocivil == 0 && hijos == 0) // soltero y sin hijos
                {
                    acumulables = ingresos * 0.80;
                }
                if (estadocivil == 1 && hijos == 0) // casado y sin hijos
                {
                    acumulables = ingresos * 0.60;
                }
                if (estadocivil == 1 && hijos == 1) // casado y con 1 hijo
                {
                    acumulables = ingresos * 0.50;
                }
                if (estadocivil == 1 && hijos == 2) // casado y con 2 hijos
                {
                    acumulables = ingresos * 0.45;
                }
                if (estadocivil == 1 && hijos >= 3) // casado y con 3 hijos o mas
                {
                    acumulables = ingresos * 0.40;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error", "Ha ocurrido la siguiente excepcion: " + ex);
            }
        }
        public void Acumulable() //REGLAS DE DECISIÓN: (PARA EL PLAN SUGERIDO)
        {

            // acum sera la cantidad del ingreso acumulable
            if (acumulables <= 3000)
            {
                MessageBox.Show("Se sugiere usar el Plan Economico para este cliente.");
                paquete = "Plan Economico";
            }
            if (acumulables >= 3001 && acumulables <= 8000)
            {
                MessageBox.Show("Se sugiere usar el Plan Estandar para este cliente.");
                paquete = "Plan Estandar";
            }
            if (acumulables >= 8001 && acumulables <= 15000)
            {
                MessageBox.Show("Se sugiere usar el Plan Oro para este cliente.");
                paquete = "Plan Oro";
            }
            if (acumulables >= 15001)
            {
                MessageBox.Show("Se sugiere usar el Plan Diamante para este cliente.");
                paquete = "Plan Diamante";
            }
        }

        public void Capturar()
        {
            Cliente = txt_Cliente.Text;
            Domicilio = txt_Domicilio.Text;
            ingresos = Convert.ToDouble(txt_Ingresos.Text);
            Desicion_Rules();
            resp_2.Text = Convert.ToString(acumulables);
            Acumulable();
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
            CBox_Hijos.Enabled = true;
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
