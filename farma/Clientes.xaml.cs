using farma.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace farma
{
    /// <summary>
    /// Lógica de interacción para Clientes.xaml
    /// </summary>
    public partial class Clientes : Window
    {
        HerramientasCliente herramientasCliente;
        bool n;

        public Clientes()
        {
            InitializeComponent();
            herramientasCliente = new HerramientasCliente();
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

            //esto para que cuando inicie no esten habilitadas si no asta qie le de nuevo
            txbIde.IsEnabled = habilitadas;
            txbNombree.IsEnabled = habilitadas;
            txbDireccion.IsEnabled = habilitadas;
            txbRfc.IsEnabled = habilitadas;
            txbTelefono.IsEnabled = habilitadas;
            txbCorreo.IsEnabled = habilitadas;
        }

        private void ActualizarrTabla()
        {
            dtgTabla.ItemsSource = null;
            dtgTabla.ItemsSource = herramientasCliente.Leer();
        }



        private void btnNuevoo_Click(object sender, RoutedEventArgs e)
        {
            HabilitarrCajas(true);
            HabilitarrBotones(false);
            n = true;
        }

        private void btnGuardarr_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txbIde.Text))
            {
                MessageBox.Show("Falta el identificador del Cliente", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(txbNombree.Text))
            {
                MessageBox.Show("Falta el nombre del cliente", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(txbDireccion.Text))
            {
                MessageBox.Show("Falta la direccion del cliente ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(txbRfc.Text))
            {
                MessageBox.Show("Falta RFC", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(txbTelefono.Text))
            {
                MessageBox.Show("Falta el telefono del cliente ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(txbCorreo.Text))
            {
                MessageBox.Show("Falta el correo del cliente", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (n)
            {

                Cliente a = new Cliente()
                {
                    Identificador = txbIde.Text,
                    Nombre = txbNombree.Text,
                    Direccion = txbDireccion.Text,
                    Rfc = txbRfc.Text,
                    Telefono = txbTelefono.Text,
                    Correo = txbCorreo.Text
                };
                if (herramientasCliente.Agregar(a))
                {
                    MessageBox.Show("Guardado con Éxito", "Cliente", MessageBoxButton.OK, MessageBoxImage.Information);
                    ActualizarrTabla();
                    HabilitarrBotones(true);
                    HabilitarrCajas(false);
                }
                else
                {
                    MessageBox.Show("Error al guardar el cliente", "Cliente", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                Cliente original = dtgTabla.SelectedItem as Cliente;
                Cliente a = new Cliente();
                a.Identificador = txbIde.Text;
                a.Nombre = txbNombree.Text;
                a.Direccion = txbDireccion.Text;
                a.Rfc = txbRfc.Text;
                a.Telefono = txbTelefono.Text;
                a.Correo = txbCorreo.Text;

                if (herramientasCliente.Modificar(original, a))
                {
                    HabilitarrBotones(true);
                    HabilitarrCajas(false);
                    ActualizarrTabla();
                    MessageBox.Show("El cliente a sido actualizado", "Cliente", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Error al guardar al cliente ", "Cliente", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnEditarr_Click(object sender, RoutedEventArgs e)
        {
            if (herramientasCliente.Leer().Count == 0)
            {
                MessageBox.Show("No tienes Clientes", "Clientes", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (dtgTabla.SelectedItem != null)
                {
                    Cliente a = dtgTabla.SelectedItem as Cliente;
                    HabilitarrCajas(true);
                    txbIde.Text = a.Identificador;
                    txbNombree.Text = a.Nombre;
                    txbDireccion.Text = a.Direccion;
                    txbRfc.Text = a.Rfc;
                    txbTelefono.Text = a.Telefono;
                    txbCorreo.Text = a.Correo;
                    HabilitarrBotones(false);
                    n = false;
                }
                else
                {
                    MessageBox.Show("No ha seleccionado ningun cliente", "cliente", MessageBoxButton.OK, MessageBoxImage.Error);
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
            if (herramientasCliente.Leer().Count == 0)
            {
                MessageBox.Show("No tiene Clientes", "Clientes", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (dtgTabla.SelectedItem != null)
                {
                    Cliente a = dtgTabla.SelectedItem as Cliente;
                    if (MessageBox.Show("Realmente deseas eliminar a " + a.Nombre + "?", "Eliminar????", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        if (herramientasCliente.Eliminar(a))
                        {
                            MessageBox.Show("Tu Cliente ha sido Eliminado", "Cliente", MessageBoxButton.OK, MessageBoxImage.Information);
                            ActualizarrTabla();
                        }
                        else
                        {
                            MessageBox.Show("Error al eliminar cliente", "cliente", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No a seleccioando ningun cliente", "cliente", MessageBoxButton.OK, MessageBoxImage.Question);
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
