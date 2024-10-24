using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Parcial_2___Agustín_López.Models
{
    class Menu
    {
        static void Main()
        {
            Sistema.CargarDatos();
            int opcion = 0;
            do
            {
                Console.WriteLine($" - menu de interacción -\n" +
                    $"1. Mostrar Catalogo\n" +
                    $"2. Agregar Productos\n" +
                    $"3. Borrar Productos\n" +
                    $"4. Modificar Productos\n" +
                    $"5. Calcular Productos\n" +
                    $"6. Guardar y Salir");
                 opcion = int.Parse(Console.ReadLine());
                string Baneado = null;
                switch (opcion)
                {
                    case 1:
                        Sistema.ProductosMostrar();
                        break;

                    case 2:
                        Sistema.AgregarProducto();
                        break;

                    case 3:
                        Sistema.ProductosMostrarNombres();
                        Console.WriteLine($"\nIngrese el NOMBRE del producto a eliminar.\n");
                        Baneado = Console.ReadLine();
                        Sistema.EliminarProducto(Baneado);
                        break;

                    case 4:
                        Sistema.ProductosMostrarNombres();
                        Console.WriteLine($"\nIngrese el nombre del producto a modificar.\n");
                        Baneado = Console.ReadLine();
                        Sistema.ActualizarProducto(Baneado);
                        break;
                    case 5:
                        Sistema.ProductosCalcular();
                        break;
                    case 6:
                        Console.WriteLine($"Cerrando el programa B)");
                        Sistema.GuardarDatos();
                        break;
                    default:
                        Console.WriteLine($"Cerrando el programa B)");
                        Sistema.GuardarDatos();
                        break;
                }

            } while (opcion != 6);



        }

    }
}
