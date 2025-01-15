using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundamentosCSHARP.Models
{
    internal interface IBebidaAlcoholica
    {
        public int Alcohol {  get; set; }

        public void MaxRecomendado();

    }
}
