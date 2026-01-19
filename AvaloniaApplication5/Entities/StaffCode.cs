using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AvaloniaApplication5.Entities;

public partial class StaffCode
{
    public int Id { get; set; }

    public int? StaffId { get; set; }
    [JsonIgnore]

    public virtual ICollection<GroupVisit> GroupVisits { get; set; } = new List<GroupVisit>();
    [JsonIgnore]

    public virtual ICollection<IndividualVisit> IndividualVisits { get; set; } = new List<IndividualVisit>();
}
