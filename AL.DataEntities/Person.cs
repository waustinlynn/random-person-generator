using Newtonsoft.Json;

namespace AL.DataEntities
{
    public class Person
    {
        public Person()
        {
            Id = Guid.NewGuid().ToString();
        }
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("firstName")]
        public string? FirstName { get; set; }
        [JsonProperty("lastName")]
        public string? LastName { get; set; }
        [JsonProperty("city")]
        public string? City { get; set; }
        [JsonProperty("hobbies")]
        public string? Hobbies { get; set; }
    }
}