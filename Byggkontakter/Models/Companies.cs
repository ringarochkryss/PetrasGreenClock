using Byggkontakter.Models.Enums;
using Byggkontakter.Models.Storlek;
using Byggkontakter.Models.Omraden;

namespace Byggkontakter.Models
{
    public class Companies
    {
        public int Id { get; set; }
        public required string Namn { get; set; }
        public string? Epost { get; set; }
        public string? Telefonnummer { get; set; }
        public string? Hemsida { get; set; }
        public string? Kontaktperson { get; set; }

        //Location
        public List<string>? VerksammaStader { get; set; }  
        public List<string>? VerksammaLander { get; set;}

        //Size
        public int StorlekId { get; set; }
        public ForetagsStorlek? Storlek { get; set; }

        //Verksamhetsområden
        public int OmradenId { get; set; }
        public VerksamhetsOmraden? Omraden { get; set; }

        //Bilder
        public byte[]? Logotype { get; set; }  // Binary for image storage
        public byte[]? Bild1 { get; set; }
        public byte[]? Bild2 { get; set; }
        public byte[]? Bild3 { get; set; }

        //Texter
        public string? Payoff { get; set; }
        public string? Text1 { get; set; }
        public string? Text2 { get; set; }
        public string? Text3 { get; set; }

        // Booleans
        public bool? Kund { get; set; }
        public bool? Underleverantor { get; set; }

        // Invoice
        public string? Organisationsnummer { get; set; }
        public string? Adressrad1 { get; set; }
        public string? Adressrad2 { get; set; }
        public string? Adressrad3 { get; set; }
        
        // Payment Information
        public DateTime? BetaldDatum { get; set; }
        public bool? Betald { get; set; }
        public DateTime? BetalningUtgangsdatum { get; set; }

        // Update and Boost Info
        public DateTime? UppdateradDatum { get; set; }
        public bool? Boost { get; set; }
        public bool? SuperBoost { get; set; }
        public DateTime? BoostStartdatum { get; set; }
        public DateTime? BoostSlutdatum { get; set; }
    }
}
