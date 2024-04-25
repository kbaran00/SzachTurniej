using System.ComponentModel;

namespace SzachTurniej.Data.Enums
{
    public enum ChessCategoryEnum
    {
        [Description("GM")]
        GM = 1,
        [Description("WGM")]
        WGM = 2,
        [Description("IM")]
        IM = 3,
        [Description("WIM")]
        WIM = 4,
        [Description("FM")]
        FM = 5,
        [Description("WFM")]
        WFM = 6,
        [Description("CM")]
        CM = 7,
        [Description("WCM")]
        WCM = 8,
        [Description("m")]
        m = 9,
        [Description("k++")]
        k11 = 10,
        [Description("k+")]
        k1 = 11,
        [Description("k")]
        k = 12,
        [Description("I++")]
        pierwsza11 = 13,
        [Description("I+")]
        pierwsza1 = 14,
        [Description("I")]
        pierwsza = 15,
        [Description("II+")]
        druga = 16,
        [Description("II+")]
        druga1 = 17,
        [Description("III")]
        trzecia = 18,
        [Description("IV")]
        czwarta = 19,
        [Description("V")]
        piata = 20,


    }
}
