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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace Sistema_de_deciciones_de_Funeraria
{
    public partial class resumen : Form
    {
        #region V A R I A B L E S
        ConexionBD obj_conexion;
        SqlConnection conexion;
        public double mensualidad, enganche, totalpaquete, ingreso_acumulado, ingreso_mensual;
        public string paquete, cliente, domicilio, descripcion;
        public int id_cliente, hijos, id_paquete, idrecibo;

        private void cboxPaquetes_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro de esta eleccion?", "AVISO", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {

                int id_paqueteNuevo = cboxPaquetes.SelectedIndex;
                obj_conexion = new ConexionBD();
                conexion = new SqlConnection(obj_conexion.Con());
                conexion.Open();
                string query = "select * from paquetes where idpaquete = @idpaquete";
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@idpaquete", id_paqueteNuevo);
                SqlDataReader leer = comando.ExecuteReader();
                if (leer.Read())
                {
                    lblPaquete.Text = leer["nombre"].ToString();
                    id_paqueteNuevo = Convert.ToInt32(leer["idpaquete"].ToString());
                    descripcion = leer["descripcion"].ToString();
                    totalpaquete = Convert.ToDouble(leer["precio"].ToString());
                    ObtenerEnganche(totalpaquete);
                    ActualizarSuperior(totalpaquete);
                }
                conexion.Close();
                id_paquete = id_paqueteNuevo;
            }
            else
            {
                cboxPaquetes.Text = "OPCIONES DISPONIBLES:";
                cboxPaquetes.Visible = false;
                mensaje.Visible = false;
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            obj_conexion = new ConexionBD();
            conexion = new SqlConnection(obj_conexion.Con());
            conexion.Open();
            string query = "INSERT into recibos VALUES(@idrecibo,@idcliente,@idpaquete,@enganche,@mensualidad,@estatus, @fecha)";
            SqlCommand comando = new SqlCommand(query, conexion);
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@idrecibo", idrecibo);
            comando.Parameters.AddWithValue("@idcliente", id_cliente);
            comando.Parameters.AddWithValue("@idpaquete", id_paquete);
            comando.Parameters.AddWithValue("@enganche", enganche);
            comando.Parameters.AddWithValue("@mensualidad", mensualidad);
            comando.Parameters.AddWithValue("@estatus", 1);
            comando.Parameters.AddWithValue("@fecha", DateTime.Now);
            comando.ExecuteNonQuery();
            conexion.Close();
            MessageBox.Show("Operacion realizada con exito!", "DATOS GUARDADOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            frmrecibos r = new frmrecibos();
            ReportDocument oRep = new ReportDocument();
            oRep.Load(@"C:\Funeraria\imprimir.rpt");
            oRep.SetParameterValue("@idcliente", id_cliente);
            oRep.SetParameterValue("@idpaquete", id_paquete);
            oRep.SetParameterValue("@fecha", DateTime.Now);
            r.crystalReportViewer2.ReportSource = oRep;
            r.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Paquetes pa = new Paquetes();
            pa.Show();
            this.Close();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            mensaje.Visible = true;
            cboxPaquetes.Visible = true;
        }

        private void resumen_Load(object sender, EventArgs e)
        {
            GetPaquete();
            Max();
        }

        public byte estadocivil;
        #endregion
        public resumen()
        {
            InitializeComponent();
        }
        #region REGLAS
        public double ObtenerEnganche(double totall) // total sera el precio total del paquete elegido
        {
            enganche = totall * 0.30;
            return enganche;
        }
        public double ObtenerMensualidad(double total) // total sera el precio total del paquete elegido
        {
            mensualidad = (total - enganche) / 3;
            lblEnganche.Text = "$ " + enganche.ToString() + " mxn";
            lblMensualidad.Text = "$ " + mensualidad.ToString() + " mxn";
            return mensualidad;
        }
        ////Regla para cuando el cliente desee actualizar a un paquete superior
        public double ActualizarSuperior(double totalsup) // totalsup sera el precio total del paquete superior
        {
            enganche = totalsup * 0.75;
            mensualidad = (totalsup - enganche) / 3;
            lblEnganche.Text = "$ " + enganche.ToString() + " mxn";
            lblMensualidad.Text = "$ " + mensualidad.ToString() + " mxn";
            return mensualidad;
        }
        #endregion

        #region M E T O D O S
        public void GetPaquete() 
        {
            obj_conexion = new ConexionBD();
            conexion = new SqlConnection(obj_conexion.Con());
            conexion.Open();
            string query = "select * from paquetes where idpaquete = @idpaquete";
            SqlCommand comando = new SqlCommand(query, conexion);
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@idpaquete", id_paquete);
            SqlDataReader leer = comando.ExecuteReader();
            if (leer.Read())
            {
                lblPaquete.Text = leer["nombre"].ToString();
                id_paquete = Convert.ToInt32(leer["idpaquete"].ToString());
                descripcion = leer["descripcion"].ToString();
                totalpaquete = Convert.ToDouble(leer["precio"].ToString());
                ObtenerEnganche(totalpaquete);
                ObtenerMensualidad(totalpaquete);
            }
            conexion.Close();
        }
        private void Max()
        {
            obj_conexion = new ConexionBD();
            conexion = new SqlConnection(obj_conexion.Con());
            conexion.Open();
            string query = "select max(idrecibo)+1 as ultimo from recibos";
            SqlCommand command = new SqlCommand(query, conexion);
            SqlDataReader leer = command.ExecuteReader();
            if (leer.Read())
            {
                idrecibo = Convert.ToInt32(leer["ultimo"].ToString());
            }
        } 
        #endregion
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
