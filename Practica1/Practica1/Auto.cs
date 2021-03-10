using System;
namespace Practica1
{
    public class Auto
    {
        private Motor motor = new Motor();
        private Carroceria carroceria = new Carroceria();
        private Llanta[] llantas = new Llanta[4];
        private Adorno[] adornos = new Adorno[2];

        public void CrearAuto()
        {
            motor.Clave = 1;
            carroceria.Clave = 1;
            for (int i = 0; i < 4; i++)
            {
                if (i < 2)
                {
                    adornos[i] = new Adorno(i + 1);
                }
                llantas[i] = new Llanta(i + 1);
            }
        }

        public Auto()
        {
            CrearAuto();
        }

        public Auto(Auto auto)
        {
            if(auto == null)
            {
                CrearAuto();
            }
            else
            {
                motor.Clave = auto.motor.Clave + 1;
                carroceria.Clave = auto.carroceria.Clave + 1;
                for(int i=0; i<4; i++)
                {
                    if(i==0)
                    {
                        adornos[i] = new Adorno(auto.adornos[1].Clave + 1);
                        llantas[i] = new Llanta(auto.llantas[3].Clave + 1); 
                    }
                    else
                    {
                        if(i<2)
                        {
                            adornos[i] = new Adorno(adornos[i - 1].Clave + 1);
                        }
                        llantas[i] = new Llanta(llantas[i - 1].Clave + 1);
                    }
                }
            }
        }

        public override string ToString()
        {
            return "\n Auto: {\n" + motor.ToString() + "\n" + carroceria.ToString() + "\n" +
                adornos[0].ToString() + "\n" + adornos[1].ToString() + "\n" +
                llantas[0].ToString() + "\n" + llantas[1].ToString() + "\n" +
                llantas[2].ToString() + "\n" + llantas[3].ToString() + "   }";
        }

        public double CostoAuto()
        {
            return motor.Precio + carroceria.Precio + (adornos[0].Precio * 2) + (llantas[0].Precio * 4);
        }

        public double CostoMotor()
        {
            return motor.Precio;
        }

        public double CostoCarroceria()
        {
            return carroceria.Precio;
        }

        public double[] CostoLlanta()
        {
            double[] costo = new double[2];
            costo[0] = llantas[0].Precio;
            costo[1] = llantas[0].Precio*4;
            return costo;
        }

        public double[] CostoAdorno()
        {
            double[] costo = new double[2];
            costo[0] = adornos[0].Precio;
            costo[1] = adornos[0].Precio * 2;
            return costo;
        }
    }
}
