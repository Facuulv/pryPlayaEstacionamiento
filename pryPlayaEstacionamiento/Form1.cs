using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryPlayaEstacionamiento
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<string> columnas = new List<string>() {"Patente", "Tipo de Vehiculo", "Cantidad de horas", "Total"};
        List<string> tipo = new List<string>() { "Auto", "Camioneta", "Moto" };
        Estacionamiento estacionamiento = new Estacionamiento();
        private void Form1_Load(object sender, EventArgs e)
        {
            Limpieza();
            columnas.ForEach(c =>
            {
                dgvEstacionamiento.Columns.Add($"col{columnas.IndexOf(c)}", c);
            });

            tipo.ForEach(tipo =>
            {
                cmbTipo.Items.Add(tipo);
            });
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string patente = formato(txtPatente.Text);
            string tipo = cmbTipo.Text;
            int cant = (int)numCant.Value;
            if (patente != "" && tipo != "" && cant > 0)
            {
                if (!estacionamiento.VerificarPatente(patente))
                {
                    Vehiculo nuevo = new Vehiculo(patente, tipo, cant);
                    estacionamiento.AgregarVehiculo(nuevo);

                    MostrarGrilla();
                    Limpieza();
                }
            }else
            {
                MessageBox.Show("Debe colocar patente, tipo y cantidad de horas", "Atencion");
            }         
        }
        public void MostrarGrilla()
        {
            dgvEstacionamiento.Rows.Clear();
            estacionamiento.estacionamiento.ForEach(e =>
            {
                dgvEstacionamiento.Rows.Add(e["patente"], e["tipo"], e["cantHoras"], (int)e["cantHoras"] * ValorTotal());                
            });
        }

        public int ValorTotal()
        {
            int total = 0;
            if (cmbTipo.SelectedIndex == 0)
            {
                total = 1575;
            }
            if (cmbTipo.SelectedIndex == 1)
            {
                total = 2450;
            }
            if (cmbTipo.SelectedIndex == 2)
            {
                total = 1250;
            }
            return total;
        }
        public string formato(string pat)
        {
            return pat.Replace(" ", "");
        }

        public void Limpieza()
        {
            txtPatente.Text = "";
            cmbTipo.Text = "";
            numCant.Value = 1;

        }

        private void btnEgreso_Click(object sender, EventArgs e)
        {
            string egreso = txtEgresar.Text;
            if (egreso != "")
            {
                if (estacionamiento.VerificarPatente(egreso))
                {
                    estacionamiento.EgresarVehiculo(egreso);
                    txtEgresar.Text = "";
                    dgvEstacionamiento.Rows.Clear();
                    MostrarGrilla();
                } else
                {
                    MessageBox.Show($"La patente {egreso} no existe", "Error");
                }               
            } else
            {
                MessageBox.Show("Debe colocar patente para egresar", "Error");
            }
        }
    }
}
