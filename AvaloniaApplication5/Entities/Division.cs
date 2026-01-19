using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AvaloniaApplication5.Entities;

public partial class Division
{
    public int Id { get; set; }

    public string? Division1 { get; set; }
    [JsonIgnore]

    public virtual ICollection<Staff> Staff { get; set; } = new List<Staff>();
}
