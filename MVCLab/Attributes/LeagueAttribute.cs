using System;
using static MVCLab.Models.Enums;

namespace MVCLab.Attributes
{
    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    public sealed class LeagueAttribute : Attribute
    {
        public LeagueEnum League { get; set; }
        public LeagueAttribute(LeagueEnum league)
        {
            this.League = league;
        }
    }
}