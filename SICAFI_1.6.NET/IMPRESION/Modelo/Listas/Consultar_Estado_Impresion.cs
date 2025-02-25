using JEJ.ImprimirFicha.Negocio.Utilidades.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JEJ.ImprimirFicha.Modelo.Listas
{
    public class Consultar_Estado_Impresion
    {
        public int intIdFichaImpresion { get; set; }
        public int intNufi { get; set; }
        public string strRutaPredio { get; set; }
        public string strRutaConstrucion { get; set; }
        public string strRutaGDB { get; set; }
        public string strUi { get; set; }
        public TipoEstadoPlano intEstado { get; set; }
    }
}
