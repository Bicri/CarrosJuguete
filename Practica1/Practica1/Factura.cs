using System;
using System.Collections.Generic;

namespace Practica1
{
    public class Factura
    {
        private double[] costoTotal = new double[5];
        //costo[0] = motor
        //costo[1] = carroceria
        //costo[2] = adornos
        //costo[3] = llantas
        //costo[4] = Total
        private int[] piezasTotal = new int[5];
        //piezas[0] = motor
        //piezas[1] = carroceria
        //piezas[2] = adornos
        //piezas[3] = llantas
        //piezas[4] = total
        private double[] descuentos = new double[5];
        //costo[0] = motor
        //costo[1] = carroceria
        //costo[2] = adornos
        //costo[3] = llantas
        //costo[4] = Total

        private Auto auto = new Auto();

        private int autosPosibles=0;

        public Factura()
        {
        }


        private void ContarAutos()
        {
            if( (piezasTotal[0]==0 || piezasTotal[1] == 0 || piezasTotal[2] == 0 || piezasTotal[3] == 0) || (piezasTotal[3]-4)<0 || (piezasTotal[2] - 2) < 0 || (piezasTotal[1] - 1) < 0 || (piezasTotal[0] - 1) < 0)
            {
                autosPosibles = autosPosibles+0;
            }
            else
            {
                piezasTotal[0] -= 1;
                piezasTotal[1] -= 1;
                piezasTotal[2] -= 2;
                piezasTotal[3] -= 4;

                autosPosibles += 1;

                ContarAutos();
            }
        }

        public void AutosPosibles()
        {
            Console.WriteLine("\n \t\tTotal de piezas por adquirir: \t"+piezasTotal[4]);
            ContarAutos();
            if(autosPosibles==0)
            {
                Console.WriteLine("\n   No es posible ensamblar un solo carro con las piezas ingresadas");
            }
            else
            {
                Console.WriteLine("\n \tCantidad de autos posible a ensamblar: \t"+ autosPosibles);
                if(piezasTotal[0] == 0 && piezasTotal[1] == 0 && piezasTotal[2] == 0 && piezasTotal[3] == 0)
                {
                    Console.WriteLine("\n \tSe ocupara el total de las piezas");

                }
                else
                {
                    Console.WriteLine("\n \tPiezas sobrantes");
                    if(piezasTotal[0]>0)
                    {
                        Console.WriteLine(" \t\tMotores:\t"+ piezasTotal[0]);
                    }
                    if (piezasTotal[1] > 0)
                    {
                        Console.WriteLine(" \t\tCarroceria:\t" + piezasTotal[1]);
                    }
                    if (piezasTotal[2] > 0)
                    {
                        Console.WriteLine(" \t\tAdornos:\t" + piezasTotal[2]);
                    }
                    if (piezasTotal[3] > 0)
                    {
                        Console.WriteLine(" \t\tLlantas:\t" + piezasTotal[3]);
                    }
                }
            }
        }



