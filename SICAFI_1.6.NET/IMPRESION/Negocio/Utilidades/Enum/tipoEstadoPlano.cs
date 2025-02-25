using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JEJ.ImprimirFicha.Negocio.Utilidades.Enum
{
   public enum TipoEstadoPlano{
        error = -1,
        ninguno =0,
        iniciando=1,
        ConsultandoCopiandoArchivos=2,
        GenerandoMedidas=3,
        ImprimiendoPlano=4,
        Terminado=5
    }
}
