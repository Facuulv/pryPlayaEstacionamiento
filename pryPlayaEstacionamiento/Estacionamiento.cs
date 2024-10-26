using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryPlayaEstacionamiento
{
    public class Estacionamiento
    {
        public List<Dictionary<string, object>> estacionamiento = new List<Dictionary<string, object>>();

        public void AgregarVehiculo(Vehiculo vehiculo)
        {
            estacionamiento.Add(vehiculo.ConvertirADicc());
        }
      
        public bool VerificarPatente(string pat)
        {
            foreach (Dictionary<string, object> vehiculo in estacionamiento)
            {
                if (vehiculo["patente"].ToString() == pat)
                {
                    return true;
                }
            }
            return false;
        }

        public void EgresarVehiculo(string patente)
        {
            int indice = estacionamiento.FindIndex(v => v["patente"].Equals(patente));
            estacionamiento.RemoveAt(indice);
        }
    }
}
