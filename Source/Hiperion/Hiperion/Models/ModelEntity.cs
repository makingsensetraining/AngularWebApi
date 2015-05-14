namespace Hiperion.Models
{
    using Newtonsoft.Json;

    public class ModelEntity
    {
        [JsonProperty("id")]
        public int Id { get; set; }
    }
}