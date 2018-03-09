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
    /// Lógica de interacción para productos.xaml
    /// </summary>
    public partial class productos : Window
    {
        HerramientasProducto herramientasProducto;
        bool n;

        public productos()
        {
            InitializeComponent();
            herramientasProducto = new HerramientasProducto();

            ActualizarTabla();
            HabilitarrCajas(false);
            HabilitarrBotones(true);

        }


        private void ActualizarTabla()
        {
            dtgTabla.ItemsSource = null;
            dtgTabla.ItemsSource = herramientasProducto.Leer();

        }


        private void HabilitarrCajas(bool habilitadas)
        {
            //esto es para limpiar
            txbIde.Clear();
            txbNombree.Clear();
            txbDescripcionn.Clear();
            txbPrecioventaa.Clear();
            txbPrecioCompraa.Clear();
            txbPresentacionn.Clear();

            //esto para que cuando inicie no esten habilitadas si no asta qie le de nuevo
            txbIde.IsEnabled = habilitadas;
            txbNombree.IsEnabled = habilitadas;
            txbDescripcionn.IsEnabled = habilitadas;
            txbPrecioventaa.IsEnabled = habilitadas;
            txbPrecioCompraa.IsEnabled = habilitadas;
            txbPresentacionn.IsEnabled = habilitadas;

        }


        private void HabilitarrBotones(bool habilitados)
        {
            btnNuevoo.IsEnabled = habilitados;
            btnEditarr.IsEnabled = habilitados;
            btnEliminarr.IsEnabled = habilitados;
            btnGuardarr.IsEnabled = !habilitados;
            btnCancelarr.IsEnabled = !habilitados;
        }





        private void btnNuevoo_Click(object sender, RoutedEventArgs e)
        {
            HabilitarrCajas(true);
            HabilitarrBotones(false);
            n = true;

        }


        private void btnCancelarr_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Esta seguro de cancelar", "Cancelar", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                HabilitarrCajas(false);
                HabilitarrBotones(true);
            }
        }


        private void btnGuardarr_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrEmpty(txbIde.Text))
            {
                MessageBox.Show("Falta el identificador del producto", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(txbNombree.Text))
            {
                MessageBox.Show("Falta el nombre del producto", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(txbDescripcionn.Text))
            {
                MessageBox.Show("Falta la del producto", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(txbPrecioventaa.Text))
            {
                MessageBox.Show("Falta el precion de venta del producto", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(txbPrecioCompraa.Text))
            {
                MessageBox.Show("Falta el precio de compra del producto", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(txbPresentacionn.Text))
            {
                MessageBox.Show("Falta la presentacion del producto", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (n)
            {

                Producto a = new Producto()
                {
                    Identidicador = txbIde.Text,
                    Nombre = txbNombree.Text,
                    Descripcion = txbDescripcionn.Text,
                    PrecioVenta = txbPrecioventaa.Text,
                    PrecioCompra = txbPrecioCompraa.Text,
                    Presentacion = txbPresentacionn.Text
                };
                if (herramientasProducto.Agregar(a))
                {
                    MessageBox.Show("Guardado con Éxito", "productos", MessageBoxButton.OK, MessageBoxImage.Information);
                    ActualizarTabla();
                    HabilitarrBotones(true);
                    HabilitarrCajas(false);
                }
                else
                {
                    MessageBox.Show("Error al guardar tu producto", "productos", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                Producto original = dtgTabla.SelectedItem as Producto;
                Producto a = new Producto();
                a.Identidicador = txbIde.Text;
                a.Nombre = txbNombree.Text;
                a.Descripcion = txbDescripcionn.Text;
                a.PrecioVenta = txbPrecioventaa.Text;
                a.PrecioCompra = txbPrecioCompraa.Text;
                a.Presentacion = txbPresentacionn.Text;

                if (herramientasProducto.Modificar(original, a))
                {
                    HabilitarrBotones(true);
                    HabilitarrCajas(false);
                    ActualizarTabla();
                    MessageBox.Show("Su producto a sido actualizado", "producto", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Error al guardar a tu producto", "productos", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }




        }


        private void btnEditarr_Click(object sender, RoutedEventArgs e)
        {

            if (herramientasProducto.Leer().Count == 0)
            {
                MessageBox.Show("No tienes productos", "Productos", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (dtgTabla.SelectedItem != null)
                {
                    Producto a = dtgTabla.SelectedItem as Producto;
                    HabilitarrCajas(true);
                    txbIde.Text = a.Identidicador;
                    txbNombree.Text = a.Nombre;
                    txbDescripcionn.Text = a.Descripcion;
                    txbPrecioventaa.Text = a.PrecioVenta;
                    txbPrecioCompraa.Text = a.PrecioCompra;
                    txbPresentacionn.Text = a.Presentacion;
                    HabilitarrBotones(false);
                    n = false;
                }
                else
                {
                    MessageBox.Show("No ha seleccionado ningua producto", "Producto", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }



        }


        private void btnEliminarr_Click(object sender, RoutedEventArgs e)
        {


            if (herramientasProducto.Leer().Count == 0)
            {
                MessageBox.Show("No tiene productos", "productos", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (dtgTabla.SelectedItem != null)
                {
                    Producto a = dtgTabla.SelectedItem as Producto;
                    if (MessageBox.Show("Realmente deseas eliminar a " + a.Nombre + "?", "Eliminar????", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        if (herramientasProducto.Eliminar(a))
                        {
                            MessageBox.Show("Tu Producto ha sido Eliminado", "Producto", MessageBoxButton.OK, MessageBoxImage.Information);
                            ActualizarTabla();
                        }
                        else
                        {
                            MessageBox.Show("Error al eliminar tu producto", "Producto", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No a seleccioando ningun producto", "producto", MessageBoxButton.OK, MessageBoxImage.Question);
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
