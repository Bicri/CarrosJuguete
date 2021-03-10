using System;
namespace Practica1
{
    public class Componente
    {
        private int clave;
        private double precio;

        public Componente()
        {
        }

        public Componente(int clave)
        {
            this.clave = clave;
        }

        public int Clave
        {
            get { return clave;  }
            set { clave = value; }
        }

        public double Precio
        {
            get { return precio; }
            set { precio = value; }
        }

        public override string ToString()
        {
            return string.Format("clave = {0}, precio = {1} pesos mexicanos", clave, precio);
        }
        
    }
}