        public void CotizacionAutos(int[] piezas)
        {
            piezasTotal[0] = piezas[0]; //motor
            piezasTotal[1] = piezas[1]; //carroceria
            piezasTotal[2] = piezas[2]; //adornos
            piezasTotal[3] = piezas[3]; //llantas
            piezasTotal[4] = piezasTotal[0] + piezasTotal[1] + piezasTotal[2] + piezasTotal[3];

            costoTotal[0] = piezasTotal[0] * auto.CostoMotor(); 
            costoTotal[1] = piezasTotal[1] * auto.CostoCarroceria();
            costoTotal[2] = piezasTotal[2] * auto.CostoAdorno()[0];
            costoTotal[3] = piezasTotal[3] * auto.CostoLlanta()[0];
            costoTotal[4] = costoTotal[0] + costoTotal[1] + costoTotal[2] + costoTotal[3];

            Console.WriteLine("\n\n\t\t\t\t\t Cotizacion por piezas");
            Console.WriteLine("----------------------------------------------------------------------------------------------------------");
            Console.WriteLine("\t\tPiezas \t\t Nombre \t\t Precio \t\t Subtotal");
            Console.WriteLine("\t\t{0} \t\t Motor \t\t\t {1} \t\t\t {2}",piezasTotal[0],auto.CostoMotor(),costoTotal[0]);

            Console.WriteLine("\t\t{0} \t\t Carroseria \t\t {1} \t\t\t {2}", piezasTotal[1], auto.CostoCarroceria(), costoTotal[1]);

            Console.WriteLine("\t\t{0} \t\t Adornos \t\t {1} \t\t\t {2}", piezasTotal[2], auto.CostoAdorno()[0], costoTotal[2]);

            Console.WriteLine("\t\t{0} \t\t Llantas \t\t {1} \t\t\t {2}", piezasTotal[3], auto.CostoLlanta()[0], costoTotal[3]);
            Console.WriteLine("\n  SUBTOTAL \t --- \t\t --- \t\t\t --- \t\t\t "+costoTotal[4]);

            Console.WriteLine("----------------------------------------------------------------------------------------------------------");


            if(piezasTotal[0]>=100)
            {
                Console.WriteLine("\n  DESCUENTOS");
                DescuentoMotorCarroseria(piezasTotal[0], true);
                DescuentoMotorCarroseria(piezasTotal[1], false);

            }


            if (costoTotal[4] > (1000 * 21.20))
            {
                Console.WriteLine("\n  OFERTAS 3x2");
                Console.WriteLine("\tAdornos");
                Oferta3x2(piezasTotal[2], costoTotal[2], auto.CostoAdorno()[0], true);
                Console.WriteLine("\tLlantas");
                Oferta3x2(piezasTotal[3], costoTotal[3], auto.CostoLlanta()[0], false);
            }

            descuentos[4] = descuentos[0] + descuentos[1] + descuentos[2] + descuentos[3];
            costoTotal[4] = costoTotal[4] - descuentos[4];
            Console.WriteLine("\n\t\t\t\tDESCUENTOS TOTALES: \t" + descuentos[4]);

            Console.WriteLine("----------------------------------------------------------------------------------------------------------");
            Console.WriteLine("\t\t\t\tTOTAL A PAGAR: $"+costoTotal[4]+" pesos mexicanos");
            Console.WriteLine("----------------------------------------------------------------------------------------------------------");

        }

        private void Oferta3x2(int piezas, double subtotal, double costoUnitario, bool flag)
        {
            int grupos = piezas / 3;
            int residuo = piezas % 3;
            double pagar = (grupos * 2 * costoUnitario) +(residuo*costoUnitario);
            double descuento = subtotal-pagar;


            Console.WriteLine("\t\t Piezas Totales: \t\t\t"+piezas);
            Console.WriteLine("\t\t Piezas con oferta 3x2: \t\t"+(grupos*3));
            Console.WriteLine("\t\t Piezas sin oferta: \t\t\t"+residuo);
            Console.WriteLine("\t\t Descuento: \t\t\t\t" + descuento);

            if(flag)
            {
                descuentos[2] = descuento;
            }
            else
            {
                descuentos[3] = descuento;
            }

        }

        private void DescuentoMotorCarroseria(int piezas, bool flag)
        {
            //flag true = Motor
            //flag false = Carroseria
            if(piezas>=100 && piezas < 500)
            {
                if(flag)
                {
                    descuentos[0] = costoTotal[0] * 0.05;
                }
                else
                {
                    descuentos[1] = costoTotal[1] * 0.05;
                }
            }
            else if(piezas>=500)
            {
                if (flag)
                {
                    descuentos[0] = costoTotal[0] * 0.1;
                }
                else
                {
                    descuentos[1] = costoTotal[1] * 0.1;
                }
            }
            else
            {
                if (flag)
                {
                    descuentos[0] = 0;
                }
                else
                {
                    descuentos[1] = 0;
                }
            }

            if(flag)
            {
                Console.WriteLine("  Descuento Motor \t\t ---\t\t\t "+ descuentos[0]);
            }
            else
            {
                Console.WriteLine("  Descuento Carroseria \t\t ---\t\t\t " + descuentos[1]);
            }

        }


    }

   
}
