using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundamentosCSHARP.Models
{
    internal class Vino : Bebida, IBebidaAlcoholica
    {
        public int Alcohol { get; set; }

        public void MaxRecomendado()
        {
            Console.WriteLine("El máximo permitido son 4 copas");
        }

        public Vino(int Cantidad = 100, string Nombre = "Vino") :
            base(Nombre, Cantidad)
        {

        }


    }
}
