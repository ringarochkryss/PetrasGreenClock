namespace Byggkontakter.Models.Enums
{
    public enum Lan
    {
        Blekinge,
        Dalarna,
        Gotland,
        Gävleborg,
        Halland,
        Jämtland,
        Jönköping,
        Kalmar,
        Kronoberg,
        Norrbotten,
        Skåne,
        Södermanland,
        Stockholm,
        Uppsala,
        Värmland,
        Västerbotten,
        Västernorrland,
        Västmanland,
        VästraGötaland,
        Örebro,
        Östergötland
    }

    public static class StaderPerLan
    {
        public static readonly Dictionary<Lan, List<string>> Stader = new Dictionary<Lan, List<string>>
    {
        { Lan.Blekinge, new List<string> { "Karlskrona", "Ronneby", "Karlshamn", "Olofström", "Sölvesborg" } },
        { Lan.Dalarna, new List<string> { "Falun", "Borlänge", "Leksand", "Rättvik", "Mora" } },
        { Lan.Gotland, new List<string> { "Visby", "Slite", "Fårösund", "Lilla Varholmen" } },
        { Lan.Gävleborg, new List<string> { "Gävle", "Sandviken", "Hudiksvall", "Ljusdal", "Bollnäs" } },
        { Lan.Halland, new List<string> { "Halmstad", "Varberg", "Laholm", "Kungsbacka", "Falkenberg" } },
        { Lan.Jämtland, new List<string> { "Östersund", "Sundsvall", "Krokom", "Strömsund", "Bräcke" } },
        { Lan.Jönköping, new List<string> { "Jönköping", "Värnamo", "Nässjö", "Gislaved", "Eksjö" } },
        { Lan.Kalmar, new List<string> { "Kalmar", "Västervik", "Oskarshamn", "Mönsterås", "Nybro" } },
        { Lan.Kronoberg, new List<string> { "Växjö", "Ljungby", "Alvesta", "Tingsryd", "Lessebo" } },
        { Lan.Norrbotten, new List<string> { "Luleå", "Piteå", "Kiruna", "Gällivare", "Arvidsjaur" } },
        { Lan.Skåne, new List<string> { "Malmö", "Helsingborg", "Lund", "Kristianstad", "Trelleborg", "Ystad", "Hässleholm", "Eslöv", "Landskrona", "Höör" } },
        { Lan.Södermanland, new List<string> { "Nyköping", "Södertälje", "Strängnäs", "Eskilstuna", "Flen" } },
        { Lan.Stockholm, new List<string> { "Stockholm", "Sundbyberg", "Solna", "Nacka", "Huddinge", "Täby", "Lidingö", "Järfälla", "Upplands Väsby", "Värmdö" } },
        { Lan.Uppsala, new List<string> { "Uppsala", "Enköping", "Heby", "Östhammar", "Tierp" } },
        { Lan.Värmland, new List<string> { "Karlstad", "Arvika", "Sunne", "Torsby", "Hagfors" } },
        { Lan.Västerbotten, new List<string> { "Umeå", "Skellefteå", "Vindeln", "Robertsfors", "Bjurholm" } },
        { Lan.Västernorrland, new List<string> { "Sundsvall", "Härnösand", "Östersund", "Kramfors", "Sollefteå" } },
        { Lan.Västmanland, new List<string> { "Västerås", "Köping", "Hallstahammar", "Surahammar", "Arboga" } },
        { Lan.VästraGötaland, new List<string> { "Göteborg", "Borås", "Mölndal", "Trollhättan", "Uddevalla", "Alingsås", "Kungälv", "Partille", "Östersund", "Vänersborg" } },
        { Lan.Örebro, new List<string> { "Örebro", "Hallsberg", "Lindesberg", "Kumla", "Karlskoga" } },
        { Lan.Östergötland, new List<string> { "Linköping", "Norrköping", "Motala", "Finspång", "Söderköping" } }
    };
    }


}
