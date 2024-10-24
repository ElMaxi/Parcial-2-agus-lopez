using Parcial_2___Agustín_López.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial_2___Agustín_López.Models
{

    class Producto
    {
        public string Nombre { get; private set; }
        public decimal Precio { get; set; }
        public Delicatessen TipoProducto { get; private set; }
        public int CantidadDisponible { get; private set; }


        public Producto(string nombre, decimal precio, Delicatessen tipoProducto, int cantidadDisponible)
        {
            Nombre = nombre;
            Precio = precio;
            TipoProducto = tipoProducto;
            CantidadDisponible = cantidadDisponible;
        }
        public Producto(string nombre, decimal precio, int ValorTipoProducto, int cantidadDisponible)
        {
            Nombre = nombre;
            Precio = precio;
            /*  foreach (Delicatessen num in Enum.GetValues(typeof(Delicatessen)))
               {
                   if ((int)num == ValorTipoProducto)
                   {
                       TipoProducto = num;
                       break;
                   }*/
            
            
            CantidadDisponible = cantidadDisponible;
        }

        public decimal CalcularPrecio(decimal PrecioActual)
        {
            PrecioActual += Precio;
            return PrecioActual;
        }
        public void Actualizar(decimal precio, Delicatessen tipoProducto, int cantidadDisponible)
        {
            Precio = precio;
            TipoProducto = tipoProducto;
            CantidadDisponible = cantidadDisponible;

        }
        public void ReducirStock(int stock)
        {
            CantidadDisponible -= stock;

            Console.WriteLine($"Stock reducido por {stock} con éxito");
        }
        public void AumentarStock(int stock)
        {
            CantidadDisponible += stock;

            Console.WriteLine($"Stock aumentado por {stock} con éxito");
        }
    }
    }
    
