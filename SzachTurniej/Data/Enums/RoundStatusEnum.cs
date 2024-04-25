using System.ComponentModel;

namespace SzachTurniej.Data.Enums
{
    public enum RoundStatusEnum
    {
        [Description("W toku")]
        OnGoing = 1,
        [Description("Zakończona")]
        Ended = 2,
    }
}
