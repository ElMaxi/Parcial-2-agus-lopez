using Parcial_2___Agustín_López.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Parcial_2___Agustín_López.Models
{
    
   public  class Sistema
    {
        static  List<Producto> ListaProductos = new();
        static string ArchivoPanaderia = "ArchivoPanaderia.txt";
        public static void AgregarProducto()
        {

            Console.WriteLine($"Ingrese el nombre del producto a ingresar.\n");
            string nombre = Console.ReadLine();

            Console.WriteLine($"Ingrese el precio del producto a ingresar.\n");
            decimal precio = decimal.Parse(Console.ReadLine());

            Console.WriteLine($"Seleccione el numero correcto para el tipo de producto que desee.\n");
            
                                int contador = 0;
           foreach (Delicatessen x in Enum.GetValues(typeof(Delicatessen)))
            { contador++;
                Console.WriteLine($"{contador}. {Enum.GetName(x)}\n");
            }
 int opcion = int.Parse(Console.ReadLine());
            Delicatessen TipoProducto = Delicatessen.Pan;
            switch (opcion)
            {
                case 1:
                    TipoProducto = Delicatessen.Pan; break;
                case 2:
                    TipoProducto = Delicatessen.Bizcocho; break;
                case 3:
                    TipoProducto = Delicatessen.Pastel; break;
                default:
                    TipoProducto = Delicatessen.Pan; break;
            }

            Console.WriteLine($"Declare la cantidad de stock de producto.\n");
            int CantidadDisponible = int.Parse(Console.ReadLine());

            Producto NuevoProducto = new Producto(nombre, precio, TipoProducto, CantidadDisponible);
            ListaProductos.Add( NuevoProducto );
        }


        public static void EliminarProducto(string nombre)
        {
            var j = ListaProductos.FirstOrDefault(j => nombre.Equals(j.Nombre));
            if (j != null)
            {
                ListaProductos.Remove(j);
                Console.WriteLine($"Producto eliminado con éxito\n");

            }
            else { Console.WriteLine($"El producto no fue encontrado\n"); }
        }

        public static void ActualizarProducto(string nombre)
        {
            var j = ListaProductos.FirstOrDefault(j => nombre.Equals(j.Nombre));

            if (j != null)
            {
                Console.WriteLine($"El producto {j.Nombre} tiene el precio de {j.Precio} y su tipo de producto es {j.TipoProducto.ToString()}, y hay {j.CantidadDisponible} disponible en stock.\n Desea cambiarlo? (S/N)");
                string opcion = Console.ReadLine();
                opcion = opcion.ToLower();
                if (opcion == "s")
                {
                    Console.WriteLine($"Ingrese el precio nuevo para el producto [actual: {j.Precio}]");
                    decimal precio = decimal.Parse(Console.ReadLine());

                    Console.WriteLine($"Seleccione el numero correcto para el tipo de producto que desee.\n");

                    int contador = 0;
                    foreach (Delicatessen x in Enum.GetValues(typeof(Delicatessen)))
                    {
                        contador++;
                        Console.WriteLine($"{contador}. {Enum.GetName(x)}");
                    }
                    int opcionado = int.Parse(Console.ReadLine());
                    Delicatessen TipoProducto = Delicatessen.Pan;
                    switch (opcionado)
                    {
                        case 1:
                            TipoProducto = Delicatessen.Pan; break;
                        case 2:
                            TipoProducto = Delicatessen.Bizcocho; break;
                        case 3:
                            TipoProducto = Delicatessen.Pastel; break;
                        default:
                            TipoProducto = Delicatessen.Pan; break;
                    }
                    Console.WriteLine($"Declare la cantidad de stock de producto.\n");
                    int CantidadDisponible = int.Parse(Console.ReadLine());

                    j.Actualizar(precio, TipoProducto, CantidadDisponible);
                    Console.WriteLine($"Producto actualizado con éxito.\n");
                }
                else { Console.WriteLine($"Sin modificaciones en el sistema. \n"); }
                
            }
            
            Console.WriteLine($"El producto no fue encontrado\n");
        }

        public static void ProductosMostrar()
        {
            int contador = 0;
            foreach( var Producto in ListaProductos)
            {
                contador++;
                Console.WriteLine($"{contador}. '{Producto.Nombre}', valor: {Producto.Precio} , Tipo de producto: {Producto.TipoProducto.ToString()}, unidades disponibles: {Producto.CantidadDisponible} \n");
            }
        }
        public static void ProductosMostrarNombres()
        {
            int contador = 0;
            foreach (var Producto in ListaProductos)
            {
                
                Console.WriteLine($"\n--. '{Producto.Nombre}'\n");
            }
        }

        public static decimal ProductosCalcular()
        {
            decimal Preciazo = 0;
            foreach( var Producto in ListaProductos)
            {
                Preciazo = Producto.CalcularPrecio(Preciazo);
            }
            return Preciazo;
        }


        public static void GuardarDatos()
        {
            using StreamWriter writer = new StreamWriter(ArchivoPanaderia);
            string separator = ",";
            foreach (var pan in ListaProductos)
            {
                writer.WriteLine($"{pan.Nombre},{pan.Precio},{((int)pan.TipoProducto)},{pan.CantidadDisponible} ");
            }

        }

        public static void CargarDatos()
        {
            
            if (File.Exists(ArchivoPanaderia))
            {
                using StreamReader reader = new StreamReader(ArchivoPanaderia);

                foreach (var linea in File.ReadAllLines(ArchivoPanaderia))
                {
                    var sp = linea.Split(",");
                    var pan = new Producto(sp[0], decimal.Parse(sp[1]), int.Parse(sp[2]), int.Parse(sp[3]));
                    ListaProductos.Add(pan);
                }
            }
        }

        public static void ReducirStockProducto(string Nombre, int Stock)
        {

            var check = ListaProductos.FirstOrDefault(check => Nombre.Equals(check));
            check.ReducirStock(Stock);

        }
        public static void AumentarStockProducto(string Nombre, int Stock)
        {

            var check = ListaProductos.FirstOrDefault(check => Nombre.Equals(check));
            check.AumentarStock(Stock);
        }

    }
}
