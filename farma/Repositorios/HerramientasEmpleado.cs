using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace farma.Repositorios
{
  public  class HerramientasEmpleado
    {
        ManejadorDeArchivoEmpleados archivoAmigos;
        List<Empleado> Empleados;
        public HerramientasEmpleado()
        {
            archivoAmigos = new ManejadorDeArchivoEmpleados("Empleado.poo");
            Empleados = new List<Empleado>();
        }

        public bool Agregar(Empleado emple)
        {

            Empleados.Add(emple);
            bool resultado = ActualizarArchivo();
            Empleados = Leer();
            return resultado;
        }

        public bool Eliminar(Empleado em)
        {
            Empleado temp = new Empleado();
            foreach (var item in Empleados)
            {
                if (item.Identificador == em.Identificador)
                {
                    temp = item;
                }
            }
            Empleados.Remove(temp);
            bool resultado = ActualizarArchivo();
            Empleados = Leer();
            return resultado;
        }

        public bool Modificar(Empleado original, Empleado modificado)
        {
            Empleado temporal = new Empleado();
            foreach (var item in Empleados)
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
            temporal.Sueldo = modificado.Sueldo;

            bool resultado = ActualizarArchivo();
            Empleados = Leer();
            return resultado;
        }

        private bool ActualizarArchivo()
        {
            string datos = "";
            foreach (Empleado item in Empleados)
            {
                datos += string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}\n", item.Identificador, item.Nombre, item.Direccion, item.Rfc, item.Telefono, item.Correo, item.Sueldo);
            }
            return archivoAmigos.Guardar(datos);
        }
        public List<Empleado> Leer()
        {
            string datos = archivoAmigos.Leer();
            if (datos != null)
            {
                List<Empleado> em = new List<Empleado>();
                string[] lineas = datos.Split('\n');
                for (int i = 0; i < lineas.Length - 1; i++)
                {
                    string[] campos = lineas[i].Split('|');
                    Empleado a = new Empleado();
                    a.Identificador = campos[0];
                    a.Nombre = campos[1];
                    a.Direccion = campos[2];
                    a.Rfc = campos[3];
                    a.Telefono = campos[4];
                    a.Correo = campos[5];
                    a.Sueldo = campos[6];




                    em.Add(a);
                }
                Empleados = em;
                return em;
            }
            else
            {
                return null;
            }
        }
    }
}
