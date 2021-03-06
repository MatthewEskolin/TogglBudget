using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TogglTimeWeb.API.Json
{
    [JsonObject(MemberSerialization.OptIn)]
    public abstract class CommonJson
    {
        protected CommonJson()
        {
        }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("at")]
        public DateTime ModifiedAt { get; set; }

        [JsonProperty("server_deleted_at", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? DeletedAt { get; set; }

        internal string ToIdString()
        {
            return String.Concat(GetType().Name, "#", Id.ToString());
        }
    }
}
