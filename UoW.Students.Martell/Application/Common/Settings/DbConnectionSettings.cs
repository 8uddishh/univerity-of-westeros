namespace UoW.Students.Martell.Application.Common.Settings
{
    using System.Text.Json.Serialization;

    public class DbConnectionSettings
    {
        [JsonPropertyName("Westros-Robert")]
        public string Westeros { get; set; }
    }
}
