using System.ComponentModel;

namespace SzachTurniej.Data.Enums
{
    public enum TournamentTypeEnum
    {
        [Description("Klasyczny")]
        Classic = 1,
        [Description("Szybki")]
        Fast = 2,
        [Description("Błyskawiczny")]
        Instant = 3,
    }
}
