using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_deciciones_de_Funeraria
{
    class reglas
    {
        public int resultado, hijos;
        public string paquete;
        public float ingresos, in_mensual, enganche, in_acum, acum_res, total, totalsup;
        public byte ec;
        //recordad transformar el tipo de dato del textbox antes de llamar  a la funcion
        // REGLAS DE DECISIÓN: (PARA EL INGRESO ACUMULABLE)
       /*public void Desicion_Rules() // En base al ingreso registrado, registrar el procentaje de su ingreso acumulable
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
        }*/

        //Para pantalla antes de psasar a imprimir fichas de pago
        public double ObtenerEnganche() // total sera el precio total del paquete elegido
        {
            enganche = (30 / 100) * total;
            return enganche;
        }
        public double ObtenerMensualidad() // total sera el precio total del paquete elegido
        {
            in_mensual = (total - enganche) / 3;
            return in_mensual;
        }
        //Regla para cuando el cliente desee actualizar a un paquete superior
        public double ActualizarSuperior() // totalsup sera el precio total del paquete superior
        {
            enganche = (75 / 100) * totalsup;
            in_mensual = (totalsup - enganche) / 3;
            return in_mensual;
        }
        public void limpieza()
        {
            resultado = 0;
            paquete = "";
            ingresos = 0;
            in_mensual = 0;
            enganche = 0;
            ec = 0;
        }
    }
}
