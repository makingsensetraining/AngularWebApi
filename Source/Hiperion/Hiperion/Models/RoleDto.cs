namespace Hiperion.Models
{
    using Newtonsoft.Json;

    public class RoleDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}