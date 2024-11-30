using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab2Asi_VH23017
{
    public partial class Form1 : Form
    {

        //Cristian Mauricio Vasquez Hernandez
        //28 - 09 - 2024

        public Form1()
        {
            InitializeComponent();
            cbxServicio.SelectedIndex = 0;
        }

        //Metodo de limpieza
        private void Limpiar()
        {
            cbxServicio.SelectedIndex = 0;
            txtEdad.Text = "";
            txtMascota.Text = "";
        }

        //Boton salir
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Boton limpiar
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
            txtCantAdultas.Text = "";
            txtCantJovenes.Text = "";
            txtTotalMes.Text = "";
            txtServicio.Text = "";
            cantAdulto = 0;
            cantJoven = 0;
            servBano = 0;
            servCorte = 0;
        }

        //Variables
        string mascota;
        int edad = 0;
        string servicio;
        double precio;
        double descuento;
        double totalMascota;
        int cantAdulto = 0;
        int cantJoven = 0;
        double totalMes;
        int servBano = 0;
        int servCorte = 0;

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            //validaciones
            if (string.IsNullOrEmpty(txtMascota.Text))
            {
                MessageBox.Show("Ingrese un nombre");
                txtMascota.Text = "";
            }
            else if (string.IsNullOrEmpty(txtEdad.Text) || !int.TryParse(txtEdad.Text, out edad))
            {
                MessageBox.Show("Ingrese una edad");
                txtEdad.Text = "";
            }
            //edad
            else
            {
                edad = Convert.ToInt32(txtEdad.Text);
                mascota = txtMascota.Text;

                //Mascota Adulta
                if (edad > 5)
                {
                    descuento = 0.25;
                    cantAdulto++;
                }
                //Mascota Joven
                else
                {
                    descuento = 0.1;
                    cantJoven++;
                }
                //servicio
                switch (cbxServicio.SelectedIndex)
                {
                    //Servicio Baño
                    case 0:
                        servicio = "Baño";
                        precio = 7;
                        totalMascota = precio - (precio * descuento);
                        totalMes += totalMascota;
                        servBano++;
                        MessageBox.Show($"Mascota: {mascota}\nPrecio: ${Convert.ToString(totalMascota)}\nServicio: {servicio}\nCantidad de servicios: 1");
                        Limpiar();
                        break;
                    //Servicio Corte
                    case 1:
                        servicio = "Corte";
                        precio = 10;
                        totalMascota = precio - (precio * descuento);
                        totalMes += totalMascota;
                        servCorte++;
                        MessageBox.Show($"Mascota: {mascota}\nPrecio: ${Convert.ToString(totalMascota)}\nServicio: {servicio}\nCantidad de servicios: 1");
                        Limpiar();
                        break;
                    //Servicio Completo
                    case 2:
                        servicio = "Servicio Completo";
                        precio = 17;
                        totalMascota = precio - (precio * descuento);
                        totalMes += totalMascota;
                        servCorte++;
                        servBano++;
                        MessageBox.Show($"Mascota: {mascota}\nPrecio: ${Convert.ToString(totalMascota)}\nServicio: {servicio}\nCantidad de servicios: 2");
                        Limpiar();
                        break;
                }

                //Salidas
                txtCantAdultas.Text = Convert.ToString(cantAdulto);
                txtCantJovenes.Text = Convert.ToString(cantJoven);
                txtTotalMes.Text = $"${Convert.ToString(totalMes)}";

                //Ciclo de servicio mas ofrecido
                if (servBano > servCorte)
                {
                    txtServicio.Text = "Baño";
                }
                else if (servCorte > servBano)
                {
                    txtServicio.Text = "Corte";
                }
                else
                {
                    txtServicio.Text = "Misma cantidad";
                }
            }
        }
    }
}
// Un saludo al inge :)