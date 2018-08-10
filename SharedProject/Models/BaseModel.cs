using System;
#if SERVICE

using Microsoft.Azure.Mobile.Server;
#else
using Newtonsoft.Json;

#endif

namespace XpenceShared.Models
{
    // The model class files are shared between the mobile and service projects. 
    // If ITableData were compatible with PCL profile 78, the models could be in a PCL.


        /// <summary>
        /// Base model shared between all users, like bank names, parsing templates and other
        /// </summary>
    public class BaseModel
#if SERVICE
        :EntityData
    {
#else
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "createdAt")]
        public DateTimeOffset? CreatedAt { get; set; }

        [JsonProperty(PropertyName = "UpdatedAt")]
        public DateTimeOffset? UpdatedAt { get; set; }


        [JsonProperty(PropertyName = "Version")]
        public string AzureVersion { get; set; }
#endif
    }
}