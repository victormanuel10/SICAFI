using JEJ.ImprimirFicha.Negocio.Utilidades.Enum;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JEJ.ImprimirFicha.Modelo
{
    class EntitySicafi : Conexion
    {
        public EntitySicafi(string strServidor, string strBaseDatos, string strUsuario, string strClave)
           : base(strServidor, strBaseDatos, strUsuario, strClave)
        {

        }
        #region CONSULTAR CONSRUCCION
        public List<Listas.Consultar_Construcciones_Result> Consultar_Construcciones(int? nufi
                                                                                   , string strTipo)
        {
            List<Listas.Consultar_Construcciones_Result> ls = new List<Listas.Consultar_Construcciones_Result>();
            try
            {
                string sql = "";
                // sql += "  declare @nufi int=" + (nufi == null ? "null" : Convert.ToString(nufi)) + "  \n";
                sql += " select     \n";
                sql += " Convert(varchar(50),(select TOP 1 MT.TICOTIPO      \n";
                sql += " from [dbo].[MANT_TIPOCONS] MT          \n";
                sql += " where MT.TICOCODI=C.FPCOTICO          \n";
                sql += " ) )TipoConst          \n";
                sql += " ,Convert(varchar(50),C.FPCOUNID)  Unidad     \n";
                sql += " ,Convert(varchar(50),C.FPCOACUE)  Acueducto       \n";
                sql += " ,Convert(varchar(50),C.FPCOALCA)  Alcantarillado       \n";
                sql += " ,Convert(varchar(50),C.FPCOENER)  Energia        \n";
                sql += " ,Convert(varchar(50),C.FPCOTELE)  Telefono        \n";
                sql += " ,Convert(varchar(50),C.FPCOGAS)  Gas        \n";
                sql += " ,Convert(varchar(50),C.FPCOPISO)  Pisos        \n";
                sql += " ,Convert(varchar(50),C.FPCOEDCO)  Edad        \n";
                sql += " ,Convert(varchar(50),C.FPCOPOCO)  Porcentaje       \n";
                sql += " , isnull(convert(varchar(2),(select sum(CAL.[FPCCPUNT])       \n";
                sql += "     from [dbo].[FIPRCACO] CAL       \n";
                sql += " where CAL.FPCCNUFI=C.FPCONUFI       \n";
                sql += " and CAL.FPCCUNID=C.FPCOUNID       \n";
                sql += " and CAL.FPCCCODI<200)),' ') Puntos100       \n";
                sql += " , isnull(convert(varchar(2),(select sum(CAL.[FPCCPUNT])      \n";
                sql += " from [dbo].[FIPRCACO] CAL       \n";
                sql += " where CAL.FPCCNUFI=C.FPCONUFI       \n";
                sql += " and CAL.FPCCUNID=C.FPCOUNID       \n";
                sql += " and (CAL.FPCCCODI<300 and CAL.FPCCCODI>=200))),' ') Puntos200      \n";
                sql += " , isnull(convert(varchar(2),(select sum(CAL.[FPCCPUNT])       \n";
                sql += " from [dbo].[FIPRCACO] CAL       \n";
                sql += " where CAL.FPCCNUFI=C.FPCONUFI       \n";
                sql += " and CAL.FPCCUNID=C.FPCOUNID       \n";
                sql += " and (CAL.FPCCCODI<400 and CAL.FPCCCODI>=300))),' ') Puntos300      \n";
                sql += " , isnull(convert(varchar(2),(select sum(CAL.[FPCCPUNT])       \n";
                sql += " from [dbo].[FIPRCACO] CAL       \n";
                sql += " where CAL.FPCCNUFI=C.FPCONUFI       \n";
                sql += " and CAL.FPCCUNID=C.FPCOUNID       \n";
                sql += " and (CAL.FPCCCODI<500 and CAL.FPCCCODI>400))),' ') Puntos400       \n";
                sql += " , isnull(convert(varchar(2),(select sum(CAL.[FPCCPUNT])       \n";
                sql += " from [dbo].[FIPRCACO] CAL       \n";
                sql += " where CAL.FPCCNUFI=C.FPCONUFI       \n";
                sql += " and CAL.FPCCUNID=C.FPCOUNID       \n";
                sql += " and(CAL.FPCCCODI<600 and CAL.FPCCCODI>=500))),' ') Puntos500       \n";
                sql += " , isnull(convert(varchar(2),(select sum(CAL.[FPCCPUNT])       \n";
                sql += " from [dbo].[FIPRCACO] CAL       \n";
                sql += " where CAL.FPCCNUFI=C.FPCONUFI       \n";
                sql += " and CAL.FPCCUNID=C.FPCOUNID)),' ') PuntosTotales      \n";
                sql += " ,(RTRIM(LTRIM(P.[FIPRMUNI]))   \n";
                sql += " +(RTRIM(LTRIM(convert( varchar(2),P.FIPRCLSE))))   \n";
                sql += " +(RTRIM(LTRIM(P.FIPRCORR)))   \n";
                sql += " +(RTRIM(LTRIM(P.FIPRBARR)))   \n";
                sql += " +(RTRIM(LTRIM(P.FIPRMANZ)))   \n";
                sql += " +(RTRIM(LTRIM(P.FIPRPRED)))   \n";
                sql += " +(RTRIM(LTRIM(P.[FIPREDIF])))   \n";
                sql += " +(RTRIM(LTRIM(P.FIPRUNPR)))   \n";
                sql += " +(right('00000'+RTRIM(LTRIM(Convert(varchar(50),C.FPCOUNID))),5))   \n";
                sql += " ) pkConstruccionAlfanumerico   \n";
                sql += " ,(right('00000'+(RTRIM(LTRIM(P.[FIPRMUNI]))),3)   \n";
                sql += " +(right('00000'+(RTRIM(LTRIM(convert( varchar(2),P.FIPRCLSE)))),1))   \n";
                sql += " +(right('00000'+(RTRIM(LTRIM(P.FIPRCORR))),3))   \n";
                sql += " +(right('00000'+(RTRIM(LTRIM(P.FIPRBARR))),3))   \n";
                sql += " +(right('00000'+(RTRIM(LTRIM(P.FIPRMANZ))),4))   \n";
                sql += " +(right('00000'+(RTRIM(LTRIM(P.FIPRPRED))),5))   \n";
                sql += " +(right('00000'+(RTRIM(LTRIM(P.[FIPREDIF])) ),4))   \n";
                sql += " +(right('00000'+(RTRIM(LTRIM(P.FIPRUNPR))),5))   \n";
                sql += " +(right('00000'+RTRIM(LTRIM(Convert(varchar(50),C.FPCOUNID))),5))   \n";
                sql += " ) pkConstruccionGrafico   \n";
                sql += " ,(RTRIM(LTRIM(P.[FIPRMUNI]))   \n";
                sql += " +(RTRIM(LTRIM(convert( varchar(2),P.FIPRCLSE))))   \n";
                sql += " +(RTRIM(LTRIM(P.FIPRCORR)))   \n";
                sql += " +(RTRIM(LTRIM(P.FIPRBARR)))   \n";
                sql += " +(RTRIM(LTRIM(P.FIPRMANZ)))   \n";
                sql += " +(RTRIM(LTRIM(P.FIPRPRED)))   \n";
                sql += " ) pkPredio   \n";
                sql += " ,(right('00000'+(RTRIM(LTRIM(P.[FIPRMUNI]))),3)   \n";
                sql += " +(right('00000'+(RTRIM(LTRIM(convert( varchar(2),P.FIPRCLSE)))),1))   \n";
                sql += " +(right('00000'+(RTRIM(LTRIM(P.FIPRCORR))),3))   \n";
                sql += " +(right('00000'+(RTRIM(LTRIM(P.FIPRBARR))),3))   \n";
                sql += " +(right('00000'+(RTRIM(LTRIM(P.FIPRMANZ))),4))   \n";
                sql += " +(right('00000'+(RTRIM(LTRIM(P.FIPRPRED))),5))   \n";
                sql += " ) pkPredioGrafico   \n";
                sql += ",convert(varchar(50), P.[FIPRNUFI] )\n";
                sql += ",ltrim(rtrim(convert(varchar(50), P.[FIPRUNPR] )))\n";
                sql += ",convert(varchar(2), C.FPCOCLCO )  \n";

                sql += " ,Convert(varchar(50),C.FPCOTICO)  Identificador     \n";
                sql += " ,Convert(varchar(50),C.FPCOARCO )  Ares     \n";
                sql += "  ,Convert(varchar(50), (case          \n";
                sql += " when C.FPCOMEJO = 0 then 'NO'   \n";
                sql += " when C.FPCOMEJO = 1 then 'SI'   \n";
                sql += " end)) Mejora   \n";
                sql += " ,Convert(varchar(50), (case        \n";
                sql += " when C.FPCOLEY = 0 then 'NO'   \n";
                sql += " when C.FPCOLEY = 1 then 'SI'   \n";
                sql += " end)) Ley56   \n";
                sql += "  ,(select top 1 MTC.TICODESC    \n";
                sql += " from[dbo].[MANT_TIPOCONS]    MTC    \n";
                sql += " where MTC.TICOCODI=C.FPCOTICO    \n";
                sql += " and MTC.TICOMUNI=C.FPCOMUNI)    \n";

                sql += " from [dbo].[FIPRCONS] C        \n";
                sql += " inner join   [dbo].[FICHPRED] P on C.FPCONUFI=P.[FIPRNUFI]   \n";
                sql += " where (C.FPCONUFI=" + nufi + ")   \n";
                sql += "and  C.[FPCOCLCO]='" + strTipo + "' \n";
                sql += "and  P.[FIPRESTA]='ac' \n";
                sql += "order by  C.FPCOUNID \n";
                SqlDataReader read = this.EjecutarConsulta(sql);
                if (read != null)
                {
                    if (read.HasRows)
                    {
                        while (read.Read())
                        {
                            Listas.Consultar_Construcciones_Result objConstruccion = new Listas.Consultar_Construcciones_Result();

                            objConstruccion.strTipoConstruccion = read.GetString(0);
                            objConstruccion.strUnidad = read.GetString(1);
                            objConstruccion.strAcueducto = read.GetString(2);
                            objConstruccion.strAlcantarillado = read.GetString(3);
                            objConstruccion.strEnergia = read.GetString(4);
                            objConstruccion.strTelefono = read.GetString(5);
                            objConstruccion.strGas = read.GetString(6);
                            objConstruccion.strPisos = read.GetString(7);
                            objConstruccion.strEdad = read.GetString(8);
                            objConstruccion.strPorcentajeConstruido = read.GetString(9);
                            objConstruccion.strTotalPuntos100 = read.GetString(10);
                            objConstruccion.strTotalPuntos200 = read.GetString(11);
                            objConstruccion.strTotalPuntos300 = read.GetString(12);
                            objConstruccion.strTotalPuntos400 = read.GetString(13);
                            objConstruccion.strTotalPuntos500 = read.GetString(14);
                            objConstruccion.strTotalPuntos = read.GetString(15);
                            objConstruccion.strPkConstruccionALfanumerico = read.GetString(16);
                            objConstruccion.strPkConstruccionGeografico = read.GetString(17);
                            objConstruccion.strPkPredioALfanumerico = read.GetString(18);
                            objConstruccion.strPkPredioGeografico = read.GetString(19);
                            objConstruccion.strNufi = read.GetString(20);
                            objConstruccion.strUnidadPredial = read.GetString(21);
                            objConstruccion.strClaseConstruccion = read.GetString(22);
                            objConstruccion.strIdentificador = read.GetString(23);
                            objConstruccion.strArea = read.GetString(24);
                            objConstruccion.strMejora = read.GetString(25);
                            objConstruccion.strLey59 = read.GetString(26);
                            objConstruccion.strDescripcionIdentificador = read.GetString(27);
                            ls.Add(objConstruccion);
                        }
                    }
                    else
                    {
                        ls = new List<Listas.Consultar_Construcciones_Result>();
                    }
                }
                else
                {
                    ls = new List<Listas.Consultar_Construcciones_Result>();
                }

            }
            catch (Exception ex)
            {
                ls = new List<Listas.Consultar_Construcciones_Result>();
            }
            this.Desconectar();
            return ls;
        }
        #endregion

        #region CONSULTAR PREDIO
        public List<Listas.Consultar_Predio_Result> Consultar_Predio(string strMunicipio
                                    , string strSector
                                    , string strCorregimiento
                                    , string strBarrio
                                    , string strManzna
                                    , string strPredio
                                    , string strEdificio
                                    , string strUnidadPredial
                                    , string strNumeroFicha)
        {
            List<Listas.Consultar_Predio_Result> objLstPredio = new List<Listas.Consultar_Predio_Result>();
            try
            {
                strMunicipio = strMunicipio == string.Empty ? "null  \n" : "'" + strMunicipio + "'  \n";
                strSector = strSector == string.Empty ? "null  \n" : strSector;
                strCorregimiento = strCorregimiento == string.Empty ? "null  \n" : "'" + strCorregimiento + "'  \n";
                strBarrio = strBarrio == string.Empty ? "null  \n" : "'" + strBarrio + "'  \n";
                strManzna = strManzna == string.Empty ? "null  \n" : "'" + strManzna + "'  \n";
                strPredio = strPredio == string.Empty ? "null  \n" : "'" + strPredio + "'  \n";
                strEdificio = strEdificio == string.Empty ? "null  \n" : "'" + strEdificio + "'  \n";
                strUnidadPredial = strUnidadPredial == string.Empty ? "null  \n" : "'" + strUnidadPredial + "'  \n";
                strNumeroFicha = strNumeroFicha == string.Empty ? "" : "and P.FIPRNUFI in(" + strNumeroFicha + ")";

                //string sql = "declare @Municipio varchar(3)='" + strMunicipio + "' \n";
                //string sql = "declare @Municipio varchar(3)='266' \n";
                string sql=" ";
                /*sql += "declare @Sector int=" + strSector + "  \n";
                sql += "declare @Corregimiento varchar(2)=" + strCorregimiento + "  \n";
                sql += "declare @Barrio varchar(3)=" + strBarrio + "  \n";
                sql += "declare @Manzana varchar(3)=" + strManzna + "  \n";
                sql += "declare @Predio varchar(5)=" + strPredio + "  \n";
                sql += "declare @Edificio varchar(3)=" + strEdificio + "  \n";
                sql += "declare @UnidadPredial varchar(3)=" + strUnidadPredial + "  \n";*/
                sql += "select   \n";
                sql += "convert(varchar(max),P.FIPRDIRE) Dirreccion   \n";
                sql += ",convert(varchar(3),P.FIPRMUNI) Municipio   \n";
                sql += ",convert(varchar(1),P.FIPRCLSE) Clase   \n";
                sql += ",convert(varchar(2),P.FIPRCORR) Corregimiento   \n";
                sql += ",convert(varchar(3),P.FIPRBARR) Barrio   \n";
                sql += ",convert(varchar(3),P.FIPRMANZ) Manzana   \n";
                sql += ",convert(varchar(5),P.FIPRPRED) Predio   \n";
                sql += ",convert(varchar(3),P.FIPREDIF) Edificio   \n";
                sql += ",convert(varchar(5),P.FIPRUNPR) UnidadPredial   \n";
                sql += ",convert(varchar(3),P.FIPRMUAN) AntMunicipio   \n";
                sql += ",convert(varchar(1),P.FIPRCSAN) AntClase   \n";
                sql += ",convert(varchar(2),P.FIPRCOAN) AntCorregimiento   \n";
                sql += ",convert(varchar(3),P.FIPRBAAN) AntBarrio   \n";
                sql += ",convert(varchar(3),P.FIPRMAAN) AntManzana   \n";
                sql += ",convert(varchar(5),P.FIPRPRAN) AntPredio   \n";
                sql += ",convert(varchar(3),P.FIPREDAN) AntEdificio   \n";
                sql += ",convert(varchar(5),P.FIPRUPAN) AntUnidadPredial   \n";
                sql += ",convert(varchar(2),D.FPDEDEEC) DestinoEconomico   \n";
                sql += ",convert(varchar(2),P.FIPRCAPR) CaracteristicaPredio   \n";
                sql += ",convert(varchar(2),P.FIPRMOAD) ModoAdquisicion   \n";
                sql += ",convert(varchar(2),P.FIPRLITI) Litigio   \n";
                sql += ",convert(varchar(max),P.FIPRPOLI) PorcentajeLitigio   \n";
                sql += " ,isnull((select top 1 PR.FPPRMAIN    \n";
                sql += " from [dbo].[FIPRPROP] PR    \n";
                sql += " where PR.FPPRNUFI=P.FIPRNUFI),'') Matricula    \n";
                sql += ",convert(varchar(35),P.FIPRNUFI) NumeroFicha     \n";
                sql += ",isnull((select top 1 PR.FPPRTOMO    \n";
                sql += "from [dbo].[FIPRPROP] PR    \n";
                sql += "where PR.FPPRNUFI=P.FIPRNUFI),'') Tomo    \n";
                sql += " ,convert(varchar(250),P.[FIPRARTE]) AreaTerreno  \n";
                sql += " ,convert(varchar(250),P.[FIPRCOED]) CoeficientePredio  \n";
                sql += " ,convert(varchar(2),P.[FIPRTIFI]) TipoFicha  \n";
                sql += ",convert(varchar(250),P.[FIPRATLO]) AreaTotalLote  \n";
                sql += ",convert(varchar(250),P.[FIPRACLO])AreaComunLote  \n";
                sql += ",convert(varchar(250),P.[FIPRAPLO])AreaPrivadaLote  \n";
                sql += ",convert(varchar(250),P.[FIPRTOED]) Edificios  \n";
                sql += ",convert(varchar(250),P.[FIPRUNCO])UnidadesEnCOndominio  \n";
                sql += ",convert(varchar(250),P.[FIPRURPH])UnidadesRPH  \n";
                sql += ",convert(varchar(250),P.[FIPRAPCA])AparatamentosOCasas  \n";
                sql += ",convert(varchar(250),P.[FIPRLOCA])Locales  \n";
                sql += ",convert(varchar(250),P.[FIPRCUUT])CUartosUriles  \n";
                sql += ",convert(varchar(250),P.[FIPRGACU])GarajesCubiertos  \n";
                sql += ",convert(varchar(250),P.[FIPRGADE])GarejesDescubierto  \n";
                sql += ",convert(varchar(250),P.[FIPRPISO])Pisos  \n";
                sql += ",DE.DEECDESC DestinoEconomicoDescripcion \n";
                sql += ",convert(varchar(250), MAD.MOADDESC) ModoAdquisicionDescripcion \n";
                sql += ",CAP.CAPRDESC \n";
                sql += ",(SELECT top 1 [MUNIDESC] \n";
                sql += "FROM[SICAFI].[dbo].[MANT_MUNICIPIO] M \n";
                sql += "where M.MUNICODI = P.FIPRMUNI \n";
                sql += "and M.MUNIDEPA = P.FIPRDEPA) Municipio \n";
                sql += ",(SELECT top 1 [CORRDESC] \n";
                sql += " FROM[SICAFI].[dbo].[MANT_CORREGIMIENTO] MC \n";
                sql += "where MC.CORRDEPA = P.FIPRDEPA \n";
                sql += " and MC.CORRMUNI = P.FIPRMUNI \n";
                sql += " and MC.CORRCODI = P.FIPRCORR \n";
                sql += " and MC.CORRCLSE = 1) Corregimiento \n";
                sql += " ,(SELECT top 1 [BAVEDESC] \n";
                sql += " FROM[SICAFI].[dbo].[MANT_BARRVERE] MBV \n";
                sql += "where MBV.BAVEDEPA = P.FIPRDEPA \n";
                sql += " and MBV.BAVEMUNI = P.FIPRMUNI \n";
                sql += " and MBV.BAVECLSE = P.FIPRCLSE \n";
                sql += "and MBV.BAVECORR = P.FIPRCORR \n";
                sql += "and MBV.BAVECODI = (case \n";
                sql += "                 when P.FIPRCLSE = 1 then P.FIPRBARR \n";
                sql += "				else P.FIPRMANZ \n";
                sql += "                end)) BarrioManzana \n";

                sql += "  ,convert(varchar(4),(select top 1 EFP.ESFPESTR \n";
                sql += "  from[dbo].[ESTRFIPR]   EFP \n";
                sql += "  where EFP.ESFPNUFI=P.FIPRNUFI)) \n";
                sql += "  ,(select top 1 ME.ESTRDESC \n";
                sql += "  from[dbo].[ESTRFIPR] EFP \n";
                sql += "  inner join[dbo].[MANT_ESTRATO] ME on ME.ESTRCODI= EFP.ESFPESTR \n";
                sql += "  where EFP.ESFPNUFI= P.FIPRNUFI) \n";

                sql += ",convert(varchar(4),P.[FIPRCASU]) \n";
                sql += " ,(select top 1 CS.CASUDESC \n";
                sql += " from[dbo].[MANT_CATESUEL] CS \n";
                sql += " where CS.CASUCODI=P.FIPRCASU) \n";

                sql += "  ,convert(varchar(250), (select top 1 sum(convert(numeric(22, 2), C.FPCOARCO)) \n";
                sql += " from FIPRCONS C \n";
                sql += " where C.FPCONUFI = P.FIPRNUFI)) AreaConstruccion \n";
                sql += ",FIPRFEMO \n";

                sql += ", P.FIPROBSE \n";
                sql += " ,[FIPRDESC]\n";

                sql += "from [dbo].[FICHPRED] P  \n";
                sql += "INNER JOIN [dbo].[FIPRDEEC] D ON P.FIPRNUFI=D.FPDENUFI \n";
                sql += "INNER JOIN [dbo].[MANT_DESTECON] DE ON DE.DEECCODI=D.FPDEDEEC \n";
                sql += "INNER JOIN [dbo].[MANT_MODOADQU] MAD ON MAD.MOADCODI=P.FIPRMOAD  \n";
                sql += "INNER JOIN [dbo].[MANT_CARAPRED] CAP ON CAP.CAPRCODI=P.FIPRCAPR  \n";
                sql += "where (P.FIPRMUNI='266')  \n";
                /*sql += "and (P.FIPRCLSE=@Sector or @Sector is null)  \n";
                sql += "and (P.FIPRCORR =@Corregimiento or @Corregimiento is null)  \n";
                sql += "and (P.FIPRBARR=@Barrio or @Barrio is null)  \n";
                sql += "and (P.FIPRMANZ=@Manzana or @Manzana is null)  \n";
                sql += "and (P.FIPRPRED=@Predio or @Predio is null)  \n";
                sql += "and (P.FIPREDIF=@Edificio or @Edificio is null)  \n";
                sql += "and(P.FIPRUNPR=@UnidadPredial or @UnidadPredial is null)  \n";*/
                sql += "and P.[FIPRESTA]='ac' \n";
                sql += strNumeroFicha;
                SqlDataReader read = this.EjecutarConsulta(sql);
                if (read != null)
                {
                    if (read.HasRows)
                    {
                        while (read.Read())
                        {
                            Listas.Consultar_Predio_Result Predio = new Listas.Consultar_Predio_Result();
                            Predio.strDirreccion = (read[0] != System.DBNull.Value ? read.GetString(0) : string.Empty);
                            Predio.strMunicipio = (read[1] != System.DBNull.Value ? read.GetString(1) : string.Empty);
                            Predio.strSector = (read[2] != System.DBNull.Value ? read.GetString(2) : string.Empty);
                            Predio.strCorregimiento = (read[3] != System.DBNull.Value ? read.GetString(3) : string.Empty);
                            Predio.strBarrio = (read[4] != System.DBNull.Value ? read.GetString(4) : string.Empty);
                            Predio.strManzana = (read[5] != System.DBNull.Value ? read.GetString(5) : string.Empty);
                            Predio.strPredio = (read[6] != System.DBNull.Value ? read.GetString(6) : string.Empty);
                            Predio.strEdificio = (read[7] != System.DBNull.Value ? read.GetString(7) : string.Empty);
                            Predio.strUnidadPredial = (read[8] != System.DBNull.Value ? read.GetString(8) : string.Empty);
                            Predio.strAntMunicipio = (read[9] != System.DBNull.Value ? read.GetString(9) : string.Empty);
                            Predio.strAntSector = (read[10] != System.DBNull.Value ? read.GetString(10) : string.Empty);
                            Predio.strAntCorregimiento = (read[11] != System.DBNull.Value ? read.GetString(11) : string.Empty);
                            Predio.strAntBarrio = (read[12] != System.DBNull.Value ? read.GetString(12) : string.Empty);
                            Predio.strAntManzana = (read[13] != System.DBNull.Value ? read.GetString(13) : string.Empty);
                            Predio.strAntPredio = (read[14] != System.DBNull.Value ? read.GetString(14) : string.Empty);
                            Predio.strAntEdificio = (read[15] != System.DBNull.Value ? read.GetString(15) : string.Empty);
                            Predio.strAntUnidadPredial = (read[16] != System.DBNull.Value ? read.GetString(16) : string.Empty);
                            Predio.strDestinoEconomico = (read[17] != System.DBNull.Value ? read.GetString(17) : string.Empty);
                            Predio.strCaracteristicaPredio = (read[18] != System.DBNull.Value ? read.GetString(18) : string.Empty);
                            Predio.strModoAdquisicion = (read[19] != System.DBNull.Value ? read.GetString(19) : string.Empty);
                            Predio.strLitigio = (read[20] != System.DBNull.Value ? read.GetString(20) : string.Empty);
                            Predio.strPorcentajeLitigio = (read[21] != System.DBNull.Value ? read.GetString(21) : string.Empty);
                            Predio.strMatricula = (read[22] != System.DBNull.Value ? read.GetString(22) : string.Empty);
                            Predio.strNumeroFicha = (read[23] != System.DBNull.Value ? read.GetString(23) : string.Empty);
                            Predio.strTomo = (read[24] != System.DBNull.Value ? read.GetString(24) : string.Empty);
                            Predio.strAreaTerreno = (read[25] != System.DBNull.Value ? read.GetString(25) : string.Empty);
                            Predio.strCoeficientePredio = (read[26] != System.DBNull.Value ? read.GetString(26) : string.Empty);
                            Predio.strTipoFicha = (read[27] != System.DBNull.Value ? read.GetString(27) : string.Empty);

                            Predio.strAreaTotalLote = (read[28] != System.DBNull.Value ? read.GetString(28) : string.Empty);
                            Predio.strAreaComunLote = (read[29] != System.DBNull.Value ? read.GetString(29) : string.Empty);
                            Predio.strAreaPrivadaLote = (read[30] != System.DBNull.Value ? read.GetString(30) : string.Empty);
                            Predio.strTotalEdificios = (read[31] != System.DBNull.Value ? read.GetString(31) : string.Empty);
                            Predio.strUnidadesEnCondominio = (read[32] != System.DBNull.Value ? read.GetString(32) : string.Empty);
                            Predio.strUnidadesRPH = (read[33] != System.DBNull.Value ? read.GetString(33) : string.Empty);
                            Predio.strAparatamentosOCasas = (read[34] != System.DBNull.Value ? read.GetString(34) : string.Empty);
                            Predio.strLocales = (read[35] != System.DBNull.Value ? read.GetString(35) : string.Empty);
                            Predio.strCuartosUriles = (read[36] != System.DBNull.Value ? read.GetString(36) : string.Empty);
                            Predio.strGarajesCubiertos = (read[37] != System.DBNull.Value ? read.GetString(37) : string.Empty);
                            Predio.strGarejesDescubierto = (read[38] != System.DBNull.Value ? read.GetString(38) : string.Empty);
                            Predio.strPisos = (read[39] != System.DBNull.Value ? read.GetString(39) : string.Empty);
                            Predio.strDestinoEconomicoDescripcion = (read[40] != System.DBNull.Value ? read.GetString(40) : string.Empty);
                            Predio.strModoAdquisicionDescripcion = (read[41] != System.DBNull.Value ? read.GetString(41) : string.Empty);
                            Predio.strCaracteristicaPredioDescripcion = (read[42] != System.DBNull.Value ? read.GetString(42) : string.Empty);

                            Predio.strNombreMunicipio = (read[43] != System.DBNull.Value ? read.GetString(43) : string.Empty);
                            Predio.strNombreCorregimiento = (read[44] != System.DBNull.Value ? read.GetString(44) : string.Empty);
                            Predio.strNombreBarrio = Predio.strSector == "1" ? (read[45] != System.DBNull.Value ? read.GetString(45) : string.Empty) : Predio.strBarrio;
                            Predio.strNombreVereda = Predio.strSector != "1" ? (read[45] != System.DBNull.Value ? read.GetString(45) : string.Empty) : Predio.strManzana;
                            Predio.strCodigoEstrado = (read[46] != System.DBNull.Value ? read.GetString(46) : string.Empty);
                            Predio.strDescripcionEstrato = (read[47] != System.DBNull.Value ? read.GetString(47) : string.Empty);
                            Predio.strCodigoCategoriaSuelo = (read[48] != System.DBNull.Value ? read.GetString(48) : string.Empty);
                            Predio.strDescripcionCategoriaSuelo = (read[49] != System.DBNull.Value ? read.GetString(49) : string.Empty);
                            Predio.strAreaConstruccion = (read[50] != System.DBNull.Value ? read.GetString(50) : string.Empty);
                            Predio.strFechaModificacion = (read[50] != System.DBNull.Value ? read.GetDateTime(51) : new DateTime());
                            Predio.strObservacionFicha = (read[52] != System.DBNull.Value ? read.GetString(52) : string.Empty);
                            Predio.strDescripcionPredio = (read[53] != System.DBNull.Value ? read.GetString(53) : string.Empty);

                            objLstPredio.Add(Predio);

                        }
                    }
                    else
                    {
                        objLstPredio = new List<Listas.Consultar_Predio_Result>();
                    }
                }
                else
                {
                    objLstPredio = new List<Listas.Consultar_Predio_Result>();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message+"-Consulta Predio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                objLstPredio = new List<Listas.Consultar_Predio_Result>();
            }
            this.Desconectar();
            return objLstPredio;
        }
        #endregion

        #region CONSULTAR PREDIO Resumen
        public List<Listas.Consultar_Predio_Result> Consultar_Predio_Resumen(string strMunicipio
                                    , string strSector
                                    , string strCorregimiento
                                    , string strBarrio
                                    , string strManzna
                                    , string strPredio
                                   )
        {
            List<Listas.Consultar_Predio_Result> objLstPredio = new List<Listas.Consultar_Predio_Result>();
            try
            {
                strMunicipio = strMunicipio == string.Empty ? "null  \n" : "'" + strMunicipio + "'  \n";
                strSector = strSector == string.Empty ? "null  \n" : strSector;
                strCorregimiento = strCorregimiento == string.Empty ? "null  \n" : "'" + strCorregimiento + "'  \n";
                strBarrio = strBarrio == string.Empty ? "null  \n" : "'" + strBarrio + "'  \n";
                strManzna = strManzna == string.Empty ? "null  \n" : "'" + strManzna + "'  \n";
                strPredio = strPredio == string.Empty ? "null  \n" : "'" + strPredio + "'  \n";


                string sql =" ";
                /*declare @Municipio varchar(3)=" + strMunicipio + " \n";
                sql += "declare @Sector int=" + strSector + "  \n";
                sql += "declare @Corregimiento varchar(2)=" + strCorregimiento + "  \n";
                sql += "declare @Barrio varchar(3)=" + strBarrio + "  \n";
                sql += "declare @Manzana varchar(3)=" + strManzna + "  \n";
                sql += "declare @Predio varchar(5)=" + strPredio + "  \n";*/

                sql += "select   \n";
                sql += "convert(varchar(max),P.FIPRDIRE) Dirreccion   \n";
                sql += ",convert(varchar(3),P.FIPRMUNI) Municipio   \n";
                sql += ",convert(varchar(1),P.FIPRCLSE) Clase   \n";
                sql += ",convert(varchar(2),P.FIPRCORR) Corregimiento   \n";
                sql += ",convert(varchar(3),P.FIPRBARR) Barrio   \n";
                sql += ",convert(varchar(3),P.FIPRMANZ) Manzana   \n";
                sql += ",convert(varchar(5),P.FIPRPRED) Predio   \n";
                sql += ",convert(varchar(3),P.FIPREDIF) Edificio   \n";
                sql += ",convert(varchar(5),P.FIPRUNPR) UnidadPredial   \n";
                sql += ",convert(varchar(3),P.FIPRMUAN) AntMunicipio   \n";
                sql += ",convert(varchar(1),P.FIPRCSAN) AntClase   \n";
                sql += ",convert(varchar(2),P.FIPRCOAN) AntCorregimiento   \n";
                sql += ",convert(varchar(3),P.FIPRBAAN) AntBarrio   \n";
                sql += ",convert(varchar(3),P.FIPRMAAN) AntManzana   \n";
                sql += ",convert(varchar(5),P.FIPRPRAN) AntPredio   \n";
                sql += ",convert(varchar(3),P.FIPREDAN) AntEdificio   \n";
                sql += ",convert(varchar(5),P.FIPRUPAN) AntUnidadPredial   \n";
                sql += " ,convert(varchar(250),P.[FIPRARTE]) AreaTerreno  \n";
                sql += " ,convert(varchar(250),P.[FIPRCOED]) CoeficientePredio  \n";
                sql += " ,convert(varchar(2),P.[FIPRTIFI]) TipoFicha  \n";
                sql += ",convert(varchar(250),P.[FIPRATLO]) AreaTotalLote  \n";
                sql += ",convert(varchar(250),P.[FIPRACLO])AreaComunLote  \n";
                sql += ",convert(varchar(250),P.[FIPRAPLO])AreaPrivadaLote  \n";
                sql += ",convert(varchar(250),P.[FIPRTOED]) Edificios  \n";
                sql += ",convert(varchar(250),P.[FIPRUNCO])UnidadesEnCOndominio  \n";
                sql += ",convert(varchar(250),P.[FIPRURPH])UnidadesRPH  \n";
                sql += ",convert(varchar(250),P.[FIPRAPCA])AparatamentosOCasas  \n";
                sql += ",convert(varchar(250),P.[FIPRLOCA])Locales  \n";
                sql += ",convert(varchar(250),P.[FIPRCUUT])CUartosUriles  \n";
                sql += ",convert(varchar(250),P.[FIPRGACU])GarajesCubiertos  \n";
                sql += ",convert(varchar(250),P.[FIPRGADE])GarejesDescubierto  \n";
                sql += ",convert(varchar(250),P.[FIPRPISO])Pisos  \n";
                sql += "  ,convert(varchar(250), (select sum(convert(numeric(22, 2), C.FPCOARCO)) \n";
                sql += " from FIPRCONS C \n";
                sql += " where C.FPCONUFI = P.FIPRNUFI)) AreaConstruccion \n";

                sql += "from [dbo].[FICHPRED] P  \n";

                sql += "where (P.FIPRMUNI='266')  \n";
                sql += "and (P.FIPRCLSE="+strSector+")  \n";
                sql += "and (P.FIPRCORR ="+strCorregimiento+")  \n";
                sql += "and (P.FIPRBARR="+strBarrio+")  \n";
                sql += "and (P.FIPRMANZ="+strManzna+")  \n";
                sql += "and (P.FIPRPRED="+strPredio+")  \n";
                sql += "and  P.FIPRTIFI = 2 \n";
                sql += "and P.[FIPRESTA]='ac' \n";

                SqlDataReader read = this.EjecutarConsulta(sql);
                if (read != null)
                {
                    if (read.HasRows)
                    {
                        while (read.Read())
                        {
                            Listas.Consultar_Predio_Result Predio = new Listas.Consultar_Predio_Result();
                            Predio.strDirreccion = read.GetString(0);
                            Predio.strMunicipio = read.GetString(1);
                            Predio.strSector = read.GetString(2);
                            Predio.strCorregimiento = read.GetString(3);
                            Predio.strBarrio = read.GetString(4);
                            Predio.strManzana = read.GetString(5);
                            Predio.strPredio = read.GetString(6);
                            Predio.strEdificio = read.GetString(7);
                            Predio.strUnidadPredial = read.GetString(8);
                            Predio.strAntMunicipio = read.GetString(9);
                            Predio.strAntSector = read.GetString(10);
                            Predio.strAntCorregimiento = read.GetString(11);
                            Predio.strAntBarrio = read.GetString(12);
                            Predio.strAntManzana = read.GetString(13);
                            Predio.strAntPredio = read.GetString(14);
                            Predio.strAntEdificio = read.GetString(15);
                            Predio.strAntUnidadPredial = read.GetString(16);
                            Predio.strAreaTerreno = read.GetString(17);
                            Predio.strCoeficientePredio = read.GetString(18);
                            Predio.strTipoFicha = read.GetString(19);

                            Predio.strAreaTotalLote = read.GetString(20);
                            Predio.strAreaComunLote = read.GetString(21);
                            Predio.strAreaPrivadaLote = read.GetString(22);
                            Predio.strTotalEdificios = read.GetString(23);
                            Predio.strUnidadesEnCondominio = read.GetString(24);
                            Predio.strUnidadesRPH = read.GetString(25);
                            Predio.strAparatamentosOCasas = read.GetString(26);
                            Predio.strLocales = read.GetString(27);
                            Predio.strCuartosUriles = read.GetString(28);
                            Predio.strGarajesCubiertos = read.GetString(29);
                            Predio.strGarejesDescubierto = read.GetString(30);
                            Predio.strPisos = read.GetString(31);
                            Predio.strAreaConstruccion = (read[32] != DBNull.Value ? read.GetString(32) : "0");

                            objLstPredio.Add(Predio);

                        }
                    }
                    else
                    {
                        objLstPredio = new List<Listas.Consultar_Predio_Result>();
                    }
                }
                else
                {
                    objLstPredio = new List<Listas.Consultar_Predio_Result>();
                }
            }
            catch (Exception ex)
            {
                objLstPredio = new List<Listas.Consultar_Predio_Result>();
            }
            this.Desconectar();
            return objLstPredio;
        }
        #endregion

        #region CONSULTAR PROPIETARIO
        public List<Listas.Consultar_Propietario_Result> Consultar_Propietario(int nufi)
        {
            List<Listas.Consultar_Propietario_Result> ls = new List<Listas.Consultar_Propietario_Result>();
            try
            {
                string sql = "";
                //sql = " declare @nufi int=" + nufi + "  \n";
                sql += " SELECT   \n";
                sql += " convert(varchar(3),P.FPPRCAPR )   \n";
                sql += " ,(case    \n";
                sql += " when P.FPPRGRAV = 1 then 'SI'   \n";
                sql += " when P.FPPRGRAV = 0 then 'NO'   \n";
                sql += " end)     \n";
                sql += " ,convert(varchar(3),P.FPPRSEXO)    \n";
                sql += " ,LTRIM( RTRIM(P.FPPRNOMB))+' '+LTRIM( RTRIM(P.FPPRPRAP))+' '+LTRIM( RTRIM(P.FPPRSEAP)) Nombre     \n";
                sql += " ,convert(varchar(3),P.FPPRSICO )     \n";
                sql += " ,LTRIM( RTRIM(P.FPPRTIDO)) TipoDocumento     \n";
                sql += " ,(CASE     \n";
                sql += "     WHEN LTRIM( RTRIM(P.FPPRTIDO))='8' THEN ''    \n";
                sql += "     ELSE LTRIM( RTRIM(convert(varchar(35),P.FPPRNUDO)))    \n";
                sql += " END) Documento      \n";
                sql += " ,convert(varchar(250),P.FPPRDERE )     \n";
                sql += " ,convert(varchar(250),P.FPPRESCR )    \n";
                sql += " ,convert(varchar(250),P.FPPRFEES )    \n";
                sql += " ,convert(varchar(250),P.FPPRNOTA )    \n";
                sql += " ,convert(varchar(250),P.FPPRDENO )    \n";
                sql += " ,convert(varchar(250),P.FPPRMUNO )    \n";
                sql += " ,convert(varchar(250),P.FPPRFERE )    \n";
                sql += " ,isnull((select PA.PRANCAAC   \n";
                sql += " 		from [PROPANTE] PA    \n";
                sql += " 		where PA.PRANNUFI=P.FPPRNUFI   \n";
                sql += " 		and PA.PRANNUDO=P.FPPRNUDO),'' )     \n";
                sql += " ,isnull((select LTRIM(RTRIM(PA.PRANNOMB)) +' '+LTRIM(RTRIM(PA.PRANPRAP))+' '+LTRIM(RTRIM(PA.PRANSEAP))    \n";
                sql += " 		from [PROPANTE] PA    \n";
                sql += " 		where PA.PRANNUFI=P.FPPRNUFI   \n";
                sql += " 		and PA.PRANNUDO=P.FPPRNUDO),'' )     \n";
                sql += " 	,DO.TIDODESC   \n";
                sql += " 	,S.SEXODESC   \n";
                sql += " 	,CP.CAPRDESC   \n";
                sql += " 	 FROM[dbo].[FIPRPROP]  P   \n";
                sql += " 	inner join[dbo].[MANT_TIPODOCU]  DO on P.FPPRTIDO=DO.TIDOCODI   \n";
                sql += " 	inner join[dbo].[MANT_SEXO]  S on P.FPPRSEXO =S.SEXOCODI   \n";
                sql += " 	inner join[dbo].[MANT_CALIPROP]  CP on P.FPPRCAPR=CP.CAPRCODI   \n";
                sql += " where P.FPPRNUFI=" + nufi + "      \n";
                sql += " order by P.FPPRIDRE     \n";
                SqlDataReader read = this.EjecutarConsulta(sql);
                if (read != null)
                {
                    if (read.HasRows)
                    {
                        while (read.Read())
                        {
                            Listas.Consultar_Propietario_Result objPropietario = new Listas.Consultar_Propietario_Result();
                            objPropietario.strCalidadPropietario = read.GetString(0);
                            objPropietario.strGravable = read.GetString(1);
                            objPropietario.strSexo = read.GetString(2);
                            objPropietario.strNombreApellido = read.GetString(3);
                            objPropietario.strSiglasComercial = read.GetString(4);
                            objPropietario.strTipoDocumento = read.GetString(5);
                            objPropietario.strDocumento = read.GetString(6);
                            objPropietario.strDerecho = read.GetString(7);
                            objPropietario.strEscritura = read.GetString(8);
                            objPropietario.strFecha = read.GetString(9);
                            objPropietario.strEntidad = read.GetString(10);
                            objPropietario.strDepartamento = read.GetString(11);
                            objPropietario.strMunicipio = read.GetString(12);
                            objPropietario.strFechaRegistro = read.GetString(13);
                            objPropietario.strCausaActo = read.GetString(14);
                            objPropietario.strPropietarioAnterior = read.GetString(15);
                            objPropietario.strDescripcionTipoDocumento = read.GetString(16);
                            objPropietario.strDescripcionSexo = read.GetString(17);
                            objPropietario.strDescripcionCalidadPropietario = read.GetString(18);
                            ls.Add(objPropietario);
                        }
                    }
                    else
                    {
                        ls = new List<Listas.Consultar_Propietario_Result>();
                    }
                }
                else
                {
                    ls = new List<Listas.Consultar_Propietario_Result>();
                }
            }
            catch (Exception ex)
            {
                ls = new List<Listas.Consultar_Propietario_Result>();
            }
            this.Desconectar();
            return ls;
        }

        #endregion



        #region CONSULTAR LINDERO
        public List<Listas.Consultar_Colindantes_Result> Consultar_Colindantes(int nufi, string strPuntoCardinal)
        {
            List<Listas.Consultar_Colindantes_Result> ls = new List<Listas.Consultar_Colindantes_Result>();
            try
            {
                string sql = "";
                //sql += " declare @nufi int=" + nufi + "      \n";
                //sql += "   declare @PuntoCardinal varchar(2)='" + strPuntoCardinal + "'     \n";
                sql += " select      \n";
                sql += " (CASE       \n";
                sql += " WHEN L.FPLIPUCA='N' THEN 'NORTE'      \n";
                sql += " WHEN L.FPLIPUCA='E' THEN 'ORIENTE'      \n";
                sql += " WHEN L.FPLIPUCA='S' THEN 'SUR'      \n";
                sql += " WHEN L.FPLIPUCA='O' THEN 'OCCIDENTE'       \n";
                sql += " WHEN L.FPLIPUCA='ZE' THEN 'ZENIT'      \n";
                sql += " WHEN L.FPLIPUCA='NA' THEN 'NADIR'      \n";
                sql += " END	      \n";
                sql += " ) ORIENTACION	      \n";
                sql += " ,L.FPLICOLI      \n";
                sql += " from [dbo].[FIPRLIND] L      \n";
                sql += " where L.FPLINUFI=" + nufi + "      \n";
                sql += " and L.[FPLIPUCA]='" + strPuntoCardinal + "'\n";
                sql += " order by L.FPLIPUCA ,L.FPLICOLI      \n";
                SqlDataReader read = this.EjecutarConsulta(sql);

                if (read != null)
                {
                    if (read.HasRows)
                    {
                        while (read.Read())
                        {
                            Listas.Consultar_Colindantes_Result objColindante = new Listas.Consultar_Colindantes_Result();
                            objColindante.strOrientacion = read.GetString(0);
                            objColindante.strColindante = read.GetString(1);
                            ls.Add(objColindante);
                        }
                    }
                    else
                    {
                        ls = new List<Listas.Consultar_Colindantes_Result>();
                    }
                }
                else
                {
                    ls = new List<Listas.Consultar_Colindantes_Result>();
                }

            }
            catch (Exception ex)
            {
                ls = new List<Listas.Consultar_Colindantes_Result>();
            }
            this.Desconectar();
            return ls;
        }

        #endregion

        #region CONSULTAR INFORMACION COMPLEMENTARIA
        public List<Listas.Consultar_Informacion_Complementaria_Result> Consultar_Inforamcion_Complementaria(int nufi)
        {
            List<Listas.Consultar_Informacion_Complementaria_Result> ls = new List<Listas.Consultar_Informacion_Complementaria_Result>();
            try
            {
                string sql = "";
                //sql += " declare @nufi int=" + nufi + "  \n";
                sql += "SELECT  [RECOINGE] Ingeniero  \n";
                sql += "  ,[RECOPRED] Prediador  \n";
                sql += ",[RECOEMPR] Empresa  \n";
                sql += ",[RECOPROP] Propietarios  \n";
                sql += " ,[RECOREPR] RepresentantePropietario  \n";
                sql += ",(case  \n";
                sql += "  when  [RECOFECH]='-  -      ' then ''  \n";
                sql += "  when [RECOFECH]<>'-  -      ' then [RECOFECH]  \n";
                sql += "end) Fecha  \n";
                sql += "  ,(select P.FIPROBSE  \n";
                sql += "  from [dbo].[FICHPRED] P  \n";
                sql += "  where P.FIPRNUFI=R.RECONUFI) Observacion  \n";
                sql += " FROM [dbo].[REGICONT] R  \n";
                sql += " where R.RECONUFI=" + nufi + " \n";

                SqlDataReader read = this.EjecutarConsulta(sql);

                if (read != null)
                {
                    if (read.HasRows)
                    {
                        while (read.Read())
                        {
                            Listas.Consultar_Informacion_Complementaria_Result objInformacionComplementaria = new Listas.Consultar_Informacion_Complementaria_Result();

                            objInformacionComplementaria.strIngenieroResidente = read.GetString(0);
                            objInformacionComplementaria.strPrediador = read.GetString(1);
                            objInformacionComplementaria.strEmpresa = read.GetString(2);
                            objInformacionComplementaria.strPropietario = read.GetString(3);
                            objInformacionComplementaria.strRespresentante = read.GetString(4);
                            objInformacionComplementaria.strFecha = read.GetString(5);
                            objInformacionComplementaria.strObservacion = read.GetString(6);

                            ls.Add(objInformacionComplementaria);
                        }
                    }
                    else
                    {
                        ls = new List<Listas.Consultar_Informacion_Complementaria_Result>();
                    }
                }
                else
                {
                    ls = new List<Listas.Consultar_Informacion_Complementaria_Result>();
                }

            }
            catch (Exception ex)
            {
                ls = new List<Listas.Consultar_Informacion_Complementaria_Result>();
            }
            this.Desconectar();
            return ls;
        }
        #endregion

        #region CONSULTAR INFORMACION GRAFICA
        public List<Listas.Consultar_Informacion_Geografica_Result> Consultar_Informacion_Geografico(int Nufi)
        {
            List<Listas.Consultar_Informacion_Geografica_Result> ls = new List<Listas.Consultar_Informacion_Geografica_Result>();
            string sql = "";
            //sql += " declare @nufi int=" + Nufi + "  \n";
            sql += "select C.[FPCAPLAN]   \n";
            sql += ",C.[FPCAVENT]   \n";
            sql += ",C.[FPCAESGR]   \n";
            sql += ",convert(varchar(10),C.[FPCAVIGR] )   \n";
            sql += ",C.FPCAVUEL    \n";
            sql += ",C.FPCAFAJA    \n";
            sql += ",C.FPCAFOTO    \n";
            sql += ",convert(varchar(10),[FPCAVIAE]  )    \n";
            sql += ",[FPCAAMPL]    \n";
            sql += ",[FPCAESAE]    \n";
            sql += "from [dbo].[FIPRCART] C   \n";
            sql += "where C.FPCANUFI=" + Nufi + "	   \n";
            sql += "order by C.[FPCAIDRE]   \n";
            SqlDataReader read = this.EjecutarConsulta(sql);

            if (read != null)
            {
                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        Listas.Consultar_Informacion_Geografica_Result objInfromacionGeografica = new Listas.Consultar_Informacion_Geografica_Result();
                        objInfromacionGeografica.strPlancha = read.GetString(0);
                        objInfromacionGeografica.strVentana = read.GetString(1);
                        objInfromacionGeografica.strEscala = read.GetString(2);
                        objInfromacionGeografica.strVegencia = read.GetString(3);
                        objInfromacionGeografica.strVuelo = read.GetString(4);
                        objInfromacionGeografica.strFaja = read.GetString(5);
                        objInfromacionGeografica.strFoto = read.GetString(6);
                        objInfromacionGeografica.strAnio = read.GetString(7);
                        objInfromacionGeografica.strAmpliacion = read.GetString(8);
                        objInfromacionGeografica.strEscalaAerografica = read.GetString(9);
                        ls.Add(objInfromacionGeografica);
                    }
                }
                else
                {
                    ls = new List<Listas.Consultar_Informacion_Geografica_Result>();
                }
            }
            else
            {
                ls = new List<Listas.Consultar_Informacion_Geografica_Result>();
            }
            this.Desconectar();
            return ls;
        }
        #endregion

        #region CONSULTAR CALIFICACION
        public List<Listas.Consultar_Calificacion_Result> Consultar_Calificacion(int strNufi, string strUnidad)
        {
            List<Listas.Consultar_Calificacion_Result> lst = new List<Listas.Consultar_Calificacion_Result>();
            string sql = " ";
            sql = "";
            //sql += " declare @nufi int=" + strNufi + "  \n";
            //sql += " declare @unidad int =" + strUnidad + "  \n";
            sql += "  select Convert(varchar(50), CO.FPCCCODI)    \n";
            sql += "  ,Convert(varchar(50), CO.FPCCPUNT)  \n";
            sql += " , MC.COCADESC  \n";
            sql += " ,MC.COCACOPA  \n";
            sql += " from[dbo].[FIPRCACO]  CO  \n";
            sql += " inner join MANT_CODICALI MC on MC.COCACODI = CO.FPCCCODI  \n";
            sql += " where CO.FPCCNUFI=" + strNufi + "  \n";
            sql += " AND CO.FPCCUNID="+strUnidad+"  \n";
            sql += " order by CO.FPCCCODI  \n";


            SqlDataReader read = this.EjecutarConsulta(sql);
            if (read != null)
            {
                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        Listas.Consultar_Calificacion_Result objConsulta = new Listas.Consultar_Calificacion_Result();
                        objConsulta.strCodigoCalificacion = read.GetString(0);
                        objConsulta.strPuntos = read.GetString(1);
                        objConsulta.strDescripcion = read.GetString(2);
                        objConsulta.strDescripcionSubCalificacion = read.GetString(3);
                        lst.Add(objConsulta);
                    }
                }
                else
                {
                    lst = new List<Listas.Consultar_Calificacion_Result>();
                }
            }
            else
            {
                lst = new List<Listas.Consultar_Calificacion_Result>();
            }
            this.Desconectar();
            return lst;
        }
        #endregion
        #region Zonas
        public List<Listas.Consultar_Zonas_Fisicas_Result> Consultar_Zonas_Fisicas(string strNufi)
        {
            List<Listas.Consultar_Zonas_Fisicas_Result> lst = new List<Listas.Consultar_Zonas_Fisicas_Result>();
            string sql = string.Empty;
            sql += " select P.FIPRNUFI \n";
            sql += " ,ZF.FPZFZOFI \n";
            sql += " ,MZF.ZOFIDESC \n";
            sql += " ,ZF.FPZFPORC \n";
            sql += " from dbo.FICHPRED P \n";
            sql += " inner join dbo.FIPRZOFI ZF on P.FIPRNUFI = ZF.FPZFNUFI \n";
            sql += " inner join dbo.MANT_ZONAFISI MZF on(ZF.FPZFZOFI = MZF.ZOFICODI \n";
            sql += "                                     and ZF.FPZFMUNI = MZF.ZOFIMUNI \n";
            sql += "                                     and ZF.FPZFDEPA = MZF.ZOFIDEPA) \n";
            sql += " where P.FIPRNUFI =" + strNufi + " \n";
            SqlDataReader read = this.EjecutarConsulta(sql);
            if (read != null)
            {
                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        Listas.Consultar_Zonas_Fisicas_Result objConsulta = new Listas.Consultar_Zonas_Fisicas_Result();
                        objConsulta.strNufi = read[0] == null ? "" : Convert.ToString(read.GetInt32(0));
                        objConsulta.strCodigo = read[1] == null ? "" : Convert.ToString(read[1]);
                        objConsulta.strDescripcion = read[2] == null ? "" : Convert.ToString(read[2]);
                        objConsulta.strPortcentaje = read[3] == null ? "" : Convert.ToString(read[3]);
                        lst.Add(objConsulta);
                    }
                }
                else
                {
                    lst = new List<Listas.Consultar_Zonas_Fisicas_Result>();
                }
            }
            else
            {
                lst = new List<Listas.Consultar_Zonas_Fisicas_Result>();
            }
            this.Desconectar();
            return lst;
        }

        public List<Listas.Consultar_Zonas_Economicas_Result> Consultar_Zonas_Economicas(string strNufi)
        {
            List<Listas.Consultar_Zonas_Economicas_Result> lst = new List<Listas.Consultar_Zonas_Economicas_Result>();
            string sql = string.Empty;
            sql += " select P.FIPRNUFI \n";
            sql += " ,ZE.FPZEZOEC \n";
            sql += " ,MZE.ZOECDESC \n";
            sql += " ,ZE.FPZEPORC \n";
            sql += " from dbo.FICHPRED P \n";
            sql += " inner join[dbo].[FIPRZOEC] \n";
            sql += "         ZE on P.FIPRNUFI=ZE.FPZENUFI \n";
            sql += " inner join[dbo].[MANT_ZONAECON] \n";
            sql += "         MZE on(MZE.ZOECCODI= ZE.FPZEZOEC \n";
            sql += "                    and MZE.ZOECMUNI= ZE.FPZEMUNI \n";
            sql += "                    and MZE.ZOECDEPA= ZE.FPZEDEPA) \n";
            sql += " where P.FIPRNUFI=" + strNufi + " \n";
            SqlDataReader read = this.EjecutarConsulta(sql);
            if (read != null)
            {
                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        Listas.Consultar_Zonas_Economicas_Result objConsulta = new Listas.Consultar_Zonas_Economicas_Result();
                        objConsulta.strNufi = read[0] == null ? "" : Convert.ToString(read.GetInt32(0));
                        objConsulta.strCodigo = read[1] == null ? "" : Convert.ToString(read[1]);
                        objConsulta.strDescripcion = read[2] == null ? "" : Convert.ToString(read[2]);
                        objConsulta.strPortcentaje = read[3] == null ? "" : Convert.ToString(read[3]);
                        lst.Add(objConsulta);
                    }
                }
                else
                {
                    lst = new List<Listas.Consultar_Zonas_Economicas_Result>();
                }
            }
            else
            {
                lst = new List<Listas.Consultar_Zonas_Economicas_Result>();
            }
            this.Desconectar();
            return lst;
        }

        public List<Listas.Consultar_Tipo_Foto_Result> Consultar_Rutas(string strDepartamento, string strMunicipio, string strSector)
        {
            List<Listas.Consultar_Tipo_Foto_Result> lst = new List<Listas.Consultar_Tipo_Foto_Result>();
            string sql = string.Empty;
            /*sql += " declare @municipio varchar(3) = '" + strMunicipio + "' \n";
            sql += " declare @departamento varchar(2) = '" + strDepartamento + "' \n";
            sql += " declare @sector int= " + strSector + " \n";*/
            sql += " SELECT \n";
            sql += "  convert(varchar(5),MR.[RUCFCAFO]) \n";
            sql += "  ,MR.[RUCFRUTA] \n";
            sql += "  ,MCF.CAFODESC \n";
            sql += "  FROM[dbo].[MANT_RUTACAFO]   MR \n";
            sql += " inner join[dbo].[MANT_CARPFOTO]    MCF on MR.RUCFCAFO=MCF.CAFOCODI  \n";
            sql += "            where  MR.RUCFMUNI='"+strMunicipio+"' \n";
            sql += " and MR.RUCFDEPA='"+strDepartamento+"' \n";
            sql += " and MR.RUCFCLSE='"+strSector+"' \n";

            SqlDataReader read = this.EjecutarConsulta(sql);
            if (read != null)
            {
                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        Listas.Consultar_Tipo_Foto_Result objConsulta = new Listas.Consultar_Tipo_Foto_Result();
                        objConsulta.strTipoFoto = read[0] == DBNull.Value ? "" : Convert.ToString(read[0]).Trim();
                        objConsulta.strRuta = read[1] == DBNull.Value ? "" : Convert.ToString(read[1]).Trim();
                        objConsulta.strNombreTipo = read[2] == DBNull.Value ? "" : Convert.ToString(read[2]).Trim();

                        lst.Add(objConsulta);
                    }
                }
                else
                {
                    lst = new List<Listas.Consultar_Tipo_Foto_Result>();
                }
            }
            else
            {
                lst = new List<Listas.Consultar_Tipo_Foto_Result>();
            }
            this.Desconectar();
            return lst;
        }
        public List<Listas.Consultar_CategoriaPredio_Result> Consultar_Categoria_Predio(string strNufi)
        {
            List<Listas.Consultar_CategoriaPredio_Result> lst = new List<Listas.Consultar_CategoriaPredio_Result>();
            string sql = string.Empty;
            //sql += " declare @nufi int= " + strNufi + "\n";
            sql += " select CF.CPFPNUFI \n";
            sql += " ,C.CAPRCODI \n";
            sql += " ,C.CAPRDESC \n";
            sql += " from[dbo].[CAPRFIPR]  CF \n";
            sql += " inner join[dbo].[MANT_CATEPRED]  C on CF.CPFPCAPR=C.CAPRCODI \n";
            sql += " where CF.CPFPNUFI=" + strNufi + " \n";
            SqlDataReader read = this.EjecutarConsulta(sql);
            if (read != null)
            {
                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        Listas.Consultar_CategoriaPredio_Result objConsulta = new Listas.Consultar_CategoriaPredio_Result();
                        objConsulta.strNufi = read[0] == null ? "" : Convert.ToString(read.GetInt32(0));
                        objConsulta.strCodigo = read[1] == null ? "" : Convert.ToString(read.GetInt32(1));
                        objConsulta.strDescripcion = read[2] == null ? "" : Convert.ToString(read[2]);
                        lst.Add(objConsulta);
                    }
                }
                else
                {
                    lst = new List<Listas.Consultar_CategoriaPredio_Result>();
                }
            }
            else
            {
                lst = new List<Listas.Consultar_CategoriaPredio_Result>();
            }
            this.Desconectar();
            return lst;
        }


        #endregion

        #region METODOS DE CONTROL
        public Listas.Consultar_Estado_Impresion Consultar_Estado_Impresion(int intNufi, string strUi)
        {
            Listas.Consultar_Estado_Impresion lst = new Listas.Consultar_Estado_Impresion();
            try
            {
                string sql = ""; //"declare @FPIMNUFI int =" + intNufi + " \n";
                //sql += " declare @FPIMPRUI  varchar(500) = '" + strUi + "' \n";
                sql += " select FI.IDFIIMPR,  \n";
                sql += " FI.FPIMNUFI , \n";
                sql += " FI.FPRUTAPR , \n";
                sql += "  FI.FPRUTACO , \n";
                sql += " FI.FPRUTGDB , \n";
                sql += " FI.FPIMPRUI, \n";
                sql += " FI.FIIMESTA \n";
                sql += " from FIPRIMPR FI \n";
                sql += " where FI.FPIMNUFI =" + intNufi + " \n";
                sql += " and FI.FPIMPRUI = '"+strUi+"' \n";
                SqlDataReader read = this.EjecutarConsulta(sql);

                if (read != null)
                {
                    if (read.HasRows)
                    {
                        while (read.Read())
                        {
                            lst.intIdFichaImpresion = read.GetInt32(0);
                            lst.intIdFichaImpresion = read.GetInt32(1);
                            lst.strRutaPredio = read.GetString(2);
                            lst.strRutaConstrucion = read.GetString(3);
                            lst.strRutaGDB = read.GetString(4);
                            lst.strUi = read.GetString(5);
                            lst.intEstado = (read[6] == null ? TipoEstadoPlano.error : (TipoEstadoPlano)read.GetInt32(6));
                        }
                    }
                    else
                    {
                        lst = null;
                    }
                }
                else
                {
                    lst = null;
                }
                this.Desconectar();

            }
            catch (Exception ex)
            {
                lst = null;
            }
            return lst;
        }

        public int Insertar_Estado_Impresion(int intNufi
                                            , string strRutaPredio
                                            , string strRutaConstrucion
                                            , string strRutaGDB
                                            , string strUi
                                            , int intEstado)
        {
            int intNumeroRows;
            string sql = "insert into FIPRIMPR (FPIMNUFI,FPRUTAPR,FPRUTACO,FPRUTGDB,FPIMPRUI,FIIMESTA) values \n";
            sql += "(";
            sql += intNufi + ",'" + strRutaPredio + "','" + strRutaConstrucion + "','" + strRutaGDB + "','" + strUi + "'," + intEstado;
            sql += ")";
            intNumeroRows = this.EjecutarQuery(sql);
            return intNumeroRows;
        }


        public int Eliminar_Estado_Impresion(int intNufi, string strUi)
        {
            int intNumeroRows=0;
            try
            {                
                /*string sql =" ";
                declare @FPIMNUFI int =" + intNufi + " \n";
                sql += " declare @FPIMPRUI  varchar(500) = '" + strUi + "' \n";
                sql += " delete[dbo].[FIPRIMPR] \n";
                sql += " where FPIMNUFI = @FPIMNUFI \n";
                sql += " and FPIMPRUI = @FPIMPRUI \n";
                SqlDataReader read = this.EjecutarConsulta(sql);
                intNumeroRows = this.EjecutarQuery(sql);                
                this.Desconectar();*/

            }
            catch (Exception ex)
            {
                intNumeroRows = 0;
            }
            return intNumeroRows;
        }

        #endregion
    }
}
