using System;
namespace Practica1
{
    public class Adorno : Componente
    {
        public Adorno()
        {
            base.Precio = TipodeCambio.CambioMoneda(1.50);
        }

        public Adorno(int clave) : base(clave)
        {
            base.Precio = TipodeCambio.CambioMoneda(1.50);
        }



        public override string ToString()
        {
            return "\t Adorno --- " + base.ToString();
        }
    }
}
