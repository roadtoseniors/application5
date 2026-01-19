using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AvaloniaApplication5.Entities;

public partial class Group
{
    public int Id { get; set; }

    public string? Group1 { get; set; }
    [JsonIgnore]

    public virtual ICollection<GroupVisit> GroupVisits { get; set; } = new List<GroupVisit>();
}
