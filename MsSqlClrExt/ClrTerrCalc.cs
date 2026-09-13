using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MsSqlClrExt.ClrTerrCalc;

namespace MsSqlClrExt
{
    public static class ClrTerrCalc
    {
        internal enum TerrEnum
        {
              WORLD
            , CIS
            , EUROPE
            , EASTERN_EUROPE
            , EUROPEAN_CONT
            , UKRAIN
        }

        internal class Terr
        {
            public TerrEnum TerrId { get; set; }
            public string Code     { get; set; }
            public string Name     { get; set; }
        }

        private static readonly Terr[] TERRS =
        {
              new Terr { TerrId = TerrEnum.WORLD          , Code = "2136", Name = "WORLD"          }
            , new Terr { TerrId = TerrEnum.CIS            , Code = "2118", Name = "CIS"            }
            , new Terr { TerrId = TerrEnum.EUROPE         , Code = "2120", Name = "EUROPE"         }
            , new Terr { TerrId = TerrEnum.EASTERN_EUROPE , Code = "2119", Name = "EASTERN EUROPE" }
            , new Terr { TerrId = TerrEnum.EUROPEAN_CONT  , Code = "2122", Name = "EUROPEAN CONT." }
            , new Terr { TerrId = TerrEnum.UKRAIN         , Code = "0804", Name = "UKRAIN"         }
        };

        [SqlFunction(DataAccess = DataAccessKind.None)]
        public static bool ClrIsUkraine(string terrsString)
        {
            var aggrTerrsIncExc = new string(' ', (int)TerrEnum.UKRAIN + 1).ToCharArray();
            var terrStrings = terrsString.Split(' ');
            foreach (var terrString in terrStrings)
            {
                var incExcInd = terrString[0];
                var code = terrString.Substring(1);
                var terr = TERRS.SingleOrDefault(x => x.Code == code);
                if(terr != null)
                {
                    aggrTerrsIncExc[(int)terr.TerrId] = incExcInd;
                }
            }

            if (
                   IsExcluded(aggrTerrsIncExc, TerrEnum.CIS)
                || IsExcluded(aggrTerrsIncExc, TerrEnum.EASTERN_EUROPE)
                || IsExcluded(aggrTerrsIncExc, TerrEnum.EUROPEAN_CONT)
                || IsExcluded(aggrTerrsIncExc, TerrEnum.UKRAIN) )
            {
                return false;
            }

            if (
                    IsExcluded(aggrTerrsIncExc, TerrEnum.EUROPE)
                && !IsIncluded(aggrTerrsIncExc, TerrEnum.EASTERN_EUROPE)
                && !IsIncluded(aggrTerrsIncExc, TerrEnum.EUROPEAN_CONT))
            {
                return false;
            }

            if (
                   IsIncluded(aggrTerrsIncExc, TerrEnum.WORLD)
                || IsIncluded(aggrTerrsIncExc, TerrEnum.CIS)
                || IsIncluded(aggrTerrsIncExc, TerrEnum.EUROPE)
                || IsIncluded(aggrTerrsIncExc, TerrEnum.EASTERN_EUROPE)
                || IsIncluded(aggrTerrsIncExc, TerrEnum.EUROPEAN_CONT)
                || IsIncluded(aggrTerrsIncExc, TerrEnum.CIS)
                || IsIncluded(aggrTerrsIncExc, TerrEnum.UKRAIN))
            {
                return true;
            }

            return false;
        }

        static private bool IsExcluded(char[] aggrTerrsIncExc, TerrEnum terrId)
        {
            return char.ToUpper(aggrTerrsIncExc[(int)terrId]) == 'E';
        }

        static private bool IsIncluded(char[] aggrTerrsIncExc, TerrEnum terrId)
        {
            return char.ToUpper(aggrTerrsIncExc[(int)terrId]) == 'I';
        }
    }
}
