using MVCLab.Attributes;

namespace MVCLab.Models
{
    public class Enums
    {
        public enum TeamEnum
        {
            [League(LeagueEnum.EPL)]
            TOT = 0,
            [League(LeagueEnum.EPL)]
            MU = 1,
            [League(LeagueEnum.SerieA)]
            AA = 2,
            [League(LeagueEnum.LaLiga)]
            BB = 3,
            [League(LeagueEnum.Bundesliga)]
            CC = 4,
            DD=5,
        }
        public enum LeagueEnum
        {
            
            EPL,
            League1,
            SerieA,
            LaLiga,
            Bundesliga
        }
    }
}