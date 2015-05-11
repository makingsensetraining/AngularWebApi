namespace Hiperion.Models
{
    using Newtonsoft.Json;

    [JsonObject(MemberSerialization.OptIn)]
    public class UserDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("age")]
        public int Age { get; set; }

        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}