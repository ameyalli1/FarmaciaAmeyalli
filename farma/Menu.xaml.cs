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
    /// Lógica de interacción para Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btnClientes_Click(object sender, RoutedEventArgs e)
        {
            Clientes abrir = new Clientes();
            abrir.Show();
            this.Close();
        }

        private void btnProductos_Click(object sender, RoutedEventArgs e)
        {
            productos abrir = new productos();
            abrir.Show();
            this.Close();
        }



        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("¿Desea salir?", "Salir", MessageBoxButton.OK, MessageBoxImage.Error);
            this.Close();
        }

        private void btnEmpleados_Click(object sender, RoutedEventArgs e)
        {
            Empleados abrir = new Empleados();
            abrir.Show();
            this.Close();
        }

    }
}
