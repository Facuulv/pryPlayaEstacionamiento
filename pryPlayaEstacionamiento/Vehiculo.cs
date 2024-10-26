using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pryPlayaEstacionamiento
{
    public class Vehiculo
    {
        public string Patente { get; set; }
        public string Tipo { get; set; }
        public int CantidadHoras { get; set; }
       
        public Vehiculo(string patente, string tipo, int canthoras)
        {
            Patente = patente;
            Tipo = tipo;
            CantidadHoras = canthoras;
        }

        public Dictionary<string, object> ConvertirADicc() 
        {
            Dictionary<string, object> aux = new Dictionary<string, object>();
            aux["patente"] = Patente;
            aux["tipo"] = Tipo;
            aux["cantHoras"] = CantidadHoras;
            return aux;
        }
               
    }
}
