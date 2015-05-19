namespace Hiperion.Models
{
    #region References

    using System.Collections.Generic;
    using Newtonsoft.Json;

    #endregion

    [JsonObject(MemberSerialization.OptIn)]
    public class UserDto : ModelEntity
    {
        [JsonProperty("name")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("age")]
        public int Age { get; set; }

        [JsonProperty("country")]
        public int Country { get; set; }

        [JsonProperty("roles")]
        public IEnumerable<RoleDto> Roles { get; set; }

        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}