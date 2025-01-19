using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundamentosCSHARP.Models
{
    internal class Cerveza: Bebida, IBebidaAlcoholica, IRequestable
    {
        public int Alcohol { get; set; }
        public string Marca { get; set; }
        public int id { get; set; }

        public void MaxRecomendado()
        {
            Console.WriteLine("El máximo permitido de una cerveza son 10");
        }


        public Cerveza(): base("", 0)
        {
            Marca = "";
        }

        public Cerveza(int Cantidad=100, string Nombre = "Cerveza") : 
            base(Nombre, Cantidad) {
            Marca = "";
        }

        
    }
}
