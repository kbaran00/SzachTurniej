using System.ComponentModel;

namespace SzachTurniej.Data.Enums
{
    public enum TournamentStatusEnum
    {
        [Description("Do akceptacji")]
        ToAccept = 1,
        [Description("Planowane")]
        Planning = 2,
        [Description("Trwające")]
        OnGoing = 3,
        [Description("Zakończone")]
        Finished = 4,
    }
}
