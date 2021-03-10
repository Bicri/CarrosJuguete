using System;
namespace Practica1
{
    public class Carroceria : Componente
    {
        public Carroceria()
        {
            base.Precio = TipodeCambio.CambioMoneda(15);
        }

        public Carroceria(int clave) : base(clave)
        {
            base.Precio = TipodeCambio.CambioMoneda(15);
        }



        public override string ToString()
        {
            return "\t Carroceria --- " + base.ToString();
        }
    }
}
