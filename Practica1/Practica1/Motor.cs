using System;
namespace Practica1
{
    public class Motor : Componente
    {
        public Motor()
        {
            base.Precio = TipodeCambio.CambioMoneda(20);
        }

        public Motor(int clave) : base(clave)
        {
            base.Precio = TipodeCambio.CambioMoneda(20);
        }



        public override string ToString()
        {
            return "\t Motor --- " + base.ToString();
        } 
    }
}
