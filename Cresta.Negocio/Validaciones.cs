using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Cresta.Negocio
{
    public class Validaciones
    {
        public static bool EsMailValido(string mail)
        {
            bool rta = false;
            Regex rx = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match m = rx.Match(mail);
            if (m.Success) { rta = true; };
            return rta;
        }
    }
}
