using System;

namespace Practica1
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int[] piezas = new int[4];
            Factura factura = new Factura();

            Console.WriteLine("\n\n Ingresa cuantos motores deseas adquirir: ");
            piezas[0] = Convert.ToInt32( Console.ReadLine());
            Console.WriteLine("\n\n Ingresa cuantas carrocerias deseas adquirir: ");
            piezas[1] = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\n\n Ingresa cuantos adornos deseas adquirir: ");
            piezas[2] = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\n\n Ingresa cuantas llantas deseas adquirir: ");
            piezas[3] = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            factura.CotizacionAutos(piezas);
            factura.AutosPosibles();
        }
    }
}
