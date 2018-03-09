using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace farma.Repositorios
{
   public  class HerramientasProducto
    {
        ManejadorDeArchivos archivoAmigos;
        List<Producto> Productos;

        public HerramientasProducto()
        {
            archivoAmigos = new ManejadorDeArchivos("Productos.poo");
            Productos = new List<Producto>();
        }

        public bool Agregar(Producto produc)
        {

            Productos.Add(produc);
            bool resultado = ActualizarArchivo();
            Productos = Leer();
            return resultado;
        }

        public bool Eliminar(Producto produc)
        {
            Producto temp = new Producto();
            foreach (var item in Productos)
            {
                if (item.Identidicador == produc.Identidicador)
                {
                    temp = item;
                }
            }
            Productos.Remove(temp);
            bool resultado = ActualizarArchivo();
            Productos = Leer();
            return resultado;
        }

        public bool Modificar(Producto original, Producto modificado)
        {
            Producto temporal = new Producto();
            foreach (var item in Productos)
            {
                if (original.Identidicador == item.Identidicador)
                {
                    temporal = item;
                }
            }
            temporal.Identidicador = modificado.Identidicador;
            temporal.Nombre = modificado.Nombre;
            temporal.Descripcion = modificado.Descripcion;
            temporal.PrecioVenta = modificado.PrecioVenta;
            temporal.PrecioCompra = modificado.PrecioCompra;
            temporal.Presentacion = modificado.Presentacion;

            bool resultado = ActualizarArchivo();
            Productos = Leer();
            return resultado;
        }

        private bool ActualizarArchivo()
        {
            string datos = "";
            foreach (Producto item in Productos)
            {
                datos += string.Format("{0}|{1}|{2}|{3}|{4}|{5}\n", item.Identidicador, item.Nombre, item.Descripcion, item.PrecioVenta, item.PrecioCompra, item.Presentacion);
            }
            return archivoAmigos.Guardar(datos);
        }



        public List<Producto> Leer()
        {
            string datos = archivoAmigos.Leer();
            if (datos != null)
            {
                List<Producto> produ = new List<Producto>();
                string[] lineas = datos.Split('\n');
                for (int i = 0; i < lineas.Length - 1; i++)
                {
                    string[] campos = lineas[i].Split('|');
                    Producto a = new Producto();
                    a.Identidicador = campos[0];
                    a.Nombre = campos[1];
                    a.Descripcion = campos[2];
                    a.PrecioVenta = campos[3];
                    a.PrecioCompra = campos[4];
                    a.Presentacion = campos[5];


                    produ.Add(a);
                }
                Productos = produ;
                return produ;
            }
            else
            {
                return null;
            }
        }

    }
}
