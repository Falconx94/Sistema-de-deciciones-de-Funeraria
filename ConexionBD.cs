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
        //int contador = 0, id= 0;
        //string salida;
        //public bool band = false;
        //SqlConnection con;
        //SqlCommand cmd;
        //SqlDataReader dr;
        public string Con()

        {
            string mi_conexion = ("Data Source=RYZEN3\\SQLEXPRESS;Initial Catalog=funeraria;Integrated Security=True");
            return mi_conexion;
        }
        //public void Con_Main()
        //{
        //    try
        //    {
        //        con = new SqlConnection("Data Source=RYZEN3@SQLEXPRESS;Initial Catalog=funeraria;Integrated Security=True");
        //        con.Open();
        //    }
        //    catch(Exception ex)
        //    {
        //        MessageBox.Show("Error en la conexión a la base de datos error: "+ex.ToString());
        //    }
        //}
        //public string Inserta_Cliente(int id, string cliente, string domicilio, int ec, int hijos, float in_mensual, float in_acum)
        //{
        //    try
        //    {
        //        id++;
        //        cmd = new SqlCommand("Insert into clientes (idcliente,nombre,domicilio,estadocivil,hijos,ingresoMen,ingresoAcum)" +
        //            "values("+id+",'"+cliente+"','"+domicilio+"','"+ec+"',"+hijos+","+in_mensual+","+in_acum+")",con);
        //        cmd.ExecuteNonQuery();
        //        salida = "Datos Capturados";
        //    }
        //    catch(Exception ex)
        //    {
        //        salida = "No se insertaron los datos: "+ex.ToString();
        //    }
        //    return salida;
        //}
        //public bool Buscar(int id, string cliente, string domicilio, int ec, int hijos, double in_mensual, double in_acum)
        //{
        //    try
        //    {
        //        cmd = new SqlCommand("Select * from clientes" +
        //            " where nombre = '"+cliente+"' ", con);
        //        dr = cmd.ExecuteReader();
        //        if (dr.Read())
        //        {
        //            band = true;
        //        }
        //        else
        //        {
        //            band = false;
        //        }
        //        dr.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("No se realizo la consulta " + ex.ToString());
        //    }
        //    return band;
        //}
        //public bool Buscar_2(int id, string cliente, string domicilio, int ec, int hijos, double in_mensual, double in_acum)
        //{
        //    try
        //    {
        //        cmd = new SqlCommand("Select idcliente from clientes where nombre = '"+cliente+"'", con);
        //        dr = cmd.ExecuteReader();
        //        if (dr.Read())
        //        {
        //            band = true;
        //        }
        //        else
        //        {
        //            band = false;
        //        }
        //        dr.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("No se realizo la consulta " + ex.ToString());
        //    }
        //    return band;
        //}
    }
}
