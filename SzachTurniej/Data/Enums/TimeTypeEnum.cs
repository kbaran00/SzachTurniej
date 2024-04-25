using System.ComponentModel;

namespace SzachTurniej.Data.Enums
{
    public enum TimeTypeEnum
    {
        [Description("sek")]
        sek = 1,
        [Description("min")]
        min = 2,
        [Description("godz")]
        hour = 3,
        [Description("dzień")]
        day = 4,
    }
}
