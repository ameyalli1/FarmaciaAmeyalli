using farma.Repositorios;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace farma
{
    /// <summary>
    /// Lógica de interacción para Empleados.xaml
    /// </summary>
    public partial class Empleados : Window
    {
        HerramientasEmpleado herramientasEmpleado;
        bool g;

        public Empleados()
        {
            InitializeComponent();
            herramientasEmpleado = new HerramientasEmpleado();
            ActualizarrTabla();
            HabilitarrCajas(false);
            HabilitarrBotones(true);

        }

        private void HabilitarrBotones(bool habilitados)
        {
            btnNuevoo.IsEnabled = habilitados;
            btnEditarr.IsEnabled = habilitados;
            btnEliminarr.IsEnabled = habilitados;
            btnGuardarr.IsEnabled = !habilitados;
            btnCancelarr.IsEnabled = !habilitados;
        }
        private void HabilitarrCajas(bool habilitadas)
        {
            //esto es para limpiar
            txbIde.Clear();
            txbNombree.Clear();
            txbDireccion.Clear();
            txbRfc.Clear();
            txbTelefono.Clear();
            txbCorreo.Clear();
            txbSueldo.Clear();

            //esto para que cuando inicie no esten habilitadas si no asta qie le de nuevo
            txbIde.IsEnabled = habilitadas;
            txbNombree.IsEnabled = habilitadas;
            txbDireccion.IsEnabled = habilitadas;
            txbRfc.IsEnabled = habilitadas;
            txbTelefono.IsEnabled = habilitadas;
            txbCorreo.IsEnabled = habilitadas;
            txbSueldo.IsEnabled = habilitadas;
        }
        private void ActualizarrTabla()
        {
            dtgTabla.ItemsSource = null;
            dtgTabla.ItemsSource = herramientasEmpleado.Leer();
        }

        private void btnNuevoo_Click(object sender, RoutedEventArgs e)
        {
            HabilitarrCajas(true);
            HabilitarrBotones(false);
            g = true;
        }

        private void btnGuardarr_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txbIde.Text))
            {
                MessageBox.Show("Falta el identificador ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(txbNombree.Text))
            {
                MessageBox.Show("Falta el nombre ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(txbDireccion.Text))
            {
                MessageBox.Show("Falta la direccion ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(txbRfc.Text))
            {
                MessageBox.Show("Falta RFC", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(txbTelefono.Text))
            {
                MessageBox.Show("Falta el telefono  ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(txbCorreo.Text))
            {
                MessageBox.Show("Falta el correo ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(txbSueldo.Text))
            {
                MessageBox.Show("Falta el sueldo", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (g)
            {

                Empleado a = new Empleado()
                {
                    Identificador = txbIde.Text,
                    Nombre = txbNombree.Text,
                    Direccion = txbDireccion.Text,
                    Rfc = txbRfc.Text,
                    Telefono = txbTelefono.Text,
                    Correo = txbCorreo.Text,
                    Sueldo = txbSueldo.Text
                };
                if (herramientasEmpleado.Agregar(a))
                {
                    MessageBox.Show("Guardado con Éxito", "Empleado", MessageBoxButton.OK, MessageBoxImage.Information);
                    ActualizarrTabla();
                    HabilitarrBotones(true);
                    HabilitarrCajas(false);
                }
                else
                {
                    MessageBox.Show("Error al guardar ", "Empleado", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                Empleado original = dtgTabla.SelectedItem as Empleado;
                Empleado a = new Empleado();
                a.Identificador = txbIde.Text;
                a.Nombre = txbNombree.Text;
                a.Direccion = txbDireccion.Text;
                a.Rfc = txbRfc.Text;
                a.Telefono = txbTelefono.Text;
                a.Correo = txbCorreo.Text;
                a.Sueldo = txbSueldo.Text;

                if (herramientasEmpleado.Modificar(original, a))
                {
                    HabilitarrBotones(true);
                    HabilitarrCajas(false);
                    ActualizarrTabla();
                    MessageBox.Show("El empleado a sido actualizado", "empleado", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Error al guardar ", "empleado", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnEditarr_Click(object sender, RoutedEventArgs e)
        {
            if (herramientasEmpleado.Leer().Count == 0)
            {
                MessageBox.Show("No tienes empleados", "Empleados", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (dtgTabla.SelectedItem != null)
                {
                    Empleado a = dtgTabla.SelectedItem as Empleado;
                    HabilitarrCajas(true);
                    txbIde.Text = a.Identificador;
                    txbNombree.Text = a.Nombre;
                    txbDireccion.Text = a.Direccion;
                    txbRfc.Text = a.Rfc;
                    txbTelefono.Text = a.Telefono;
                    txbCorreo.Text = a.Correo;
                    txbSueldo.Text = a.Sueldo;


                    HabilitarrBotones(false);
                    g = false;
                }
                else
                {
                    MessageBox.Show("No ha seleccionado ningun Empleado", "Empleado", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }



        private void btnCancelarr_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Esta seguro de cancelar", "Cancelar", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                HabilitarrCajas(false);
                HabilitarrBotones(true);
            }
        }



        private void btnEliminarr_Click(object sender, RoutedEventArgs e)
        {
            if (herramientasEmpleado.Leer().Count == 0)
            {
                MessageBox.Show("No tiene empleados", "empleados", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (dtgTabla.SelectedItem != null)
                {
                    Empleado a = dtgTabla.SelectedItem as Empleado;
                    if (MessageBox.Show("Realmente deseas eliminar a " + a.Nombre + "?", "Eliminar????", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        if (herramientasEmpleado.Eliminar(a))
                        {
                            MessageBox.Show("Tu empleado ha sido Eliminado", "Empleado", MessageBoxButton.OK, MessageBoxImage.Information);
                            ActualizarrTabla();
                        }
                        else
                        {
                            MessageBox.Show("Error al eliminar empleado", "empleado", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No a seleccioando ningun empleado", "empleado", MessageBoxButton.OK, MessageBoxImage.Question);
                }
            }
        }


        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            Menu abrir = new Menu();
            abrir.Show();
            this.Close();
        }


    }
}
