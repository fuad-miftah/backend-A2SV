using BlogApi.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlogApi.Domain
{
    public class Comment: BaseDomainEntity
    {
        public string Text { get; set; } = "";
        public int PostId { get; set; }
        [JsonIgnore]
        public virtual Post? Post { get; set; }
    }
}
