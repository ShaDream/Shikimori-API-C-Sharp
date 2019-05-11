using Newtonsoft.Json;

using System;

namespace ShikiApi
{
    public class PersonInfo : Character
    {
        [JsonProperty("japanese")]
        public string Japanese { get; set; }

        [JsonProperty("job_title")]
        public string JobTitle { get; set; }

        [JsonProperty("birthday")]
        public DateTime? Birthday { get; set; }

        [JsonProperty("website")]
        public string Website { get; set; }

        [JsonProperty("groupped_roles")]
        public PersonGrouppedRole[] PersonGrouppedRoles { get; set; }

        [JsonProperty("roles")]
        public Role[] Roles { get; set; }

        [JsonProperty("works")]
        public PersonWork[] PersonWorks { get; set; }

        [JsonProperty("thread_id")]
        public int ThreadId { get; set; }

        [JsonProperty("topic_id")]
        public int TopicId { get; set; }

        [JsonProperty("person_favoured")]
        public bool PersonFavoured { get; set; }

        [JsonProperty("producer")]
        public bool Producer { get; set; }

        [JsonProperty("producer_favoured")]
        public bool ProducerFavoured { get; set; }

        [JsonProperty("mangaka")]
        public bool Mangaka { get; set; }

        [JsonProperty("mangaka_favoured")]
        public bool MangakaFavoured { get; set; }

        [JsonProperty("seyu")]
        public bool Seyu { get; set; }

        [JsonProperty("seyu_favoured")]
        public bool SeyuFavoured { get; set; }

        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }
}