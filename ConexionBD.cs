using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Sistema_de_deciciones_de_Funeraria
{
    class ConexionBD
    {
        int id= 0;
        string salida;
        public bool band = false;
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public void Con_Main()
        {
            try
            {
                con = new SqlConnection("Data Source=FALCON-DELL;Initial Catalog=funeraria;Integrated Security=True");
                con.Open();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error en la conexión a la base de datos error: "+ex.ToString());
            }
        }
        public bool Buscar_consulta(int idconsulta, string fecha,int paquete)
        {
            try
            {
                cmd = new SqlCommand("Select * from NuevaConsulta" +
                    " where idconsulta = '" + idconsulta + "' ", con);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    band = true;
                }
                else
                {
                    band = false;
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se realizo la consulta " + ex.ToString());
            }
            return band;
        }
        public void Inserta_Consulta(int idconsulta, string fecha, int paquete)
        {
            try
            {
                id++;
                cmd = new SqlCommand("Insert into NuevaConsulta(idconsulta,Fec_Consulta,pack_elegido)" +
                    "values("+ idconsulta +", cast('"+fecha+"' as datetime ),"+paquete+")", con);
                cmd.ExecuteNonQuery();
                salida = "Datos Capturados";
            }
            catch (Exception ex)
            {
                salida = "No se insertaron los datos: " + ex.ToString();
            }
            MessageBox.Show(salida);
        }
        public void Inserta_Cliente(int id, string cliente, string domicilio, int ec, int hijos, float in_mensual, float in_acum,int idpaquete)
        {
            try
            {
                id++;
                cmd = new SqlCommand("Insert into clientes (idcliente,nombre,domicilio,estadocivil,hijos,in_mensual,in_acum)" +
                    "values("+id+",'"+cliente+"','"+domicilio+"','"+ec+"',"+hijos+","+in_mensual+","+in_acum+")",con);
                cmd.ExecuteNonQuery();
                salida = "Datos Capturados";
            }
            catch(Exception ex)
            {
                salida = "No se insertaron los datos: "+ex.ToString();
            }
           MessageBox.Show(salida);
        }
        public void Actualiza_Cliente(int id, string cliente, string domicilio, int ec, int hijos, float in_mensual, float in_acum, int idpaquete)
        {
            try
            {
                id++;
                cmd = new SqlCommand("Update clientes set nombre = '" + cliente + "', domicilio = '" + domicilio + "', estadocivil = '" + ec + "', hijos =" + hijos + ", in_mensual =" + in_mensual + ", in_acum = " + in_acum + ")", con);
                cmd.ExecuteNonQuery();
                salida = "Datos Capturados";
            }
            catch (Exception ex)
            {
                salida = "No se insertaron los datos: " + ex.ToString();
            }
            MessageBox.Show(salida);
        }
        public bool Buscar(int id, string cliente, string domicilio, int ec, int hijos, float in_mensual, float in_acum, int idpaquete)
        {
            try
            {
                cmd = new SqlCommand("Select * from clientes" +
                    " where nombre = '"+cliente+"' ", con);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    band = true;
                }
                else
                {
                    band = false;
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se realizo la consulta " + ex.ToString());
            }
            return band;
        }
        public bool Buscar_2(int id, string cliente, string domicilio, int ec, int hijos, float in_mensual, float in_acum, int idpaquete)
        {
            try
            {
                cmd = new SqlCommand("Select idcliente from clientes where nombre = '"+cliente+"'", con);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    band = true;
                }
                else
                {
                    band = false;
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se realizo la consulta " + ex.ToString());
            }
            return band;
        }
    }
}
