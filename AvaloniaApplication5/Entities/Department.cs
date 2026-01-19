using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AvaloniaApplication5.Entities;

public partial class Department
{
    public int Id { get; set; }

    public string? Department1 { get; set; }
    [JsonIgnore]

    public virtual ICollection<Staff> Staff { get; set; } = new List<Staff>();
}
