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
        ConexionBD conex = new ConexionBD();
        public int hijos, id=0;
        public byte ec;
        public float in_mensual, in_acum;
        public double total, enganche, totalsup, mensualidad;
        public string paquete, cliente, domicilio;
        reglas r = new reglas();
        Paquete_Sugerido ps = new Paquete_Sugerido();
        public Datos()
        {
            InitializeComponent();
            //resp_1.Text = "";
            resp_2.Text = "";
            resp_3.Text = "";
            bt_Continue.Enabled = false;
            conex.Con_Main();
            txt_Domicilio.Enabled = false;
            groupBox1.Enabled = false;
            CBox_Hijos.Enabled = false;
            txt_Ingresos.Enabled = false;
        }

        private void txt_Ingresos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                Valida_datos();
            }
        }

        private void txt_Cliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                cliente = txt_Cliente.Text;
                if (conex.Buscar(id, cliente, domicilio, ec, hijos, in_mensual, in_acum))
                {
                    MessageBox.Show("Ya existe el cliente registrado");
                }
                else
                {
                    MessageBox.Show("Cliente no registrado");
                    conex.Buscar_2(id, cliente, domicilio, ec, hijos, in_mensual, in_acum);
                    id++;
                    txt_Domicilio.Enabled = true;
                    groupBox1.Enabled = true;
                    CBox_Hijos.Enabled = true;
                    txt_Ingresos.Enabled = true;
                }
            }
        }
        public void Desicion_Rules() // En base al ingreso registrado, registrar el procentaje de su ingreso acumulable
        {
            // soltero 0, casado 1
            try
            {
                if (ec == 0 && hijos == 0) // soltero y sin hijos
                {
                    in_acum = (float)(in_mensual * 0.80);
                }
                if (ec == 1 && hijos == 0) // casado y sin hijos
                {
                    in_acum = (float)(in_mensual * 0.60);
                }
                if (ec == 1 && hijos == 1) // casado y con 1 hijo
                {
                    in_acum = (float)(in_mensual * 0.50);
                }
                if (ec == 1 && hijos == 2) // casado y con 2 hijos
                {
                    in_acum = (float)(in_mensual * 0.45);
                }
                if (ec == 1 && hijos >= 3) // casado y con 3 hijos o mas
                {
                    in_acum = (float)(in_mensual * 0.40);
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
            if (in_acum <= 3000)
            {
                MessageBox.Show("Se sugiere usar el Plan Economico para este cliente.");
                paquete = "Plan Economico";
            }
            if (in_acum >= 3001 && in_acum <= 8000)
            {
                MessageBox.Show("Se sugiere usar el Plan Estandar para este cliente.");
                paquete = "Plan Estandar";
            }
            if (in_acum >= 8001 && in_acum <= 15000)
            {
                MessageBox.Show("Se sugiere usar el Plan Oro para este cliente.");
                paquete = "Plan Oro";
            }
            if (in_acum >= 15001)
            {
                MessageBox.Show("Se sugiere usar el Plan Diamante para este cliente.");
                paquete = "Plan Diamante";
            }
        }
        public void Capturar()
        {
            cliente = txt_Cliente.Text;
            domicilio = txt_Domicilio.Text;
            in_mensual = float.Parse(txt_Ingresos.Text);
            Desicion_Rules();
            resp_2.Text = Convert.ToString(in_acum);
            Acumulable();
            resp_3.Text = paquete;
        }
        private void rb_EC_Soltero_Click(object sender, EventArgs e)
        {
            rb_EC_Casado.Checked = false;
            CBox_Hijos.Enabled = false;
            hijos = 0;
            ec = 0;
        }
        private void rb_EC_Casado_Click(object sender, EventArgs e)
        {
            rb_EC_Soltero.Checked = false;
            CBox_Hijos.Enabled = true;
            ec = 1;
        }
        public void Valida_datos()
        {   
            if(rb_EC_Casado.Checked == true)
            {
                ec = 1;
                hijos = Convert.ToInt32(CBox_Hijos.Text);
                Capturar();
                bt_Continue.Enabled = true;
            }
            else if(rb_EC_Soltero.Checked == true)
            {
                ec = 0;
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
            conex.Inserta_Cliente(id, cliente, domicilio, ec, hijos, in_mensual, in_acum);
            ps.ShowDialog();
        }
    }
}
