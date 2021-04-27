using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Sistema_de_deciciones_de_Funeraria
{
    public partial class Datos : Form
    {
        #region variables 
        //ConexionBD conex = new ConexionBD();
        ConexionBD obj_conexion;
        SqlConnection conexion;
        public int hijos, idcliente=0, idpaquete;
        public byte ec;
        public double total, enganche, totalsup, mensualidad, in_mensual, in_acum;
        public string paquete, cliente, domicilio;
        #endregion

        private void Datos_Load(object sender, EventArgs e)
        {
            Max();
            CleanAll();
        }

        #region metodos
        private void Max()
        {
            obj_conexion = new ConexionBD();
            conexion = new SqlConnection(obj_conexion.Con());
            conexion.Open();
            string query = "select max(idcliente)+1 as ultimo from clientes";
            SqlCommand command = new SqlCommand(query, conexion);
            SqlDataReader leer = command.ExecuteReader();
            if (leer.Read())
            {
                idcliente = Convert.ToInt32(leer["ultimo"].ToString());
            }
        } // B I E N
        private void Busqueda()
        {
            obj_conexion = new ConexionBD();
            conexion = new SqlConnection(obj_conexion.Con());
            conexion.Open();
            string query = "select * from clientes where nombre = @nombre";
            SqlCommand comando = new SqlCommand(query, conexion);
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@nombre", txt_Cliente.Text);
            SqlDataReader leer = comando.ExecuteReader();
            if (leer.Read())
            {
                MessageBox.Show("Este cliente ya esta registrado en la base de datos.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_Cliente.Clear();
                txt_Cliente.Focus();
            }
            else
            {
                txt_Domicilio.Enabled = true;
                txt_Domicilio.Focus();
            }
        } // B I E N
        private void CleanAll()
        {
            bt_Continue.Visible = false;
            lbl_sugerido.Visible = false;
            lbl_acumulable.Visible = false;
            txt_Ingresos.Clear();
            txt_Ingresos.Enabled = false;
            CBox_Hijos.SelectedIndex = 0;
            CBox_Hijos.Enabled = false;

            rb_casado.AutoCheck = false;
            rb_casado.Checked = false;
            rb_casado.AutoCheck = true;

            rb_soltero.AutoCheck = false;
            rb_soltero.Checked = false;
            rb_soltero.AutoCheck = true;

            groupBox1.Enabled = false;
            txt_Domicilio.Clear();
            txt_Domicilio.Enabled = false;

            txt_Cliente.Clear();
            txt_Cliente.Focus();
            Max();
        } //LA T E R    U S E 
        #endregion 

        public Datos()
        {
            InitializeComponent();
        }

        private void txt_Cliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (string.IsNullOrEmpty(txt_Cliente.Text))
                {
                    MessageBox.Show("El recuadro no debe estar vacio!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_Cliente.Clear();
                    txt_Cliente.Focus();
                }
                else
                {
                    Busqueda();
                }
            }
            if (e.KeyChar == 27)
            {
                txt_Cliente.Clear();
                txt_Cliente.Focus();
            }
            // cliente = txt_Cliente.Text;
            //if (conex.Buscar(id, cliente, domicilio, ec, hijos, in_mensual, in_acum))
            //{
            //    MessageBox.Show("Ya existe el cliente registrado");
            //}
            //else
            //{
            //    MessageBox.Show("Cliente no registrado");
            //    //conex.Buscar_2(id, cliente, domicilio, ec, hijos, in_mensual, in_acum);
            //    id++;
            //    txt_Domicilio.Enabled = true;
            //    groupBox1.Enabled = true;
            //    CBox_Hijos.Enabled = true;
            //    txt_Ingresos.Enabled = true;
            //}
        }

        private void txt_Domicilio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (string.IsNullOrEmpty(txt_Domicilio.Text))
                {
                    MessageBox.Show("El recuadro no debe estar vacio!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_Domicilio.Clear();
                    txt_Domicilio.Focus();
                }
                else
                {
                    groupBox1.Enabled = true;
                }
            }
            if (e.KeyChar == 27)
            {
                txt_Domicilio.Clear();
                txt_Domicilio.Focus();
            }
        }

        private void rb_casado_CheckedChanged(object sender, EventArgs e)
        {
            CBox_Hijos.Enabled = true;
            ec = 1;
        }

        private void bt_Continue_Click(object sender, EventArgs e)
        {
            obj_conexion = new ConexionBD();
            conexion = new SqlConnection(obj_conexion.Con());
            conexion.Open();
            string query = "INSERT into clientes VALUES(@id,@nombre,@domicilio,@estadocivil, @hijos,@ingresoMen,@ingresoAcum )";
            SqlCommand comando = new SqlCommand(query, conexion);
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@id", idcliente);
            comando.Parameters.AddWithValue("@nombre", txt_Cliente.Text);
            comando.Parameters.AddWithValue("@domicilio", txt_Domicilio.Text);
            comando.Parameters.AddWithValue("@estadocivil", ec);
            comando.Parameters.AddWithValue("@hijos", hijos);
            comando.Parameters.AddWithValue("@ingresoMen", in_mensual);
            comando.Parameters.AddWithValue("@ingresoAcum", in_acum);
            comando.ExecuteNonQuery();
            conexion.Close();
            MessageBox.Show("Datos guardados con exito!", "SOLICITUD REALIZADA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            resumen r = new resumen();
            r.paquete = lbl_sugerido.Text;
            r.id_cliente = idcliente;
            r.cliente = txt_Cliente.Text;
            r.domicilio = txt_Domicilio.Text;
            r.estadocivil = ec;
            r.hijos = hijos;
            r.ingreso_mensual = in_mensual;
            r.ingreso_acumulado = in_acum;
            r.id_paquete = idpaquete;
            this.Close();
            r.Show();
            CleanAll();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            CleanAll();
        }

        private void rb_soltero_CheckedChanged(object sender, EventArgs e)
        {
            CBox_Hijos.Enabled = false;
            txt_Ingresos.Enabled = true;
            ec = 0;
        }

        private void CBox_Hijos_SelectionChangeCommitted(object sender, EventArgs e)
        {
            in_acum = 0;
            in_mensual = 0;
            if (CBox_Hijos.SelectedIndex == 0)
            {
                MessageBox.Show("Seleccione una opcion correcta");
            }
            if (CBox_Hijos.SelectedIndex == 1)
            {
                hijos = 0;
            }
            if (CBox_Hijos.SelectedIndex == 2)
            {
                hijos = 1;
            }
            if (CBox_Hijos.SelectedIndex == 3)
            {
                hijos = 2;
            }
            if (CBox_Hijos.SelectedIndex == 4)
            {
                hijos = 3;
            }
            if (CBox_Hijos.SelectedIndex == 5)
            {
                hijos = 4;
            }
            txt_Ingresos.Enabled = true;
            txt_Ingresos.Focus();
        }

        private void txt_Ingresos_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (string.IsNullOrEmpty(txt_Ingresos.Text))
                {
                    MessageBox.Show("El recuadro no debe estar vacio!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_Ingresos.Clear();
                    txt_Ingresos.Focus();
                }
                else
                {
                    //MessageBox.Show(hijos.ToString());
                    in_mensual = Convert.ToDouble(txt_Ingresos.Text);
                    Desicion_Rules(ec, hijos);
                    Acumulable();
                    btnLimpiar.Visible = true;
                    bt_Continue.Visible = true;
                }
            }
            if (e.KeyChar == 27)
            {
                txt_Ingresos.Clear();
                txt_Ingresos.Focus();
            }
        }

        public double Desicion_Rules(byte ec, int hijos) // En base al ingreso registrado, registrar el procentaje de su ingreso acumulable
        {
            // soltero 0, casado 1
            in_mensual = Convert.ToDouble(txt_Ingresos.Text);
            try
            {
                if (ec == 0 && hijos == 0) // soltero y sin hijos
                {
                    in_acum = in_mensual * 0.80;
                    lbl_acumulable.Text = in_acum.ToString();
                    lbl_acumulable.Visible = true;
                }
                if (ec == 1 && hijos == 0) // casado y sin hijos
                {
                    in_acum = in_mensual * 0.60;
                    lbl_acumulable.Text = in_acum.ToString();
                    lbl_acumulable.Visible = true;
                }
                if (ec == 1 && hijos == 1) // casado y con 1 hijo
                {
                    in_acum = in_mensual * 0.50;
                    lbl_acumulable.Text = in_acum.ToString();
                    lbl_acumulable.Visible = true;
                }
                if (ec == 1 && hijos == 2) // casado y con 2 hijos
                {
                    in_acum = in_mensual * 0.45;
                    lbl_acumulable.Text = in_acum.ToString();
                    lbl_acumulable.Visible = true;
                }
                if (ec == 1 && hijos >= 3) // casado y con 3 hijos o mas
                {
                    in_acum = in_mensual * 0.40;
                    lbl_acumulable.Text = in_acum.ToString();
                    lbl_acumulable.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error", "Ha ocurrido la siguiente excepcion: " + ex);
            }
            return in_acum;
        }
        
        public void Acumulable() //REGLAS DE DECISIÓN: (PARA EL PLAN SUGERIDO)
        {

            // acum sera la cantidad del ingreso acumulable
            if (in_acum <= 3000)
            {
                MessageBox.Show("Se sugiere usar el Plan Economico para este cliente.");
                paquete = "Plan Economico";
                idpaquete = 1;
                lbl_sugerido.Text = "Plan Economico";
                lbl_sugerido.Visible = true;

            }
            if (in_acum >= 3001 && in_acum <= 8000)
            {
                MessageBox.Show("Se sugiere usar el Plan Estandar para este cliente.");
                paquete = "Plan Estandar";
                idpaquete = 2;
                lbl_sugerido.Text = "Plan Estandar";
                lbl_sugerido.Visible = true;

            }
            if (in_acum >= 8001 && in_acum <= 15000)
            {
                MessageBox.Show("Se sugiere usar el Plan Oro para este cliente.");
                paquete = "Plan Oro";
                idpaquete = 3;
                lbl_sugerido.Text = "Plan Oro";
                lbl_sugerido.Visible = true;

            }
            if (in_acum >= 15001)
            {
                MessageBox.Show("Se sugiere usar el Plan Diamante para este cliente.");
                paquete = "Plan Diamante";
                idpaquete = 4;
                lbl_sugerido.Text = "Plan Diamante";
                lbl_sugerido.Visible = true;

            }

        }

        private void rb_EC_Soltero_Click(object sender, EventArgs e)
        {
            rb_casado.Checked = false;
            CBox_Hijos.Enabled = false;
            hijos = 0;
            ec = 0;
        }

        private void rb_EC_Casado_Click(object sender, EventArgs e)
        {
            rb_soltero.Checked = false;
            CBox_Hijos.Enabled = true;
            ec = 1;
        }

        //public void Valida_datos()
        //{   
        //    if(rb_casado.Checked == true)
        //    {
        //        ec = 1;
        //        hijos = Convert.ToInt32(CBox_Hijos.Text);
        //        bt_Continue.Enabled = true;
        //    }
        //    else if(rb_soltero.Checked == true)
        //    {
        //        ec = 0;
        //        bt_Continue.Enabled = true;
        //    }
        //    else
        //    {
        //        MessageBox.Show("Seleccione un estado civil");
        //    }
            
        //}
    }
}
