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
        //public int resultado, paquete;
        //public double ingresos, mensualidad, enganche, acumulables, acum_res;
        //public byte estadocivil;
        ////recordad transformar el tipo de dato del textbox antes de llamar  a la funcion
        //// REGLAS DE DECISIÓN: (PARA EL INGRESO ACUMULABLE)
        //public double Desicion_Rules(byte estadocivil ,int hijos, double ingresos, double acumulables) // En base al ingreso registrado, registrar el procentaje de su ingreso acumulable
        //{
        //    // soltero 0, casado 1
        //    try
        //    {
        //        if (estadocivil == 0 && hijos == 0 ) // soltero y sin hijos
        //        {
        //            acumulables = ingresos * 0.80 ;
        //        }
        //        if (estadocivil == 1 && hijos == 0) // casado y sin hijos
        //        {
        //            acumulables = ingresos * 0.60;
        //        }
        //        if (estadocivil == 1 && hijos == 1) // casado y con 1 hijo
        //        {
        //            acumulables = ingresos * 0.50;
        //        }
        //        if (estadocivil == 1 && hijos == 2) // casado y con 2 hijos
        //        {
        //            acumulables = ingresos * 0.45;
        //        }
        //        if (estadocivil == 1 && hijos >= 3) // casado y con 3 hijos o mas
        //        {
        //            acumulables = ingresos * 0.40;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error", "Ha ocurrido la siguiente excepcion: " + ex);
        //    }
        //    return acumulables;
        //}
        
        //public int Acumulable(double acumulables) //REGLAS DE DECISIÓN: (PARA EL PLAN SUGERIDO)
        //{

        //    // acum sera la cantidad del ingreso acumulable
        //    if (acumulables <= 3000)
        //    {
        //        MessageBox.Show("Se sugiere usar el Plan Economico para este cliente.");
        //        paquete = 1;
        //    }
        //    if (acumulables >= 3001 && acumulables <= 8000)
        //    {
        //        MessageBox.Show("Se sugiere usar el Plan Estandar para este cliente.");
        //        paquete = 2;
        //    }
        //    if (acumulables >= 8001 && acumulables <= 15000)
        //    {
        //        MessageBox.Show("Se sugiere usar el Plan Oro para este cliente.");
        //        paquete = 3;
        //    }
        //    if (acumulables >= 15001)
        //    {
        //        MessageBox.Show("Se sugiere usar el Plan Diamante para este cliente.");
        //        paquete = 4;
        //    }
        //    return paquete;
        //}

        ////Para pantalla antes de psasar a imprimir fichas de pago
        //public double ObtenerEnganche(double total) // total sera el precio total del paquete elegido
        //{
        //    enganche = (30 / 100) * total;
        //    return enganche;
        //}
        //public double ObtenerMensualidad (double total) // total sera el precio total del paquete elegido
        //{
        //    mensualidad = (total - enganche) / 3;
        //    return mensualidad;
        //}
        ////Regla para cuando el cliente desee actualizar a un paquete superior
        //public double ActualizarSuperior(double totalsup) // totalsup sera el precio total del paquete superior
        //{
        //    enganche = (75 / 100) * totalsup;
        //    mensualidad = (totalsup - enganche) / 3;
        //    return mensualidad;
        //}
        //public void limpieza()
        //{
        //    resultado = 0;
        //    paquete = 0;
        //    ingresos = 0;
        //    mensualidad = 0;
        //    enganche = 0;
        //    estadocivil = 0;
        //}
    }
}
