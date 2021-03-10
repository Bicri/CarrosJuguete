using System;
namespace Practica1
{
    public class Llanta : Componente
    {
        public Llanta()
        {
            base.Precio = TipodeCambio.CambioMoneda(1);
        }

        public Llanta(int clave) : base(clave)
        {
            base.Precio = TipodeCambio.CambioMoneda(1);
        }



        public override string ToString()
        {
            return "\t Llanta --- " + base.ToString();
        }
    }
}
