using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Comparadores
{
    public class ComparadorPorFecha : IComparer<Pasaje>
    {
        public int Compare(Pasaje x, Pasaje y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return 1;
            if (y == null) return -1;
            return x.FechaVuelo.CompareTo(y.FechaVuelo);
        }
    }

}
