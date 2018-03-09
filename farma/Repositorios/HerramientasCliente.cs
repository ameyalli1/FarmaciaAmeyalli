using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace farma.Repositorios
{
  public  class HerramientasCliente
    {
        ManejadorDeArchivosClientes archivoAmigos;
        List<Cliente> Clientes;
        public HerramientasCliente()
        {
            archivoAmigos = new ManejadorDeArchivosClientes("Clientes.poo");
            Clientes = new List<Cliente>();
        }

        public bool Agregar(Cliente clien)
        {

            Clientes.Add(clien);
            bool resultado = ActualizarArchivo();
            Clientes = Leer();
            return resultado;
        }

        public bool Eliminar(Cliente clien)
        {
            Cliente temp = new Cliente();
            foreach (var item in Clientes)
            {
                if (item.Identificador == clien.Identificador)
                {
                    temp = item;
                }
            }
            Clientes.Remove(temp);
            bool resultado = ActualizarArchivo();
            Clientes = Leer();
            return resultado;
        }

        public bool Modificar(Cliente original, Cliente modificado)
        {
            Cliente temporal = new Cliente();
            foreach (var item in Clientes)
            {
                if (original.Identificador == item.Identificador)
                {
                    temporal = item;
                }
            }
            temporal.Identificador = modificado.Identificador;
            temporal.Nombre = modificado.Nombre;
            temporal.Direccion = modificado.Direccion;
            temporal.Rfc = modificado.Rfc;
            temporal.Telefono = modificado.Telefono;
            temporal.Correo = modificado.Correo;

            bool resultado = ActualizarArchivo();
            Clientes = Leer();
            return resultado;
        }

        private bool ActualizarArchivo()
        {
            string datos = "";
            foreach (Cliente item in Clientes)
            {
                datos += string.Format("{0}|{1}|{2}|{3}|{4}|{5}\n", item.Identificador, item.Nombre, item.Direccion, item.Rfc, item.Telefono, item.Correo);
            }
            return archivoAmigos.Guardar(datos);
        }
        public List<Cliente> Leer()
        {
            string datos = archivoAmigos.Leer();
            if (datos != null)
            {
                List<Cliente> clie = new List<Cliente>();
                string[] lineas = datos.Split('\n');
                for (int i = 0; i < lineas.Length - 1; i++)
                {
                    string[] campos = lineas[i].Split('|');
                    Cliente a = new Cliente();
                    a.Identificador = campos[0];
                    a.Nombre = campos[1];
                    a.Direccion = campos[2];
                    a.Rfc = campos[3];
                    a.Telefono = campos[4];
                    a.Correo = campos[5];


                    clie.Add(a);
                }
                Clientes = clie;
                return clie;
            }
            else
            {
                return null;
            }
        }

    }
}
